using System.Collections.Generic;

namespace ExportDocHandles
{
    public interface IColumnHeaderRequester
    {
        void FinishedHeaderSelection(Dictionary<string, string> docColumnHeaders_List, DocumentType docType);
    }
}
