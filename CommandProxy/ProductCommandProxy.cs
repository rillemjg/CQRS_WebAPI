using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commands;
using Commands.Commands;
using Commands.Handlers;

namespace CommandProxy
{
    public class ProductCommandProxy
    {
        private List<ICommand> commandsList;

        public ProductCommandProxy()
        {
            commandsList = new List<ICommand>();
        }

        public void Store(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            commandsList.Add(command);
        }

        public bool Process()
        {
            if (commandsList.Count == 0)
            {
                return true;
            }

            var command = commandsList[0];

            if (command is AddQuantityCommand)
            {
                var commandHandler = new AddQuantityCommandHandler();
                commandHandler.Handle((AddQuantityCommand)command);
            }

            commandsList.RemoveAt(0);
            return commandsList.Count == 0;
        }
    }
}
