using System;
using System.Linq;

namespace MontyHallParadox
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("How many times would you like to play? : ");
            var times = int.Parse(Console.ReadLine());

            var sticking = GetResult(times, false);
            var switching = GetResult(times, true);

            Console.WriteLine($"Sticking won {sticking} times.");
            Console.WriteLine($"Switching won {switching} times.");
            if (switching > sticking)
            {
                Console.WriteLine("It's better to switch your selection every time.");
            }
            else
            {
                Console.WriteLine("It's better to stick with your original choice every time.");
            }

            Console.ReadKey();
        }

        private static Random rand = new Random();

        private static int GetResult(int times, bool switching)
        {
            var retval = 0;

            for (var i = 0; i < times; i++)
            {
                var answer = rand.Next(1, 4);
                var winner = rand.Next(1, 4);

                if (switching)
                {
                    var doorLeft = Enumerable.Range(1, 3).Where(x => x != answer).Skip(rand.Next(0, 2));
                    if (doorLeft.First() == winner)
                    {
                        retval++;
                    }
                }
                else if (answer == winner)
                {
                    retval++;
                }
            }

            return retval;
        }
    }
}
