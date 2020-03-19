using System.Numerics;
using System.Collections.Generic;
using System;

namespace CalculatorLibrary
{
    public class Reciever
    {
        public Complex Register { get; private set; }
        public Complex MemoryValue { get; private set; }
        public ComplexDegreeResultHolder ComplexDegreeResult { get; private set; }
        private Stack<Complex> operationHistory { get; set; }

        public Reciever()
        {
            operationHistory = new Stack<Complex>();
        }

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
                    if (secondOperand == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    else
                    {
                        Register /= secondOperand;
                    }
                    break;
            }
            operationHistory.Push(firstOperand);
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

        public void CalculateDegree(Complex operand, int degree)
        {
            ComplexDegreeResult = new ComplexDegreeResultHolder();
            var res = Complex.Pow(operand, degree);
            ComplexDegreeResult.Results.Add(new Complex(Math.Round(res.Real, 5), Math.Round(res.Imaginary, 5)));
        }

        public void CalculateRadical(Complex operand, int degree)
        {
            ComplexDegreeResult = new ComplexDegreeResultHolder();
            double a = operand.Real;
            double b = operand.Imaginary;

            bool numbersAreInteger = false;
           
            if (operand.Real == Math.Truncate(operand.Real) && operand.Imaginary == Math.Truncate(operand.Imaginary))
            {
                long nod = NODCalculator.FindGreatestCommonDivisor((long)a, (long)b);
                a = a / nod;
                b = b / nod;
                numbersAreInteger = true;
            }

            ComplexDegreeResult.Mod = Math.Pow((Math.Pow(operand.Real, 2) + Math.Pow(operand.Imaginary, 2)), 1.0 / 2.0);
            double trigArg;
            double radMod = Math.Pow(ComplexDegreeResult.Mod, 1.0 / (double)degree);

            if (a != 0 && b != 0)
            {
                if (a > 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        if (numbersAreInteger)
                            ComplexDegreeResult.Arguments.Add($"arctg({Math.Round(b, 0)}/{Math.Round(a, 0)}) + 2*pi*{i}");
                        else
                            ComplexDegreeResult.Arguments.Add($"arctg({Math.Round(b, 5)}/{Math.Round(a, 5)}) + 2*pi*{i}");              
                        trigArg = (Math.Atan(b / a) + 2 * Math.PI * i) / (double)degree;
                        ComplexDegreeResult.Results.Add(new Complex(Math.Round(radMod * Math.Cos(trigArg), 5),Math.Round(radMod * Math.Sin(trigArg), 5)));
                    }
                }
                else if (a < 0 && b > 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        if (numbersAreInteger)
                            ComplexDegreeResult.Arguments.Add($"pi + arctg({Math.Round(b, 0)}/{Math.Round(a, 0)}) + 2*pi*{i}");
                        else
                            ComplexDegreeResult.Arguments.Add($"pi + arctg({Math.Round(b, 5)}/{Math.Round(a, 5)}) + 2*pi*{i}");
                        trigArg = (Math.PI + Math.Atan(b / a) + 2 * Math.PI * i) / (double)degree;
                        ComplexDegreeResult.Results.Add(new Complex(Math.Round(radMod * Math.Cos(trigArg), 5), Math.Round(radMod * Math.Sin(trigArg), 5)));
                    }
                }
                else if (a < 0 && b < 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        if (numbersAreInteger)
                            ComplexDegreeResult.Arguments.Add($"-pi + arctg({Math.Round(b, 0)}/{Math.Round(a, 0)}) + 2*pi*{i}");
                        else
                            ComplexDegreeResult.Arguments.Add($"-pi + arctg({Math.Round(b, 5)}/{Math.Round(a, 5)}) + 2*pi*{i}");
                        trigArg = (-Math.PI + Math.Atan(b / a) + 2 * Math.PI * i) / (double)degree;
                        ComplexDegreeResult.Results.Add(new Complex(Math.Round(radMod * Math.Cos(trigArg), 5), Math.Round(radMod * Math.Sin(trigArg), 5)));
                    }
                }
            }
            else if (a == 0 && b!= 0)
            {
                if (b > 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        if (numbersAreInteger)
                            ComplexDegreeResult.Arguments.Add($"pi/2 + 2*pi*{i}");
                        else
                            ComplexDegreeResult.Arguments.Add($"pi/2 + 2*pi*{i}");
                        trigArg = (Math.PI/2 + 2 * Math.PI * i) / (double)degree;
                        ComplexDegreeResult.Results.Add(new Complex(Math.Round(radMod * Math.Cos(trigArg), 5), Math.Round(radMod * Math.Sin(trigArg), 5)));
                    }
                }
                else if (b < 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        if (numbersAreInteger)
                            ComplexDegreeResult.Arguments.Add($"-pi/2 + 2*pi*{i}");
                        else
                            ComplexDegreeResult.Arguments.Add($"-pi/2 + 2*pi*{i}");
                        trigArg = (-Math.PI / 2 + 2 * Math.PI * i) / (double)degree;
                        ComplexDegreeResult.Results.Add(new Complex(Math.Round(radMod * Math.Cos(trigArg), 5), Math.Round(radMod * Math.Sin(trigArg), 5)));
                    }
                }
            }
            else if (b == 0 && a != 0)
            {
                if (a > 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        if (numbersAreInteger)
                            ComplexDegreeResult.Arguments.Add($"2*pi*{i}");
                        else
                            ComplexDegreeResult.Arguments.Add($"2*pi*{i}");
                        trigArg = (2 * Math.PI * i) / (double)degree;
                        ComplexDegreeResult.Results.Add(new Complex(Math.Round(radMod * Math.Cos(trigArg), 5), Math.Round(radMod * Math.Sin(trigArg), 5)));
                    }
                }
                else if (a < 0)
                {
                    for (int i = 0; i < degree; i++)
                    {
                        if (numbersAreInteger)
                            ComplexDegreeResult.Arguments.Add($"pi + 2*pi*{i}");
                        else
                            ComplexDegreeResult.Arguments.Add($"pi + 2*pi*{i}");
                        trigArg = (Math.PI + 2 * Math.PI * i) / (double)degree;
                        ComplexDegreeResult.Results.Add(new Complex(Math.Round(radMod * Math.Cos(trigArg), 5), Math.Round(radMod * Math.Sin(trigArg), 5)));
                    }
                }
            }
            else
            {
                ComplexDegreeResult.Results.Add(new Complex(0,0));
            }
        }

        public void CancelOperation()
        {
            if (operationHistory.Count != 0)
                Register = operationHistory.Pop();
        }
    }
}
