using System.IO;

namespace FileGlitcher
{
  /// <summary>
  /// A file to glitch.
  /// </summary>
  class BaseFile
  {
    #region Properties

    /// <summary>
    /// Number of bytes of the header of the file.
    /// </summary>
    public uint NumHeaderBytes { get; private set; }

    /// <summary>
    /// The raw byte data of the file.
    /// </summary>
    public byte[] Bytes { get; private set; }

    /// <summary>
    /// The path of the file.
    /// </summary>
    public string FileName { get; private set; }

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="file">File to open.</param>
    public BaseFile(string file)
    {
      Bytes = File.ReadAllBytes(file);
    }
  }
}