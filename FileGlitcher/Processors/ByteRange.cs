namespace FileGlitcher.Processors
{
  /// <summary>
  /// Range of bytes to glitch.
  /// </summary>
  public struct ByteRange
  {
    /// <summary>
    /// Start index of the byte range.
    /// </summary>
    public uint Start;

    /// <summary>
    /// End index of the byte range.
    /// </summary>
    public uint End;

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="start">Start index of the byte range.</param>
    /// <param name="end">End index of the byte range.</param>
    public ByteRange(uint start, uint end)
    {
      Start = start;
      End = end;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="file">File whose range to use.</param>
    /// <param name="excludeHeaderBytes">If true, important header bytes
    /// are not included in the range, to make sure that the file
    /// can be read afterwards.</param>
    public ByteRange(BaseFile file, bool excludeHeaderBytes)
      : this(excludeHeaderBytes ? 0 + file.NumHeaderBytes : 0, (uint)file.Bytes.Length)
    { }

    #endregion Construction
  }
}