using FileGlitcher.Processors.ByteProviders;
using System;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Base class for all processors whose
  /// values are provided by an <see cref="IByteProvider"/>.
  /// </summary>
  public abstract class ByteProvidedIProcessor : IProcessor
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
    /// <param name="byteProvider">Provider of bytes to use.</param>
    public ByteProvidedIProcessor(IByteProvider byteProvider)
    {
      ByteProvider = byteProvider ?? throw new ArgumentNullException(nameof(byteProvider));
    }

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public abstract byte[] Apply(byte[] bytes);
  }
}