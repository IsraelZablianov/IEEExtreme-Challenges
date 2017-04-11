using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysBeInControl
{
    class Program
    {
        private const string InControl = "In Control";
        private const string OutOfControl = "Out of Control";
        private const int defaultSuccessiveValue = 0;

        private static List<int> points;
        private static Dictionary<int, double> sizeOfGroups = new Dictionary<int, double>(9);
        private static double UCL;
        private static double LCL;
        private static double CL;
        private static double A2;
        private static double sigma;

        static void Main(string[] args)
        {
            Init();
            var tests = long.Parse(Console.ReadLine());
            var answers = new List<string>(20);

            for (int i = 0; i < tests; i++)
            {
                answers.Add(SingleTest());
            }

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        private static void Init()
        {
            sizeOfGroups.Add(2, 1.880);
            sizeOfGroups.Add(3, 1.023);
            sizeOfGroups.Add(4, 0.729);
            sizeOfGroups.Add(5, 0.577);
            sizeOfGroups.Add(6, 0.483);
            sizeOfGroups.Add(7, 0.419);
            sizeOfGroups.Add(8, 0.373);
            sizeOfGroups.Add(9, 0.337);
            sizeOfGroups.Add(10, 0.308);
        }

        public static string SingleTest()
        {
            var input = Console.ReadLine();
            var values = input.Split(' ');
            int sizeOfPoints = int.Parse(values[0]);
            int sizeOfGroup = int.Parse(values[1]);

            points = new List<int>(sizeOfPoints);

            for (int i = 0; i < sizeOfPoints; i++)
            {
                points.Add(int.Parse(values[i + 2]));
            }

            calcControlLimitationValues(sizeOfGroup);

            var isOutOfControl = IsOutOfControl();
            return isOutOfControl ? OutOfControl : InControl;
        }

        private static void calcControlLimitationValues(int sizeOfGroup)
        {
            double subGroupsAvgValue = 0, subGroupsAvgRange = 0;
            var amountOfPoints = points.Count;
            var sizeOfSubGroups = (amountOfPoints / sizeOfGroup) + 1;
            var subGroupValues = new List<double>(sizeOfSubGroups);
            var subGroupRanges = new List<double>(sizeOfSubGroups);

            var size = 0;
            double sum = 0, max = int.MinValue, min = int.MaxValue;
            for (int i = 0; i < amountOfPoints; i++)
            {
                sum += points[i];
                max = Math.Max(points[i], max);
                min = Math.Min(points[i], min);
                size++;
                if (size == sizeOfGroup || i == amountOfPoints - 1)
                {
                    subGroupValues.Add(sum / size);
                    subGroupRanges.Add(max - min);
                    size = 0;
                    sum = 0;
                    max = int.MinValue;
                    min = int.MaxValue;
                }
            }

            subGroupsAvgValue = subGroupValues.Sum() / subGroupValues.Count;
            subGroupsAvgRange = subGroupRanges.Sum() / subGroupRanges.Count;
            setControlLimitationValues(sizeOfGroup, subGroupsAvgValue, subGroupsAvgRange);
        }

        private static void setControlLimitationValues(int sizeOfGroup, double subgroupsAvgValue, double subgroupsAvgRange)
        {
            A2 = sizeOfGroups[sizeOfGroup];
            CL = subgroupsAvgValue;
            var mid = A2 * subgroupsAvgRange;
            UCL = subgroupsAvgValue + mid;
            LCL = subgroupsAvgValue - mid;
            sigma = (UCL - CL) / 3;
        }

        private static bool IsOutOfControl()
        {
            return SinglePointFallsOutside3SigmaControlLimits() 
                || AtLeastTwoOutOfThreeSuccessiveValuesFallOnTheSameSideOfAndMoreThanTwoSigmaUnitsAwayFromTheCenterLine()
                || AtLeastFourOutOfFiveSuccessiveValuesFallOnTheSameSideOfAndMoreThanOneSigmaUnitsAwayFromTheCenterLine()
                || AtLeastEightSuccessiveValuesFallOnTheSameSideOfTheCenterLine();
        }

        private static bool SinglePointFallsOutside3SigmaControlLimits()
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] > UCL || points[i] < LCL)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool AtLeastTwoOutOfThreeSuccessiveValuesFallOnTheSameSideOfAndMoreThanTwoSigmaUnitsAwayFromTheCenterLine()
        {
            return CalcIfInControl(CL + sigma * 2, CL - sigma * 2, 2, 3);
        }

        private static bool AtLeastFourOutOfFiveSuccessiveValuesFallOnTheSameSideOfAndMoreThanOneSigmaUnitsAwayFromTheCenterLine()
        {
            return CalcIfInControl(CL + sigma, CL - sigma, 4, 5);
        }

        private static bool AtLeastEightSuccessiveValuesFallOnTheSameSideOfTheCenterLine()
        {
            return CalcIfInControl(CL, CL, 7, 8);
        }

        private static bool CalcIfInControl(double minAwayValue, double maxAwayValue, int checForMin,int checkUpTo)
        {
            int above = 0, under = 0;

            for (int i = 0; i < points.Count - checForMin; i++)
            {
                above = 0;
                under = 0;
                for (int j = 0; j < checkUpTo; j++)
                {
                    if (points[i + j] > minAwayValue)
                    {
                        above++;
                    }
                    if (points[i + j] < maxAwayValue)
                    {
                        under++;
                    }
                }

                if (above >= checForMin || under >= checForMin)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
