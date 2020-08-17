using ExportDocHandles;
using System.Collections.Generic;

namespace ExportDocsHandler_WPF.ViewModels.Factories
{
    public interface IColumnHeaderSelector_WindowCreator<T>
    {
        T CreateNewWindow(List<string> allColumnHeaders, DocumentType DocumentType);

    }
}
