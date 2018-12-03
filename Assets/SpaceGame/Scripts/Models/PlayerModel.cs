using SpaceGame.Scripts.Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceGame.Scripts.Models
{
    public class PlayerModel : LiveModel
    {
        public UnityAction OnHeal;
        public UnityAction OnDamage;

        public float              Sensivity = 0.3f;
        public WeaponController[] Weapons;
        public AnimationCurve     DamageCurve;
        public float              DamageAnimationTime = 0.3f;

        protected override void OnAwake()
        {
            OnHpChanged += OnHpChange;

            Weapons = GetComponentsInChildren<WeaponController>();
        }

        private void OnHpChange(float deltaHp)
        {
            if ( deltaHp > 0 ) {
                OnHeal?.Invoke();
            } else if ( deltaHp < 0 ) {
                OnDamage?.Invoke();
            }
        }
    }
}