using System;
using FileGlitcher.Processors.ByteProviders;
using FileGlitcher.Processors.ByteIndexProviders;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Base class for all processors whose
  /// values are provided by an <see cref="IByteProvider"/>.
  /// </summary>
  public abstract class ByteProvidedProcessorBase : ProcessorBase
  {
    #region Properties

    /// <summary>
    /// Object providing bytes.
    /// </summary>
    public IByteProvider ByteProvider;

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteIndexProvider">Provider of byte indexes..</param>
    /// <param name="byteProvider">Provider of bytes to use.</param>
    public ByteProvidedProcessorBase(ByteIndexProviderBase byteIndexProvider, IByteProvider byteProvider)
      : base(byteIndexProvider)
    {
      ByteProvider = byteProvider ?? throw new ArgumentNullException(nameof(byteProvider));
    }
  }
}