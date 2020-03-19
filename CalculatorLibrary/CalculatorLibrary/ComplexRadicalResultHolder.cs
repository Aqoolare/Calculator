using System.Numerics;
using System.Collections.Generic;

namespace CalculatorLibrary
{
    public class ComplexDegreeResultHolder
    {
        public double Mod { get; set; }
        public List<string> Arguments { get; set; }
        public List<Complex> Results { get; set; }

        public ComplexDegreeResultHolder()
        {
            Mod = 0;
            Arguments = new List<string>();
            Results = new List<Complex>();
        }

        public ComplexDegreeResultHolder(int mod, List<string> arguments, List<Complex> results)
        {
            Mod = mod;
            Arguments = arguments;
            Results = results;
        }
    }
}
