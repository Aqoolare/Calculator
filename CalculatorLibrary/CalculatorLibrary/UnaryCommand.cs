using System.Numerics;

namespace CalculatorLibrary
{
    public abstract class UnaryCommand : Command
    {
        protected Complex operand;
        protected int degree;
    }
}
