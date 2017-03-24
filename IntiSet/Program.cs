using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiSet
{
    class Program
    {
        public static List<long> primes;
        public static long[] participents;
        public static long leftLimit;
        public static long rightLimit;
        public static long intiSet;
        public static long modolo = 1000000007;

        static void Main(string[] args)
        {
            var test = long.Parse(Console.ReadLine());
            long[] results = new long[test];

            for (int i = 0; i < test; i++)
            {
                results[i] = SingleTest() % modolo;
            }

            for (int i = 0; i < test; i++)
            {
                Console.WriteLine(results[i]);
            }

            Console.ReadLine();
        }

        public static long SingleTest()
        {
            string input = Console.ReadLine();
            var values = input.Split(' ');
            if (InitialValues(long.Parse(values[0]), long.Parse(values[1]), long.Parse(values[2])))
            {
                var sum = SumOfArithmeticProgression(leftLimit, rightLimit - leftLimit + 1, 1);
                if (rightLimit == intiSet)
                {
                    return sum - intiSet;
                }
                return sum;
            }
            return Result();
        }

        public static bool InitialValues(long n, long left, long right)
        {
            leftLimit = left;
            rightLimit = right;
            intiSet = n;
            var exit = (intiSet / 2) + 1;
            primes = new List<long>(100);

            for (int i = 2; n > 1 && i <= exit; i++)
            {
                if (n % i == 0)
                {
                    n /= i;
                    primes.Add(i);
                    exit = intiSet / primes.Last();
                    while (n % i == 0 && n > 1)
                    {
                        n /= i;
                    }
                }
            }

            long sizeOfPrimes = primes.Count;

            if (sizeOfPrimes <= 1)
            {
                return true;
            }

            participents = new long[sizeOfPrimes];
            participents[0] = 1;
            for (int i = 1; i < sizeOfPrimes; i++)
            {
                participents[i] = participents[i - 1] * 2;
            }

            return false;
        }

        public static long SumOfArithmeticProgression(long a1, long n, long d)
        {
            var sum = ((2 * a1) + d * (n - 1)) % modolo;
            n = n % modolo;
            if (sum % 2 == 0)
            {
                sum /= 2;
            }
            else
            {
                n /= 2;
            }
            return (sum * n) % modolo;
        }

        public static long CalcSum(long prime)
        {
            var mid = (long)Math.Ceiling(leftLimit / (double)prime);
            var firstApearnce = (prime * mid) % modolo;
            var amount = ((rightLimit / prime) - (mid - 1)) % modolo;
            return SumOfArithmeticProgression(firstApearnce, amount, prime);
        }

        public static long Result()
        {
            long sizeOfPrimes = primes.Count;
            long pow = (long)Math.Pow(2, sizeOfPrimes);
            long result = SumOfArithmeticProgression(leftLimit, rightLimit - leftLimit + 1, 1);
            long factor = 1;
            long sign = 1;
            for (long i = 1; i < pow; i++)
            {
                factor = 1;
                sign = 1;
                for (int j = 0; j < sizeOfPrimes; j++)
                {
                    if ((i & participents[j]) != 0)
                    {
                        sign *= -1;
                        factor *= primes[j];

                        if (i == participents[j])
                        {
                            break;
                        }
                    }
                }

                if (factor > 1)
                {
                    result += CalcSum(factor) * sign;
                }
            }

            return result;
        }
    }
}