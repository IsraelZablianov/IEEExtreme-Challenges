using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerGames
{
    class Program
    {
        private static ulong powOf63 = 9223372036854775808;

        static void Main(string[] args)
        {
            var tests = ulong.Parse(Console.ReadLine());
            var answers = new List<string>(100);

            for (ulong i = 0; i < tests; i++)
            {
                answers.Add(SingleTest().ToString());
            }

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        public static ulong FindClosestPowOfTwo(ulong amountOfPetals)
        {
            ulong closestPowOfTwo = 1;

            while (closestPowOfTwo <= amountOfPetals)
            {
                closestPowOfTwo *= 2;
            }

            return closestPowOfTwo / 2;
        }

        public static ulong SingleTest()
        {
            ulong amountOfPetals = ulong.Parse(Console.ReadLine());

            if (powOf63 == amountOfPetals)
            {
                return 1;
            }

            ulong startCountFrom = FindClosestPowOfTwo(amountOfPetals);
            ulong endPosition = 1 + (amountOfPetals - startCountFrom) * 2;

            return endPosition;
        }
    }
}
