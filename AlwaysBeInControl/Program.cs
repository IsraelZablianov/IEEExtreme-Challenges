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
            var minAwayValue = CL + sigma * 2;
            var maxAwayValue = CL - sigma * 2;

            for (int i = 0; i < points.Count - 2; i++)
            {
                int countUp = 0, countDown = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (points[i + j] > minAwayValue) countUp++;
                    if (points[i + j] < maxAwayValue) countDown++;
                }
                if (countUp >= 2 || countDown >= 2)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool AtLeastFourOutOfFiveSuccessiveValuesFallOnTheSameSideOfAndMoreThanOneSigmaUnitsAwayFromTheCenterLine()
        {
            var minAwayValue = CL + sigma;
            var maxAwayValue = CL - sigma;
            for (int i = 0; i < points.Count - 4; i++)
            {
                int countUp = 0, countDown = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (points[i + j] > minAwayValue) countUp++;
                    if (points[i + j] < maxAwayValue) countDown++;
                }
                if (countUp >= 4 || countDown >= 4)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool AtLeastEightSuccessiveValuesFallOnTheSameSideOfTheCenterLine()
        {
            for (int i = 0; i < points.Count - 7; i++)
            {
                int countUp = 0, countDown = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (points[i + j] > CL) countUp++;
                    if (points[i + j] < CL) countDown++;
                }
                if (countUp == 8 || countDown == 8)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
