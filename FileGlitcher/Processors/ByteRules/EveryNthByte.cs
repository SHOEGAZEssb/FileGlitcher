using System;

namespace FileGlitcher.Processors.ByteRules
{
  /// <summary>
  /// Byte rule where every nth byte is selected
  /// for glitching.
  /// </summary>
  public class EveryNthByte : ByteRuleBase
  {
    #region Member

    /// <summary>
    /// Every 'nth' byte should be glitched.
    /// </summary>
    private uint _n;

    #endregion Member

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="numBytesToGlitch">Number of bytes to glitch.
    /// <paramref name="n"/>Byte skip factor.
    public EveryNthByte(ByteRange range, uint numBytesToGlitch, uint n) 
      : base(range, numBytesToGlitch)
    {
      if (n == 0)
        throw new ArgumentOutOfRangeException(nameof(n));
      if (numBytesToGlitch > (range.End - range.Start))
        throw new ArgumentOutOfRangeException(nameof(numBytesToGlitch));

      _n = n;
      CreatePossibleByteIndexes();
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="n">Byte skip factor.</param>
    public EveryNthByte(ByteRange range, uint n)
      : this(range, range.End - range.Start, n)
    { }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    protected override void CreatePossibleByteIndexes()
    {
      for (uint i = 0; i < _numBytesToGlitch; i++)
      {
        if (i % _n == 0)
          PossibleByteIndexes.Add(_range.Start + i);
      }
    }
  }
}