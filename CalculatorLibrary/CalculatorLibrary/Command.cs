using System.Numerics;

namespace CalculatorLibrary
{
    public abstract class Command
    {
        protected Reciever reciever;
        protected Complex firstOperand;
        protected Complex secondOperand;

        public abstract void Execute();
    }
}
