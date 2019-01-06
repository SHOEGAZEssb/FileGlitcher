using Caliburn.Micro;
using FileGlitcher.Processors.ByteIndexProviders;
using FileGlitcherUI.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGlitcherUI.Processors.ByteIndexProvider
{
  class CreateByteIndexProviderViewModel : PropertyChangedBase
  {
    public ByteIndexProviderBase CreatedByteIndexProvider
    {
      get => _createdByteIndexProvider;
      private set
      {
        if(CreatedByteIndexProvider != value)
        {
          _createdByteIndexProvider = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private ByteIndexProviderBase _createdByteIndexProvider;

    public ByteRangePickerViewModel ByteRangeVM
    {
      get => _byteRangeVM;
      private set
      {
        if(ByteRangeVM != value)
        {
          _byteRangeVM = value;
          NotifyOfPropertyChange();
        }
      }
    }
    private ByteRangePickerViewModel _byteRangeVM;

    #region Construction

    public CreateByteIndexProviderViewModel(FileViewModelBase file)
    {
      ByteRangeVM = new ByteRangePickerViewModel(file);
    }

    #endregion Construction
  }
}