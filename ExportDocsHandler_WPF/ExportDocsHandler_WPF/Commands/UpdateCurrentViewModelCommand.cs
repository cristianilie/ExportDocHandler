using ExportDocsHandler_WPF.Helpers;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.ViewModels
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly MainViewModel mainViewModel;
        public UpdateCurrentViewModelCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType currentViewType = (ViewType)parameter;

                switch (currentViewType)
                {
                    case ViewType.DocumentCreatorView:
                        mainViewModel.CurrentViewModel = new DocumentCreatorViewModel();
                        break;
                    case ViewType.DocumentHandlerView:
                        mainViewModel.CurrentViewModel = new DocumentHandlerViewModel();
                        break;
                    default:
                        throw new ArgumentException("Invalid View Type");
                }
            }
        }
    }
}