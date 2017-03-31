using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPalindromes
{
    class Program
    {
        public static long modulo = 1000000007;
        static void Main(string[] args)
        {
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

        private static long SingleTest()
        {
            var input = Console.ReadLine();
            var values = input.Split(' ');
            long replacesRequierd = long.Parse(values[0]);
            long totalUnmatched = FindUnmatched(values[1]);
            var isEven = values[1].Length % 2 == 0;
            double sum = 0;

            var oneReplaces = totalUnmatched;
            while ((replacesRequierd - oneReplaces) * 2 - oneReplaces <= replacesRequierd || totalUnmatched == 0)
            {
                if ((replacesRequierd - oneReplaces) % 2 == 0)
                {
                    var remainOfN = replacesRequierd - oneReplaces;
                    var remainOfR = totalUnmatched - oneReplaces;
                    sum += ((((Combination(totalUnmatched, oneReplaces) % modulo)
                    * Math.Pow(2, oneReplaces) % modulo)
                    * Math.Pow(24, remainOfR) % modulo)
                    * (Math.Pow(25, (remainOfN / 2) - remainOfR)) % modulo) % modulo;
                }
                else if (!isEven || totalUnmatched == 0)
                {
                    var remainOfN = replacesRequierd - oneReplaces - 1;
                    var remainOfR = totalUnmatched - oneReplaces;
                    if (remainOfN > remainOfR || remainOfN >= 0 && remainOfR == 0)
                    {
                        sum += ((((Combination(totalUnmatched, oneReplaces) % modulo)
                        * Math.Pow(2, oneReplaces) % modulo)
                        * Math.Pow(24, remainOfR) % modulo)
                        * (Math.Pow(25, (remainOfN / 2) - remainOfR) * 25) % modulo) % modulo;
                    }
                }

                oneReplaces--;
            }

            return (long)sum % modulo;
        }

        public static long Combination(long n, long k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log10(n - i);
                sum -= Math.Log10(i + 1);
            }

            return (long)Math.Pow(10, sum);
        }

        private static long FindUnmatched(string word)
        {
            int sum = 0;
            int length = word.Length;
            int halfLength = length / 2;

            for (int i = 0; i < halfLength; i++)
            {
                if (word[i] != word[length - i - 1])
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}