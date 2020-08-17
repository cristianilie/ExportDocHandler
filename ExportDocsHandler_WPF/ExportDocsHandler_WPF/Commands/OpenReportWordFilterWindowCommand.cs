using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.ViewModels.Factories;
using ExportDocsHandler_WPF.Views;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class OpenReportWordFilterWindowCommand : ICommand
    {
        private DocumentHandlerViewModel documentHandlerViewModel;
        private  ISimpleWindowCreator<ReportWordFilterWindow> reportWordFilterWindowCreator;

        public OpenReportWordFilterWindowCommand(DocumentHandlerViewModel documentHandlerViewModel)
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
            reportWordFilterWindowCreator = new ReportWordFilterWindowCreator(documentHandlerViewModel);
            reportWordFilterWindowCreator.CreateWindow().Show();
        }
    }
}
