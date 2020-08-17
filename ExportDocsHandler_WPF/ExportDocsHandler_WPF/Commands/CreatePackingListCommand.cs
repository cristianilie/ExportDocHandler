using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class CreatePackingListCommand : ICommand
    {
        private DocumentCreatorViewModel docCreatorVM;

        public CreatePackingListCommand(DocumentCreatorViewModel documentCreatorViewModel)
        {
            this.docCreatorVM = documentCreatorViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (docCreatorVM.FileHandler == null)
                docCreatorVM.FileHandler = new FileHandler();
            if (docCreatorVM.DocumentCreator == null)
                docCreatorVM.DocumentCreator = new DocumentCreator();

            docCreatorVM.CreatePackingList(docCreatorVM.DocumentCreator, docCreatorVM.FileHandler, MainViewModel.SalesInvoiceContent, docCreatorVM.CompanyInformation,
                docCreatorVM.BuyerInformation, docCreatorVM.PalletsNumber, docCreatorVM.BoxesNumber, docCreatorVM.Weight);
        }
    }
}
