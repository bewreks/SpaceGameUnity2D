using SpaceGame.Scripts.Models;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceGame.Scripts {
    
    public abstract class ModelContainter<M> : MonoBehaviour
        where M : BaseModel
    {
        public UnityAction OnInitialized;

        private bool _isInitialized;

        protected M _model;

        public bool IsInitialized => _isInitialized;

        private void Awake()
        {
            _model = GetComponent<M>();

            if ( !_model ) {
                _model = GetComponentInParent<M>();
            }

            if ( !_model ) {
                _model = GetComponentInChildren<M>();
            }

            if ( !_model ) {
                _model = FindObjectOfType<M>();
            }

            if ( _model ) {
                if ( _model.IsInitialized ) {
                    InternalInitialize();
                } else {
                    _model.OnInitialized += InternalInitialize;
                }
            }
        }

        private void InternalInitialize()
        {
            _isInitialized = true;
            Initialize();
            OnInitialized?.Invoke();
            OnInitialized = null;
        }

        protected abstract void Initialize();
    }
}