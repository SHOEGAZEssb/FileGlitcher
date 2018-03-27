using System;

namespace FileGlitcher
{
  /// <summary>
  /// Extensions for <see cref="Array"/>s.
  /// </summary>
  static class ArrayExtensions
  {
    /// <summary>
    /// Gets a subarray of the array.
    /// </summary>
    /// <typeparam name="T">Type of the array.</typeparam>
    /// <param name="data">Source array.</param>
    /// <param name="index">Starting index.</param>
    /// <param name="length">Number of items to add.</param>
    /// <returns>Subarray.</returns>
    public static T[] SubArray<T>(this T[] data, uint index, uint length)
    {
      T[] result = new T[length];
      Array.Copy(data, index, result, 0, length);
      return result;
    }
  }
}