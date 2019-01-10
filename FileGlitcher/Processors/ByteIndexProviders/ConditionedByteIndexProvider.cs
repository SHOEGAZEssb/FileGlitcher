using System;

namespace FileGlitcher.Processors.ByteIndexProviders
{
  /// <summary>
  /// Provides byte indexes based on a set condition
  /// each byte is checked against.
  /// </summary>
  public class ConditionedByteIndexProvider : ByteIndexProviderBase
  {
    #region Member

    /// <summary>
    /// The possible bytes based on the range.
    /// </summary>
    private byte[] _possibleBytes;

    /// <summary>
    /// The predicate each byte is checked against.
    /// </summary>
    private Func<byte, bool> _conditionPredicate;

    #endregion Member

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="maxNumBytesToGlitch">Maximum number of bytes to glitch.</param>
    /// <param name="bytes">The bytes to check with the <paramref name="conditionPredicate"/>.</param>
    /// <param name="conditionPredicate">The condition to check each byte for.</param>
    public ConditionedByteIndexProvider(ByteRange range, uint maxNumBytesToGlitch, byte[] bytes, Func<byte, bool> conditionPredicate)
      : base(range, maxNumBytesToGlitch)
    {
      if (bytes == null)
        throw new ArgumentNullException(nameof(bytes));
      if (bytes.Length == 0)
        throw new ArgumentException(string.Format("{0} can't be empty", nameof(bytes)));

      _possibleBytes = bytes.SubArray(_range.Start, _range.End - _range.Start);
      _conditionPredicate = conditionPredicate ?? throw new ArgumentNullException(nameof(conditionPredicate));
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">Range to glitch.</param>
    /// <param name="bytes">The bytes to check with the <paramref name="conditionPredicate"/>.</param>
    /// <param name="conditionPredicate">The condition to check each byte for.</param>
    public ConditionedByteIndexProvider(ByteRange range, byte[] bytes, Func<byte, bool> conditionPredicate)
      : this(range, range.End - range.Start, bytes, conditionPredicate)
    { }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    public override void CreatePossibleByteIndexes()
    {
      uint counter = 0;
      for(uint i = _range.Start; i < _range.End - _range.Start; i++)
      {
        if (_conditionPredicate.Invoke(_possibleBytes[counter++]))
          _possibleByteIndexes.Add(i);
        if (_possibleByteIndexes.Count == _numBytesToGlitch)
          return;
      }
    }
  }
}