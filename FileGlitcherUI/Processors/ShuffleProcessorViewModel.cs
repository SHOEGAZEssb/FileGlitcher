using FileGlitcher.Processors;

namespace FileGlitcherUI.Processors
{
  class ShuffleProcessorViewModel : ProcessorViewModelBase
  {
    #region Properties

    public override IProcessor Processor => _processor;
    private ShuffleProcessor _processor;

    #endregion Properties

    #region Construction

    public ShuffleProcessorViewModel()
    {

    }

    #endregion Construction
  }
}
