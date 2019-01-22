using System;
using System.Linq;
using FileGlitcher.Processors.ByteIndexProviders;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Processor that shuffles bytes.
  /// </summary>
  public class ShuffleProcessor : ProcessorBase
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
    /// <param name="byteIndexProvider">Provider of the indexes of
    /// the bytes to glitch.</param>
    /// <param name="seed">Seed for random number generation.</param>
    public ShuffleProcessor(ByteIndexProviderBase byteIndexProvider, int seed)
      : base(byteIndexProvider)
    {
      Seed = seed;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteIndexProvider">Provider of the indexes of
    /// the bytes to glitch.</param>
    public ShuffleProcessor(ByteIndexProviderBase byteIndexProvider)
      : this(byteIndexProvider, DateTime.Now.Ticks.GetHashCode())
    { }

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      _byteIndexProvider.CreatePossibleByteIndexes();

      // build the original value array
      byte[] originalBytes = new byte[_byteIndexProvider.ByteIndexPool.Count];
      for(int i = 0; i < _byteIndexProvider.ByteIndexPool.Count; i++)
      {
        originalBytes[i] = bytes[_byteIndexProvider.ByteIndexPool[i]];
      }

      // shuffle the bytes
      Random rnd = new Random(Seed);
      byte[] shuffledBytes = originalBytes.OrderBy(i => rnd.Next(0, int.MaxValue)).ToArray();

      int shuffledByteIndex = 0;
      while(_byteIndexProvider.ByteIndexPool.Count != 0)
      {
        bytes[_byteIndexProvider.GetNextByteIndex()] = shuffledBytes[shuffledByteIndex++];
      }

      return bytes;
    }
  }
}