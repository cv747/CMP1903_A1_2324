using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903_A1_2324 {

  /// <summary>
  /// Is used to manage an instance of a game being played of dice rolling.
  /// </summary>
  internal class Game {

    /// <value>
    /// A constant value that defines how many dice the Game contains.
    /// </value>
    public const int DiceCount = 3;

    /// <value>
    /// A list that stores the Die objects that will be rolled.
    /// </value>
    /// <remarks>
    /// By using an array instead of fields, it is easier to change the number of die being rolled
    /// by changing the value of the <c>DiceCount</c> field.
    /// </remarks>
    private readonly Die[] dice = new Die[DiceCount];

    /// <summary>
    /// The constructor for the Game class, it is used to initialise instances of all the Die 
    /// objects.
    /// </summary>
    public Game() {
      for (int i = 0; i < DiceCount; i++) {
        dice[i] = new Die();  // Create each die object and store into the array of dice.
      }
    }

    /// <summary>
    /// Plays the game by rolling the 3 die objects.
    /// </summary>
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
    /// A tuple of the total as an int and an int array of the individual rolls.
    /// </returns>
    public (int, int[]) RollDice() {
      int[] rolls = dice.Select(die => die.Roll()).ToArray();  // Roll each die and collect their
                                                               // output to an array.
      return (rolls.Sum(), rolls);
    }

    /// <summary>
    /// A method which extends the functionality of the RollDice method by adding reporting of 
    /// each roll to the console.
    /// </summary>
    /// <returns>
    /// A tuple of the total as an int and an int array of the individual rolls.
    /// </returns>
    public (int, int[]) RollDiceReported() {
      (int total, int[] rolls) = RollDice();
      Console.WriteLine("###############################");
      foreach (int roll in rolls) {
        Console.WriteLine($"Rolled a {roll}.");
      }
      Console.WriteLine($"Total of rolls was {total}");
      Console.WriteLine("###############################");

      return (total, rolls);
    }

    /// <summary>
    /// Plays the game continually until the user presses Q, it also calls for the reporting of 
    /// statistics.
    /// </summary>
    /// <returns>
    /// An array of ints for all the rolls that occured during the game.
    /// </returns>
    public int[] RollDiceContinually() {
      List<int> allRolls = new List<int>();

      do {
        (int _, int[] rolls) = RollDiceReported();
        allRolls.AddRange(rolls);

        Console.Write("Press Q to exit, or anything else to continue. ");
        Console.WriteLine();
      } while (Console.ReadKey().Key != ConsoleKey.Q);
      Console.WriteLine();

      int[] rollsArr = allRolls.ToArray();
      GenerateStats(rollsArr);
      return rollsArr;
    }

    /// <summary>
    /// A static method that generates and prints out statistics of all the rolls.
    /// </summary>
    /// <param name="rolls">
    /// An array of integers that contains all the die values that have been rolled.
    /// </param>
    public static void GenerateStats(int[] rolls) {
      // Holds the occurance of each die value.
      Dictionary<int, int> rollCounter = new Dictionary<int, int>();

      foreach (int roll in rolls) {
        if (!rollCounter.ContainsKey(roll))
          rollCounter.Add(roll, 0);

        rollCounter[roll]++; // Count occurance.
      }

      float total = rolls.Sum();
      double averageRoll = Math.Round(total / rolls.Length, 2);  // Averages the rolls.

      // Averages the total score from each round
      double averageTotal = Math.Round(total * DiceCount / rolls.Length, 2);
      // score from each 
      Console.WriteLine($"The average of the totals was {averageTotal}.");
      foreach (KeyValuePair<int, int> entry in rollCounter) {
        Console.WriteLine($"The number {entry.Key} occured {entry.Value} times.");
      }
      Console.WriteLine($"The average roll was {averageRoll}.");
      Console.WriteLine($"The game was played {rolls.Length / DiceCount} time(s).");
    }

    /// <summary>
    /// A method to get an array countaining the dice mapped to be just their values.
    /// </summary>
    public int[] GetDieValues() {
      return dice.Select(die => die.Value).ToArray();
    }
  }
}
