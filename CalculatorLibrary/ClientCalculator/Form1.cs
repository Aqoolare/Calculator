using System;
using CalculatorLibrary;
using System.Numerics;
using System.Windows.Forms;

namespace ClientCalculator
{
    public partial class Form1 : Form
    {
        Reciever arithmeticUnit;
        Invoker controlUnit;
        Complex result = 0;

        public Form1()
        {
            InitializeComponent();
            arithmeticUnit = new Reciever();
            controlUnit = new Invoker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "+":
                    result = Add(ConvertDataToComplexNumber(comboBox2.Text, textBox1.Text, comboBox3.Text, textBox2.Text), 
                        ConvertDataToComplexNumber(comboBox5.Text, textBox4.Text, comboBox4.Text, textBox3.Text));
                    OutputResult(result);
                    break;
                case "-":
                    result = Sub(ConvertDataToComplexNumber(comboBox2.Text, textBox1.Text, comboBox3.Text, textBox2.Text),
                        ConvertDataToComplexNumber(comboBox5.Text, textBox4.Text, comboBox4.Text, textBox3.Text));
                    OutputResult(result);
                    break;
                case "*":
                    result = Mul(ConvertDataToComplexNumber(comboBox2.Text, textBox1.Text, comboBox3.Text, textBox2.Text),
                        ConvertDataToComplexNumber(comboBox5.Text, textBox4.Text, comboBox4.Text, textBox3.Text));
                    OutputResult(result);
                    break;
                case "/":
                    result = Div(ConvertDataToComplexNumber(comboBox2.Text, textBox1.Text, comboBox3.Text, textBox2.Text),
                        ConvertDataToComplexNumber(comboBox5.Text, textBox4.Text, comboBox4.Text, textBox3.Text));
                    OutputResult(result);
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

        private void OutputResult(Complex number)
        {
            textBox6.Text = number.Real.ToString();
            textBox5.Text = number.Imaginary.ToString();
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
                    return new Complex(-int.Parse(realPart), -int.Parse(imaginaryPart));
                }
                else
                {
                    return new Complex(-int.Parse(realPart), int.Parse(imaginaryPart));
                }
            }
            else
            {
                if (secondSign == "-")
                {
                    return new Complex(int.Parse(realPart), -int.Parse(imaginaryPart));
                }
                else
                {
                    return new Complex(int.Parse(realPart), int.Parse(imaginaryPart));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = MPlus(new Complex(Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox5.Text))).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label8.Text = MMinus(new Complex(Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox5.Text))).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (arithmeticUnit.MemoryValue.Real < 0)
            {
                comboBox2.Text = "-";
                textBox1.Text = Math.Abs(arithmeticUnit.MemoryValue.Real).ToString();
            }
            else
            {
                comboBox2.Text = "+";
                textBox1.Text = arithmeticUnit.MemoryValue.Real.ToString();
            }
            if (arithmeticUnit.MemoryValue.Imaginary < 0)
            {
                comboBox3.Text = "-";
                textBox2.Text = Math.Abs(arithmeticUnit.MemoryValue.Imaginary).ToString();
            }
            else
            {
                comboBox3.Text = "+";
                textBox2.Text = arithmeticUnit.MemoryValue.Imaginary.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label8.Text = MC().ToString();
        }
    }
}
