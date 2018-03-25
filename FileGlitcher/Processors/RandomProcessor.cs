using System;
using System.Collections.Generic;

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
    /// <param name="seed">Seed to use for RNG.</param>
    /// <param name="minByte">Minimum byte value.</param>
    /// <param name="MaxByte">Maximum byte value.</param>
    public RandomProcessor(uint numBytesToGlitch, uint rangeStart, uint rangeEnd, string seed = null, byte minByte = 0, byte maxByte = 255)
      : base(numBytesToGlitch, rangeStart, rangeEnd)
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
      List<uint> possibleByteIndexes = new List<uint>();
      for(uint i = RangeStart; i <= RangeEnd; i++)
      {
        possibleByteIndexes.Add(i);
      }

      Random rnd = string.IsNullOrEmpty(Seed) ? new Random(DateTime.Now.Ticks.GetHashCode()) : new Random(Seed.GetHashCode());

      for(int i = 0; i < NumBytesToGlitch; i++)
      {
        uint byteIndex = (uint)rnd.Next(0, possibleByteIndexes.Count);
        bytes[byteIndex] = (byte)rnd.Next(MinByte, MaxByte);
        possibleByteIndexes.Remove(byteIndex);
      }

      return bytes;
    }
  }
}