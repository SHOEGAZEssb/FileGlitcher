using FileGlitcher.Processors.ByteRules;
using System;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Processor that randomizes bytes of a file.
  /// </summary>
  public class RandomProcessor : ProcessorBase
  {
    #region Properties

    /// <summary>
    /// Seed to use for RNG.
    /// </summary>
    public string Seed;

    /// <summary>
    /// Minimum byte value.
    /// </summary>
    public byte MinByte;

    /// <summary>
    /// Maximum byte value.
    /// </summary>
    public byte MaxByte;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="numBytesToGlitch">Amount of bytes to glitch.</param>
    /// <param name="range">Range of bytes to possibly glitch.</param>
    /// <param name="seed">Seed to use for RNG.</param>
    /// <param name="minByte">Minimum byte value.</param>
    /// <param name="maxByte">Maximum byte value.</param>
    public RandomProcessor(ByteRuleBase rule, string seed = null, byte minByte = 0, byte maxByte = 255)
      : base(rule)
    {
      Seed = seed;
      MinByte = minByte;
      MaxByte = maxByte;
    }

    #endregion Construction

    /// <summary>
    /// Applies this processor to
    /// the given <paramref name="bytes"/>.
    /// Randomizes a total of <see cref="ProcessorBase.NumBytesToGlitch"/>
    /// bytes by filling them with random numbers between
    /// <see cref="MinByte"/> and <see cref="MaxByte"/>.
    /// If no <see cref="Seed"/> is given, <see cref="DateTime.Now.Ticks"/>
    /// HashCode will be used as a seed.
    /// </summary>
    /// <param name="bytes">Bytes to glitch.</param>
    /// <returns>Glitched bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      // todo: create rule index pool

      Random rnd = string.IsNullOrEmpty(Seed) ? new Random(DateTime.Now.Ticks.GetHashCode()) : new Random(Seed.GetHashCode());

      while(_byteRule.NumBytesLeftToGlitch != 0)
      {
        uint byteIndex = _byteRule.GetNextByteIndex();
        bytes[byteIndex] = (byte)rnd.Next(MinByte, MaxByte);
      }

      return bytes;
    }
  }
}