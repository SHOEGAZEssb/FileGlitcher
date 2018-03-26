using System;
using System.Collections.Generic;
using System.Linq;

namespace FileGlitcher.Processors.ByteIndexProviders
{
  /// <summary>
  /// Base class for all byte rules.
  /// A byte rules defines which bytes
  /// are selected for glitching.
  /// </summary>
  public abstract class ByteIndexProviderBase
  {
    #region Properties

    /// <summary>
    /// The pool of byte indexes.
    /// Each <see cref="GetNextByteIndex"/> removes
    /// the index from the pool.
    /// </summary>
    public IReadOnlyList<uint> ByteIndexPool => _possibleByteIndexes.AsReadOnly();

    #endregion Properties

    #region Member

    /// <summary>
    /// The byte range to get possible indexes from.
    /// </summary>
    protected ByteRange _range;

    /// <summary>
    /// Amount of bytes to glitch.
    /// </summary>
    protected uint _numBytesToGlitch;

    /// <summary>
    /// List of possible byte indexes;
    /// </summary>
    protected List<uint> _possibleByteIndexes { get; set; }

    #endregion Member

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">The byte range to get possible indexes from.</param>
    /// <param name="numBytesToGlitch">Amount of bytes to glitch.</param>
    public ByteIndexProviderBase(ByteRange range, uint numBytesToGlitch)
    {
      _range = range;

      if (numBytesToGlitch == 0)
        throw new ArgumentOutOfRangeException(nameof(numBytesToGlitch));

      _numBytesToGlitch = numBytesToGlitch;
      _possibleByteIndexes = new List<uint>();
    }

    #endregion Construction

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    protected abstract void CreatePossibleByteIndexes();

    /// <summary>
    /// Gets the index of the next byte to glitch.
    /// </summary>
    /// <returns>Index of the next byte to glitch.</returns>
    public uint GetNextByteIndex()
    {
      uint index = _possibleByteIndexes.First();
      _possibleByteIndexes.RemoveAt(0);
      return index;
    }
  }
}