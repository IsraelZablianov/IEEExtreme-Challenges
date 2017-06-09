using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSquare1
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = -1;
            while (num != 0)
            {
                num = double.Parse(Console.ReadLine());
                if (num == 0)
                {
                    Environment.Exit(0);
                }
                else if (num == 1)
                {
                    Console.WriteLine(1);
                }
                else
                {
                    List<double> propabilities = GetPropabilities();
                    Console.WriteLine(SingleResult(propabilities));
                }
            }
        }

        private static List<double> GetPropabilities()
        {
            var input = Console.ReadLine();
            string[] values = input.Split(' ');
            List<double> propabilities = new List<double>(values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                try
                {
                    propabilities.Add(double.Parse(values[i]));
                }
                catch (Exception)
                {
                    //propabilities.Add(int.Parse(values[i]));
                    //Console.WriteLine(0);
                }
            }

            return propabilities;
        }

        static int SingleResult(List<double> propabilities)
        {
            double temp = 1;
            double result = 1;
            for (int i = propabilities.Count; i > 0; i--)
            {
                try
                {
                    temp *= (1 / propabilities[i - 1]);
                }
                catch (Exception)
                {
                    return 0;
                }

                result += temp;
            }

            return (int)Math.Round(result);
        }
    }
}
