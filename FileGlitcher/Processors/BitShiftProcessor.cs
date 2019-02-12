using FileGlitcher.Processors.ByteProviders;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Direction to shift the bits.
  /// </summary>
  public enum ShiftDirection
  {
    /// <summary>
    /// Bits should be shifted right.
    /// </summary>
    Right,

    /// <summary>
    /// Bits should be shifted right.
    /// </summary>
    Left
  }

  /// <summary>
  /// Processor that shifts bits.
  /// </summary>
  public class BitShiftProcessor : ByteProvidedIProcessor
  {
    #region Properties

    /// <summary>
    /// Direction to shift the bits.
    /// </summary>
    public ShiftDirection Direction;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteProvider">Provider of byte values.</param>
    /// <param name="direction">Direction to shift the bits.</param>
    public BitShiftProcessor(IByteProvider byteProvider, ShiftDirection direction)
      : base(byteProvider)
    {
      Direction = direction;
    }

    #endregion Construction

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <returns>Modified bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      byte[] glitchedBytes = new byte[bytes.Length];

      for(int i = 0; i < glitchedBytes.Length; i++)
      {
        byte byteToShift = bytes[i];
        if (Direction == ShiftDirection.Left)
          glitchedBytes[i] = (byte)(byteToShift << ByteProvider.GetByte());
        else
          glitchedBytes[i] = (byte)(byteToShift >> ByteProvider.GetByte());
      }

      return glitchedBytes;
    }
  }
}