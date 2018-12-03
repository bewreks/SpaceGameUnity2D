using SpaceGame.Scripts.Interfaces;
using SpaceGame.Scripts.Models;
using SpaceGame.Scripts.Pool;
using UnityEngine;

namespace SpaceGame.Scripts.Controllers {
    public class AsteroidController : MovableController<AsteroidModel>
    {
        private Vector3 _rotation;

        protected override void Hide()
        {
            gameObject.SetActive(false);
        }

        protected override void OnDie()
        {
            var explosion = PoolManager.GetObject(PoolsEnum.EXPLOSION);
            explosion.SetActive(true);
            explosion.transform.position = _position;
            Hide();
        }

        protected override void OnUpdate(float deltaTime)
        {
            _transform.Rotate(_rotation * deltaTime);
        }

        public void SetStartData(float size, Vector3 position, Vector3 rotation)
        {
            _model.ResetModel();

            _transform.localScale = Vector3.one * size;
            _transform.position   = position;
            _position             = position;
            _rotation             = rotation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if ( !_model.IsAlive ) {
                return;
            }

            if ( other.CompareTag("Main") ) {
                return;
            }

            var liveController = other.GetComponent<ILive>();
            liveController?.DoDamage(_model.Damage);
            Die();
        }

        private void OnTriggerExit(Collider other)
        {
            if ( !_model.IsAlive ) {
                return;
            }
            
            Hide();
        }
    }
}