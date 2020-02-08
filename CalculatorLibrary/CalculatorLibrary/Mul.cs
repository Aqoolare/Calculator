using System.Numerics;

namespace CalculatorLibrary
{
    public class Mul : Command
    {
        public Mul(Reciever reciever, Complex firstOperand, Complex secondOperand)
        {
            this.reciever = reciever;
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }

        public override void Execute()
        {
            reciever.Run('*', firstOperand, secondOperand);
        }
    }
}
