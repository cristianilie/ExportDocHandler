using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class CloseWindowCommand : ICommand
    {
        private MissingInvoicesViewModel missingInvoicesViewModel;

        public CloseWindowCommand(MissingInvoicesViewModel missingInvoicesViewModel)
        {
            this.missingInvoicesViewModel = missingInvoicesViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Window)
            {
                missingInvoicesViewModel.CloseWindow((MissingInvoicesWindow)parameter);
            }
        }
    }
}
