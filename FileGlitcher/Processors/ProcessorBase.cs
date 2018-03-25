namespace FileGlitcher.Processors
{
  /// <summary>
  /// Base class for all glitch processors.
  /// </summary>
  abstract class ProcessorBase
  {
    #region Properties

    /// <summary>
    /// Number of bytes to glitch.
    /// </summary>
    public uint NumBytesToGlitch;

    /// <summary>
    /// Byte number of the start of
    /// the range to possibly glitch.
    /// </summary>
    public uint RangeStart;

    /// <summary>
    /// Byte number of the end of
    /// the range to possibly glitch.
    /// </summary>
    public uint RangeEnd;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="numBytesToGlitch">Number of bytes to glitch.</param>
    /// <param name="rangeStart">Byte number of the start of
    /// the range to possibly glitch.</param>
    /// <param name="rangeEnd">Byte number of the end of
    /// the range to possibly glitch.</param>
    protected ProcessorBase(uint numBytesToGlitch, uint rangeStart, uint rangeEnd)
    {
      NumBytesToGlitch = numBytesToGlitch;
      RangeStart = rangeStart;
      RangeEnd = rangeEnd;
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