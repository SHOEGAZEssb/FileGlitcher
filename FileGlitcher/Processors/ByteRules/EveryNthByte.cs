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
    /// <param name="maxNumBytesToGlitch">Maximum number of bytes to glitch.
    /// <paramref name="n"/>Byte skip factor.
    public EveryNthByte(ByteRange range, uint maxNumBytesToGlitch, uint n)
      : base(range, maxNumBytesToGlitch)
    {
      if (n == 0 || n > range.End - range.Start)
        throw new ArgumentOutOfRangeException(nameof(n));
      if (maxNumBytesToGlitch == 0)
        throw new ArgumentOutOfRangeException(nameof(maxNumBytesToGlitch));

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
      for (uint i = 0; i <= _range.End - _range.Start; i++)
      {
        if ((i + 1) % _n == 0)
          PossibleByteIndexes.Add(_range.Start + i);
        if (PossibleByteIndexes.Count == _numBytesToGlitch)
          return;
      }
    }
  }
}