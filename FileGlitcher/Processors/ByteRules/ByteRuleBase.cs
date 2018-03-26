using System;
using System.Collections.Generic;
using System.Linq;

namespace FileGlitcher.Processors.ByteRules
{
  /// <summary>
  /// Base class for all byte rules.
  /// A byte rules defines which bytes
  /// are selected for glitching.
  /// </summary>
  public abstract class ByteRuleBase
  {
    #region Properties

    /// <summary>
    /// Amount of bytes left to glitch.
    /// </summary>
    public uint NumBytesLeftToGlitch => (uint)PossibleByteIndexes.Count;

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
    protected List<uint> PossibleByteIndexes { get; set; }

    #endregion Member

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="range">The byte range to get possible indexes from.</param>
    /// <param name="numBytesToGlitch">Amount of bytes to glitch.</param>
    public ByteRuleBase(ByteRange range, uint numBytesToGlitch)
    {
      _range = range;

      if (numBytesToGlitch == 0)
        throw new ArgumentOutOfRangeException(nameof(numBytesToGlitch));

      _numBytesToGlitch = numBytesToGlitch;
      PossibleByteIndexes = new List<uint>();
    }

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
      uint index = PossibleByteIndexes.First();
      PossibleByteIndexes.RemoveAt(0);
      return index;
    }
  }
}