using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteIndexProviders;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FileGlitcherTest.ByteIndexProvidersTest
{
  /// <summary>
  /// Tests for the <see cref="EveryNthByteIndexProvider"/> rule.
  /// </summary>
  [TestFixture]
  class EveryNthByteIndexProviderTest
  {
    /// <summary>
    /// Tests the <see cref="EveryNthByteIndexProvider"/> rule
    /// with a given max byte number.
    /// </summary>
    [Test]
    public void WithMaxBytesTest()
    {
      // given: range and byte rule with max 4 bytes
      ByteRange range = new ByteRange(0, 10);
      EveryNthByteIndexProvider rule = new EveryNthByteIndexProvider(range, 4, 2);
      rule.CreatePossibleByteIndexes();

      List<uint> expectedIndexes = new List<uint>()
      {
        1,
        3,
        5,
        7
      };

      // when: getting the bytes
      List<uint> actualIndexes = new List<uint>();
      while (rule.ByteIndexPool.Count != 0)
        actualIndexes.Add(rule.GetNextByteIndex());

      // then: indexes match
      CollectionAssert.AreEqual(expectedIndexes, actualIndexes);
    }

    /// <summary>
    /// Tests the <see cref="EveryNthByteIndexProvider"/> rule
    /// without a given max byte number.
    /// </summary>
    [Test]
    public void WithoutMaxBytesTest()
    {
      // given: range and byte rule
      ByteRange range = new ByteRange(0, 11);
      EveryNthByteIndexProvider rule = new EveryNthByteIndexProvider(range, 2);
      rule.CreatePossibleByteIndexes();

      List<uint> expectedIndexes = new List<uint>()
      {
        1,
        3,
        5,
        7,
        9,
        11
      };

      // when: getting the bytes
      List<uint> actualIndexes = new List<uint>();
      while (rule.ByteIndexPool.Count != 0)
        actualIndexes.Add(rule.GetNextByteIndex());

      // then: indexes match
      CollectionAssert.AreEqual(expectedIndexes, actualIndexes);
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

    /// <summary>
    /// Tests if incorrect max byte amount
    /// throws the correct exception.
    /// </summary>
    [Test]
    public void IncorrectMaxBytesTest()
    {
      // when: trying to create a rule with incorrect max bytes
      // then: ArgumentOutOfRangeException
      Assert.That(() => new EveryNthByteIndexProvider(new ByteRange(0, 10), 0, 2), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
  }
}