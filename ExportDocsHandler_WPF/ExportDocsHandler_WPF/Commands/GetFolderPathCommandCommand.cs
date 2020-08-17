using ExportDocHandles;
using ExportDocsHandler_WPF.ViewModels;
using System;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.Commands
{
    public class GetFolderPathCommand : ICommand
    {
        private DocumentHandlerViewModel documentHandlerViewModel;
        private readonly IFileHandler fileHandler;

        public GetFolderPathCommand(DocumentHandlerViewModel documentHandlerViewModel)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
            fileHandler = new FileHandler();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Search")
            {
                documentHandlerViewModel.SearchDirectory = fileHandler.GetFolderPathToHandleFiles();
            }
            else if (parameter.ToString() == "Move")
            {
                documentHandlerViewModel.FolderToMoveFiles = fileHandler.GetFolderPathToHandleFiles();
            }
        }
    }
}
