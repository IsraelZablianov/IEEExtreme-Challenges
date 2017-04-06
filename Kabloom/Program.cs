using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabloom
{
    class Program
    {
        private static Dictionary<long, long> cardValues = new Dictionary<long, long>();
        private static Dictionary<string, long> cardInTable = new Dictionary<string, long>();
        private static long joker = -14;
        private static long[,] table;

        public static void Init()
        {
            cardValues[-1] = 40;
            cardValues[-2] = 4;
            cardValues[-3] = 6;
            cardValues[-4] = 8;
            cardValues[-5] = 10;
            cardValues[-6] = 12;
            cardValues[-7] = 14;
            cardValues[-8] = 16;
            cardValues[-9] = 18;
            cardValues[-10] = 20;
            cardValues[-11] = 30;
            cardValues[-12] = 30;
            cardValues[-13] = 30;
            cardValues[-14] = 100;

            cardInTable["A"] = -1;
            cardInTable["2"] = -2;
            cardInTable["3"] = -3;
            cardInTable["4"] = -4;
            cardInTable["5"] = -5;
            cardInTable["6"] = -6;
            cardInTable["7"] = -7;
            cardInTable["8"] = -8;
            cardInTable["9"] = -9;
            cardInTable["T"] = -10;
            cardInTable["J"] = -11;
            cardInTable["Q"] = -12;
            cardInTable["K"] = -13;
            cardInTable["R"] = -14;
        }

        static void Main(string[] args)
        {
            Init();
            var list = new List<string>();
            string n = "";

            do
            {
                n = Console.ReadLine();
                if (n != "0")
                {
                    var result = SingleResult(int.Parse(n));
                    list.Add(result.ToString());
                }

            } while (n != "0");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static long SingleResult(int n)
        {
            string firstRaw = Console.ReadLine();
            string secondRaw = Console.ReadLine();
            table = new long[n + 1, n + 1];

            var firstValues = firstRaw.Split(' ');
            var secondtValues = secondRaw.Split(' ');

            InitTableFirstCols(n, firstValues, secondtValues);

            for (int i = 2; i < n + 1; i++)
            {
                for (int j = 2; j < n + 1; j++)
                {
                    var op1 = CalculateValue(table[i, 0], table[0, j]) + table[i - 1, j - 1];
                    var op2 = table[i - 1, j];
                    var op3 = table[i, j - 1];
                    var max = op2 > op3 ? op2 : op3;
                    max = max > op1 ? max : op1;
                    table[i, j] = max;
                }
            }

            return table[n, n];
        }

        private static void InitTableFirstCols(int n, string[] firstValues, string[] secondtValues)
        {
            for (int i = 0; i < n; i++)
            {
                table[0, i + 1] = cardInTable[firstValues[i]];
            }

            for (int i = 0; i < n; i++)
            {
                table[i + 1, 0] = cardInTable[secondtValues[i]];
            }

            for (int i = 0; i < n; i++)
            {
                var value = CalculateValue(table[1, 0], table[0, i + 1]);
                if (i + 1 > 1)
                {
                    table[1, i + 1] = Math.Max(value, table[1, i]);
                }
                else
                {
                    table[1, i + 1] = value;
                }
            }

            for (int i = 0; i < n; i++)
            {
                var val = CalculateValue(table[0, 1], table[i + 1, 0]);
                if (i + 1 > 1)
                {
                    table[i + 1, 1] = Math.Max(val, table[i, 1]);
                }
                else
                {
                    table[i + 1, 1] = val;
                }
            }
        }

        private static long CalculateValue(long card1, long card2)
        {
            if (card1 != card2)
            {
                if (card1 == joker) return cardValues[card2];
                if (card2 == joker) return cardValues[card1];
                return 0;
            }

            return cardValues[card1];
        }
    }
}
