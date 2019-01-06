using Caliburn.Micro;
using FileGlitcher;

namespace FileGlitcherUI.Files
{
  class FileViewModelBase : Screen
  {
    public byte[] Bytes => _file.Bytes;

    #region Member

    protected BaseFile _file;

    #endregion Member

    #region Construction

    public FileViewModelBase(string fileName)
    {
      _file = new BaseFile(fileName);
    }

    #endregion Construction
  }
}
