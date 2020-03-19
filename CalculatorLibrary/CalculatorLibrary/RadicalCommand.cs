using System.Numerics;

namespace CalculatorLibrary
{
    public class RadicalCommand : UnaryCommand
    {
        public RadicalCommand(Reciever reciever, Complex operand, int degree)
        {
            this.reciever = reciever;
            this.operand = operand;
            this.degree = degree;
        }

        public override void Execute()
        {
            reciever.CalculateRadical(operand, degree);
        }
    }
}
