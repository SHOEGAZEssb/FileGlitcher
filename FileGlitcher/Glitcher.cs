namespace FileGlitcher
{
  /// <summary>
  /// Class used to glitch files.
  /// </summary>
  static class Glitcher
  {
    /// <summary>
    /// Glitches a file via the given <paramref name="config"/>.
    /// </summary>
    /// <param name="config">Glitch configuration.</param>
    /// <returns>Glitched file.</returns>
    public static GlitchFile Glitch(GlitcherConfiguration config)
    {
      byte[] bytes = config.FileToGlitch.Bytes;
      foreach(var processor in config.ProcessorChain)
      {
        bytes = processor.Apply(bytes);
      }

      return new GlitchFile(bytes);
    }
  }
}