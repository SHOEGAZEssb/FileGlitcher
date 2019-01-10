namespace FileGlitcher.Processors.ByteIndexProviders
{
  /// <summary>
  /// Byte rule where random bytes are selected
  /// for glitching.
  /// </summary>
  public class RandomByteIndexProvider : ByteIndexProviderBase
  {
    #region Properties

    /// <summary>
    /// Generator for random numbers.
    /// </summary>
    public IRandomNumberGenerator RandomNumberGenerator;

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="randomNumberGenerator">Generator for random numbers.</param>
    public RandomByteIndexProvider(ByteRange range, IRandomNumberGenerator randomNumberGenerator)
      : this(range, randomNumberGenerator, range.End - range.Start)
    { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="randomNumberGenerator">Generator for random numbers.</param>
    /// <param name="numBytesToGlitch">Amount of bytes to glitch in the range.</param>
    public RandomByteIndexProvider(ByteRange range, IRandomNumberGenerator randomNumberGenerator, uint numBytesToGlitch)
      : base(range, numBytesToGlitch)
    {
      RandomNumberGenerator = randomNumberGenerator;
    }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    public override void CreatePossibleByteIndexes()
    {
      for(int i = 0; i < _numBytesToGlitch; i++)
      {
        _possibleByteIndexes.Add((uint)RandomNumberGenerator.GetRandomNumber((int)_range.Start, (int)_range.End));
      }
    }
  }
}