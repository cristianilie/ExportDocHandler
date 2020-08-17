using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class AddHeaderCommand : ICommand
    {
        private ColumnHeaderSelectorViewModel columnHeaderSelectorViewModel;

        public AddHeaderCommand(ColumnHeaderSelectorViewModel columnHeaderSelectorViewModel)
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
            columnHeaderSelectorViewModel.AddToSelectedHeadersList(columnHeaderSelectorViewModel.SelectedItemAllHeadersList);
        }
    }
}
