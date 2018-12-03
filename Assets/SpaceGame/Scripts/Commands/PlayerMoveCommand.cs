using UnityEngine;

namespace SpaceGame.Scripts.Commands {
    public class PlayerMoveCommand : InputCommand
    {
        private float _x;
        private float _y;

        public void Initialize(float x, float y)
        {
            _x = x;
            _y = y;
        }
        
        protected override void InternalExecute()
        {
            Main.Instance.PlayerController.Move(new Vector3(_x, _y));
        }

        protected override void InternalInitialize()
        {
            _commandType = GetType();
        }
    }
}