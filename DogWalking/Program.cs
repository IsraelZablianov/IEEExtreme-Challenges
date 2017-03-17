using System;
using System.Collections.Generic;
using System.Linq;

namespace DogWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            long tests = long.Parse(Console.ReadLine());
            List<long> results = new List<long>();

            for (int i = 0; i < tests; i++)
            {
                SingleTest(results);
            }

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine(results[i]); 
            }
        }

        private static void SingleTest(List<long> results)
        {
            string dogsAndWalkersStr = Console.ReadLine();
            string[] dogsAndWalkers = dogsAndWalkersStr.Split(' ');
            List<long> dogsValue = new List<long>(int.Parse(dogsAndWalkers[0]));
            long dogWalkers = long.Parse(dogsAndWalkers[1]);
            for (int i = 0; i < int.Parse(dogsAndWalkers[0]); i++)
            {
                dogsValue.Add(long.Parse(Console.ReadLine()));
            }
            results.Add(Result(dogsValue, dogWalkers));
        }

        public static long Result(List<long> dogsValue, long dogWalkers)
        {
            if (dogsValue.Count <= 1)
            {
                return 0;
            }

            if (dogsValue.Count < dogWalkers)
            {
                return 0;
            }

            dogsValue.Sort();
            dogsValue.Reverse();
            long max = dogsValue.First() - dogsValue.Last();
            List<long> differences = new List<long>();

            for (int i = 0; i + 1 < dogsValue.Count; i++)
            {
                differences.Add(dogsValue[i] - dogsValue[i + 1]);
            }

            differences.Sort();
            long sum = 0;

            for (int i = 0; i < dogsValue.Count - dogWalkers; i++)
            {
                sum += differences[i];
            }

            return sum;
        }
    }
}
