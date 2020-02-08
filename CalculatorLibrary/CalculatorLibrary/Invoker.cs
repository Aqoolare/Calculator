using System.Collections.Generic;

namespace CalculatorLibrary
{
    public class Invoker
    {
        private Command command;

        public void StoreCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
