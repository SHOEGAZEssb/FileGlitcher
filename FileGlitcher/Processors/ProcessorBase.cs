using FileGlitcher.Processors.ByteIndexProviders;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Base class for all glitch processors.
  /// </summary>
  public abstract class ProcessorBase
  {
    #region Member

    /// <summary>
    /// Byte rule to apply.
    /// </summary>
    protected ByteIndexProviderBase _byteIndexProvider;

    #endregion Member

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteIndexProvider">Byte rule to apply.</param>
    protected ProcessorBase(ByteIndexProviderBase byteIndexProvider)
    {
      _byteIndexProvider = byteIndexProvider;
    }

    #endregion Construction

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public abstract byte[] Apply(byte[] bytes);
  }
}