using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteIndexProviders;
using FileGlitcher.Processors.ByteProviders;
using NUnit.Framework;

namespace FileGlitcherTest.ProcessorTests
{
  /// <summary>
  /// Tests for the <see cref="BitShiftProcessor"/>.
  /// </summary>
  [TestFixture]
  class BitShiftProcessorTest
  {
    /// <summary>
    /// Tests if shifting right works.
    /// </summary>
    [Test]
    public void ShiftRightTest()
    {
      // given: BitShiftProcessor
      byte[] bytes = new byte[] { 0, 1, 2, 3, 4 };
      BitShiftProcessor proc = new BitShiftProcessor(new EveryNthByteIndexProvider(new ByteRange(0, (uint)bytes.Length), 1), new FixedByteProvider(1), ShiftDirection.Right);

      // when: executing the processor
      var actual = proc.Apply(bytes);

      // then: correctly modified
      byte[] expected = new byte[] { 0, 0, 1, 1, 2 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests if shifting left works.
    /// </summary>
    [Test]
    public void ShiftLeftTest()
    {
      // given: BitShiftProcessor
      byte[] bytes = new byte[] { 0, 1, 2, 3, 4 };
      BitShiftProcessor proc = new BitShiftProcessor(new EveryNthByteIndexProvider(new ByteRange(0, (uint)bytes.Length), 1), new FixedByteProvider(1), ShiftDirection.Left);

      // when: executing the processor
      var actual = proc.Apply(bytes);

      // then: correctly modified
      byte[] expected = new byte[] { 0, 2, 4, 6, 8 };
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}