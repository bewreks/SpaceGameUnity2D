using UnityEngine;
using UnityEngine.Events;

namespace SpaceGame.Scripts.Models {
    public enum MovableDirection
    {
        LEFT,
        RIGHT
    }

    [RequireComponent(typeof(Collider))]
    public class MovableModel : LiveModel
    {
        public Collider         Collider;
        public float            Speed     = 10;
        public float            Damage    = 10;
        public MovableDirection Direction = MovableDirection.LEFT;

        public int IntDirection => Direction == MovableDirection.LEFT ? -1 : 1;

        private void OnValidate()
        {
            OnAwake();
        }

        protected override void OnAwake()
        {
            Collider = GetComponent<Collider>();
        }
    }
}