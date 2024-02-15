using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// A class that is used to provide the capabilities to test the different code sections.
    /// </summary>
    internal class Testing
    {
        /// <summary>
        /// Tests the Die class to ensure that all parts are operating correctly.
        /// </summary>
        public void TestDie()
        {
            Die die = new Die();
            HashSet<int> numbersOccured = new HashSet<int>();  // HashSet will ensure only unique items are stored.

            for (int i = 0; i < 1000; i++)
            {
                int rolledNum = die.Roll();
                Debug.Assert(rolledNum == die.Value);  // Test: Property set by roll.
                Debug.Assert(die.Value >= 1);  // Test: Value lower bound.
                Debug.Assert(die.Value <= 6);  // Test: Value upper bound.
                _ = numbersOccured.Add(rolledNum);
            }

            Debug.Assert(numbersOccured.Count == 6);  // Test: Only 6 unique numbers occured.
        }

        /// <summary>
        /// Tests the Game class to ensure it is operating correctly.
        /// </summary>
        public void TestGame()
        {
            Game game = new Game();

            (int total, int[] rolls) = game.RollDie();

            Debug.Assert(total == rolls.Sum());  // Test: Total and sum of rolls equal.

            int[] storedRolls = game.GetDieValues();

            Debug.Assert(rolls.Length == storedRolls.Length);  // Test: Same number of die.

            Debug.Assert(ArraysEqual(rolls, storedRolls));  // Test: Die rolls all the same.
        }

        /// <summary>
        /// Tests that the <c>ArraysEqual</c> method works correctly.
        /// </summary>
        public void TestArrayEqual()
        {
            Debug.Assert(ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }));  // Test: Equal arrays.
            Debug.Assert(!ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 }));  // Test: Unequal arrays.
            Debug.Assert(!ArraysEqual(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }));  // Test: Different array lengths.
        }

        /// <summary>
        /// Tests if two array of ints are equal.
        /// </summary>
        public bool ArraysEqual(int[] arrOne, int[] arrTwo)
        {
            if (arrOne.Length != arrTwo.Length)
                return false;

            for (int i = 0; i < arrOne.Length; i++)
            {
                if (arrOne[i] != arrTwo[i])
                    return false;
            }

            return true;
        }
    }
}
