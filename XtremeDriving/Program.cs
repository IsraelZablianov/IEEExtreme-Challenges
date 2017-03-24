using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtremeDriving
{
    public class CowPlace
    {
        public long col;
        public long row;
    }

    class Program
    {
        public static long rows = 4;
        public static long[,] highway = new long[rows, 2];
        public static long modolo = 1000000007;
        public static long highwayLength;
        public static long cow = -1;
        public static int amountOfCows;
        public static List<CowPlace> cows = new List<CowPlace>(100);

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(' ');

            highwayLength = long.Parse(values[0]);
            amountOfCows = int.Parse(values[1]);

            string inputCow;
            string[] valuesCow;
            long row;
            long col;

            for (int i = 0; i < amountOfCows; i++)
            {
                inputCow = Console.ReadLine();
                valuesCow = inputCow.Split(' ');
                row = long.Parse(valuesCow[0]);
                col = long.Parse(valuesCow[1]);
                cows.Add(new CowPlace() {row = row, col = col });
            }

            cows.Sort((cow1, cow2)=> { return cow1.col > cow2.col ? 1 : cow1.col < cow2.col ? -1 : 0; });
            Console.WriteLine(Result());
        }

        public static long Result()
        {
            highway[0, 0] = 1;
            long one;
            long two;
            long three;

            if (CheckIfZero())
            {
                return 0;
            }

            for (int i = 1; i < highwayLength; i++)
            {
                SetCows(i);
                for (int j = 0; j < rows; j++)
                {
                    one = (j > 0 && (highway[j - 1, 0]) != cow ? highway[j - 1, 0] : 0) % modolo;
                    two = (highway[j, 0] != cow ? highway[j, 0] : 0) % modolo;
                    three = ((j + 1 < rows) && (highway[j + 1, 0]) != cow ? highway[j + 1, 0] : 0) % modolo;
                    highway[j, 1] = highway[j, 1] != cow ? (((one + two) % modolo) + three) % modolo : cow;
                }
                ResetHighway();
            }

            return highway[0, 0];
        }

        public static void ResetHighway()
        {
            highway[0, 0] = highway[0, 1];
            highway[1, 0] = highway[1, 1];
            highway[2, 0] = highway[2, 1];
            highway[3, 0] = highway[3, 1];
            highway[0, 1] = 0;
            highway[1, 1] = 0;
            highway[2, 1] = 0;
            highway[3, 1] = 0;
        }

        private static void SetCows(long col)
        {
            while(amountOfCows > 0 && cows[0].col - 1 == col)
            {
                highway[cows[0].row - 1, 1] = cow;
                cows.RemoveAt(0);
                amountOfCows--;
            }
        }

        public static bool CheckIfZero()
        {
            int blockEnd = 0;
            int blockBeforeEnd = 0;
            long prevCol = amountOfCows > 0 ? cows[0].col : 0;
            int block = 0;

            int blockSteps3 = 0;
            int blockSteps2 = 0;
            long prevColSteps = prevCol;
            long lastRow = amountOfCows > 0 ? cows[0].row : 0;


            for (int i = 0; i < amountOfCows; i++)
            {
                if (cows[i].col == highwayLength - 1 && (cows[i].row == 0 || cows[i].row == 1))
                {
                    blockEnd++;
                }

                if (cows[i].col == highwayLength - 2 && (cows[i].row == 0 || cows[i].row == 1 || cows[i].row == 2))
                {
                    blockBeforeEnd++;
                }

                if (cows[i].col == prevColSteps && cows[i].row == lastRow)
                {
                    blockSteps2++;
                    blockSteps3++;
                    lastRow++;
                }
                else if(cows[i].col == prevColSteps + 1 && cows[i].row >= lastRow - 1)
                {
                    blockSteps3++;
                    blockSteps2++;
                    lastRow++;
                }
                else
                {
                    prevColSteps = cows[i].col;
                    lastRow = cows[i].row;
                    blockSteps3 = 1;
                    blockSteps2 = 1; 
                }

                if (cows[i].col == prevCol)
                {
                    block++;
                }
                else
                {
                    prevCol = cows[i].col;
                    block = 0;
                }
            }

            if (blockEnd == 2 || block == 4 || blockBeforeEnd == 3 || blockSteps3 + blockSteps2 >= 10)
            {
                return true;
            }

            return false;
        }
    }
}
