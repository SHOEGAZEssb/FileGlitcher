using Caliburn.Micro;

namespace FileGlitcherUI
{
  class MainViewModel : Screen
  {
    #region Properties

    public GlitcherViewModel GlitcherVM
    {
      get => _glitcherVM;
      private set
      {
        if(GlitcherVM != value)
        {
          _glitcherVM = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private GlitcherViewModel _glitcherVM;

    #endregion Properties

    #region Construction

    public MainViewModel()
    {
      GlitcherVM = new GlitcherViewModel();
    }

    #endregion Construction
  }
}