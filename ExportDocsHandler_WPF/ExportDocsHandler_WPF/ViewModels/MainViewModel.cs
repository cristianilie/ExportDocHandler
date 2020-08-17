using ExportDocHandles;
using System.Collections.Generic;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public static List<InvoiceProductModel> SalesInvoiceContent { get; set; }


        public MainViewModel()
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this);
            CurrentViewModel = new DocumentHandlerViewModel();
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }
    }
}
