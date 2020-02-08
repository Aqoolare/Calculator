using System.Numerics;

namespace CalculatorLibrary
{
    public class Div : Command
    {
        public Div(Reciever reciever, Complex firstOperand, Complex secondOperand)
        {
            this.reciever = reciever;
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }

        public override void Execute()
        {
            reciever.Run('/', firstOperand, secondOperand);
        }
    }
}
