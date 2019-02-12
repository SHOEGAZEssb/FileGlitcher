using Caliburn.Micro;
using FileGlitcher.Processors;

namespace FileGlitcherUI.Processors
{
  abstract class ProcessorViewModelBase : Screen
  {
    #region Properties

    public abstract IProcessor Processor { get; }

    #endregion Properties
  }
}