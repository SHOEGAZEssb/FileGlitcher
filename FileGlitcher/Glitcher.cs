using System;

namespace FileGlitcher
{
  /// <summary>
  /// Class used to glitch files.
  /// </summary>
  public static class Glitcher
  {
    /// <summary>
    /// Glitches the given <paramref name="bytesToGlitch"/>
    /// via the given <paramref name="config"/>.
    /// </summary>
    /// <param name="bytesToGlitch">The bytes that should be glitched.</param>
    /// <param name="config">Glitch configuration.</param>
    /// <returns>Glitched bytes.</returns>
    public static byte[] GlitchBytes(byte[] bytesToGlitch, GlitcherConfiguration config)
    {
      if (bytesToGlitch == null)
        throw new ArgumentNullException(nameof(bytesToGlitch));
      if (bytesToGlitch.Length == 0)
        throw new ArgumentException(string.Format("{0} can't be empty", nameof(bytesToGlitch)));

      if (config == null)
        throw new ArgumentNullException(nameof(config));

      byte[] bytes = (byte[])bytesToGlitch.Clone();
      foreach(var processor in config.ProcessorChain)
      {
        bytes = processor.Apply(bytes);
      }

      return bytes;
    }

    /// <summary>
    /// Glitches the given <paramref name="fileToGlitch"/>
    /// via the given <paramref name="config"/>.
    /// </summary>
    /// <param name="fileToGlitch">The file whose bytes should be glitched.</param>
    /// <param name="config">Glitch configuration.</param>
    /// <returns>Glitched file.</returns>
    public static GlitchFile GlitchFile(BaseFile fileToGlitch, GlitcherConfiguration config)
    {
      return new GlitchFile(GlitchBytes(fileToGlitch.Bytes, config));
    }
  }
}