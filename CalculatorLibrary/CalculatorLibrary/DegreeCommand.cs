using System.Numerics;

namespace CalculatorLibrary
{
    public class DegreeCommand : UnaryCommand
    {
        public DegreeCommand(Reciever reciever, Complex operand, int degree)
        {
            this.reciever = reciever;
            this.operand = operand;
            this.degree = degree;
        }

        public override void Execute()
        {
            reciever.CalculateDegree(operand, degree);
        }
    }
}
