using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.ViewModels.Services;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class CopyToClipboardCommand : ICommand
    {
        private MissingInvoicesViewModel missingInvoicesViewModel;

        public CopyToClipboardCommand(MissingInvoicesViewModel missingInvoicesViewModel)
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
            if (missingInvoicesViewModel.ClipboardService == null)
                missingInvoicesViewModel.ClipboardService = new ClipboardService();

            missingInvoicesViewModel.CopyToClipboard(missingInvoicesViewModel.MissingInvoices, missingInvoicesViewModel.ClipboardService);
        }
    }
}
