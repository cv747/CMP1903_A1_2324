using System;

namespace CMP1903_A1_2324 {

  /// <summary>
  /// This class is designed to be simulate a normal 6-sided die.
  /// </summary>
  internal class Die {

    /// <value>
    /// Holds the number of sides on the die.
    /// </value>
    /// <remarks>
    /// Used for future extendability.
    /// </remarks>
    public static readonly int NumberOfSides = 6;

    /// <value>
    /// A static instance of the Random object to create random values for the class.
    /// </value>
    /// <remarks>
    /// This means that we only need to create an instance of the Random class once rather than on 
    /// every die roll.
    ///
    /// This avoids <c>_random</c> being created on Die instantiation, which would cause Die's 
    /// created at the same time to have the same seed.
    ///
    /// Same seed generation could also have been done by passing a Random object to the Die class 
    /// to increase memory efficiency, but that creates more complexity that is not needed for 
    /// this.
    /// </remarks>
    private static readonly Random _random = new Random();

    /// <value>
    /// The <c>Value</c> property is used to access the side the dice is displaying.
    /// </value>
    /// <remarks>
    /// Doing a property without a specific field attached to it automatically generates an 
    /// anonymous backing field.
    /// </remarks>
    public int Value { get; private set; } = _random.Next(1, NumberOfSides + 1);

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
    public int Roll() {
      Value = _random.Next(1, NumberOfSides + 1);
      return Value;
    }

  }
}
