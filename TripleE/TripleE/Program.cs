using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleE
{
    public static class Extensions
    { 
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        public static long InnerMmultiplication(this IEnumerable<long> elements)
        {
            long mul = elements.Any() ? 1 : 0;
            foreach(var item in elements)
            {
                mul *= item;
            }

            return mul;
        }
    }

    class Program
    {
        private static Dictionary<int, Func<long, long[], long>> fastSummon = new Dictionary<int, Func<long, long[], long>>();
        private static List<string> answers = new List<string>();

        static void Main(string[] args)
        {
            init();

            var amountOfTest = int.Parse(Console.ReadLine());

            for(int i = 0; i < amountOfTest; i++)
            {

                runSingleTest(Console.ReadLine());
            }

            answers.ForEach((value) => Console.WriteLine(value));
            Console.ReadLine();
        }

        private static void runSingleTest(string input)
        {
            string[] values = input.Split(' ');
            long switches = long.Parse(values[0]);
            var gremlins = new List<long>();

            for (int i = 2; i < values.Length; i++)
            {
                gremlins.Add(long.Parse(values[i]));
            }

            answers.Add(fastSummon[gremlins.Count](switches, gremlins.ToArray()).ToString());
        }

        public static long reminder(long attacment,long switches, long[] gremlins)
        {
            return attacment * (switches / gremlins.InnerMmultiplication());
        }

        public static long duplications(long dup, long switches, long[] gremlins)
        {
            return dup * gremlins.Sum((value) => switches / value);
        }

        private static void init()
        {
            fastSummon.Add(1, Solution1);
            fastSummon.Add(2, Solution2);
            fastSummon.Add(3, Solution3);
            fastSummon.Add(4, Solution4);
            fastSummon.Add(5, Solution5);
            fastSummon.Add(6, Solution6);
            fastSummon.Add(7, Solution7);
            fastSummon.Add(8, Solution8);
            fastSummon.Add(9, Solution9);
            fastSummon.Add(10, Solution10);
            fastSummon.Add(11, Solution11);
            fastSummon.Add(12, Solution12);
            fastSummon.Add(13, Solution13);
            fastSummon.Add(14, Solution14);
            fastSummon.Add(15, Solution15);
            fastSummon.Add(16, Solution16);
            fastSummon.Add(17, Solution17);
            fastSummon.Add(18, Solution18);
            fastSummon.Add(19, Solution19);
            fastSummon.Add(20, Solution20);
            fastSummon.Add(21, Solution21);
            fastSummon.Add(22, Solution22);
            fastSummon.Add(23, Solution23);
            fastSummon.Add(24, Solution24);
        }

        public static long Solution1(long switches, long[] gremlins)
        {
            return gremlins.Sum((value)=>switches / value);
        }

        public static long Solution2(long switches, long[] gremlins)
        {
            return Solution1(switches, gremlins) + reminder(-2, switches, gremlins);
        }

        public static long Solution3(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach(var gremlin in gremlins.Combinations(2))
            {
                ans += Solution2(switches, gremlin.ToArray());
            }

            return ans + reminder(4, switches, gremlins) - duplications(1, switches, gremlins);
        }

        public static long Solution4b(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(3))
            {
                ans += Solution3(switches, gremlin.ToArray());
            }

            return ans + reminder(-8, switches, gremlins) - duplications(2, switches, gremlins);
        }

        public static long Solution4(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(3))
            {
                ans += Solution3(switches, gremlin.ToArray());
            }

            return ans + reminder(-8, switches, gremlins) - duplications(2, switches, gremlins);
        }

        public static long Solution5(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(4))
            {
                ans += Solution4(switches, gremlin.ToArray());
            }

            return ans + reminder(16, switches, gremlins) - duplications(3, switches, gremlins);
        }

        public static long Solution6(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(5))
            {
                ans += Solution5(switches, gremlin.ToArray());
            }

            return ans + reminder(-32, switches, gremlins) - duplications(4, switches, gremlins);
        }

        public static long Solution7(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(6))
            {
                ans += Solution6(switches, gremlin.ToArray());
            }

            return ans + reminder(64, switches, gremlins) - duplications(5, switches, gremlins);
        }

        public static long Solution8(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(7))
            {
                ans += Solution7(switches, gremlin.ToArray());
            }

            return ans + reminder(-128, switches, gremlins) - duplications(6, switches, gremlins);
        }

        public static long Solution9(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(8))
            {
                ans += Solution8(switches, gremlin.ToArray());
            }

            return ans + reminder(256, switches, gremlins) - duplications(7, switches, gremlins);
        }

        public static long Solution10(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(9))
            {
                ans += Solution9(switches, gremlin.ToArray());
            }

            return ans + reminder(-512, switches, gremlins) - duplications(8, switches, gremlins);
        }

        public static long Solution11(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(10))
            {
                ans += Solution10(switches, gremlin.ToArray());
            }

            return ans + reminder(1024, switches, gremlins) - duplications(9, switches, gremlins);
        }

        public static long Solution12(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(11))
            {
                ans += Solution11(switches, gremlin.ToArray());
            }

            return ans + reminder(-2048, switches, gremlins) - duplications(10, switches, gremlins);
        }

        public static long Solution13(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(12))
            {
                ans += Solution12(switches, gremlin.ToArray());
            }

            return ans + reminder(4096, switches, gremlins) - duplications(11, switches, gremlins);
        }

        public static long Solution14(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(13))
            {
                ans += Solution13(switches, gremlin.ToArray());
            }

            return ans + reminder(-8192, switches, gremlins) - duplications(12, switches, gremlins);
        }

        public static long Solution15(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(14))
            {
                ans += Solution14(switches, gremlin.ToArray());
            }

            return ans + reminder(16384, switches, gremlins) - duplications(13, switches, gremlins);
        }

        public static long Solution16(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(15))
            {
                ans += Solution15(switches, gremlin.ToArray());
            }

            return ans + reminder(-32768, switches, gremlins) - duplications(14, switches, gremlins);
        }

        public static long Solution17(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(16))
            {
                ans += Solution16(switches, gremlin.ToArray());
            }

            return ans + reminder(65536, switches, gremlins) - duplications(15, switches, gremlins);
        }

        public static long Solution18(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(17))
            {
                ans += Solution17(switches, gremlin.ToArray());
            }

            return ans + reminder(-131072, switches, gremlins) - duplications(16, switches, gremlins);
        }

        public static long Solution19(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(18))
            {
                ans += Solution18(switches, gremlin.ToArray());
            }

            return ans + reminder(262144, switches, gremlins) - duplications(17, switches, gremlins);
        }

        public static long Solution20(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(19))
            {
                ans += Solution19(switches, gremlin.ToArray());
            }

            return ans + reminder(-524288, switches, gremlins) - duplications(18, switches, gremlins);
        }

        public static long Solution21(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(20))
            {
                ans += Solution20(switches, gremlin.ToArray());
            }

            return ans + reminder(1048576, switches, gremlins) - duplications(19, switches, gremlins);
        }

        public static long Solution22(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(21))
            {
                ans += Solution21(switches, gremlin.ToArray());
            }

            return ans + reminder(-2097152, switches, gremlins) - duplications(20, switches, gremlins);
        }

        public static long Solution23(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(22))
            {
                ans += Solution22(switches, gremlin.ToArray());
            }

            return ans + reminder(4194304, switches, gremlins) - duplications(21, switches, gremlins);
        }

        public static long Solution24(long switches, long[] gremlins)
        {
            long ans = 0;
            foreach (var gremlin in gremlins.Combinations(23))
            {
                ans += Solution23(switches, gremlin.ToArray());
            }

            return ans + reminder(-8388608, switches, gremlins) - duplications(22, switches, gremlins);
        }
    }
}
