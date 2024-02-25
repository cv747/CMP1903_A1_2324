using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903_A1_2324
{

    internal class Game
    {
        /// <value>
        /// A constant value that defines how many dice the Game contains.
        /// </value>
        public const int DICE_COUNT = 3;

        /// <value>
        /// A list that stores the Die objects that will be rolled.
        /// </value>
        /// <remarks>
        /// This is used so that the Die objects do not need to be re-created repeatedly.
        /// Furthermore, by using an array to store the values instead of fields, it is easier to add more die if it was ever required by just modifying the <c>DICE_COUNT</c> constant.
        /// </remarks>
        private readonly Die[] dice = new Die[DICE_COUNT];

        /// <summary>
        /// The constructor for the Game class, it is used to initialise instances of all the Die objects.
        /// </summary>
        public Game()
        {
            for (int i = 0; i < DICE_COUNT; i++)
            {
                dice[i] = new Die();  // Create each die object and store into the array of dice.
            }
        }

        /// <summary>
        /// Plays the game by rolling the 3 die objects.
        /// </summary>
        /// <remarks>
        /// This method for the game is less likely to be used and is more for the usage of the <c>RollDiceContinually</c> method.
        /// </remarks>
        /// <example>
        /// <code>
        /// Game game = new Game();
        /// var (total, rolls) = game.RollDie();
        /// Console.WriteLine(total);
        /// foreach (int roll in rolls) {
        ///   Console.WriteLine(roll);
        /// }
        /// </code>
        /// </example>
        /// <returns>
        /// A tuple containing the total and an array of the individual rolls.
        /// </returns>
        public (int, int[]) RollDice()
        {
            int[] rolls = dice.Select(die => die.Roll()).ToArray();  // Roll each die and collect their output to an array.
            return (rolls.Sum(), rolls);
        }

        /// <summary>
        /// A method which extends the functionality of the RollDice method by adding reporting to the console.
        /// </summary>
        /// <returns>
        /// A tuple containing the total and an array of the individual rolls.
        /// </returns>
        public (int total, int[] rolls) RollDiceReported()
        {
            (int total, int[] rolls) = RollDice();
            Console.WriteLine("###############################");
            foreach (int roll in rolls)
            {
                Console.WriteLine($"Rolled a {roll}.");
            }
            Console.WriteLine($"Total of rolls was {total}");
            Console.WriteLine("###############################");

            return (total, rolls);
        }

        /// <summary>
        /// Plays the game continually until the user presses Q, it also reports the stats.
        /// </summary>
        public void RollDiceContinually()
        {
            List<int> allRolls = new List<int>();

            do
            {
                (int _, int[] rolls) = RollDiceReported();
                allRolls.AddRange(rolls);

                Console.Write("Press Q to exit, or anything else to continue. ");
                Console.WriteLine();
            } while (Console.ReadKey().Key != ConsoleKey.Q);

            GenerateStats(allRolls.ToArray());
        }

        /// <summary>
        /// A static method that generates and prints out statistics of all the rolls.
        /// </summary>
        /// <param name="rolls">
        /// An array of integers that contains all the die values that have been rolled.
        /// </param>
        public static void GenerateStats(int[] rolls)
        {
            Dictionary<int, int> rollCounter = new Dictionary<int, int>();  // Count the occurance of each die value.
            foreach (int roll in rolls)
            {
                if (!rollCounter.ContainsKey(roll))
                    rollCounter.Add(roll, 0);

                rollCounter[roll]++;
            }

            float total = rolls.Sum();
            double averageRoll = Math.Round(total / rolls.Length, 2);  // Averages the rolls.
            double averageTotal = Math.Round(total * DICE_COUNT / rolls.Length);  // Averages the totals.

            Console.WriteLine($"The average of the totals was {averageTotal}.");
            foreach (KeyValuePair<int, int> entry in rollCounter)
            {
                Console.WriteLine($"The number {entry.Key} occured {entry.Value} times.");
            }
            Console.WriteLine($"The average roll was {averageRoll}.");
            Console.WriteLine($"The game was played {rolls.Length / DICE_COUNT} time(s).");
        }

        /// <summary>
        /// A method to get an array countaining the dice mapped to be just their values..
        /// </summary>
        public int[] GetDieValues()
        {
            return dice.Select(die => die.Value).ToArray();
        }
    }
}
