using System;
using System.Windows.Media.Imaging;

namespace FileGlitcherUI.Files
{
  class ImageFileViewModel : FileViewModelBase
  {
    #region Properties

    public BitmapSource Image
    {
      get => _image;
      private set
      {
        if(Image != value)
        {
          _image = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private BitmapSource _image;

    #endregion Properties

    #region Construction

    public ImageFileViewModel(string fileName)
      : base(fileName)
    {
      Image = new BitmapImage(new Uri(fileName));
    }

    #endregion Construction
  }
}
