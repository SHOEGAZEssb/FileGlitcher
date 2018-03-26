﻿using System;

namespace FileGlitcher.Processors.ByteProviders
{
  /// <summary>
  /// Provides random generated bytes.
  /// </summary>
  public class RandomByteProvider : IByteProvider
  {
    #region Properties

    /// <summary>
    /// Seed to use for byte generation.
    /// </summary>
    public int Seed
    {
      get { return _seed; }
      set
      {
        _seed = value;
        _random = new Random(Seed);
      }
    }
    private int _seed;

    /// <summary>
    /// Minimum byte value to generate.
    /// </summary>
    public byte MinByte
    {
      get { return _minByte; }
      set
      {
        if (value > MaxByte)
          throw new ArgumentOutOfRangeException(nameof(MinByte));
        _minByte = value;
      }
    }
    private byte _minByte;

    /// <summary>
    /// Maximum byte value to generate.
    /// </summary>
    public byte MaxByte
    {
      get { return _maxByte; }
      set
      {
        if (value < MinByte)
          throw new ArgumentOutOfRangeException(nameof(MaxByte));
        _maxByte = value;
      }
    }
    private byte _maxByte;

    #endregion Properties

    #region Member

    /// <summary>
    /// Random number generator.
    /// </summary>
    private Random _random;

    #endregion Member

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    public RandomByteProvider()
      : this(DateTime.Now.Ticks.GetHashCode(), 0, 255)
    { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="seed">Seed to use for byte generation.</param>
    /// <param name="minByte">Minimum byte value to generate.</param>
    /// <param name="maxByte">Maximum byte value to generate.</param>
    public RandomByteProvider(int seed, byte minByte, byte maxByte)
    {
      Seed = seed;
      MinByte = minByte;
      MaxByte = maxByte;
    }

    #endregion Construction

    /// <summary>
    /// Generates a random byte.
    /// </summary>
    /// <returns>Random generated byte.</returns>
    public byte GetByte()
    {
      return (byte)_random.Next(MinByte, MaxByte);
    }
  }
}