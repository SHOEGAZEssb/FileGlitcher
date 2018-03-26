using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteProviders;
using FileGlitcher.Processors.ByteRules;
using NUnit.Framework;

namespace FileGlitcherTest.ProcessorTests
{
  /// <summary>
  /// Tests for the <see cref="MathProcessor"/>.
  /// </summary>
  [TestFixture]
  class MathProcessorTest
  {
    /// <summary>
    /// Tests the <see cref="Operation.Add"/> of the
    /// <see cref="MathProcessor"/> with
    /// <see cref="MathProcessor.WrapAround"/> false.
    /// </summary>
    [Test]
    public void AddNoWrapAroundTest()
    {
      // given: MathProcessor
      byte[] bytes = new byte[] { 250, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      EveryNthByte byteRule = new EveryNthByte(new ByteRange(0, (uint)bytes.Length), 1);
      MathProcessor proc = new MathProcessor(byteRule, new FixedByteProvider(10), Operation.Add, false);

      // when: applying the processor
      var actual = proc.Apply(bytes);

      // then: correctly modified
      byte[] expected = new byte[] { 255, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests the <see cref="Operation.Add"/> of the
    /// <see cref="MathProcessor"/> with
    /// <see cref="MathProcessor.WrapAround"/> true.
    /// </summary>
    [Test]
    public void AddWrapAroundTest()
    {
      // given: MathProcessor
      byte[] bytes = new byte[] { 250, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      EveryNthByte byteRule = new EveryNthByte(new ByteRange(0, (uint)bytes.Length), 1);
      MathProcessor proc = new MathProcessor(byteRule, new FixedByteProvider(10), Operation.Add, true);

      // when: applying the processor
      var actual = proc.Apply(bytes);

      // then: correctly modified
      byte[] expected = new byte[] { 4, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests the <see cref="Operation.Subtract"/> of the
    /// <see cref="MathProcessor"/> with
    /// <see cref="MathProcessor.WrapAround"/> false.
    /// </summary>
    [Test]
    public void SubtractNoWrapAroundTest()
    {
      // given MathProcessor
      byte[] bytes = new byte[] { 5, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

      EveryNthByte byteRule = new EveryNthByte(new ByteRange(0, (uint)bytes.Length), 1);
      MathProcessor proc = new MathProcessor(byteRule, new FixedByteProvider(10), Operation.Subtract, false);

      // when: applying the processor
      var actual = proc.Apply(bytes);

      // then: correctly modified
      byte[] expected = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests the <see cref="Operation.Subtract"/> of the
    /// <see cref="MathProcessor"/> with
    /// <see cref="MathProcessor.WrapAround"/> true.
    /// </summary>
    [Test]
    public void SubtractWrapAroundTest()
    {
      // given MathProcessor
      byte[] bytes = new byte[] { 5, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

      EveryNthByte byteRule = new EveryNthByte(new ByteRange(0, (uint)bytes.Length), 1);
      MathProcessor proc = new MathProcessor(byteRule, new FixedByteProvider(10), Operation.Subtract, true);

      // when: applying the processor
      var actual = proc.Apply(bytes);

      // then: correctly modified
      byte[] expected = new byte[] { 251, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}