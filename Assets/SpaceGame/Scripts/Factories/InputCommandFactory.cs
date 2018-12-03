using System;
using System.Collections.Generic;
using SpaceGame.Scripts.Commands;

namespace SpaceGame.Scripts.Factories {
    public static class InputCommandFactory
    {
        private static readonly Dictionary<Type, Queue<InputCommand>> _commands;

        static InputCommandFactory()
        {
            _commands = new Dictionary<Type, Queue<InputCommand>>();
        }

        public static T GetCommand<T>()
            where T : InputCommand, new()
        {
            InputCommand        command = default(T);
            Queue<InputCommand> queue;

            _commands.TryGetValue(typeof(T), out queue);

            if ( queue?.Count > 0 ) {
                command = queue.Dequeue();
            }

            return (T) (command ?? new T());
        }

        public static void Realize<T>(T command)
            where T : InputCommand
        {
            Queue<InputCommand> queue;
            _commands.TryGetValue(command._commandType, out queue);

            if ( queue == null ) {
                queue = new Queue<InputCommand>();
                _commands.Add(command._commandType, queue);
            }

            queue.Enqueue(command);
        }
    }
}