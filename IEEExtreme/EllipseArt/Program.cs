using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EllipseArt
{
    public class EllipseHandler
    {
        public float x1;
        public float y1;
        public float x2;
        public float y2;
        public float r;

        public bool IsPointInside(float x, float y)
        {
            if (Distance(x1, y1, x, y) + Distance(x2, y2, x, y) < r)
            {
                return true;
            }

            return false;
        }

        public double Distance(float x1, float y1, float x2, float y2)
        {
            float mid1 = x2 - x1, mid2 = y2 - y1;
            return Math.Sqrt((mid1 * mid1) + (mid2 * mid2));
        }
    }

    class Program
    {
        public static EllipseHandler[] EllipseHandler;
        public static float offset = 0.4f;
        public static int border = 50;
        public static float globalSize = 10000;
        public static float concreteSize = globalSize / offset;

        static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            int[] values = new int[tests];
            for (int i = 0; i < tests; i++)
            {
                values[i] = SingleTest();
            }

            for (int i = 0; i < tests; i++)
            {
                Console.WriteLine(values[i] + "%");
            }

            Console.ReadLine();
        }

        public static int SingleTest()
        {
            var n = int.Parse(Console.ReadLine());
            EllipseHandler = new EllipseHandler[n];
            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine().Split(' ');
                EllipseHandler[i] = CreateEllipseHandler(int.Parse(value[0]), int.Parse(value[1]), int.Parse(value[2]), int.Parse(value[3]), int.Parse(value[4]));
            }

            return Result();
        }

        public static int Result()
        {
            double sum = 0;
            for (float i = -border; i < border; i += offset)
            {
                for (float j = -border; j < border; j += offset)
                {
                    foreach (var handler in EllipseHandler)
                    {
                        if (handler.IsPointInside(i, j))
                        {
                            sum++;
                            break;
                        }
                    }
                }
            }

            sum *= offset;
            return (int)Math.Round((1 - (sum / concreteSize)) * 100);
        }

        public static EllipseHandler CreateEllipseHandler(float x1, float y1, float x2, float y2, float r)
        {
            return new EllipseHandler() { x1= x1, y1=y1, x2=x2, y2=y2, r=r };
        }
    }
}
