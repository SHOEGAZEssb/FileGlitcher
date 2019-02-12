namespace FileGlitcher.Processors
{
  /// <summary>
  /// Base class for all glitch processors.
  /// </summary>
  public interface IProcessor
  {
    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    byte[] Apply(byte[] bytes);
  }
}