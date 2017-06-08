using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomIn
{
    class Program
    {
        private static Dictionary<char, Dictionary<int, string>> map;
        private static int col;
        private static int row;

        static void Main(string[] args)
        {
            col = int.Parse(Console.ReadLine());
            row = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            map = new Dictionary<char, Dictionary<int, string>>(size);

            for (int i = 0; i < size; i++)
            {
                var letter = char.Parse(Console.ReadLine());
                map.Add(letter, new Dictionary<int, string>(row));
                for (int j = 0; j < row; j++)
                {
                    map[letter].Add(j, Console.ReadLine());
                }
            }

            int numberOfRows = int.Parse(Console.ReadLine());
            for (int k = 0; k < numberOfRows; k++)
            {
                Console.WriteLine(ZoomIn(Console.ReadLine(), row));
            }
        }

        static string ZoomIn(string word, int rowSize)
        {
            StringBuilder str = new StringBuilder();
            char[] wordArr = word.ToCharArray();
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < wordArr.Length; j++)
                {
                    str.Append(map[wordArr[j]][i]);
                }

                if(i != rowSize - 1)
                {
                    str.Append(Environment.NewLine);
                }
            }


            return str.ToString();
        }
    }
}
