using FileGlitcher;
using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteIndexProviders;
using FileGlitcher.Processors.ByteProviders;
using NUnit.Framework;

namespace FileGlitcherTest
{
  /// <summary>
  /// Tests for the <see cref="Glitcher"/>.
  /// </summary>
  [TestFixture]
  class GlitcherTests
  {
    /// <summary>
    /// Tests if glitching with multiple processors work.
    /// </summary>
    [Test]
    public void MultipleProcessorTest()
    {
      // given: glitcher configuration with multiple processors
      byte[] bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      GlitcherConfiguration config = new GlitcherConfiguration();
      BitShiftProcessor bitShiftProcessor = new BitShiftProcessor(new FixedByteProvider(1), ShiftDirection.Left);
      MathProcessor mathProcessor = new MathProcessor(new FixedByteProvider(1), Operation.Add, false);
      config.ProcessorChain.Add(bitShiftProcessor, new EveryNthByteIndexProvider(new ByteRange(0, 5), 1));
      config.ProcessorChain.Add(mathProcessor, new EveryNthByteIndexProvider(new ByteRange(0, (uint)bytes.Length), 1));

      // when: glitching
      byte[] actual = Glitcher.GlitchBytes(bytes, config);

      // then: bytes are correct
      byte[] expected = new byte[] { 1, 3, 5, 7, 9, 6, 7, 8, 9, 10 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests if the correct exception is thrown
    /// when no <see cref="GlitcherConfiguration"/> is provided.
    /// </summary>
    [Test]
    public void NoGlitcherConfigurationTest()
    {
      // when: trying to glitch without a GlitcherConfiguration
      // then: ArgumentNullException
      Assert.That(() => Glitcher.GlitchBytes(new byte[] { 0, 1, 2, 3, 4 }, null), Throws.ArgumentNullException);
    }

    /// <summary>
    /// Tests if the correct exception is thrown
    /// when no bytes to glitch are provided.
    /// </summary>
    [Test]
    public void NoBytesToGlitchTest()
    {
      // when: trying to glitch without a GlitcherConfiguration
      // then: ArgumentNullException
      Assert.That(() => Glitcher.GlitchBytes(null, new GlitcherConfiguration()), Throws.ArgumentNullException);
    }

    /// <summary>
    /// Tests if the correct exception is thrown
    /// when bytes to glitch are empty.
    /// </summary>
    [Test]
    public void EmptyBytesToGlitchTest()
    {
      // when: trying to glitch without a GlitcherConfiguration
      // then: ArgumentNullException
      Assert.That(() => Glitcher.GlitchBytes(new byte[0], new GlitcherConfiguration()), Throws.ArgumentException);
    }
  }
}