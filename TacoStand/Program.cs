using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoStand
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = int.Parse(Console.ReadLine());
            List<long> list = new List<long>(tests);

            for (long i = 0; i < tests; i++)
            {
                var input = Console.ReadLine();
                var values = input.Split(' ');
                list.Add(SingleResult(
                    long.Parse(values[0]),
                    long.Parse(values[1]),
                    long.Parse(values[2]),
                    long.Parse(values[3])));
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static long SingleResult(long s, long m, long r, long b)
        {
            long max1 = Math.Max(m, Math.Max(r, b));
            long max3 = Math.Min(m, Math.Min(r, b));
            long max2 = r + b + m - max1 - max3;
            return Result( s, max1, max2, max3);
        }

        static long Result(long s, long max1, long max2, long max3)
        {
            if (max1 > max2 + max3)
            {
                return Math.Min(max2 + max3, s);
            }
            else
            {
                return Math.Min(s, (max1 + max2 + max3) / 2);
            }
        }
    }
}