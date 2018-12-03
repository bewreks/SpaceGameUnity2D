using System.Collections;

namespace SpaceGame.Scripts.Controllers
{
    public class AutomaticWeaponController : WeaponController
    {
        protected override IEnumerator StartCD()
        {
            yield return base.StartCD();
            Shoot();
        }
    }
}