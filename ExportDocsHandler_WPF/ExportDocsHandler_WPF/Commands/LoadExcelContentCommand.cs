using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class LoadExcelContentCommand : ICommand
    {

        private DocumentHandlerViewModel docHandlerVM;

        public LoadExcelContentCommand(DocumentHandlerViewModel documentHandlerViewModel)
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
            if(parameter is DocumentType)
                docHandlerVM.LoadExcelContent((DocumentType)parameter, new ExcelReader());
        }
    }
}
