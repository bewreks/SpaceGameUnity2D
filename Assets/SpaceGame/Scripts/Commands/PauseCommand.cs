namespace SpaceGame.Scripts.Commands
{
    public class PauseCommand : InputCommand
    {
        protected override void InternalExecute()
        {
            Main.Instance.PauseController.Switch();
        }

        protected override void InternalInitialize()
        {
            _commandType      = GetType();
            _isEnabledInPause = true;
        }
    }
}