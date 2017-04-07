using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAndBobPlaySheldonsFavoriteGame
{
    class Program
    {
        private static string Bob = "Bob";
        private static string Alice = "Alice";

        static void Main(string[] args)
        {
            var tests = long.Parse(Console.ReadLine());
            var answers = new List<string>(100);

            for (int i = 0; i < tests; i++)
            {
                answers.Add(SingleTest());
            }

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        private static string SingleTest()
        {
            var input = Console.ReadLine();
            string[] values = input.Split(' ');
            long n = long.Parse(values[2]);
            var game = values[1] + " " + values[0];
            var answer = "";

            switch (game)
            {
                case "Rock Rock":// 1
                    {
                        return Handle_Rock_Rock(n);
                    }
                case "Rock Paper":// 2
                    {
                        return Handle_Rock_Paper(n);
                    }
                case "Rock Scissors":// 3
                    {
                        return Handle_Rock_Scissors_Or_Rock_Lizard(n);
                    }
                case "Rock Lizard":// 4
                    {
                        return Handle_Rock_Scissors_Or_Rock_Lizard(n);
                    }
                case "Rock Spock":// 5
                    {
                        return Handle_Rock_Spock_Or_Scissors_Spock(n);
                    }
                case "Paper Rock":// 6
                    {
                        return Handle_Paper_Rock_Or_Paper_Spock_Or_Lizard_Paper_Or_Lizard_Spock(n);
                    }
                case "Paper Paper":// 7
                    {
                        return Handle_Paper_Paper(n);
                    }
                case "Paper Scissors":// 8
                    {
                        return Handle_Paper_Scissors_Or_Lizard_Scissors_Or_Scissors_Rock_Or_Lizard_Rock(n);
                    }
                case "Paper Lizard":// 9
                    {
                        return Handle_Paper_Lizard_Or_Spock_Lizard(n);
                    }
                case "Paper Spock":// 10
                    {
                        return Handle_Paper_Rock_Or_Paper_Spock_Or_Lizard_Paper_Or_Lizard_Spock(n);
                    }
                case "Scissors Rock":// 11
                    {
                        return Handle_Paper_Scissors_Or_Lizard_Scissors_Or_Scissors_Rock_Or_Lizard_Rock(n);
                    }
                case "Scissors Paper":// 12
                    {
                        return Handle_Scissors_Paper_Or_Scissors_Lizard(n);
                    }
                case "Scissors Scissors":// 13
                    {
                        return Handle_Scissors_Scissors(n);
                    }
                case "Scissors Lizard":// 14
                    {
                        return Handle_Scissors_Paper_Or_Scissors_Lizard(n);
                    }
                case "Scissors Spock":// 15
                    {
                        return Handle_Rock_Spock_Or_Scissors_Spock(n);
                    }
                case "Lizard Rock":// 16
                    {
                        return Handle_Paper_Scissors_Or_Lizard_Scissors_Or_Scissors_Rock_Or_Lizard_Rock(n);
                    }
                case "Lizard Paper":// 17
                    {
                        return Handle_Paper_Rock_Or_Paper_Spock_Or_Lizard_Paper_Or_Lizard_Spock(n);
                    }
                case "Lizard Scissors":// 18
                    {
                        return Handle_Paper_Scissors_Or_Lizard_Scissors_Or_Scissors_Rock_Or_Lizard_Rock(n);
                    }
                case "Lizard Lizard":// 19
                    {
                        return Handle_Lizard_Lizard(n);
                    }
                case "Lizard Spock":// 20
                    {
                        return Handle_Paper_Rock_Or_Paper_Spock_Or_Lizard_Paper_Or_Lizard_Spock(n);
                    }
                case "Spock Rock":// 21
                    {
                        return Handle_Spock_Rock_Or_Spock_Scissors(n);
                    }
                case "Spock Paper":// 22
                    {
                        return Handle_Spock_Paper(n);
                    }
                case "Spock Scissors":// 23
                    {
                        return Handle_Spock_Rock_Or_Spock_Scissors(n);
                    }
                case "Spock Lizard":// 24
                    {
                        return Handle_Paper_Lizard_Or_Spock_Lizard(n);
                    }
                case "Spock Spock":// 25
                    {
                        return Handle_Spock_Spock(n);
                    }
            }

            return answer;
        }

        private static string Handle_Spock_Spock(long n)
        {
            if (n == 1)
            {
                return TieMsg(0, 1);
            }
            else if (n == 2)
            {
                return TieMsg(0, 2);
            }
            else if (n == 3)
            {
                return WinnerMessage(Bob, 1, 2);
            }
            else if (n == 4)
            {
                return WinnerMessage(Bob, 2, 2);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 4) / 4;
            long remain = (n - 4) % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours + 2;
            bobWins = numberOfFours * 2;
            bobWins += 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Spock_Paper(long n)
        {
            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = n / 4;
            long remain = n % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours;
            bobWins = numberOfFours * 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Spock_Rock_Or_Spock_Scissors(long n)
        {
            if (n <= 2)
            {
                return WinnerMessage(Bob, n, 0);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 2) / 4;
            long remain = (n - 2) % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours;
            bobWins = numberOfFours * 2;
            bobWins += 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Lizard_Lizard(long n)
        {
            if (n == 1)
            {
                return TieMsg(0, 1);
            }
            else if (n == 2)
            {
                return WinnerMessage(Bob, 1, 1);
            }
            else if (n == 3)
            {
                return WinnerMessage(Bob, 2, 1);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 3) / 4;
            long remain = (n - 3) % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours + 1;
            bobWins = numberOfFours * 2;
            bobWins += 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Scissors_Scissors(long n)
        {
            if (n == 1)
            {
                return TieMsg(0, 1);
            }
            else if (n == 2)
            {
                return TieMsg(0, 2);
            }
            else if (n == 3)
            {
                return TieMsg(0, 3);
            }
            else if (n == 4)
            {
                return WinnerMessage(Bob, 1, 3);
            }
            else if (n == 5)
            {
                return WinnerMessage(Bob, 2, 3);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 5) / 4;
            long remain = (n - 5) % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours + 3;
            bobWins = numberOfFours * 2;
            bobWins += 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Scissors_Paper_Or_Scissors_Lizard(long n)
        {
            if (n == 1)
            {
                return WinnerMessage(Bob, 1, 0);
            }
            else if (n == 2)
            {
                return WinnerMessage(Bob, 1, 1);
            }
            else if (n == 3)
            {
                return WinnerMessage(Bob, 1, 2);
            }
            else if (n == 4)
            {
                return WinnerMessage(Bob, 2, 2);
            }
            else if (n == 5)
            {
                return WinnerMessage(Bob, 3, 2);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 5) / 4;
            long remain = (n - 5) % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours + 2;
            bobWins = numberOfFours * 2;
            bobWins += 3;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Paper_Lizard_Or_Spock_Lizard(long n)
        {
            return WinnerMessage(Alice, n, 0);
        }

        private static string Handle_Paper_Scissors_Or_Lizard_Scissors_Or_Scissors_Rock_Or_Lizard_Rock(long n)
        {
            if (n == 1)
            {
                return WinnerMessage(Alice, 1, 0);
            }
            else if (n == 2)
            {
                return TieMsg(1, 0);
            }
            else if (n == 3)
            {
                return WinnerMessage(Bob, 2, 1);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 3) / 4;
            long remain = (n - 3) % 4;

            aliceWins = numberOfFours + 1;
            ties = numberOfFours;
            bobWins = numberOfFours * 2;
            bobWins += 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Paper_Paper(long n)
        {
            if (n == 1)
            {
                return TieMsg(0, 1);
            }
            else if(n <= 3)
            {
                return WinnerMessage(Bob, n - 1, 1);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 3) / 4;
            long remain = (n - 3) % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours + 1;
            bobWins = numberOfFours * 2;
            bobWins += 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Paper_Rock_Or_Paper_Spock_Or_Lizard_Paper_Or_Lizard_Spock(long n)
        {
            if (n <= 3)
            {
                return WinnerMessage(Bob, n, 0);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 3) / 4;
            long remain = (n - 3) % 4;

            aliceWins = numberOfFours;
            ties = numberOfFours;
            bobWins = numberOfFours * 2;
            bobWins += 3;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Rock_Spock_Or_Scissors_Spock(long n)
        {
            if (n == 1)
            {
                return WinnerMessage(Alice, 1, 0);
            }
            else if (n == 2)
            {
                return WinnerMessage(Alice, 1, 1);
            }
            else if (n == 3)
            {
                return WinnerMessage(Alice, 1, 2);
            }
            else if (n == 4)
            {
                return TieMsg(1, 2);
            }
            else if (n == 5)
            {
                return WinnerMessage(Bob, 2, 2);
            }

            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 5) / 4;
            long remain = (n - 5) % 4;

            aliceWins = numberOfFours + 1;
            ties = numberOfFours + 2;
            bobWins = numberOfFours * 2;
            bobWins += 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Rock_Scissors_Or_Rock_Lizard(long n)
        {
            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 1) / 4;
            long remain = (n - 1) % 4;

            if (n == 1)
            {
                return WinnerMessage(Bob, 1, 0);
            }

            aliceWins = numberOfFours;
            ties = numberOfFours;
            bobWins = numberOfFours * 2;
            bobWins++;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Rock_Paper(long n)
        {
            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 1) / 4;
            long remain = (n - 1) % 4;

            if (n == 1)
            {
                return WinnerMessage(Alice, 1, 0);
            }

            aliceWins = numberOfFours + 1;
            ties = numberOfFours;
            bobWins = numberOfFours * 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if (remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Handle_Rock_Rock(long n)
        {
            long aliceWins = 0;
            long bobWins = 0;
            long ties = 0;

            long numberOfFours = (n - 1) / 4;
            long remain = (n - 1) % 4;

            if (n == 1)
            {
                return TieMsg(0, 1);
            }

            aliceWins = numberOfFours;
            ties = numberOfFours + 1;
            bobWins = numberOfFours * 2;

            if (remain == 1)
            {
                aliceWins++;
            }
            else if (remain == 2)
            {
                aliceWins++;
                ties++;
            }
            else if(remain == 3)
            {
                aliceWins++;
                ties++;
                bobWins++;
            }

            return Message(aliceWins, bobWins, ties);
        }

        private static string Message(long aliceWins, long bobWins, long ties)
        {
            if (aliceWins == bobWins)
            {
                return TieMsg(bobWins, ties);
            }
            else if(aliceWins > bobWins)
            {
                return WinnerMessage(Alice, aliceWins, ties);
            }
            else
            {
                return WinnerMessage(Bob, bobWins, ties);
            }
        }

        private static string WinnerMessage(string winner, long numberOfWins, long numberOfTies)
        {
            return $"{winner} wins, by winning {numberOfWins} game(s) and tying {numberOfTies} game(s)";
        }

        private static string TieMsg(long numberOfWinsForEach, long numberOfTies)
        {
            return $"Alice and Bob tie, each winning {numberOfWinsForEach} game(s) and tying {numberOfTies} game(s)";
        }
    }
}
