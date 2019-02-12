using System;

namespace FileGlitcher.Processors.ByteIndexProviders
{
  /// <summary>
  /// Byte rule where every nth byte is selected
  /// for glitching.
  /// </summary>
  public class EveryNthByteIndexProvider : ByteIndexProviderBase
  {
    #region Properties

    /// <summary>
    /// Every 'nth' byte should be glitched.
    /// </summary>
    public int N
    {
      get => _n;
      set
      {
        if (value == 0 || value > _range.End - _range.Start)
          throw new ArgumentOutOfRangeException(nameof(N));

        if (N != value)
        {
          _n = value;
          CreatePossibleByteIndexes();
        }
      }
    }
    private int _n;

    #endregion EndRegion

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="n"/>Byte skip factor.
    public EveryNthByteIndexProvider(ByteRange range, int n)
      : base(range)
    {
      N = n;
    }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    protected override void CreatePossibleByteIndexes()
    {
      for (uint i = 0; i <= _range.End - _range.Start; i++)
      {
        if ((i + 1) % _n == 0)
          _possibleByteIndexes.Add(_range.Start + i);
        if (_possibleByteIndexes.Count == _range.End - _range.Start)
          return;
      }
    }
  }
}