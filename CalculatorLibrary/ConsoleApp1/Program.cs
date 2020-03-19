using System;
using CalculatorLibrary;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reciever r = new Reciever();
            ComplexDegreeResultHolder c = r.CalculateRadical(new Complex(4, 0), 3);

            Console.WriteLine(c.Mod);
            Console.WriteLine("----------------------");
            for (int i = 0; i < c.Arguments.Count; i++)
            {        
                Console.WriteLine(c.Arguments[i]);
            }
            Console.WriteLine("----------------------");
            for (int i = 0; i < c.Results.Count; i++)
            {
                Console.WriteLine(c.Results[i]);
            }
            Console.ReadKey();
        }
    }
}
