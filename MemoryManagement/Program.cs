using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = int.Parse(Console.ReadLine());
            var answers = new List<string>();

            for (int i = 0; i < tests; i++)
            {
                answers.Add(SingleTest());
            }

            foreach(var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        public static string SingleTest()
        {
            var input = Console.ReadLine();
            var values = input.Split(' ');
            var ramSize = int.Parse(values[0]);
            var pageSize = int.Parse(values[1]);
            var pagesRequests = int.Parse(values[2]);
            var pages = new List<int>(pagesRequests);

            for (int i = 0; i < pagesRequests; i++)
            {
                pages.Add(int.Parse(Console.ReadLine()));
            }

            return Result(ramSize, pageSize, pagesRequests, pages);
        }

        public static string Result(int ramSize, int pageSize, int pagesRequests, List<int> pages)
        {
            if (ramSize >= pagesRequests || pageSize > pages.Max())
            {
                return $"no {0} {0}"; ;
            }

            var fifo = CalcFIFOReplacments(ramSize, pageSize, pagesRequests, pages.ToList());
            var lru = CalcLRUReplacments(ramSize, pageSize, pagesRequests, pages);

            if (lru < fifo)
            {
                return $"yes {fifo} {lru}";
            }

            return $"no {fifo} {lru}";
        }

        public static int CalcFIFOReplacments(int ramSize, int pageSize, int pagesRequests, List<int> pages)
        {
            var fifoList = new List<int>(ramSize);
            var replaces = 0;

            for (int i = 0; i < pagesRequests; i++)
            {
                var thePage = pages[i] / pageSize;

                if (fifoList.Count < ramSize && !fifoList.Contains(thePage))
                {
                    fifoList.Add(thePage);
                }
                else if (!fifoList.Contains(thePage) && fifoList.Count == ramSize)
                {
                    fifoList.RemoveAt(0);
                    fifoList.Insert(ramSize - 1, thePage);
                    replaces++;
                }
            }

            return replaces;
        }

        public static int CalcLRUReplacments(int ramSize, int pageSize, int pagesRequests, List<int> pages)
        {
            var lruList = new List<int>(ramSize);
            var replaces = 0;

            for (int i = 0; i < pagesRequests; i++)
            {
                var thePage = pages[i] / pageSize;

                if (lruList.Count < ramSize && !lruList.Contains(thePage))
                {
                    lruList.Add(thePage);
                }
                else if(lruList.Contains(thePage))
                {
                    var size = lruList.Count - 1;
                    lruList.Remove(thePage);
                    lruList.Insert(size, thePage);
                }
                else if (!lruList.Contains(thePage) && lruList.Count == ramSize)
                {
                    lruList.RemoveAt(0);
                    lruList.Insert(ramSize - 1, thePage);
                    replaces++;
                }
                else
                {
                    throw new Exception();
                }
            }

            return replaces;
        }
    }
}