using UnityEngine;
using UnityEngine.Events;

namespace SpaceGame.Scripts.Models {
    public class BaseModel : MonoBehaviour
    {
        public UnityAction OnInitialized;

        protected bool _isInitialized;

        public bool IsInitialized => _isInitialized;

        private void Awake()
        {
            _isInitialized = true;
            OnInitialized?.Invoke();
            OnAwake();
        }

        public virtual void ResetModel()
        {
        
        } 

        protected virtual void OnAwake() {}
    }
}