namespace SpaceGame.Scripts.Interfaces {
    public interface ILive
    {
        void DoDamage(float damage);
        void DoHeal(float   heal);
        void Die();
    }
}