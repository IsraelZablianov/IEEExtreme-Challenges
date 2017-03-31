using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfStones
{
    class Program
    {
        public static string Alice = "Alice";
        public static string Bob = "Bob";

        static void Main(string[] args)
        {
            var tests = long.Parse(Console.ReadLine());
            var answers = new List<string>(100);

            for (int i = 0; i < tests; i++)
            {
                answers.Add(SingleTest());
            }

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        public static string SingleTest()
        {
            long amountOfGames = long.Parse(Console.ReadLine());
            long amountOfSplitPossible = 0;

            for (int i = 0; i < amountOfGames; i++)
            {
                long amountOfPiles = long.Parse(Console.ReadLine());
                string inputAmountInPiles = Console.ReadLine();
                string[] values = inputAmountInPiles.Split(' ');

                for (int j = 0; j < amountOfPiles; j++)
                {
                    amountOfSplitPossible += long.Parse(values[j]) / 2;
                }
            }

            if (amountOfSplitPossible % 2 == 0)
            {
                return Bob;
            }

            return Alice;
        }
    }
}
