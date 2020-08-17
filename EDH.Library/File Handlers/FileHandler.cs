using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExportDocHandles
{
    /// <summary>
    /// Handles files(read/write/search/move)
    /// </summary>
    public class FileHandler : IFileHandler
    {
        /// <summary>
        /// Searches a file by Name, in a directory
        /// </summary>
        /// <param name="fileName">The Name we search by</param>
        /// <param name="directoryPath">The directory we search in</param>
        /// <returns>The path to the searched file or empty string if not found</returns>
        public static string SearchForFile(string fileName, string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            string[] directories = Directory.GetDirectories(directoryPath);
            string foundFile = "";
            bool fileWasFound = false;

            foreach (var item in files)
            {
                if (item.Contains(fileName) || item.Contains(fileName.Replace("/", " ").Replace(@"\", " ")))
                {
                    foundFile = item;
                    fileWasFound = true;
                    break;
                }
            }

            if (!fileWasFound)
            {
                foreach (string dirPath in directories)
                {
                    if (foundFile != "")
                        return foundFile;
                    else
                        foundFile = SearchForFile(fileName, dirPath);
                }
            }

            return foundFile;
        }

        /// <summary>
        /// Gets path to the selected folder
        /// </summary>
        /// <returns>The path to the selected folder</returns>
        public string GetFolderPathToHandleFiles()
        {
            string path = "";

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.Favorites;
                if (dialogResult == DialogResult.OK)
                    path = folderBrowserDialog.SelectedPath;
            }

            return path;
        }

        /// <summary>
        /// Writes to a text file
        /// </summary>
        /// <param name="text">The content we are about to write to the file</param>
        /// <param name="fileName">The file name</param>
        /// <param name="filePath">The file path</param>
        public void WriteToFile(string[] text, string fileName, string filePath)
        {
            using (StreamWriter writer = new StreamWriter($"{filePath}\\{fileName}.txt"))
            {
                foreach (string line in text)
                {
                    writer.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Loads the selected text file content 
        /// </summary>
        /// <returns>The selected text file content </returns>
        public string LoadSelectedTextFile( )
        {
            string output = "";
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Text files (*.txt)|*.txt" })
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(dialog.FileName))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            output += $"{line}\r\n";
                        }
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Searches and moves documents(purchase invoices) to the selected directory
        /// </summary>
        /// <param name="productInvoices">Product code/ Purchase Invoices list mapping</param>
        /// <param name="invoiceContent"> Sales Invoice Content</param>
        /// <param name="searchDirectoryPath">Search Directory Path</param>
        /// <param name="moveFilesDirectoryPath">Path to move the files</param>
        public void MoveDocuments(Dictionary<string, List<string>> productInvoices, List<InvoiceProductModel> invoiceContent, string searchDirectoryPath, string moveFilesDirectoryPath)
        {
            for (int i = 0; i < productInvoices.Keys.Count; i++)
            {
                for (int j = 0; j < productInvoices[productInvoices.Keys.ElementAt(i)].Count(); j++)
                {
                    string invoicePath = FileHandler.SearchForFile(productInvoices[productInvoices.Keys.ElementAt(i)][j], searchDirectoryPath);
                    string pathToMoveInvoiceTo = $"{moveFilesDirectoryPath}\\{invoicePath.Replace("\\", "*").Split('*').Last()}";

                    if (invoicePath != string.Empty && !File.Exists(pathToMoveInvoiceTo))
                    {
                        File.Move(invoicePath, pathToMoveInvoiceTo);

                        InvoiceProductModel invoiceItem = invoiceContent.Where(a => a.Code == productInvoices.Keys.ElementAt(i)).FirstOrDefault();
                        invoiceItem.FileWasMoved = true;
                        invoiceItem.PurchaseInvoice = productInvoices[productInvoices.Keys.ElementAt(i)][j];
                        break;
                    }
                }
            }
        }

    }
}
