using System;

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
    /// Seed for random number generation.
    /// </summary>
    public int Seed;

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    public RandomByteIndexProvider(ByteRange range)
      : this(range, range.End - range.Start)
    { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="numBytesToGlitch">Amount of bytes to glitch in the range.</param>
    public RandomByteIndexProvider(ByteRange range, uint numBytesToGlitch)
      : this(range, numBytesToGlitch, DateTime.Now.Ticks.GetHashCode())
    { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="numBytesToGlitch">Amount of bytes to glitch in the range.</param>
    /// <param name="seed">Seed for random number generation.</param>
    public RandomByteIndexProvider(ByteRange range, uint numBytesToGlitch, int seed)
      : base(range, numBytesToGlitch)
    {
      Seed = seed;
    }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    public override void CreatePossibleByteIndexes()
    {
      Random rnd = new Random(Seed);
      for(int i = 0; i < _numBytesToGlitch; i++)
      {
        _possibleByteIndexes.Add((uint)rnd.Next((int)_range.Start, (int)_range.End));
      }
    }
  }
}