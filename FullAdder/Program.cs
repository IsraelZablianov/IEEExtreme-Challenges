using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder
{
    class Program
    {
        private static Dictionary<char, int> baseTranslationFromChar = new Dictionary<char, int>(63);
        private static Dictionary<int, char> baseTranslationFromInt = new Dictionary<int, char>(63);

        static void Main(string[] args)
        {
            var baseStr = Console.ReadLine();
            var firstValueStr = Console.ReadLine();
            var secondValueStr = Console.ReadLine();
            var lines = Console.ReadLine();
            var stam = Console.ReadLine();

            var baseStrValues = baseStr.Split(' ');
            var baseSize = int.Parse(baseStrValues[0]);
            var charOfBaseArray = baseStrValues[1].ToCharArray();
            for (int i = 0; i < baseSize; i++)
            {
                baseTranslationFromChar.Add(charOfBaseArray[i], i);
                baseTranslationFromInt.Add(i, charOfBaseArray[i]);
            }

            var secondFixedValueStr = secondValueStr.Replace("+", "");

            var sum = ClacSum(firstValueStr.Trim(), secondFixedValueStr.Trim(), baseSize);
            Console.WriteLine(baseStr);
            Console.WriteLine(firstValueStr);
            Console.WriteLine(secondValueStr);
            Console.WriteLine(lines);
            sum = sum.PadLeft(lines.Length, ' ');
            Console.WriteLine(sum);

        }

        static string ClacSum(string s1, string s2, int baseSize)
        {
            var carry = 0;
            var result = new StringBuilder();
            var maxSize = Math.Max(s1.Length, s2.Length);
            var pad = baseTranslationFromInt[0];
            s1 = s1.PadLeft(maxSize, pad);
            s2 = s2.PadLeft(maxSize, pad);
            var size = s1.Length - 1;

            for (int i = size; i >= 0; i--)
            {
                var sum = baseTranslationFromChar[s1[i]] + baseTranslationFromChar[s2[i]] + carry;
                carry = sum >= baseSize ? 1 : 0;
                result.Append(baseTranslationFromInt[sum % baseSize]);
            }

            char[] charArray = result.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}