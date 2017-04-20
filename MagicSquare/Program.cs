using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine();
            int squareSize = int.Parse(size);
            int[,] square = new int[squareSize, squareSize];
            SetSquare(square);
            var result = ClacMagicResult(square);

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void SetSquare(int[,] square)
        {
            var size = square.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                var input = Console.ReadLine();
                var values = input.Split(' ');
                for (int j = 0; j < size; j++)
                {
                    square[i,j] = int.Parse(values[j]);
                }
            }
        }

        private static List<int> ClacMagicResult(int[,] square)
        {
            List<int> result = new List<int>();
            long desiredNumber = GetMainDiagonalSum(square);
            int colSize = square.GetLength(1);
            int rowSize = square.GetLength(0);

            for (int i = colSize - 1; i >= 0; i--)
            {
                var sumCol = GetColSum(i, square);
                if(sumCol != desiredNumber)
                {
                    result.Add(((i + 1) * -1));
                }
            }

            var sumAnti = GetAntiDiagonalSum(square);
            if (sumAnti != desiredNumber)
            {
                result.Add(0);
            }

            for (int i = 0; i < rowSize; i++)
            {
                var sumRow = GetRowSum(i, square);
                if (sumRow != desiredNumber)
                {
                    result.Add((i + 1));
                }
            }

            return result;
        }

        private static long GetMainDiagonalSum(int[,] square)
        {
            long sum = 0;
            var length = square.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                sum += square[i, i];
            }

            return sum;
        }

        private static long GetAntiDiagonalSum(int[,] square)
        {
            long sum = 0;
            var length = square.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                sum += square[i, length - i - 1];
            }

            return sum;
        }

        private static long GetColSum(int col, int[,] square)
        {
            long sum = 0;
            var length = square.GetLength(1);

            for (int i = 0; i < length; i++)
            {
                sum += square[i, col];
            }

            return sum;
        }

        private static long GetRowSum(int row, int[,] square)
        {
            long sum = 0;
            var length = square.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                sum += square[row, i];
            }

            return sum;
        }
    }
}
