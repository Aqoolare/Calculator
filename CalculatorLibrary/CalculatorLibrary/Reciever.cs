using System.Numerics;

namespace CalculatorLibrary
{
    public class Reciever
    {
        public Complex Register { get; set; }
        public void Run(char operationCode, Complex firstOperand, Complex secondOperand)
        {
            Register = firstOperand;
            switch (operationCode)
            {
                case '+':
                    Register += secondOperand;
                    break;
                case '-':
                    Register -= secondOperand;
                    break;
                case '*':
                    Register *= secondOperand;
                    break;
                case '/':
                    Register /= secondOperand;
                    break;
            }
        }
    }
}
