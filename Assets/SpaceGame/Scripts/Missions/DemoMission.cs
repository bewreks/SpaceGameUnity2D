using UnityEngine;

namespace SpaceGame.Scripts.Missions
{
    public class DemoMission : BaseMission
    {
        private float _asteriodRate;

        protected override void OnMissionStart()
        {
            _asteriodRate = 1f;
        }

        protected override void OnRoundStart()
        {
            /*var random  = (int)Random(0, 4);
            var isMedic = random % 4 == 0;
            if (isMedic)
            {
                CreateMedic(new MedkitModelIniter
                            {
                                x = 19.5f,
                                y = Random(-5.0f, 5.0f),
                            });
            }
            else
            {
                CreateAsteroid(new AsteroidModelIniter
                               {
                                   radius = Random(0.3f, 1),
                                   x      = 19.5f,
                                   y      = Random(-5.0f, 5.0f),
                                   speed  = Random(-6,    -3)
                               });
            }*/

            var asteroidController = CreateAsteroid();
            var size               = Random.Range(0.25f, .7f);
            var halfSize           = size * 0.5f;

            var asteroidRotation = new Vector3(Random.Range(0, 359.9f), Random.Range(0, 60f), Random.Range(0, 60f));
            var asteroidPosition = Vector3.up * Random.Range(-Main.Instance.CameraHalfHeightInUnits + halfSize, Main.Instance.CameraHalfHeightInUnits - halfSize);
            asteroidPosition.x = Main.Instance.CameraHalfWidthInUnits + halfSize;

            asteroidController.SetStartData(size,
                                            asteroidPosition,
                                            asteroidRotation
                                           );

            asteroidController.gameObject.SetActive(true);

            Waiting(1 / _asteriodRate);
        }

        public override void UpdateScore(int score)
        {
            if ( score % 300 == 0 ) {
                _asteriodRate++;
            }

            /*if (score % 500 == 0)
            {
                foreach (var part in PlayerController.Instance.GetParts())
                {
                    part.AddTempPower(1);
                }
            }*/
        }

        public override void OnWaitingEnd()
        {
            Round();
        }
    }
}