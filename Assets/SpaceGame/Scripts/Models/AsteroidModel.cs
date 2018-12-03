namespace SpaceGame.Scripts.Models {
    public class AsteroidModel : MovableModel
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            Collider.isTrigger = true;
        }
    }
}