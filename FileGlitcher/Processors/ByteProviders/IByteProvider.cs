namespace FileGlitcher.Processors.ByteProviders
{
  /// <summary>
  /// Interface for a class providing the glitched bytes.
  /// </summary>
  public interface IByteProvider
  {
    /// <summary>
    /// Gets the next byte.
    /// </summary>
    /// <returns>Byte.</returns>
    byte GetByte();
  }
}