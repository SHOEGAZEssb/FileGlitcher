using System;

namespace FileGlitcher.Processors.ByteProviders
{
  /// <summary>
  /// Provides a specific set of bytes.
  /// </summary>
  public class ByteProvider : IByteProvider
  {
    #region Properties

    /// <summary>
    /// The byte pool.
    /// </summary>
    public byte[] Bytes;

    #endregion Properties

    #region Member

    /// <summary>
    /// Last used byte index.
    /// </summary>
    private uint _lastByteIndex;

    #endregion Member

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="bytesToProvide">Bytes to provide.</param>
    public ByteProvider(byte[] bytesToProvide)
    {
      if (bytesToProvide == null)
        throw new ArgumentNullException(nameof(bytesToProvide));
      if (bytesToProvide.Length == 0)
        throw new ArgumentException(string.Format("{0} can't be empty", nameof(bytesToProvide)));

      Bytes = bytesToProvide;
    }

    #endregion Construction

    /// <summary>
    /// Gets the next byte.
    /// </summary>
    /// <returns>Byte.</returns>
    public byte GetByte()
    {
      if (_lastByteIndex == Bytes.Length)
        _lastByteIndex = 0;
      return Bytes[_lastByteIndex++];
    }
  }
}