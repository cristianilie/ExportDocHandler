using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.ViewModels.Factories;
using ExportDocsHandler_WPF.Views;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class OpenMissingInvoicesWindowCommand : ICommand
    {
        private DocumentHandlerViewModel documentHandlerViewModel;
        private ISimpleWindowCreator<MissingInvoicesWindow> simpleWindowCreator;
        public OpenMissingInvoicesWindowCommand(DocumentHandlerViewModel documentHandlerViewModel)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            simpleWindowCreator = new MissingInvoicesWindowCreator(documentHandlerViewModel);
            simpleWindowCreator.CreateWindow().Show();
        }
    }
}
