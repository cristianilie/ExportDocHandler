using EDH.Library;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class GetPurchaseInvoicesCommand : ICommand
    {
        private DocumentHandlerViewModel docHandlerVM;

        public GetPurchaseInvoicesCommand(DocumentHandlerViewModel documentHandlerViewModel)
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
            if (docHandlerVM.DocHandler == null)
                docHandlerVM.DocHandler = new DocHandler();

            docHandlerVM.AllProductInvoices = docHandlerVM.GetPurchaseInvoices(docHandlerVM.DocHandler, docHandlerVM.InvoiceContent, docHandlerVM.PurchaseReportContent, docHandlerVM.WordsToExclude);
        }
    }
}
