using UnityEngine.Events;

namespace SpaceGame.Scripts.Models {
    public class PauseModel : BaseModel
    {
        public UnityAction<bool> PauseStateChanged;

        private bool _isPaused;

        public bool IsPaused
        {
            get { return _isPaused; }
            set {
                if ( _isPaused != value ) {
                    _isPaused = value;
                    PauseStateChanged?.Invoke(_isPaused);
                }
            }
        }
    }
}