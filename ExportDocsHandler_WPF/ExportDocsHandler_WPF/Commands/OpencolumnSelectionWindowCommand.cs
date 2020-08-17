using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.ViewModels.Factories;
using ExportDocsHandler_WPF.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class OpencolumnSelectionWindowCommand : ICommand
    {
        private IColumnHeaderSelector_WindowCreator<ColumnHeaderSelectorWindow> windowCreator;
        private DocumentHandlerViewModel documentHandlerViewModel;
        private List<string> allColumnHeaders;
        private DocumentType currentDocumentType;

        public OpencolumnSelectionWindowCommand(DocumentHandlerViewModel documentHandlerViewModel, List<string> allColumnHeaders, DocumentType _currentDocumentType)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
            this.allColumnHeaders = allColumnHeaders;
            this.currentDocumentType = _currentDocumentType;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            windowCreator = new ColumnHeaderSelectorWindowCreator(documentHandlerViewModel, allColumnHeaders, currentDocumentType);
            windowCreator.CreateNewWindow(allColumnHeaders, currentDocumentType).Show();
        }
    }
}