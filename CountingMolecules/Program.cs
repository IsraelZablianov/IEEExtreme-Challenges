using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingMolecules
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(' ');
            Console.WriteLine(Test(double.Parse(values[0]), double.Parse(values[1]), double.Parse(values[2])));
        }

        public static string Test(double C, double H, double O)
        {
            double water = 0, carbon = 0, glucose = 0;

            carbon = ((2 * O) - H) / 4;
            glucose = (C - (((2 * O) - H) / 4)) / 6;
            water = O - C - ((2 * O) - H) / 4;

            if(water == (long)water && glucose == (long)glucose && carbon == (long)carbon)
            {
                return $"{water} {carbon} {glucose}";
            }

            return "Error";
        }
    }
}
