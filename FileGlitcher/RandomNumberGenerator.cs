using System;

namespace FileGlitcher
{
  /// <summary>
  /// Returns random numbers.
  /// </summary>
  public class RandomNumberGenerator : IRandomNumberGenerator
  {
    #region Properties

    /// <summary>
    /// Seed to use for random number generation.
    /// </summary>
    public int Seed
    {
      get { return _seed; }
      set
      {
        _seed = value;
        _random = new Random(Seed);
      }
    }
    private int _seed;

    #endregion Properties

    #region Member

    /// <summary>
    /// Actual random number generator.
    /// </summary>
    private Random _random;

    #endregion Member

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    public RandomNumberGenerator()
      : this(DateTime.Now.Ticks.GetHashCode())
    { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="seed">Seed to use for random number generation.</param>
    public RandomNumberGenerator(int seed)
    {
      Seed = seed;
    }

    #endregion Construction

    /// <summary>
    /// Returns a random number.
    /// </summary>
    /// <param name="minValue">Inclusive minimum value to generate.</param>
    /// <param name="maxValue">Inclusive maximum value to generate.</param>
    /// <returns>Randomly generated number.</returns>
    public int GetRandomNumber(int minValue, int maxValue)
    {
      return _random.Next(minValue, maxValue);
    }
  }
}