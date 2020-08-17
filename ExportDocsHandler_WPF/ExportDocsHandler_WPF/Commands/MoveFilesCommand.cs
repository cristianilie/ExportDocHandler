using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class MoveFilesCommand : ICommand
    {
        private DocumentHandlerViewModel docHandlerVM;

        public MoveFilesCommand(DocumentHandlerViewModel documentHandlerViewModel)
        {
            this.docHandlerVM = documentHandlerViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (docHandlerVM.FileHandler == null)
                docHandlerVM.FileHandler = new FileHandler();

            docHandlerVM.MovePurchasingInvoices(docHandlerVM.FileHandler, docHandlerVM.AllProductInvoices, docHandlerVM.InvoiceContent, 
                docHandlerVM.SearchDirectory, docHandlerVM.FolderToMoveFiles);
        }
    }
}
