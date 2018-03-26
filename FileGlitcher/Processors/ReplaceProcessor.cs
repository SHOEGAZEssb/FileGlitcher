using FileGlitcher.Processors.ByteProviders;
using FileGlitcher.Processors.ByteRules;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Processor that replaces bytes.
  /// </summary>
  public class ReplaceProcessor : ProcessorBase
  {
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteRule">Byte rule to apply.</param>
    /// <param name="byteProvider">Provider of bytes.</param>
    public ReplaceProcessor(ByteRuleBase byteRule, IByteProvider byteProvider)
      : base(byteRule, byteProvider)
    { }

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      // todo: initialize byterule

      while(_byteRule.NumBytesLeftToGlitch != 0)
      {
        bytes[_byteRule.GetNextByteIndex()] = ByteProvider.GetByte();
      }

      return bytes;
    }
  }
}