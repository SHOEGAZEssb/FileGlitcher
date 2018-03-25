using System.IO;

namespace FileGlitcher.Models
{
  /// <summary>
  /// A glitched file.
  /// </summary>
  class GlitchFile
  {
    #region Properties

    /// <summary>
    /// The glitched bytes.
    /// </summary>
    public byte[] Bytes { get; private set; }

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="bytes">The data of the glitched files.</param>
    public GlitchFile(byte[] bytes)
    {
      Bytes = bytes;
    }

    /// <summary>
    /// Saves the <see cref="Bytes"/> to
    /// the given <paramref name="fileName"/>.
    /// </summary>
    /// <param name="fileName">Path of the file to save.</param>
    public void Save(string fileName)
    {
      File.WriteAllBytes(fileName, Bytes);
    }
  }
}