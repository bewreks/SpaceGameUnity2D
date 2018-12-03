using UnityEngine.Events;

namespace SpaceGame.Scripts.Models
{
    public class LiveModel : BaseModel
    {
        public UnityAction<float> OnHpChanged;
        public UnityAction        OnDie;

        private float _changableHp;

        public float BaseHp;

        public float Hp      => BaseHp + _changableHp;
        public bool  IsAlive => Hp > 0;

        public float ChangableHp
        {
            get { return _changableHp; }
            set {
                if ( _changableHp != value ) {
                    var deltaHp = value - _changableHp;
                    _changableHp = value;
                    OnHpChanged?.Invoke(deltaHp);

                    if ( !IsAlive ) {
                        OnDie?.Invoke();
                    }
                }
            }
        }

        public override void ResetModel()
        {
            OnHpChanged  = null;
//            OnDie        = null;
            _changableHp = 0;
        }
    }
}