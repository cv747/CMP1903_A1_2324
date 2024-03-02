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
            int[] _ = game.RollDiceContinually();

            Testing testing = new Testing();
            testing.TestDie();  // Test: Ensures Die class operates correctly.
            testing.TestArrayEqual();   // Test: Ensure array equality checking method works (required for the game test).
            testing.TestGame();  // Test: Ensure the game class works.
        }

    }
}
