using System;
using System.Linq;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Processor that shuffles bytes.
  /// </summary>
  public class ShuffleProcessor : IProcessor
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
    /// <param name="seed">Seed for random number generation.</param>
    public ShuffleProcessor(int seed)
    {
      Seed = seed;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public ShuffleProcessor()
      : this(DateTime.Now.Ticks.GetHashCode())
    { }

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public byte[] Apply(byte[] bytes)
    {
      // shuffle the bytes
      Random rnd = new Random(Seed);
      return bytes.OrderBy(i => rnd.Next(0, int.MaxValue)).ToArray();
    }
  }
}