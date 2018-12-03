using SpaceGame.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceGame.Scripts.Controllers
{
    public class PauseController : BaseController<PauseModel>
    {
        public Button PlayButton;
        public Button ResumeButton;
        public Button InventoryButton;
        public Button ExitButton;

        public bool IsPaused => _model.IsPaused;

        protected override void Initialize()
        {
            var buttons = GetComponentsInChildren<Button>(true);

            foreach ( var button in buttons ) {
                switch ( button.name ) {
                    case "Play":
                        PlayButton = button;

                        break;
                    case "Resume":
                        ResumeButton = button;

                        break;
                    case "Inventory":
                        InventoryButton = button;

                        break;
                    case "Exit":
                        ExitButton = button;

                        break;
                }
            }


            Cursor.lockState = CursorLockMode.Confined;
        }

        private void OnValidate()
        {
            Initialize();
        }

        public void Pause()
        {
            Time.timeScale = 0;

            _model.IsPaused = true;

            PlayButton.gameObject.SetActive(false);
            ResumeButton.gameObject.SetActive(true);
            InventoryButton.gameObject.SetActive(true);
            ExitButton.gameObject.SetActive(true);

            Cursor.visible = true;
        }

        public void Resume()
        {
            Time.timeScale = 1;

            _model.IsPaused = false;

            PlayButton.gameObject.SetActive(false);
            ResumeButton.gameObject.SetActive(false);
            InventoryButton.gameObject.SetActive(false);
            ExitButton.gameObject.SetActive(false);
            
            Cursor.visible = false;
        }

        public void Switch()
        {
            if ( IsPaused ) {
                Resume();
            } else {
                Pause();
            }
        }
    }
}