using SpaceGame.Scripts.Models;
using UnityEngine;

namespace SpaceGame.Scripts.Controllers {
    public abstract class MovableController<M> : LiveController<M>
        where M : MovableModel
    {
        protected Transform _transform;
        protected Vector3   _position;

        protected override void Initialize()
        {
            _transform = transform;
            _position  = _transform.position;

            _model.OnDie += OnDie;
        }

        private void Update()
        {
            if ( !_model.IsAlive ) {
                return;
            }

            _position.x         += _model.Speed * Time.deltaTime * _model.IntDirection;
            _transform.position =  _position;
            OnUpdate(Time.deltaTime);
        }

        private void OnTriggerExit(Collider other)
        {
            Hide();
        }

        protected abstract void OnDie();
        protected abstract void Hide();
        protected abstract void OnUpdate(float deltaTime);
    }
}