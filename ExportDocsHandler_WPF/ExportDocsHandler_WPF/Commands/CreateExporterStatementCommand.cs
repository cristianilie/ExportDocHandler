using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class CreateExporterStatementCommand : ICommand
    {
        private DocumentCreatorViewModel docCreatorVM;

        public CreateExporterStatementCommand(DocumentCreatorViewModel documentCreatorViewModel)
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

            docCreatorVM.CreateExporterStatement(docCreatorVM.DocumentCreator, docCreatorVM.FileHandler, docCreatorVM.CompanyInformation, docCreatorVM.ExporterStatementTitle,
                                                                docCreatorVM.ExporterStatementPart1, docCreatorVM.ExporterStatementPart2, docCreatorVM.ExporterStatementPart3, 
                                                                docCreatorVM.SalesAgentName, docCreatorVM.PathToStampAndSignature);
        }
    }
}
