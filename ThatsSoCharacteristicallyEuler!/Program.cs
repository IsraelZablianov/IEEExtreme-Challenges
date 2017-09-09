using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatsSoCharacteristicallyEuler_
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        static char[,] Image { get; set; }
        static List<List<Point>> regionsBlack;
        static List<List<Point>> regionsWhite;
        static char black = 'X';
        static char white = 'O';
        static char addedToRegion = 'V';

        static void Main(string[] args)
        {
            var test = int.Parse(Console.ReadLine());

            for (int i = 0; i < test; i++)
            {
                regionsBlack = new List<List<Point>>();
                regionsWhite = new List<List<Point>>();
                CreateImage();
                Console.WriteLine(SingleResult());
            }
        }

        static void CreateImage()
        {
            var height = int.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            Image = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < width; j++)
                {
                    Image[i, j] = line[j];
                }
            }
        }

        static List<Point> GetAllNeighboursAndMarkThemAsAdded(Point p, char type, bool checkForDiagonal = true)
        {
            var q = new List<Point>(1000000);
            q.Add(p);
            var height = Image.GetLength(0);
            var width = Image.GetLength(1);
            for (int i = 0; i < q.Count; i++)
            {
                // Right
                if (q[i].X + 1 < width && Image[q[i].Y, q[i].X + 1] == type)
                {
                    q.Add(new Point() {
                        X = q[i].X + 1,
                        Y = q[i].Y
                    });
                    Image[q[i].Y, q[i].X + 1] = addedToRegion;
                }
                // Left
                //if (q[i].X - 1 >= 0 && Image[q[i].X - 1, q[i].Y] == type)
                //{
                //    q.Add(new Point()
                //    {
                //        X = q[i].X - 1,
                //        Y = q[i].Y
                //    });
                //    Image[q[i].X - 1, q[i].Y] = addedToRegion;

                //}
                // Bottom
                if (q[i].Y + 1 < height && Image[q[i].Y + 1, q[i].X] == type)
                {
                    q.Add(new Point()
                    {
                        X = q[i].X,
                        Y = q[i].Y + 1
                    });
                    Image[q[i].Y + 1, q[i].X] = addedToRegion;

                }
                // Top
                //if (q[i].Y - 1 >= 0 && Image[q[i].X, q[i].Y - 1] == type)
                //{
                //    q.Add(new Point()
                //    {
                //        X = q[i].X,
                //        Y = q[i].Y - 1
                //    });
                //    Image[q[i].X, q[i].Y - 1] = addedToRegion;
                //}

                if (checkForDiagonal)
                {
                    // Top Left
                    //if (q[i].Y - 1 >= 0 && q[i].X - 1 >= 0 && Image[q[i].X - 1, q[i].Y - 1] == type)
                    //{
                    //    q.Add(new Point()
                    //    {
                    //        X = q[i].X - 1,
                    //        Y = q[i].Y - 1
                    //    });
                    //    Image[q[i].X - 1, q[i].Y - 1] = addedToRegion;
                    //}

                    // Top Right
                    if (q[i].Y - 1 >= 0 && q[i].X + 1 < width && Image[q[i].Y - 1, q[i].X + 1] == type)
                    {
                        q.Add(new Point()
                        {
                            X = q[i].X + 1,
                            Y = q[i].Y - 1
                        });
                        Image[q[i].Y - 1, q[i].X + 1] = addedToRegion;
                    }

                    // Bottom Right
                    if (q[i].Y + 1 < height && q[i].X + 1 < width && Image[q[i].Y + 1, q[i].X + 1] == type)
                    {
                        q.Add(new Point()
                        {
                            X = q[i].X + 1,
                            Y = q[i].Y + 1
                        });
                        Image[q[i].Y + 1, q[i].X + 1] = addedToRegion;
                    }

                    // Bottom Left
                    //if (q[i].Y + 1 < height && q[i].X - 1 >= 0 && Image[q[i].X - 1, q[i].Y + 1] == type)
                    //{
                    //    q.Add(new Point()
                    //    {
                    //        X = q[i].X - 1,
                    //        Y = q[i].Y + 1
                    //    });
                    //    Image[q[i].X - 1, q[i].Y + 1] = addedToRegion;
                    //}
                }
            }

            return q;
        }

        static int SingleResult()
        {
            var height = Image.GetLength(0);
            var width = Image.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (Image[i, j] == black)
                    {
                        regionsBlack.Add(GetAllNeighboursAndMarkThemAsAdded(new Point()
                        {
                            X = i,
                            Y = j
                        }, black, true));
                    }
                    else if(Image[i, j] == white)
                    {
                        regionsWhite.Add(GetAllNeighboursAndMarkThemAsAdded(new Point()
                        {
                            X = i,
                            Y = j
                        }, white, false));
                    }
                }
            }

            return regionsBlack.Count - (Math.Max(regionsWhite.Count - 1, 0));
        }
    }
}