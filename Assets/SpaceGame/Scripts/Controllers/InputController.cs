using System.Collections.Generic;
using System.Runtime.InteropServices;
using SpaceGame.Scripts.Commands;
using SpaceGame.Scripts.Factories;
using SpaceGame.Scripts.Models;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceGame.Scripts.Controllers
{
    public class InputController : BaseController<BaseModel>
    {
        public static UnityAction<List<InputCommand>> OnUpdate;

        private List<InputCommand> _commands;

        protected override void Initialize()
        {
            _commands = new List<InputCommand>();
        }

        private void Update()
        {
            _commands.Clear();

            var mouseX            = Input.GetAxis("Mouse X");
            var mouseY            = Input.GetAxis("Mouse Y");
            var playerMoveCommand = InputCommandFactory.GetCommand<PlayerMoveCommand>();
            playerMoveCommand.Initialize(mouseX, mouseY);
            _commands.Add(playerMoveCommand);

            if ( Input.GetButtonUp("Cancel") ) {
                _commands.Add(InputCommandFactory.GetCommand<PauseCommand>());
            }

            if ( Input.GetButtonDown("Fire1") ) {
                _commands.Add(InputCommandFactory.GetCommand<EMPCommand>());
            }

            OnUpdate?.Invoke(_commands);
        }
    }
}