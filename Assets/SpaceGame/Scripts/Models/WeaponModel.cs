using SpaceGame.Scripts.Pool;

namespace SpaceGame.Scripts.Models
{
    public enum WeaponsType
    {
        BASE,
        EMP
    }

    public class WeaponModel : BaseModel
    {
        public bool        IsCD;
        public float       CoolDown;
        public WeaponsType Bullet;
    }
}