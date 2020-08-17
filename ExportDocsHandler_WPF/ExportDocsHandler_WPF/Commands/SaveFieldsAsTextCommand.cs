using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class SaveFieldsAsTextCommand : ICommand
    {
        private DocumentCreatorViewModel documentCreatorViewModel;

        public SaveFieldsAsTextCommand(DocumentCreatorViewModel documentCreatorViewModel)
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

            documentCreatorViewModel.SaveFieldsAsTextFiles(documentCreatorViewModel.FileHandler);
        }
    }
}
