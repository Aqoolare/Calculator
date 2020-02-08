using System.Numerics;

namespace CalculatorLibrary
{
    public class Add : Command
    {
        public Add(Reciever reciever, Complex firstOperand, Complex secondOperand)
        {
            this.reciever = reciever;
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }

        public override void Execute()
        {
            reciever.Run('+', firstOperand, secondOperand);
        }
    }
}
