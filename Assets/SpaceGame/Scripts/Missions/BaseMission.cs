using System;
using SpaceGame.Scripts.Controllers;
using SpaceGame.Scripts.Pool;
using UnityEngine.Events;

namespace SpaceGame.Scripts.Missions
{
    public abstract class BaseMission
    {
        protected bool _stop = false;
        public    bool IsEnd => _stop;

        public UnityAction   OnMissionEnd { get; set; }
        public Action<float> Waiting      { set; protected get; }

//        public Func<AsteroidIniter, AsteroidController> CreateAsteroid { set; protected get; }

//    public MedkitController     CreateMedic    { set; protected get; }

        public void StartMission()
        {
            OnMissionStart();
            Round();
        }

        public void StopMission()
        {
            _stop = true;
            OnMissionEnd();
        }

        public void Round()
        {
            if ( _stop ) {
                return;
            }

            OnRoundStart();
        }

        public AsteroidController CreateAsteroid()
        {
            var asteroid = PoolManager.GetObject(PoolsEnum.ASTEROID);

            return asteroid.GetComponent<AsteroidController>();
        }

        protected abstract void OnRoundStart();
        protected abstract void OnMissionStart();
        public abstract    void UpdateScore(int score);
        public abstract    void OnWaitingEnd();
    }
}