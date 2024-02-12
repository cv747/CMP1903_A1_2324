using System.Collections.Generic;
using System.Diagnostics;

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
                Debug.Assert(rolledNum == die.Value);
                Debug.Assert(die.Value >= 1);
                Debug.Assert(die.Value <= 6);
                _ = numbersOccured.Add(rolledNum);
            }

            Debug.Assert(numbersOccured.Count == 6);  // Ensure only 6 unique items occured.
        }

    }
}
