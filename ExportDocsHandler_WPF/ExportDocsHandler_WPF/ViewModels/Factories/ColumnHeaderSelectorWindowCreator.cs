using ExportDocHandles;
using ExportDocsHandler_WPF.Views;
using System;
using System.Collections.Generic;

namespace ExportDocsHandler_WPF.ViewModels.Factories
{
    /// <summary>
    /// Creates a new <see cref="ColumnHeaderSelectorWindow"/>
    /// </summary>
    public class ColumnHeaderSelectorWindowCreator : IColumnHeaderSelector_WindowCreator<ColumnHeaderSelectorWindow>
    {
        private DocumentHandlerViewModel documentHandlerViewModel;

        public ColumnHeaderSelectorWindowCreator(DocumentHandlerViewModel documentHandlerViewModel, List<string> allColumnHeaders, DocumentType DocumentType)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
        }

        public ColumnHeaderSelectorWindow CreateNewWindow(List<string> allColumnHeaders, DocumentType DocumentType)
        {
            return new ColumnHeaderSelectorWindow() { DataContext = new ColumnHeaderSelectorViewModel(documentHandlerViewModel, allColumnHeaders, DocumentType) };
        }

        public ColumnHeaderSelectorWindow CreateNewWindow()
        {
            throw new NotImplementedException();
        }
    }
}
