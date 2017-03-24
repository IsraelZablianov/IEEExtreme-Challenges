using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck
{
    class Information
    {
        public DateTime time;
        public double lat;
        public double lon;
        public long phoneNumber;
        public double dist;
    }

    class Program
    {
        public static double r = 6378.137;
        public static IFormatProvider culture = new CultureInfo("en-US", true);
        public static string format = "MM/dd/yyyy HH:mm";
        public static double lat1;
        public static double lon1;
        public static double desiredRadius;
        public static int maxFileData = 5000000;
        public static List<Information> fileData = new List<Information>(maxFileData);
        public static double pi = 3.1415926;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(',');
            desiredRadius = double.Parse(Console.ReadLine());
            lat1 = double.Parse(values[0]);
            lon1 = double.Parse(values[1]);
            lat1 = lat1 * pi / 180;
            lon1 = lon1 * pi / 180;

            ReadSubscribersData();
            var size = fileData.Count;
            var printComma = false;
            fileData.Sort((a, b) => { return a.phoneNumber > b.phoneNumber ? 1 : a.phoneNumber < b.phoneNumber ? -1 : 0; });
            if (size == 0)
            {
                throw new Exception("Fuck Off");
            }
            for (int i = 0; i < size; i++)
            {
                if (printComma)
                {
                    Console.Write(",");
                }

                printComma = true;
                Console.Write(fileData[i].phoneNumber);
            }
        }

        public static double CalcDistance(double lat, double lon)
        {
            lat = lat * pi / 180;
            lon = lon * pi / 180;
            var sinLat = Math.Sin((lat - lat1) / 2);
            var sinLon = Math.Sin((lon - lon1) / 2);
            return 2 * r * Math.Asin(Math.Sqrt(Math.Pow(sinLat, 2) + Math.Cos(lat1) * Math.Cos(lat) * Math.Pow(sinLon, 2)));
        }

        public static void ReadSubscribersData()
        {
            Console.ReadLine();
            string input;
            string[] values;
            while (!string.IsNullOrEmpty((input = Console.ReadLine())))
            {
                values = input.Split(',');
                var lat = double.Parse(values[1]);
                var lon = double.Parse(values[2]);
                var dist = CalcDistance(lat, lon);
                var time = DateTime.ParseExact(values[0], format, culture);
                var phoneNumber = long.Parse(values[3]);

                if (dist <= desiredRadius)
                {
                    var info = fileData.Find(item => item.phoneNumber == phoneNumber);
                    if (info == null)
                    {
                        fileData.Add(new Information() { time = time, lat = lat, lon = lon, phoneNumber = phoneNumber, dist = dist });
                    }
                    else if (info.time <= time)
                    {
                        fileData.Remove(info);
                        fileData.Add(new Information() { time = time, lat = lat, lon = lon, phoneNumber = phoneNumber, dist = dist });
                    }
                }
            }
        }
    }
}
