namespace FileGlitcher.Processors.ByteProviders
{
  /// <summary>
  /// Provides a fixed byte value.
  /// </summary>
  public class FixedByteProvider : IByteProvider
  {
    #region Properties

    /// <summary>
    /// Byte to provide.
    /// </summary>
    public byte Value;

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">Byte to provide.</param>
    public FixedByteProvider(byte value)
    {
      Value = value;
    }

    /// <summary>
    /// Provides the <see cref="Value"/>.
    /// </summary>
    /// <returns><see cref="Value"/>.</returns>
    public byte GetByte()
    {
      return Value;
    }
  }
}