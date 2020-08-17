using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class ClearFieldsCommand : ICommand
    {
        private DocumentCreatorViewModel docCreatorVM;

        public ClearFieldsCommand(DocumentCreatorViewModel documentCreatorViewModel)
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
            docCreatorVM.ClearFields();
        }
    }
}
