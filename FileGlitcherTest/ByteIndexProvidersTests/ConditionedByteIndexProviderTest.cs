using FileGlitcher.Processors;
using FileGlitcher.Processors.ByteIndexProviders;
using NUnit.Framework;
using System.Collections.Generic;

namespace FileGlitcherTest.ByteIndexProvidersTests
{
  /// <summary>
  /// Tests for the <see cref="ConditionedByteIndexProvider"/>.
  /// </summary>
  [TestFixture]
  class ConditionedByteIndexProviderTest
  {
    /// <summary>
    /// Tests if the correct byte indexes are provided.
    /// </summary>
    [Test]
    public void ProvideTest()
    {
      // given: processor
      byte[] bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      ConditionedByteIndexProvider processor = new ConditionedByteIndexProvider(new ByteRange(0, (uint)bytes.Length), bytes, b => b > 5);

      // when: getting the indexes
      List<uint> actual = new List<uint>();
      while (processor.ByteIndexPool.Count != 0)
        actual.Add(processor.GetNextByteIndex());

      // then: correct indexes provided
      byte[] expected = new byte[] { 6, 7, 8, 9 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests if the correct exception is thrown
    /// when no bytes are given.
    /// </summary>
    [Test]
    public void NoBytesTest()
    {
      // when: creating without bytes
      // then: ArgumentNullException
      Assert.That(() => new ConditionedByteIndexProvider(new ByteRange(0, 10), null, b => b > 5), Throws.ArgumentNullException);
    }

    /// <summary>
    /// Tests if the correct exception is thrown
    /// when empty bytes are given.
    /// </summary>
    [Test]
    public void EmptyBytesTest()
    {
      // when: creating with empty bytes
      // then: ArgumentException
      Assert.That(() => new ConditionedByteIndexProvider(new ByteRange(0, 10), new byte[0], b => b > 5), Throws.ArgumentException);
    }

    /// <summary>
    /// Tests if the correct exception is thrown
    /// when no condition predicate is given.
    /// </summary>
    [Test]
    public void NoConditionPredicateTest()
    {
      // when: creating with no condition predicate
      // then: ArgumentNullException
      Assert.That(() => new ConditionedByteIndexProvider(new ByteRange(0, 10), new byte[10], null), Throws.ArgumentNullException);
    }
  }
}