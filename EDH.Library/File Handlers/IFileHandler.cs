using System.Collections.Generic;

namespace ExportDocHandles
{
    public interface IFileHandler
    {
        string GetFolderPathToHandleFiles();
        string LoadSelectedTextFile();
        void WriteToFile(string[] text, string fileName, string filePath);
        void MoveDocuments(Dictionary<string, List<string>> productInvoices, List<InvoiceProductModel> invoiceContent, string searchDirectoryPath, string moveFilesDirectoryPath);

    }
}