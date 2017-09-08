using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSpark
{
    class CarRentDetails
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int value { get; set; }
    }

    class Program
    {
        public static List<CarRentDetails> carRentDetails { get; set; }

        static void Main(string[] args)
        {
            var test = int.Parse(Console.ReadLine());

            for (int i = 0; i < test; i++)
            {
                var inputSize = int.Parse(Console.ReadLine());
                carRentDetails = new List<CarRentDetails>(inputSize);
                for (int j = 0; j < inputSize; j++)
                {
                    AddCarDetails(Console.ReadLine());
                }

                CalcResult();
            }
        }

        static void CalcResult()
        {
            Dictionary<int, int> timesIntervalValues = new Dictionary<int, int>(50);
            for (int i = 0; i < 50; i++)
            {
                timesIntervalValues[i] = 0;
            }
            carRentDetails.Sort((car1, car2) => {
                var compareVal = car1.EndTime.CompareTo(car2.EndTime);
                if (compareVal == 0)
                {
                    return car1.StartTime.CompareTo(car2.StartTime);

                }
                return compareVal;
            });

            for (int i = 0; i < carRentDetails.Count; i++)
            {
                for (int j = carRentDetails[i].StartTime; j >= 0; j--)
                {
                    timesIntervalValues[carRentDetails[i].EndTime] = 
                        Math.Max(timesIntervalValues[carRentDetails[i].EndTime], timesIntervalValues[j] + carRentDetails[i].value);
                }
            }
    
            int ans = 0;
            for (int i = 0; i < 50; i++)
            {
                ans = Math.Max(ans, timesIntervalValues[i]);
            }

            Console.WriteLine(ans);
        }

        static void AddCarDetails(string input)
        {
            var values = input.Split(' ');
            carRentDetails.Add(new CarRentDetails()
            {
                StartTime = int.Parse(values[0]),
                EndTime = int.Parse(values[1]),
                value = int.Parse(values[2])
            });
        }
    }
}
