using System.IO;

namespace FileGlitcherUI.Files
{
  static class FileViewModelFactory
  {
    public static FileViewModelBase CreateViewModel(string fileName)
    {
      switch (Path.GetExtension(fileName).ToLower())
      {
        case ".bmp":
        case ".png":
        case ".jpeg":
        case ".jpg":
          return new ImageFileViewModel(fileName);
        default:
          return new FileViewModelBase(fileName);
      }
    }
  }
}
