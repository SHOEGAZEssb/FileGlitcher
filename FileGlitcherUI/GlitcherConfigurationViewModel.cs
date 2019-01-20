using Caliburn.Micro;
using FileGlitcher;
using FileGlitcherUI.Files;
using FileGlitcherUI.Processors;
using System;
using System.Collections.ObjectModel;

namespace FileGlitcherUI
{
  class GlitcherConfigurationViewModel : Screen
  {
    #region Properties

    public GlitcherConfiguration Configuration
    {
      get => _configuration;
      private set
      {
        if(Configuration != value)
        {
          _configuration = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private GlitcherConfiguration _configuration;

    public ObservableCollection<ProcessorViewModelBase> Processors
    {
      get => _processors;
      private set
      {
        if(Processors != value)
        {
          _processors = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private ObservableCollection<ProcessorViewModelBase> _processors;

    public ProcessorViewModelBase SelectedProcessor
    {
      get => _selectedProcessor;
      set
      {
        if(SelectedProcessor != value)
        {
          _selectedProcessor = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private ProcessorViewModelBase _selectedProcessor;

    #endregion Properties

    #region Member

    private FileViewModelBase _fileVM;

    #endregion Member

    #region Construction

    public GlitcherConfigurationViewModel(FileViewModelBase fileVM)
    {
      Configuration = new GlitcherConfiguration();
      Processors = new ObservableCollection<ProcessorViewModelBase>();
      _fileVM = fileVM;
    }

    #endregion Construction

    public void AddProcessor()
    {
      WindowManager w = new WindowManager();
      var vm = new CreateProcessorViewModel(_fileVM);
      if (w.ShowDialog(vm) ?? false)
      {
        Configuration.ProcessorChain.Add(vm.ProcessorVM.Processor);
        Processors.Add(vm.ProcessorVM);
      }
    }

    public void RemoveProcessor()
    {
      if (SelectedProcessor == null)
        throw new InvalidOperationException();
      Configuration.ProcessorChain.Remove(SelectedProcessor.Processor);
      Processors.Remove(SelectedProcessor);
    }

    public void EditProcessor()
    {

    }
  }
}