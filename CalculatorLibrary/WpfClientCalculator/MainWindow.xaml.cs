using System;
using System.Numerics;
using CalculatorLibrary;
using System.Windows;

namespace WpfClientCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Reciever arithmeticUnit;
        Invoker controlUnit;
        Complex result = 0;

        public MainWindow()
        {
            InitializeComponent();
            arithmeticUnit = new Reciever();
            controlUnit = new Invoker();
        }

        private void GetResult_Click(object sender, RoutedEventArgs e)
        {
            switch (generalSign.Text)
            {
                case "+":
                    result = Add(ConvertDataToComplexNumber(FirstOperandRealSign.Text, FirstOperandRealPart.Text, FirstOperandImaginarySign.Text, FirstOperandImaginaryPart.Text),
                        ConvertDataToComplexNumber(SecondOperandRealSign.Text, SecondOperandRealPart.Text, SecondOperandImaginarySign.Text, SecondOperandImaginaryPart.Text));
                    OutputResult(result);
                    break;
                case "-":
                    result = Sub(ConvertDataToComplexNumber(FirstOperandRealSign.Text, FirstOperandRealPart.Text, FirstOperandImaginarySign.Text, FirstOperandImaginaryPart.Text),
                        ConvertDataToComplexNumber(SecondOperandRealSign.Text, SecondOperandRealPart.Text, SecondOperandImaginarySign.Text, SecondOperandImaginaryPart.Text));
                    OutputResult(result);
                    break;
                case "*":
                    result = Mul(ConvertDataToComplexNumber(FirstOperandRealSign.Text, FirstOperandRealPart.Text, FirstOperandImaginarySign.Text, FirstOperandImaginaryPart.Text),
                        ConvertDataToComplexNumber(SecondOperandRealSign.Text, SecondOperandRealPart.Text, SecondOperandImaginarySign.Text, SecondOperandImaginaryPart.Text));
                    OutputResult(result);
                    break;
                case "/":
                    try
                    {
                        result = Div(ConvertDataToComplexNumber(FirstOperandRealSign.Text, FirstOperandRealPart.Text, FirstOperandImaginarySign.Text, FirstOperandImaginaryPart.Text),
                            ConvertDataToComplexNumber(SecondOperandRealSign.Text, SecondOperandRealPart.Text, SecondOperandImaginarySign.Text, SecondOperandImaginaryPart.Text));
                        OutputResult(result);
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Деление на ноль.");
                    }
                    break;
            }
        }

        private Complex Run(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.Register;
        }

        private Complex RunMemoryCommand(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.MemoryValue;
        }

        private Complex RunCancelCommand(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.Register;
        }

        private ComplexDegreeResultHolder RunUnaryCommand(UnaryCommand unaryCommand)
        {
            controlUnit.StoreCommand(unaryCommand);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.ComplexDegreeResult;
        }

        public ComplexDegreeResultHolder CalculateRadical(Complex number, int degree)
        {
            return RunUnaryCommand(new RadicalCommand(arithmeticUnit, number, degree));
        }

        public ComplexDegreeResultHolder CalculateDegree(Complex number, int degree)
        {
            return RunUnaryCommand(new DegreeCommand(arithmeticUnit, number, degree));
        }

        private void OutputResult(Complex number)
        {
            resultRealPart.Text = number.Real.ToString();
            resultImaginaryPart.Text = number.Imaginary.ToString();
        }

        public Complex Add(Complex firstOperand, Complex secondOperand)
        {
            return Run(new Add(arithmeticUnit, firstOperand, secondOperand));
        }

        public Complex Sub(Complex firstOperand, Complex secondOperand)
        {
            return Run(new Sub(arithmeticUnit, firstOperand, secondOperand));
        }

        public Complex Mul(Complex firstOperand, Complex secondOperand)
        {
            return Run(new Mul(arithmeticUnit, firstOperand, secondOperand));
        }

        public Complex Div(Complex firstOperand, Complex secondOperand)
        {
            return Run(new Div(arithmeticUnit, firstOperand, secondOperand));
        }

        public Complex MPlus(Complex value)
        {
            return RunMemoryCommand(new MPlus(arithmeticUnit, value));
        }

        public Complex MMinus(Complex value)
        {
            return RunMemoryCommand(new MMinus(arithmeticUnit, value));
        }

        public Complex MC()
        {
            return RunMemoryCommand(new MC(arithmeticUnit));
        }

        public Complex ConvertDataToComplexNumber(string firstSign, string realPart, string secondSign, string imaginaryPart)
        {
            if (firstSign == "-")
            {
                if (secondSign == "-")
                {
                    return new Complex(-Convert.ToDouble(realPart), -Convert.ToDouble(imaginaryPart));
                }
                else
                {
                    return new Complex(-Convert.ToDouble(realPart), Convert.ToDouble(imaginaryPart));
                }
            }
            else
            {
                if (secondSign == "-")
                {
                    return new Complex(Convert.ToDouble(realPart), -Convert.ToDouble(imaginaryPart));
                }
                else
                {
                    return new Complex(Convert.ToDouble(realPart), Convert.ToDouble(imaginaryPart));
                }
            }
        }

        private void MP_Click(object sender, RoutedEventArgs e)
        {
            MemoryValue.Content = MPlus(new Complex(Convert.ToDouble(resultRealPart.Text), Convert.ToDouble(resultImaginaryPart.Text))).ToString();
        }

        private void MMin_Click(object sender, RoutedEventArgs e)
        {
            MemoryValue.Content = MMinus(new Complex(Convert.ToDouble(resultRealPart.Text), Convert.ToDouble(resultRealPart.Text))).ToString();
        }

        private void MRead_Click(object sender, RoutedEventArgs e)
        {
            if (arithmeticUnit.MemoryValue.Real < 0)
            {
                FirstOperandRealSign.Text = "-";
                FirstOperandRealPart.Text = Math.Abs(arithmeticUnit.MemoryValue.Real).ToString();
            }
            else
            {
                FirstOperandRealSign.Text = "+";
                FirstOperandRealPart.Text = arithmeticUnit.MemoryValue.Real.ToString();
            }
            if (arithmeticUnit.MemoryValue.Imaginary < 0)
            {
                FirstOperandImaginarySign.Text = "-";
                FirstOperandImaginaryPart.Text = Math.Abs(arithmeticUnit.MemoryValue.Imaginary).ToString();
            }
            else
            {
                FirstOperandImaginarySign.Text = "+";
                FirstOperandImaginaryPart.Text = arithmeticUnit.MemoryValue.Imaginary.ToString();
            }
        }

        private void MClear_Click(object sender, RoutedEventArgs e)
        {
            MemoryValue.Content = MC().ToString();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            var num = RunCancelCommand(new Cancel(arithmeticUnit));
            if (num.Real < 0)
            {
                FirstOperandRealSign.SelectedItem = '-';
            }
            else
            {
                FirstOperandRealSign.SelectedItem = '+';
            }
            if (num.Imaginary < 0)
            {
                FirstOperandImaginarySign.SelectedItem = '-';
            }
            else
            {
                FirstOperandImaginarySign.SelectedItem = '+';
            }
            FirstOperandRealPart.Text = Math.Abs(num.Real).ToString();
            FirstOperandImaginaryPart.Text = Math.Abs(num.Imaginary).ToString();
            SecondOperandRealPart.Text = null;
            SecondOperandImaginaryPart.Text = null;
            SecondOperandRealSign.SelectedItem = null;
            SecondOperandImaginarySign.SelectedItem = null;
            resultRealPart.Text = null;
            resultImaginaryPart.Text = null;
        }

        private void GetResultRoot_Click(object sender, RoutedEventArgs e)
        {
            ComplexDegreeResultHolder crh = CalculateRadical(new Complex(Convert.ToDouble(RealPartUnderRoot.Text), Convert.ToDouble(ImaginaryPartUnderRoot.Text)),
                Convert.ToInt32(RootDegree.Text));
            ExactValues.Items.Clear();
            NumericalValues.Items.Clear();
            foreach (var arg in crh.Arguments)
            {
                ExactValues.Items.Add($"{crh.Mod} * (cos(({arg}) / {RootDegree.Text}) + i * sin(({arg}) / {RootDegree.Text}))");
            }
            foreach (var res in crh.Results)
            {
                NumericalValues.Items.Add(res);
            }
        }

        private void GetResultDegree_Click(object sender, RoutedEventArgs e)
        {
            ComplexDegreeResultHolder crh = CalculateDegree(new Complex(Convert.ToDouble(RealPartForDegree.Text), Convert.ToDouble(ImaginaryPartForDegree.Text)),
                Convert.ToInt32(NumberDegree.Text));
            RealResultDegree.Text = crh.Results[0].Real.ToString();
            ImaginaryResultDegree.Text = crh.Results[0].Imaginary.ToString();
        }
    }
}
