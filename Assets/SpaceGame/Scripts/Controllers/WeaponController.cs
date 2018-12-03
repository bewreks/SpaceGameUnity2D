using System.Collections;
using SpaceGame.Scripts.Models;
using SpaceGame.Scripts.Pool;
using UnityEngine;

namespace SpaceGame.Scripts.Controllers
{
    public class WeaponController : BaseController<WeaponModel>
    {
        public WeaponsType Type => _model.Bullet;

        public PoolsEnum Pool
        {
            get {
                switch ( Type ) {
                    case WeaponsType.EMP:

                        return PoolsEnum.EMP;
                    case WeaponsType.BASE:
                    default:

                        return PoolsEnum.BULLET;
                }
            }
        }

        public void Shoot()
        {
            if ( _model.IsCD ) {
                return;
            }

            DoShoot();
            StartCoroutine(StartCD());
        }

        private void DoShoot()
        {
            var bulletObject = PoolManager.GetObject(Pool);
            var bullet       = bulletObject.GetComponent<BulletController>();
            bullet.SetStartData(transform.position);
            bulletObject.SetActive(true);
        }

        protected virtual IEnumerator StartCD()
        {
            _model.IsCD = true;

            yield return new WaitForSeconds(_model.CoolDown);

            _model.IsCD = false;
        }
    }
}