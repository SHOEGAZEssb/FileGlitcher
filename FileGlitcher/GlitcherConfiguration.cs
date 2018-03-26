using FileGlitcher.Processors;
using System.Collections.Generic;

namespace FileGlitcher
{
  /// <summary>
  /// Configuration for the <see cref="Glitcher"/>.
  /// </summary>
  public class GlitcherConfiguration
  {
    #region Properties

    /// <summary>
    /// The processor chain used to
    /// glitch the bytes.
    /// </summary>
    public List<ProcessorBase> ProcessorChain { get; private set; }

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    public GlitcherConfiguration()
    {
      ProcessorChain = new List<ProcessorBase>();
    }
  }
}