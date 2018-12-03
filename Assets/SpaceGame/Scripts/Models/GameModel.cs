using SpaceGame.Scripts.Missions;
using UnityEngine.Events;

namespace SpaceGame.Scripts.Models {
    public class GameModel : BaseModel
    {
        public UnityAction<int> OnScoreChanged;

        private int _score;

        public int Score
        {
            get { return _score; }
            set {
                if ( _score != value ) {
                    _score = value;
                    OnScoreChanged?.Invoke(_score);
                }
            }
        }

        public BaseMission Mission { get; set; }
    }
}