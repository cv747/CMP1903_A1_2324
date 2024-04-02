using System;

namespace CMP1903_A1_2324 {

  /// <summary>
  /// This is the main class for the program.
  /// </summary>
  internal class Program {

    /// <summary>
    /// This is the program entry-point, all the code begins execution from here.
    /// </summary>
    public static void Main() {
      Game game = new Game();
      int[] _ = game.RollDiceContinually();  // _ is used to throw away the result.


      Testing testing = new Testing();
      testing.TestDie();  // Test: Ensures Die class operates correctly.
      testing.TestArrayEqual(); // Test: Ensure array equality checking method works
                                // (required for the game test).
      testing.TestGame(); // Test: Ensure the game class works.
    }

    public static T Choice(T[] choices) {
      int i = 0;
      foreach (T item in choice) {
        Console.WriteLine($"[{i}] {item.ToString()}");
      }
      return choices[IntChoice(0, choice.Length - 1)];
    }

    public static int IntChoice(int min, int max) {
      while (true) {
        try {
          int choice = int.Parse(Console.ReadLine());
          if (choice < min || choice > max) {
            Console.WriteLine($"Please enter a number in the range {min}-{max}");
          }
          return choice;
        } catch (Exception) {
          Console.WriteLine("Please enter a number.");
        }
      }
    }

  }
}
