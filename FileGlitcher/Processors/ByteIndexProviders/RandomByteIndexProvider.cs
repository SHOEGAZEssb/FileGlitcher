using System;

namespace FileGlitcher.Processors.ByteIndexProviders
{
  /// <summary>
  /// Byte rule where random bytes are selected
  /// for glitching.
  /// </summary>
  public class RandomByteIndexProvider : ByteIndexProviderBase
  {
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
      : base(range, numBytesToGlitch)
    {
      CreatePossibleByteIndexes();
    }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    protected override void CreatePossibleByteIndexes()
    {
      Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
      for(int i = 0; i < _numBytesToGlitch; i++)
      {
        _possibleByteIndexes.Add((uint)rnd.Next((int)_range.Start, (int)_range.End));
      }
    }
  }
}