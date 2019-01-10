using FileGlitcher.Processors.ByteProviders;
using FileGlitcher.Processors.ByteIndexProviders;

namespace FileGlitcher.Processors
{
  /// <summary>
  /// Mathematical operation to perform.
  /// </summary>
  public enum Operation
  {
    /// <summary>
    /// Adds the glitched byte to the original byte.
    /// </summary>
    Add,

    /// <summary>
    /// Subtracts the glitched byte from the original byte.
    /// </summary>
    Subtract
  }

  /// <summary>
  /// Processor that performs mathematical
  /// operations on the bytes to glitch.
  /// </summary>
  public class MathProcessor : ByteProvidedProcessorBase
  {
    #region Properties

    /// <summary>
    /// Mathematical operation to perform.
    /// </summary>
    public Operation OperationToPerform;

    /// <summary>
    /// If true, wraps the calculated byte if needed.
    /// </summary>
    public bool WrapAround;

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="byteRule">Byte rule to apply.</param>
    /// <param name="byteProvider">Provider of bytes.</param>
    /// <param name="operation">Mathematical operation to perform.</param>
    /// <param name="wrapAround">If true, wraps the calculated byte if needed.</param>
    public MathProcessor(ByteIndexProviderBase byteRule, IByteProvider byteProvider, Operation operation, bool wrapAround)
      : base(byteRule, byteProvider)
    {
      OperationToPerform = operation;
      WrapAround = wrapAround;
    }

    /// <summary>
    /// Applies this processor to the
    /// given <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes to apply the processor to.</param>
    /// <returns>Modified bytes.</returns>
    public override byte[] Apply(byte[] bytes)
    {
      _byteIndexProvider.CreatePossibleByteIndexes();

      while (_byteIndexProvider.ByteIndexPool.Count != 0)
      {
        uint byteIndex = _byteIndexProvider.GetNextByteIndex();
        byte original = bytes[byteIndex];
        byte value = ByteProvider.GetByte();

        switch(OperationToPerform)
        {
          case Operation.Add:
            bytes[byteIndex] = AddByte(original, value);
            break;
          case Operation.Subtract:
            bytes[byteIndex] = SubtractByte(original, value);
            break;
        }
      }

      return bytes;
    }

    /// <summary>
    /// Adds the given <paramref name="toAdd"/> to the
    /// <paramref name="original"/>.
    /// </summary>
    /// <param name="original">Original byte.</param>
    /// <param name="toAdd">Byte to add to the <paramref name="original"/>.</param>
    /// <returns>New byte.</returns>
    private byte AddByte(byte original, byte toAdd)
    {
      if (!WrapAround && (original + toAdd) > 255)
        return 255;
      else
        return (byte)(original + toAdd);
    }

    /// <summary>
    /// Subtracts the given <paramref name="toSubtract"/>
    /// from the <paramref name="original"/>.
    /// </summary>
    /// <param name="original">Original byte.</param>
    /// <param name="toSubtract">Byte to subtract from the <paramref name="original"/>.</param>
    /// <returns>New byte.</returns>
    private byte SubtractByte(byte original, byte toSubtract)
    {
      if (!WrapAround && (original - toSubtract) < 0)
        return 0;
      else
        return (byte)(original - toSubtract);
    }
  }
}