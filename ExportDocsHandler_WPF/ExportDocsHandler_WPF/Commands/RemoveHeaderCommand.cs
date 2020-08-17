using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class RemoveHeaderCommand : ICommand
    {
        private ColumnHeaderSelectorViewModel columnHeaderSelectorViewModel;

        public RemoveHeaderCommand(ColumnHeaderSelectorViewModel columnHeaderSelectorViewModel)
        {
            this.columnHeaderSelectorViewModel = columnHeaderSelectorViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            columnHeaderSelectorViewModel.RemoveFromSelectedHeadersList(columnHeaderSelectorViewModel.SelectedItemSelectedHeadersList);
        }
    }
}
