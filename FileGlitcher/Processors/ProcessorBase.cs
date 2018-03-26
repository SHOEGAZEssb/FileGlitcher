using FileGlitcher.Processors.ByteRules;

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
    protected ByteRuleBase _byteRule;

    #endregion Member

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteRule">Byte rule to apply.</param>
    protected ProcessorBase(ByteRuleBase byteRule)
    {
      _byteRule = byteRule;
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