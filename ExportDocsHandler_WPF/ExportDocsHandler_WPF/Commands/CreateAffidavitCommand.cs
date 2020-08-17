using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class CreateAffidavitCommand : ICommand
    {
        private DocumentCreatorViewModel docCreatorVM;

        public CreateAffidavitCommand(DocumentCreatorViewModel documentCreatorViewModel)
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

            docCreatorVM.CreateAffidavitStatement(docCreatorVM.DocumentCreator, docCreatorVM.FileHandler, docCreatorVM.AffidavitTitle, docCreatorVM.AffidavitContent, 
                                                                        docCreatorVM.SalesAgentName, docCreatorVM.PathToStampAndSignature);
        }
    }
}
