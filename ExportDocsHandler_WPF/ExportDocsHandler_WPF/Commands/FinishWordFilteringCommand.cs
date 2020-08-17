using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class FinishWordFilteringCommand : ICommand
    {
        private ReportWordFilterViewModel reportWordFilterViewModel;

        public FinishWordFilteringCommand(ReportWordFilterViewModel reportWordFilterViewModel)
        {
            this.reportWordFilterViewModel = reportWordFilterViewModel;
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
                reportWordFilterViewModel.FinishWordFiltering((ReportWordFilterWindow)parameter);
            }
        }
    }
}
