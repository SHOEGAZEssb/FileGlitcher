using FileGlitcher.Processors.ByteProviders;
using FileGlitcher.Processors.ByteRules;
using System;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Base class for all glitch processors.
  /// </summary>
  public abstract class ProcessorBase
  {
    #region Properties

    /// <summary>
    /// Object providing bytes.
    /// </summary>
    public IByteProvider ByteProvider;

    #endregion Properties

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
    /// <param name="byteProvider">Provider of bytes.</param>
    protected ProcessorBase(ByteRuleBase byteRule, IByteProvider byteProvider)
    {
      _byteRule = byteRule;
      ByteProvider = byteProvider ?? throw new ArgumentNullException(nameof(byteProvider));
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