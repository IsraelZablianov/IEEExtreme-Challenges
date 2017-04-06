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
        public static double trackLat;
        public static double trackLon;
        public static double desiredRadius;
        public static int maxFileData = 5000000;
        public static List<Information> fileData = new List<Information>(maxFileData);
        public static double pi = 3.141592653589;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(',');
            desiredRadius = double.Parse(Console.ReadLine());
            trackLat = ToRadiands(double.Parse(values[0]));
            trackLon = ToRadiands(double.Parse(values[1]));

            ReadSubscribersData();

            var size = fileData.Count;
            fileData.Sort((a, b) => { return a.phoneNumber > b.phoneNumber ? 1 : a.phoneNumber < b.phoneNumber ? -1 : 0; });

            for (int i = 0; i < size; i++)
            {
                if (i > 0)
                {
                    Console.Write(",");
                }

                Console.Write(fileData[i].phoneNumber);
            }
        }

        public static double ToRadiands(double degree)
        {
            double mid = 180;
            return degree * pi / mid;
        }

        public static double CalcDistance(double lat, double lon)
        {
            lat = ToRadiands(lat);
            lon = ToRadiands(lon);
            double two = 2;
            double sinLat = Math.Sin((lat - trackLat) / two);
            double sinLon = Math.Sin((lon - trackLon) / two);
            return two * r * Math.Asin(Math.Sqrt(Math.Pow(sinLat, two) + Math.Cos(trackLat) * Math.Cos(lat) * Math.Pow(sinLon, two)));
        }

        public static void ReadSubscribersData()
        {
            Console.ReadLine();//for the describe raw
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

                var info = fileData.Find(item => item.phoneNumber == phoneNumber);
                if (info == null)
                {
                    if (dist < desiredRadius)
                    {
                        fileData.Add(new Information() { time = time, lat = lat, lon = lon, phoneNumber = phoneNumber, dist = dist });
                    }
                }
                else
                {
                    if (info.time <= time)
                    {
                        fileData.Remove(info);
                        if (dist < desiredRadius)
                        {
                            fileData.Add(new Information() { time = time, lat = lat, lon = lon, phoneNumber = phoneNumber, dist = dist });
                        }
                    }
                }
            }
        }
    }
}
