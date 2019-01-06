namespace FileGlitcher
{
  /// <summary>
  /// Interface for a loaded file.
  /// </summary>
  public interface IFile
  {
    /// <summary>
    /// The raw byte data of the file.
    /// </summary>
    byte[] Bytes { get; }
  }
}
