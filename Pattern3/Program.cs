using System;

namespace Pattern3
{
    class Program
    {
        static int[] patternRepeatedCounts = new int[10000001];

        static void Main(string[] args)
        {
            //Reminded me KMP alg
            int i = int.Parse(Console.ReadLine());
            for (; i > 0; i--)
            {
                var input = Console.ReadLine();
                for (int j = 1; j < input.Length; j++)
                {
                    int maxPatternRepeatedCount = patternRepeatedCounts[j];
                    while (maxPatternRepeatedCount != 0 && input[j] != input[maxPatternRepeatedCount])
                    {
                        maxPatternRepeatedCount = patternRepeatedCounts[maxPatternRepeatedCount];
                    }
                    patternRepeatedCounts[j + 1] = (input[j] == input[maxPatternRepeatedCount]) ? maxPatternRepeatedCount + 1 : 0;
                }
                Console.WriteLine(input.Length - patternRepeatedCounts[input.Length]);
            }
        }
    }
}
