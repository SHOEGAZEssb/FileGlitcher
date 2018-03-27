using FileGlitcher.Processors.ByteIndexProviders;
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
  public class BitShiftProcessor : ByteProvidedProcessorBase
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
    /// <param name="byteIndexProvider">Provider of byte indexes.</param>
    /// <param name="byteProvider">Provider of byte values.</param>
    /// <param name="direction">Direction to shift the bits.</param>
    public BitShiftProcessor(ByteIndexProviderBase byteIndexProvider, IByteProvider byteProvider, ShiftDirection direction) 
      : base(byteIndexProvider, byteProvider)
    {
      Direction = direction;
    }

    #endregion Construction

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      // todo: byterule

      while(_byteIndexProvider.ByteIndexPool.Count != 0)
      {
        uint byteIndex = _byteIndexProvider.GetNextByteIndex();
        byte byteToShift = bytes[byteIndex];
        if (Direction == ShiftDirection.Left)
          bytes[byteIndex] = (byte)(byteToShift << ByteProvider.GetByte());
        else
          bytes[byteIndex] = (byte)(byteToShift >> ByteProvider.GetByte());
      }

      return bytes;
    }
  }
}