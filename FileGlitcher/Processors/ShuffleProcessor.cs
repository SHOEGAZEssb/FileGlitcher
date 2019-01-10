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
    /// Generator for random numbers.
    /// </summary>
    public IRandomNumberGenerator RandomNumberGenerator;

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteIndexProvider">Provider of the indexes of
    /// the bytes to glitch.</param>
    /// <param name="randomNumberGenerator">Generator for random numbers.</param>
    public ShuffleProcessor(ByteIndexProviderBase byteIndexProvider, IRandomNumberGenerator randomNumberGenerator)
      : base(byteIndexProvider)
    {
      RandomNumberGenerator = randomNumberGenerator;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteIndexProvider">Provider of the indexes of
    /// the bytes to glitch.</param>
    public ShuffleProcessor(ByteIndexProviderBase byteIndexProvider)
      : this(byteIndexProvider, new RandomNumberGenerator())
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
      byte[] shuffledBytes = originalBytes.OrderBy(i => RandomNumberGenerator.GetRandomNumber(0, int.MaxValue)).ToArray();

      int shuffledByteIndex = 0;
      while(_byteIndexProvider.ByteIndexPool.Count != 0)
      {
        bytes[_byteIndexProvider.GetNextByteIndex()] = shuffledBytes[shuffledByteIndex++];
      }

      return bytes;
    }
  }
}