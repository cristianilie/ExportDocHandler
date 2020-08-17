using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.ViewModels.Interfaces;
using ExportDocsHandler_WPF.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class FinishHeaderSelectionCommand : ICommand
    {
        private ColumnHeaderSelectorViewModel columnHeaderSelectorViewModel;
        private DocumentHandlerViewModel documentHandlerViewModel;

        public FinishHeaderSelectionCommand(ColumnHeaderSelectorViewModel columnHeaderSelectorViewModel, DocumentHandlerViewModel documentHandlerViewModel)
        {
            this.columnHeaderSelectorViewModel = columnHeaderSelectorViewModel;
            this.documentHandlerViewModel = documentHandlerViewModel;
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
                ICloseable window = (ColumnHeaderSelectorWindow)parameter;
                columnHeaderSelectorViewModel.FinishColumnHeaderSelection(columnHeaderSelectorViewModel.SelectedHeadersList, window, documentHandlerViewModel);
            }
        }
    }
}
