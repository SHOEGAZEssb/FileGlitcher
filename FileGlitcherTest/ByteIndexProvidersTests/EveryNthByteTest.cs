using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteIndexProviders;
using NUnit.Framework;
using System;

namespace FileGlitcherTest.ByteIndexProvidersTest
{
  /// <summary>
  /// Tests for the <see cref="EveryNthByteIndexProvider"/> rule.
  /// </summary>
  [TestFixture]
  class EveryNthByteIndexProviderTest
  {
    /// <summary>
    /// Tests the created byte indexes.
    /// </summary>
    [Test]
    public void ByteIndexesTest()
    {
      // given: index provider
      var provider = new EveryNthByteIndexProvider(new ByteRange(0, 10), 2);

      int[] expected = new[] { 1, 3, 5, 7, 9 };

      // then:
      CollectionAssert.AreEqual(expected, provider.ByteIndexPool);
    }

    /// <summary>
    /// Tests if incorrect n throws the correct
    /// exception.
    /// </summary>
    [Test]
    public void IncorrectNTest()
    {
      // when: trying to create a rule with incorrect n
      // then: ArgumentOutOfRangeException
      Assert.That(() => new EveryNthByteIndexProvider(new ByteRange(0, 10), 0), Throws.InstanceOf<ArgumentOutOfRangeException>());
      Assert.That(() => new EveryNthByteIndexProvider(new ByteRange(0, 10), 11), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
  }
}