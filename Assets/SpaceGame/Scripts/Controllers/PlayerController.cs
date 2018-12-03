using SpaceGame.Scripts.Models;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceGame.Scripts.Controllers
{
    public class PlayerController : LiveController<PlayerModel>
    {
        public UnityAction OnDie;

        private Transform _transform;

        protected override void Initialize()
        {
            _transform      =  transform;
            _model.OnDamage += OnDamage;
        }

        private void OnDamage()
        {
            if ( !_model.IsAlive ) {
                OnDie?.Invoke();
                OnDie = null;
            }
        }

        public void Shoot(WeaponsType type)
        {
            foreach ( var weapon in _model.Weapons ) {
                if ( weapon.Type == type ) {
                    weapon.Shoot();
                }
            }
        }

        public void Move(Vector3 deltaPosition)
        {
            if ( !_model.IsAlive ) {
                return;
            }

            _transform.position += deltaPosition * _model.Sensivity;
        }
    }
}