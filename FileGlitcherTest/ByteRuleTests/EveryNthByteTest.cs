﻿using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteRules;
using NUnit.Framework;
using System.Collections.Generic;

namespace FileGlitcherTest.ByteRuleTests
{
  /// <summary>
  /// Tests for the <see cref="EveryNthByte"/> rule.
  /// </summary>
  [TestFixture]
  class EveryNthByteTest
  {
    /// <summary>
    /// Tests the <see cref="EveryNthByte"/> rule
    /// with a given max byte number.
    /// </summary>
    [Test]
    public void WithMaxBytesTest()
    {
      // given: range and byte rule with max 4 bytes
      ByteRange range = new ByteRange(0, 10);
      EveryNthByte rule = new EveryNthByte(range, 4, 2);

      List<uint> expectedIndexes = new List<uint>()
      {
        1,
        3,
        5,
        7
      };

      // when: getting the bytes
      List<uint> actualIndexes = new List<uint>();
      while (rule.NumBytesLeftToGlitch != 0)
        actualIndexes.Add(rule.GetNextByteIndex());

      // then: indexes match
      CollectionAssert.AreEqual(expectedIndexes, actualIndexes);
    }

    /// <summary>
    /// Tests the <see cref="EveryNthByte"/> rule
    /// without a given max byte number.
    /// </summary>
    [Test]
    public void WithoutMaxBytesTest()
    {
      // given: range and byte rule
      ByteRange range = new ByteRange(0, 11);
      EveryNthByte rule = new EveryNthByte(range, 2);

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
      while (rule.NumBytesLeftToGlitch != 0)
        actualIndexes.Add(rule.GetNextByteIndex());

      // then: indexes match
      CollectionAssert.AreEqual(expectedIndexes, actualIndexes);
    }
  }
}