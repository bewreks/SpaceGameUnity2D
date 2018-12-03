namespace SpaceGame.Scripts.Models {
    public class BulletModel : MovableModel
    {
        public float LifeTime = 5;
        
        protected override void OnAwake()
        {
            base.OnAwake();
            Collider.isTrigger = true;
        }
    }
}