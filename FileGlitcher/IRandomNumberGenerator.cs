namespace FileGlitcher
{
  /// <summary>
  /// Interface for an object returning random numbers.
  /// </summary>
  public interface IRandomNumberGenerator
  {
    /// <summary>
    /// Seed to use for random number generation.
    /// </summary>
    int Seed { get; set; }

    /// <summary>
    /// Returns a random number.
    /// </summary>
    /// <param name="minValue">Inclusive minimum value to generate.</param>
    /// <param name="maxValue">Inclusive maximum value to generate.</param>
    /// <returns>Randomly generated number.</returns>
    int GetRandomNumber(int minValue, int maxValue);
  }
}