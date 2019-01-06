using Caliburn.Micro;
using System.Windows;

namespace FileGlitcherUI
{
  class AppBootstrapper : BootstrapperBase
  {
    public AppBootstrapper()
    {
      Initialize();
    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
      DisplayRootViewFor<MainViewModel>();
    }
  }
}