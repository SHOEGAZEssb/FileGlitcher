using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteProviders;
using NUnit.Framework;

namespace FileGlitcherTest.ProcessorTests
{
  /// <summary>
  /// Tests for the <see cref="ReplaceProcessor"/>.
  /// </summary>
  [TestFixture]
  class ReplaceProcessorTest
  {
    /// <summary>
    /// Tests the <see cref="ReplaceProcessor.Apply(byte[])"/>.
    /// </summary>
    [Test]
    public void ReplaceTest()
    {
      // given: ReplaceProcessor
      byte[] bytes = new byte[] { 0, 1, 2, 3, 4 };
      ReplaceProcessor proc = new ReplaceProcessor(new FixedByteProvider(5));

      // when: applying the processor
      var actual = proc.Apply(bytes);

      // then: correctly modified
      byte[] expected = new byte[] { 5, 5, 5, 5, 5 };
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}