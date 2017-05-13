using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitFun
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            List<string> values = new List<string>(10000);
            while (input != "END")
            {
                input = Console.ReadLine();
                if(input != "END")
                {
                    values.Add(input);
                }
            }

            foreach (var value in values)
            {
                Console.WriteLine(Result(value));
            }
        }

        static int Result(string n)
        {
            var result = 1;
            var sizeOfN = n.Length.ToString();
            if (sizeOfN == n)
            {
                return result;
            }

            for (result = 2; sizeOfN != "1"; result++)
            {
                if (sizeOfN.Length.ToString() != sizeOfN)
                {
                    sizeOfN = sizeOfN.Length.ToString();
                }
            }
            
            return result;
        }
    }
}
