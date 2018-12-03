using SpaceGame.Scripts.Interfaces;
using SpaceGame.Scripts.Models;

namespace SpaceGame.Scripts.Controllers {
    public class LiveController<M> : BaseController<M>, ILive
        where M : LiveModel
    {
        public void DoDamage(float damage)
        {
            if ( _model.IsAlive )
                _model.ChangableHp -= damage;
        }

        public void DoHeal(float heal)
        {
            if ( _model.IsAlive )
                _model.ChangableHp += heal;
        }

        public void Die()
        {
            if ( _model.IsAlive )
                _model.ChangableHp -= _model.Hp;
        }
    }
}