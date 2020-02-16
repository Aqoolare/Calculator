using System.Numerics;

namespace CalculatorLibrary
{
    public class Reciever
    {
        public Complex Register { get; private set; }
        public Complex MemoryValue { get; private set; }

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

        public void ChangeMemory(char operationCode, Complex value)
        {
            switch (operationCode)
            {
                case '+':
                    MemoryValue += value;
                    break;
                case '-':
                    MemoryValue -= value;
                    break;
                case '0':
                    MemoryValue = value;
                    break;
            }
        }
    }
}
