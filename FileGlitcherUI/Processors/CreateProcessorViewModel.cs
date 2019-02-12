using Caliburn.Micro;
using FileGlitcherUI.Files;
using FileGlitcherUI.Processors.ByteIndexProvider;

namespace FileGlitcherUI.Processors
{
  public enum ProcessorType
  {
    BitShiftProcessor,
    MathProcessor,
    ReplaceProcessor,
    ShuffleProcessor
  }

  class CreateProcessorViewModel : Screen
  {
    #region Properties

    public ProcessorType SelectedProcessorType
    {
      get => _selectedProcessorType;
      set
      {
        if(SelectedProcessorType != value)
        {
          _selectedProcessorType = value;
          NotifyOfPropertyChange();
          CreateProcessorVM();
        }
      }
    }
    private ProcessorType _selectedProcessorType;

    public CreateByteIndexProviderViewModel CreateByteIndexProviderVM
    {
      get => _createByteIndexProviderVM;
      private set
      {
        if(CreateByteIndexProviderVM != value)
        {
          _createByteIndexProviderVM = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private CreateByteIndexProviderViewModel _createByteIndexProviderVM;

    public ProcessorViewModelBase ProcessorVM
    {
      get => _processorVM;
      private set
      {
        if(ProcessorVM != value)
        {
          _processorVM = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private ProcessorViewModelBase _processorVM;

    #endregion Properties

    #region Construction

    public CreateProcessorViewModel(FileViewModelBase file)
    {
      CreateByteIndexProviderVM = new CreateByteIndexProviderViewModel(file);
    }

    #endregion Construction

    private void CreateProcessorVM()
    {
      switch (SelectedProcessorType)
      {
        case ProcessorType.ShuffleProcessor:
          ProcessorVM = new ShuffleProcessorViewModel();
          break;
        default:
          ProcessorVM = null;
          break;
      }
    }
  }
}