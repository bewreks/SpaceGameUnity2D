using SpaceGame.Scripts.Interfaces;
using SpaceGame.Scripts.Models;
using UnityEngine;

namespace SpaceGame.Scripts.Controllers {
    public class BulletController : MovableController<BulletModel>
    {
        protected override void OnDie()
        {
            Hide();
            CancelInvoke("Hide");
        }

        protected override void Hide()
        {
            gameObject.SetActive(false);
        }

        protected override void Initialize()
        {
            base.Initialize();
            Invoke("Hide", _model.LifeTime);
        }

        protected override void OnUpdate(float deltaTime) {}

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
            
            Die();
        }

        public void SetStartData(Vector3 position)
        {
            _model.ResetModel();

            _transform.position   = position;
            _position             = position;
        }
    }
}