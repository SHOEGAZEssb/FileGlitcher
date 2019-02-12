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
    /// </summary>
    public IReadOnlyList<uint> ByteIndexPool => _possibleByteIndexes.AsReadOnly();

    #endregion Properties

    #region Member

    /// <summary>
    /// The byte range to get possible indexes from.
    /// </summary>
    protected ByteRange _range;

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
    public ByteIndexProviderBase(ByteRange range)
    {
      _range = range;
      _possibleByteIndexes = new List<uint>();
    }

    #endregion Construction

    /// <summary>
    /// Gets the bytes to glitch from the given <paramref name="bytes"/>
    /// based on the provided indexes.
    /// </summary>
    /// <param name="bytes">Bytes to get subarray from.</param>
    /// <returns>Subarray with actual bytes to glitch.</returns>
    public byte[] GetBytesToGlitch(byte[] bytes)
    {
      byte[] bytesToGlitch = new byte[_possibleByteIndexes.Count];
      for(int i = 0; i < bytesToGlitch.Length; i++)
      {
        bytesToGlitch[i] = bytes[i];
      }

      return bytesToGlitch;
    }

    /// <summary>
    /// Applies the <paramref name="partBytesToGlitch"/> to the <paramref name="bytes"/>.
    /// </summary>
    /// <param name="partBytesToGlitch">The glitched bytes.</param>
    /// <param name="bytes">The original bytes to apply the <paramref name="partBytesToGlitch"/> to.</param>
    public void ApplyGlitchedBytes(byte[] partBytesToGlitch, byte[] bytes)
    {
      for(int i = 0; i < partBytesToGlitch.Length; i++)
      {
        bytes[_possibleByteIndexes[i]] = partBytesToGlitch[i];
      }
    }

    /// <summary>
    /// Creates the possible byte indexes to use.
    /// </summary>
    protected abstract void CreatePossibleByteIndexes();
  }
}