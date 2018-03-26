namespace FileGlitcher.Processors
{
  /// <summary>
  /// Base class for all glitch processors.
  /// </summary>
  public abstract class ProcessorBase
  {
    #region Properties

    /// <summary>
    /// Number of bytes to glitch.
    /// </summary>
    public uint NumBytesToGlitch;

    /// <summary>
    /// Range of bytes to possibly glitch.
    /// </summary>
    public ByteRange Range;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="numBytesToGlitch">Number of bytes to glitch.</param>
    /// <param name="range">Range of bytes to possibly glitch.</param>
    protected ProcessorBase(uint numBytesToGlitch, ByteRange range)
    {
      NumBytesToGlitch = numBytesToGlitch;
      Range = range;
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