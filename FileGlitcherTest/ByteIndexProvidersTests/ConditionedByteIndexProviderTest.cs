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