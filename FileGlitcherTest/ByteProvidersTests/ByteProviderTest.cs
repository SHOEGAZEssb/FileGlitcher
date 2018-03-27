using FileGlitcher.Processors.ByteProviders;
using NUnit.Framework;

namespace FileGlitcherTest.ByteProvidersTests
{
  /// <summary>
  /// Tests for the <see cref="ByteProvider"/>
  /// </summary>
  [TestFixture]
  class ByteProviderTest
  {
    /// <summary>
    /// Tests if the correct values are provided.
    /// </summary>
    [Test]
    public void ProvideTest()
    {
      // given: ByteProvider with bytes
      byte[] bytes = new byte[] { 0, 1, 2, 3, 4 };
      ByteProvider provider = new ByteProvider(bytes);

      // when: getting the bytes
      byte[] actual = new byte[10];
      for(int i = 0; i < actual.Length; i++)
      {
        actual[i] = provider.GetByte();
      }

      // then: correct bytes were provided.
      byte[] expected = new byte[] { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
      CollectionAssert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests that the correct exception
    /// is thrown when no bytes are provided.
    /// </summary>
    [Test]
    public void NoBytesToProvideTest()
    {
      // when: creating a ByteProvider with no bytes
      // then: ArgumentNullException
      Assert.That(() => new ByteProvider(null), Throws.ArgumentNullException);
    }

    /// <summary>
    /// Tests that the correct exception
    /// is thrown when empty bytes are provided.
    /// </summary>
    [Test]
    public void EmptyBytesToProvideTest()
    {
      // when: creating a ByteProvider with no bytes
      // then: ArgumentNullException
      Assert.That(() => new ByteProvider(new byte[0]), Throws.ArgumentException);
    }
  }
}