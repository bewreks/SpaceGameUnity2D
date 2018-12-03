using System.Collections.Generic;
using SpaceGame.Scripts.Commands;
using SpaceGame.Scripts.Controllers;
using SpaceGame.Scripts.Missions;
using SpaceGame.Scripts.Models;
using UnityEngine;

namespace SpaceGame.Scripts
{
    public class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        public InputController  InputController  { get; private set; }
        public PauseController  PauseController  { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public GameController   GameController   { get; private set; }

        private int   _controllerCounter;
        private bool  _isInitialized;
        private float _cameraHalfWidthInUnits;
        private float _cameraHalfHeightInUnits;

        public bool  IsInitialized           => _isInitialized;
        public float CameraHalfHeightInUnits => _cameraHalfHeightInUnits;
        public float CameraHalfWidthInUnits  => _cameraHalfWidthInUnits;

        public void Exit()
        {
#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif
        }

        public void Play()
        {
            if ( _isInitialized ) {
                InputController.OnUpdate += OnUpdate;
                GameController.StartMission<DemoMission>();
                PlayerController.transform.localScale = Vector3.one;
//                PlayerController.Shoot(WeaponsType.BASE);
                PauseController.Resume();
            }
        }

        private void Awake()
        {
            if ( Instance ) {
                DestroyImmediate(gameObject);
            } else {
                Construct();
            }
        }

        private void Construct()
        {
            _cameraHalfWidthInUnits  = Camera.main.orthographicSize * Camera.main.aspect;
            _cameraHalfHeightInUnits = Camera.main.orthographicSize;

            Instance = this;

            gameObject.AddComponent<BaseModel>();
            gameObject.AddComponent<GameModel>();

            InputController  = gameObject.AddComponent<InputController>();
            GameController   = gameObject.AddComponent<GameController>();
            PauseController  = FindObjectOfType<PauseController>();
            PlayerController = FindObjectOfType<PlayerController>();

            RegisterController<InputController, BaseModel>(InputController);
            RegisterController<PauseController, PauseModel>(PauseController);
            RegisterController<PlayerController, PlayerModel>(PlayerController);
            RegisterController<GameController, GameModel>(GameController);

            CheckInitialize();
        }

        protected void RegisterController<C, M>(C controller)
            where C : BaseController<M>
            where M : BaseModel
        {
            if ( !controller.IsInitialized ) {
                _controllerCounter--;
                controller.OnInitialized += OnInitialized;
            }
        }

        private void OnInitialized()
        {
            _controllerCounter++;
            CheckInitialize();
        }

        protected void CheckInitialize()
        {
            if ( _controllerCounter >= 0 ) {
                _isInitialized = true;
            }
        }

        private void OnUpdate(List<InputCommand> commands)
        {
            foreach ( var command in commands ) {
                command.Execute();
            }
        }
    }
}