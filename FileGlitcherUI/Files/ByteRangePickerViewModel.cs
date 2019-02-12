using Caliburn.Micro;
using FileGlitcher.Processors;
using System;

namespace FileGlitcherUI.Files
{
  class ByteRangePickerViewModel : Screen
  {
    #region Properties

    public int Maximum => _file.Bytes.Length;

    public int From
    {
      get => _from;
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException("'From' must be >= 0");
        else if(value > Maximum)
          throw new ArgumentOutOfRangeException($"'From' must be >= {Maximum}");

        if (From != value)
        {
          _from = value;
          NotifyOfPropertyChange();
          NotifyOfPropertyChange(() => CreatedByteRange);
        }
      }
    }
    private int _from;

    public int To
    {
      get => _to;
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException("'From' must be >= 0");
        else if (value > Maximum)
          throw new ArgumentOutOfRangeException($"'From' must be >= {Maximum}");

        if (To != value)
        {
          _to = value;
          NotifyOfPropertyChange();
          NotifyOfPropertyChange(() => CreatedByteRange);
        }
      }
    }
    private int _to;

    public ByteRange CreatedByteRange => new ByteRange((uint)From, (uint)To);

    #endregion Properties

    #region Member

    private FileViewModelBase _file;

    #endregion Member

    #region Construction

    public ByteRangePickerViewModel(FileViewModelBase baseFile)
    {
      _file = baseFile;
      From = 0;
      To = Maximum;
    }

    #endregion Construction
  }
}