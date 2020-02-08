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
                    label1.Text = Convert.ToString(result);
                    break;
                case "-":
                    result = Sub(ConvertDataToComplexNumber(comboBox2.Text, textBox1.Text, comboBox3.Text, textBox2.Text),
                        ConvertDataToComplexNumber(comboBox5.Text, textBox4.Text, comboBox4.Text, textBox3.Text));
                    label1.Text = Convert.ToString(result);
                    break;
                case "*":
                    result = Mul(ConvertDataToComplexNumber(comboBox2.Text, textBox1.Text, comboBox3.Text, textBox2.Text),
                        ConvertDataToComplexNumber(comboBox5.Text, textBox4.Text, comboBox4.Text, textBox3.Text));
                    label1.Text = Convert.ToString(result);
                    break;
                case "/":
                    result = Div(ConvertDataToComplexNumber(comboBox2.Text, textBox1.Text, comboBox3.Text, textBox2.Text),
                        ConvertDataToComplexNumber(comboBox5.Text, textBox4.Text, comboBox4.Text, textBox3.Text));
                    label1.Text = Convert.ToString(result);
                    break;
            }
        }

        private Complex Run(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.Register;
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
    }
}
