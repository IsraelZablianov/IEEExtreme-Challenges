using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety
{
    class Program
    {
        private static StringBuilder password;
        private static string N = "N";
        private static string Y = "Y";
        private static Dictionary<char, char> dictionary = new Dictionary<char, char>(26);
        private static Dictionary<string, Action<int, int, int>> mapMethods = new Dictionary<string, Action<int, int, int>>(3);
        private static List<string> results;

        static void Main(string[] args)
        {
            init();
            password = new StringBuilder(Console.ReadLine());

            var tests = int.Parse(Console.ReadLine());
            results = new List<string>(tests);

            for (int i = 0; i < tests; i++)
            {
                string input = Console.ReadLine();
                string[] values = input.Split(' ');
                mapMethods[values[0]](int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[values.Length - 1]));
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        private static void init()
        {
            dictionary['a'] = 'b';
            dictionary['b'] = 'c';
            dictionary['c'] = 'd';
            dictionary['d'] = 'e';
            dictionary['e'] = 'f';
            dictionary['f'] = 'g';
            dictionary['g'] = 'h';
            dictionary['h'] = 'i';
            dictionary['i'] = 'j';
            dictionary['j'] = 'k';
            dictionary['k'] = 'l';
            dictionary['l'] = 'm';
            dictionary['m'] = 'n';
            dictionary['n'] = 'o';
            dictionary['o'] = 'p';
            dictionary['p'] = 'q';
            dictionary['q'] = 'r';
            dictionary['r'] = 's';
            dictionary['s'] = 't';
            dictionary['t'] = 'u';
            dictionary['u'] = 'v';
            dictionary['v'] = 'w';
            dictionary['w'] = 'x';
            dictionary['x'] = 'y';
            dictionary['y'] = 'z';
            dictionary['z'] = 'a';

            mapMethods["1"] = (i, j, k) => {
                results.Add(Action1(i, j, k));
            };
            mapMethods["2"] = (i, j, k) => {
                Action2(i, j, k);
            };
            mapMethods["3"] = (i, j, k) => {
                Action3(i, j, k);
            };
        }

        static string Action1(int i, int j, int k)
        {
            if (i == k)
            {
                return Y;
            }

            var length = j - i + 1;
            for (int x = 0; x < length; x++)
            {
                if (password[i - 1 + x] != password[k - 1 + x])
                {
                    return N;
                }
            }

            return Y;
        }

        static void Action2(int i, int j, int k)
        {
            if(i != k)
            {
                var length = j - i + 1;
                string sub = password.ToString(k - 1, length);
                password.Remove(i - 1, length).Insert(i - 1, sub);
            }
        }

        static void Action3(int i0, int j, int k)
        {
            var start = i0 - 1;
            var end = j - i0 + 1;
            for (int i = 0; i < end; i++)
            {
                password[start + i] = dictionary[password[start + i]];
            }
        }
    }
}
