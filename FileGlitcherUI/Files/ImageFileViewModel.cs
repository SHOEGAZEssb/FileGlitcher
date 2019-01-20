using System;
using System.Windows.Media.Imaging;

namespace FileGlitcherUI.Files
{
  /// <summary>
  /// ViewModel for a image file.
  /// </summary>
  class ImageFileViewModel : FileViewModelBase
  {
    #region Properties

    /// <summary>
    /// The actual image.
    /// </summary>
    public BitmapSource Image
    {
      get => _image;
      private set
      {
        if (Image != value)
        {
          _image = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private BitmapSource _image;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="fileName">Path to the image.</param>
    public ImageFileViewModel(string fileName)
      : base(fileName)
    {
      Image = new BitmapImage(new Uri(fileName));
    }

    #endregion Construction
  }
}