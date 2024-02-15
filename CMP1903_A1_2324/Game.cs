using System.Linq;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        /// <value>
        /// A list that stores the Die objects that will be rolled.
        /// </value>
        /// <remarks>
        /// This is used so that the Die objects do not need to be re-created repeatedly.
        /// Furthermore, by using a List it makes it easier to add more die if it was ever required.
        /// </remarks>
        private readonly Die[] dice;

        public Game()
        {
            dice = new Die[] { new Die(), new Die(), new Die() };
        }

        /// <summary>
        /// Plays the game by rolling the 3 die objects.
        /// </summary>
        /// <example>
        /// <code>
        /// Game game = new Game();
        /// var (total, rolls) = game.RollDie();
        /// Console.WriteLine(total);
        /// foreach (int roll in rolls)
        /// {
        ///     Console.WriteLine(roll);
        /// }
        /// </code>
        /// </example>
        /// <returns>
        /// A tuple containing the total and an array of the individual rolls.
        /// </returns>
        public (int, int[]) RollDie()
        {
            int[] rolls = dice.Select(die => die.Roll()).ToArray();
            return (rolls.Sum(), rolls);
        }

        public int[] GetDieValues()
        {
            return dice.Select(die => die.Value).ToArray();
        }
    }
}
