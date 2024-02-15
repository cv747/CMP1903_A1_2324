using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// This is the main class for the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This is the program entry-point, all the code begins execution from here.
        /// </summary>
        public static void Main()
        {
            Game game = new Game();

            List<int> allRolls = new List<int>();
            List<int> totals = new List<int>();

            do
            {
                (int total, int[] rolls) = game.RollDie();

                totals.Add(total);

                foreach (int roll in rolls)
                {
                    Console.WriteLine("Rolled a " + roll + ".");
                    allRolls.Add(roll);
                }
                Console.WriteLine("The total was " + total + ".");

                Console.Write("\nWould you like to roll again? (press q for no) ");
            } while (Console.ReadKey().Key != ConsoleKey.Q);

            GenerateStats(allRolls, totals);

            Testing testing = new Testing();
            testing.TestDie();  // Test: Ensures Die class operates correctly.
            testing.TestArrayEqual();   // Test: Ensure array equality checking method works.
            testing.TestGame();  // Test: Ensure the game class works.
        }

        /// <summary>
        /// Generates and prints out the statistics of all the rolls.
        /// </summary>
        public static void GenerateStats(List<int> rolls, List<int> totals)
        {
            Dictionary<int, int> rollCounter = new Dictionary<int, int>();
            rolls.ForEach(roll =>
            {
                if (!rollCounter.ContainsKey(roll))
                    rollCounter.Add(roll, 0);

                rollCounter[roll]++;
            });

            float averageRoll = (float)rolls.Sum() / rolls.Count;
            float averageTotal = (float)totals.Sum() / totals.Count;

            Console.WriteLine("The average of the totals was " + Math.Round(averageTotal, 2) + ".");
            foreach (KeyValuePair<int, int> entry in rollCounter)
            {
                Console.WriteLine("The number " + entry.Key + " occured " + entry.Value + " times.");
            }
            Console.WriteLine("The average of roll was " + Math.Round(averageRoll, 2) + ".");

        }
    }
}
