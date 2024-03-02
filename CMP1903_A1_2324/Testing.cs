using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CMP1903_A1_2324 {

  /// <summary>
  /// A class that is used to provide the capabilities to test the different code sections.
  /// </summary>
  internal class Testing {

    /// <summary>
    /// Tests the Die class to ensure that all parts are operating correctly.
    /// </summary>
    public void TestDie() {
      Die die = new Die();

      HashSet<int> numbersOccured = new HashSet<int>();  // HashSet will ensure only unique items 
                                                         // are stored.

      for (int i = 0; i < 1000; i++) {
        int rolledNum = die.Roll();
        Debug.Assert(rolledNum == die.Value); // Test: Property set by roll.
        Debug.Assert(die.Value >= 1); // Test: Value lower bound.
        Debug.Assert(die.Value <= Die.NumberOfSides); // Test: Value upper bound.
        bool _ = numbersOccured.Add(rolledNum); // We can throw away the result.
      }

      Debug.Assert(numbersOccured.Count == Die.NumberOfSides);  // Test: Only 6 unique numbers 
                                                                // occured.
    }

    /// <summary>
    /// Tests the Game class to ensure it is operating correctly.
    /// </summary>
    public void TestGame() {
      Game game = new Game();

      (int total, int[] rolls) = game.RollDice();

      Debug.Assert(rolls.Length == Game.DiceCount); // Test: Correct number of rolls occured.

      Debug.Assert(total == rolls.Sum()); // Test: Total report and sum of rolls array equal.

      int[] storedRolls = game.GetDieValues();

      Debug.Assert(storedRolls.Length == Game.DiceCount);  // Test: Correct number of dice exist.

      Debug.Assert(rolls.Length == storedRolls.Length);  // Test: Same number of die.

      Debug.Assert(ArraysEqual(rolls, storedRolls));  // Test: Die rolls all the same.
    }

    /// <summary>
    /// Tests that the <c>ArraysEqual</c> method works correctly.
    /// </summary>
    public void TestArrayEqual() {
      // Test: Equal arrays.
      Debug.Assert(ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }));
      // Test: Unequal arrays.
      Debug.Assert(!ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 }));
      // Test: Different array lengths.
      Debug.Assert(!ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }));
    }

    /// <summary>
    /// Tests if two array of ints are equal.
    /// </summary>
    /// <param name="arrOne">
    /// An array of integers to test.
    /// </param>
    /// <param name="arrTwo">
    /// An array of integers to test against.
    /// </param>
    /// <returns>
    /// A boolean value to show if they are equal or not.
    /// </returns>
    public static bool ArraysEqual(int[] arrOne, int[] arrTwo) {
      if (arrOne.Length != arrTwo.Length) {
        return false;  // Incorrect length must be not equal.
      }

      for (int i = 0; i < arrOne.Length; i++) {
        if (arrOne[i] != arrTwo[i]) { // Compare each element.
          return false;
        }
      }

      return true;  // Arrays equal.
    }

  }
}
