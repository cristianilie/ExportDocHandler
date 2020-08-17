using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class LoadTextFromFileCommand : ICommand
    {
        private DocumentCreatorViewModel documentCreatorViewModel;

        public LoadTextFromFileCommand(DocumentCreatorViewModel documentCreatorViewModel)
        {
            this.documentCreatorViewModel = documentCreatorViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (documentCreatorViewModel.FileHandler == null)
                documentCreatorViewModel.FileHandler = new FileHandler();

            if (parameter != null)
            {
                string propertyValue = parameter.ToString();

                switch (parameter.ToString())
                {
                    case nameof(documentCreatorViewModel.CompanyInformation):
                        documentCreatorViewModel.CompanyInformation = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.ExporterStatementTitle):
                        documentCreatorViewModel.ExporterStatementTitle = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.ExporterStatementPart1):
                        documentCreatorViewModel.ExporterStatementPart1 = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.ExporterStatementPart2):
                        documentCreatorViewModel.ExporterStatementPart2 = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.ExporterStatementPart3):
                        documentCreatorViewModel.ExporterStatementPart3 = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.BuyerInformation):
                        documentCreatorViewModel.BuyerInformation = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.AffidavitTitle):
                        documentCreatorViewModel.AffidavitTitle = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.AffidavitContent):
                        documentCreatorViewModel.AffidavitContent = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.SalesAgentName):
                        documentCreatorViewModel.SalesAgentName = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    case nameof(documentCreatorViewModel.PathToStampAndSignature):
                        documentCreatorViewModel.PathToStampAndSignature = documentCreatorViewModel.LoadFromFile(documentCreatorViewModel.FileHandler);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
