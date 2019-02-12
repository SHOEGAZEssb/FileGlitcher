using FileGlitcher.Processors.ByteProviders;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Processor that replaces bytes.
  /// </summary>
  public class ReplaceProcessor : ByteProvidedIProcessor
  {
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteProvider">Provider of bytes.</param>
    public ReplaceProcessor(IByteProvider byteProvider)
      : base(byteProvider)
    { }

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      byte[] glitchedBytes = new byte[bytes.Length];

      for(int i = 0; i < glitchedBytes.Length; i++)
        glitchedBytes[i] = ByteProvider.GetByte();

      return glitchedBytes;
    }
  }
}