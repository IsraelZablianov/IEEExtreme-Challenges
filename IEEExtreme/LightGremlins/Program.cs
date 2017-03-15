using System;
using System.Collections.Generic;

namespace LightGremlins
{
    class Program
    {
        public static long[] participents = new long[24];

        static void Main(string[] args)
        {
            participents[0] = 1;
            for (int i = 1; i < 24; i++)
            {
                participents[i] = participents[i - 1] * 2;
            }

            int tests = int.Parse(Console.ReadLine());
            long[] results = new long[tests];

            for (int i = 0; i < tests; i++)
            {
                results[i] = SingleTest();
            }

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i]);
            }
        }

        public static long SingleTest()
        {
            var input = Console.ReadLine();
            var values = input.Split(' ');
            ulong[] gremlins = new ulong[int.Parse(values[1])];

            for (int i = 2; i < values.Length; i++)
            {
                gremlins[i - 2] = ulong.Parse(values[i]);
            }

            return Result(gremlins, ulong.Parse(values[0]));
        }

        public static long Result(ulong[] gremlins, ulong switches)
        {
            long pow = (long)Math.Pow(2, gremlins.Length);
            long result = 0;
            int j;
            long i;
            ulong minProblem = 10000000000;
            for (i = 1; i <= pow; i++)
            {
                int sign = -1;
                ulong factor = 1;
                long cofficent = 0;
                for (j = 0; j < gremlins.Length; j++)
                {
                    if ((i & participents[j]) != 0)
                    {
                        if ((gremlins[j] > minProblem || factor > minProblem && switches / factor < gremlins[j]))
                        {
                            cofficent = 0;
                            break;
                        }
                        factor *= gremlins[j];
                        sign *= -1;
                        cofficent = cofficent == 0 ? 1 : cofficent * 2;
                    }
                }

                result += cofficent == 0 ? 0 : cofficent * (long)(switches / factor) * sign;
            }

            return result;
        }
    }
}