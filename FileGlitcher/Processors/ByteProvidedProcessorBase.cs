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

    public ByteProvidedProcessorBase(ByteIndexProviderBase byteRule, IByteProvider byteProvider)
      : base(byteRule)
    {
      ByteProvider = byteProvider ?? throw new ArgumentNullException(nameof(byteProvider));
    }
  }
}