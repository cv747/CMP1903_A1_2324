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
        Debug.Assert(rolledNum == die.Value, "Failed roll value property check.");
        Debug.Assert(die.Value >= 1, "Failed lower bound check.");
        Debug.Assert(die.Value <= Die.NumberOfSides, "Failed upper bound check.");
        bool _ = numbersOccured.Add(rolledNum); // We can throw away the result.
      }

      Debug.Assert(numbersOccured.Count == Die.NumberOfSides, "Failed dice occured check.");
    }

    /// <summary>
    /// Tests the Game class to ensure it is operating correctly.
    /// </summary>
    public void TestGame() {
      Game game = new Game();

      (int total, int[] rolls) = game.RollDice();

      Debug.Assert(rolls.Length == Game.DiceCount, "Failed rolls vs game dice check.");
      Debug.Assert(total == rolls.Sum(), "Failed total vs dice sum check.");
      int[] storedRolls = game.GetDieValues();

      Debug.Assert(storedRolls.Length == Game.DiceCount, "Failed stored dice vs game dice check.");
      Debug.Assert(rolls.Length == storedRolls.Length, "Failed rolls vs stored check.");
      Debug.Assert(ArraysEqual(rolls, storedRolls), "Failed rolls vs stored rolls array check.");
    }

    /// <summary>
    /// Tests that the <c>ArraysEqual</c> method works correctly.
    /// </summary>
    public void TestArrayEqual() {
      Debug.Assert(ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }),
                  "Failed array equality check.");
      Debug.Assert(!ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 }),
                  "Failed arrays unequal check.");
      Debug.Assert(!ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }),
                  "Failed different length array check.");
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
