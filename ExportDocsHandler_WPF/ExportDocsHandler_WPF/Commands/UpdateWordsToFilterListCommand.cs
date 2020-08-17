using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class UpdateWordsToFilterListCommand : ICommand
    {
        private ReportWordFilterViewModel reportWordFilterViewModel;

        public UpdateWordsToFilterListCommand(ReportWordFilterViewModel reportWordFilterViewModel)
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
            if(parameter.ToString() == "Add")
            {
                reportWordFilterViewModel.AddToWordList(reportWordFilterViewModel.WordToAdd);
                reportWordFilterViewModel.WordToAdd = "";
            }
            else if (parameter.ToString() == "Remove")
            {
                reportWordFilterViewModel.RemoveFromWordList(reportWordFilterViewModel.WordToRemove);
            }
        }
    }
}
