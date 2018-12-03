using System;
using SpaceGame.Scripts.Factories;
using UnityEngine;

namespace SpaceGame.Scripts.Commands {
    public abstract class InputCommand
    {
        protected bool _isEnabledInPause;
        internal  Type _commandType;

        protected InputCommand()
        {
            _isEnabledInPause = false;
            _commandType      = GetType();

            InternalInitialize();
        }

        public void Execute()
        {
            if ( !Main.Instance.PauseController.IsPaused || _isEnabledInPause ) {
                try {
                    InternalExecute();
                } catch ( Exception e ) {
                    Debug.LogError(e);
                }
            }

            InputCommandFactory.Realize(this);
        }

        protected abstract void InternalExecute();
        protected abstract void InternalInitialize();
    }
}