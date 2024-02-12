using System;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// This class is designed to be simulate a normal 6-sided die.
    /// </summary>
    internal class Die
    {
        /// <value>
        /// A static instance of the Random object to create random values for the class.
        /// </value>
        /// <remarks>
        /// This means that we only need to create an instance of the Random class once rather than on every die roll.
        /// </remarks>
        private static readonly Random RANDOM = new Random();

        /// <value>
        /// The <c>Value</c> property is used to store the current state of the die (the side it is showing).
        /// </value>
        public int Value { get; private set; } = RANDOM.Next(1, 7);


        /// <summary>
        /// Simulates the action of rolling a die.
        /// </summary>
        /// <example>
        /// <code>
        /// Die die = new Die();
        /// int result = die.Roll();
        /// Console.WriteLine(result);
        /// </code>
        /// </example>
        /// <returns>
        /// An integer of the side the die displayed once rolled.
        /// </returns>
        public int Roll()
        {
            Value = RANDOM.Next(1, 7);
            return Value;
        }

    }
}
