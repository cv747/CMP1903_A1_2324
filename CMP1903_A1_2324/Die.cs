using System;

namespace CMP1903_A1_2324 {

  /// <summary>
  /// This class is designed to be simulate a normal 6-sided die.
  /// </summary>
  internal class Die {

    /// <value>
    /// A static instance of the Random object to create random values for the class.
    /// </value>
    /// <remarks>
    /// By having the <c>Random</c> object being a static field, we can avoid the potential issue
    /// of some <c>Die</c> objects having the same seed for randomness when created sequentially.
    /// </remarks>
    private static readonly Random _random = new Random();


    public int NumberOfSides { get; private set; }

    /// <value>
    /// The <c>Value</c> property is used to access the side the dice is displaying.
    /// </value>
    public int Value { get; private set; }

    public Die() {
      this.Value = _random.Next(1, NumberOfSides + 1);
      this.NumberOfSides = 6;
    }

    public Die(int numberOfSides) {
      this.Value = _random.Next(1, NumberOfSides + 1);
      this.NumberOfSides = numberOfSides;
    }

    /// <summary>
    /// Simulates the action of rolling a die.
    /// </summary>
    /// <returns>
    /// An integer of the side the die displayed once rolled.
    /// </returns>
    public int Roll() {
      Value = _random.Next(1, NumberOfSides + 1);
      return Value;
    }

  }
}
