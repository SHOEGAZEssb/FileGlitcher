using Caliburn.Micro;
using FileGlitcher;
using FileGlitcherUI.Files;
using Microsoft.Win32;
using System;
using System.IO;

namespace FileGlitcherUI
{
  class GlitcherViewModel : Screen
  {
    #region Properties

    public FileViewModelBase InputFileVM
    {
      get => _inputFileVM;
      private set
      {
        if(InputFileVM != value)
        {
          _inputFileVM = value;
          NotifyOfPropertyChange();

          if (InputFileVM != null)
            GlitcherConfigurationVM = new GlitcherConfigurationViewModel(InputFileVM);
        }
      }
    }
    private FileViewModelBase _inputFileVM;

    public FileViewModelBase OutputFileVM
    {
      get => _outputFileVM;
      private set
      {
        if(OutputFileVM != value)
        {
          _outputFileVM = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private FileViewModelBase _outputFileVM;

    public GlitcherConfigurationViewModel GlitcherConfigurationVM
    {
      get => _glitcherConfigurationVM;
      private set
      {
        if(GlitcherConfigurationVM != value)
        {
          _glitcherConfigurationVM = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private GlitcherConfigurationViewModel _glitcherConfigurationVM;

    public string OutputFileName
    {
      get => _outputFileName;
      set
      {
        if(OutputFileName != value)
        {
          _outputFileName = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private string _outputFileName;

    #endregion Properties

    public void LoadInputFile()
    {
      var ofd = new OpenFileDialog();
      if (ofd.ShowDialog() ?? false)
        InputFileVM = FileViewModelFactory.CreateViewModel(ofd.FileName);
    }

    public void Glitch()
    {
      if (InputFileVM == null || GlitcherConfigurationVM == null)
        throw new InvalidOperationException();

      File.WriteAllBytes(OutputFileName, Glitcher.GlitchBytes(InputFileVM.Bytes, GlitcherConfigurationVM.Configuration));

      OutputFileVM = FileViewModelFactory.CreateViewModel(OutputFileName);
    }
  }
}