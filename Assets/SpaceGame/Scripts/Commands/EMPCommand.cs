using SpaceGame.Scripts.Models;

namespace SpaceGame.Scripts.Commands {
    public class EMPCommand : InputCommand 
    {
        protected override void InternalExecute()
        {
            Main.Instance.PlayerController.Shoot(WeaponsType.EMP);
        }

        protected override void InternalInitialize()
        {
            _commandType      = GetType();
            _isEnabledInPause = false;
        }
    }
}