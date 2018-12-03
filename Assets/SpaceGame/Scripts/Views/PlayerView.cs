using SpaceGame.Scripts.Models;
using UnityEngine;

namespace SpaceGame.Scripts.Views
{
    public class PlayerView : BaseView<PlayerModel>
    {
        private Color    _getColor;
        private Material _material;
        private float    _damageAnimationTimer = 1;

        protected override void Initialize()
        {
            var renderer = GetComponent<Renderer>();
            _material       =  renderer.material;
            _getColor       =  _material.GetColor("_EmissionColor");
            _model.OnDamage += OnDamage;
        }

        private void OnDamage()
        {
            _damageAnimationTimer = 0;
        }

        private void Update()
        {
            if ( _damageAnimationTimer <= _model.DamageAnimationTime ) {
                _damageAnimationTimer += Time.deltaTime;
                var curve = _model.DamageCurve.Evaluate(_damageAnimationTimer);
                var color = Color.Lerp(_getColor, Color.black, curve);
                Debug.Log($"{curve} {color}");
                _material.SetColor("_EmissionColor", color);
            }
        }
    }
}