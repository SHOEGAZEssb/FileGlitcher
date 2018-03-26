using System;

namespace FileGlitcher.Processors.ByteRules
{
  /// <summary>
  /// Byte rule where random bytes are selected
  /// for glitching.
  /// </summary>
  public class RandomBytes : ByteRuleBase
  {
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    public RandomBytes(ByteRange range)
      : this(range, range.End - range.Start)
    { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="numBytesToGlitch">Amount of bytes to glitch in the range.</param>
    public RandomBytes(ByteRange range, uint numBytesToGlitch)
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
        PossibleByteIndexes.Add((uint)rnd.Next((int)_range.Start, (int)_range.End));
      }
    }
  }
}