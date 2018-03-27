using FileGlitcher.Processors.ByteProviders;
using NUnit.Framework;
using System.Collections.Generic;

namespace FileGlitcherTest.ByteProvidersTests
{
  /// <summary>
  /// Tests for the <see cref="FixedByteProvider"/>
  /// </summary>
  [TestFixture]
  class FixedByteProviderTest
  {
    /// <summary>
    /// Tests if the correct values are provided.
    /// </summary>
    [Test]
    public void ProvideTest()
    {
      // given: FixedByteProvider
      FixedByteProvider provider = new FixedByteProvider(10);

      // when: getting some values
      List<byte> actual = new List<byte>()
      {
        provider.GetByte(),
        provider.GetByte(),
        provider.GetByte()
      };

      // then: correct values where provided
      List<byte> expected = new List<byte>() { 10, 10, 10 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests if the correct values are provided,
    /// when the value is changed after the initialization
    /// of the <see cref="FixedByteProvider"/>.
    /// </summary>
    [Test]
    public void ProvideChangedValueTest()
    {
      // given: FixedByteProvider
      FixedByteProvider provider = new FixedByteProvider(10);

      // when: changing the value and getting some values
      provider.Value = 15;
      List<byte> actual = new List<byte>()
      {
        provider.GetByte(),
        provider.GetByte(),
        provider.GetByte()
      };

      // then: correct values where provided
      List<byte> expected = new List<byte>() { 15, 15, 15 };
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}