using System;
using System.Collections;
using SpaceGame.Scripts.Missions;
using SpaceGame.Scripts.Models;
using SpaceGame.Scripts.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceGame.Scripts.Controllers
{
    public class GameController : BaseController<GameModel>
    {
        public void StartMission<M>()
            where M : BaseMission
        {
            var instance = Activator.CreateInstance(typeof(M));
            _model.Mission              =  (BaseMission) instance;
            _model.Mission.OnMissionEnd =  OnMissionEnd;
            _model.Mission.Waiting      =  Waiting;
            _model.OnScoreChanged       += _model.Mission.UpdateScore;
            _model.Mission.StartMission();
        }

        private void OnMissionEnd() {}

        protected void Waiting(float seconds)
        {
            StartCoroutine(CoroutineWaiting(seconds));
        }

        private IEnumerator CoroutineWaiting(float waiting)
        {
            yield return new WaitForSeconds(waiting);

            _model.Mission.OnWaitingEnd();
        }
    }
}