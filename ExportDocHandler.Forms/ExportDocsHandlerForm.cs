using EDH.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExportDocHandles
{
    public partial class ExportDocsHandlerForm : Form, IColumnHeaderRequester, IWordsToExcludeRequester
    {
        private DataTable excelInvoiceContent;
        private DataTable excelReportContent;
        private int cellColumnIndex;
        private IExcelReader excelReader;
        private IDocHandler docHandler;
        private IFileHandler fileHandler;

        private ReportFilterForm reportWordFilterForm;
        private MissingDocumentsForm missingDocumentsForm;
        private CustomsDocumentsDataForm customsDocumentsDataForm;
        private ColumnHeaderSelectForm columnHeaderSelectForm;
        public List<string> WordsToExclude { get; set; }
        public List<InvoiceProductModel> BackupInvoiceContent { get; set; }
        public List<InvoiceProductModel> InvoiceContent { get; set; }
        public List<PurchaseReportModel> PurchaseReportContent { get; set; }
        public Dictionary<string, List<string>> AllProductInvoices { get; set; }
        public string SearchDirectoryPath { get; set; }
        public string MoveFilesDirectoryPath { get; set; }

        //Constructor
        public ExportDocsHandlerForm(IExcelReader _excelReader, IDocHandler _docHandler, IFileHandler _fileHandler)
        {
            InitializeComponent();
            excelReader = _excelReader;
            docHandler = _docHandler;
            fileHandler = _fileHandler;
        }

        /// <summary>
        /// Loads the Sales Invoice and filters the columns by column headers(by opening a ColumnHeaderSelectForm)
        /// </summary>
        private void LoadSalesInvoiceButton_Click(object sender, EventArgs e)
        {
            excelInvoiceContent = excelReader.GetExcelContent()[0];

            List<string> invoiceHeaders = new List<string>();
            for (int i = 0; i < excelInvoiceContent.Columns.Count; i++)
            {
                invoiceHeaders.Add(excelInvoiceContent.Columns[i].ColumnName);
            }

            columnHeaderSelectForm = new ColumnHeaderSelectForm(this, invoiceHeaders, DocumentType.SalesInvoice, docHandler);
            columnHeaderSelectForm.Show();
        }

        /// <summary>
        /// Loads the Purchase Report and filters the columns by column headers(by opening a ColumnHeaderSelectForm)
        /// </summary>
        private void LoadPurchaseReportButton_Click(object sender, EventArgs e)
        {
            excelReportContent = excelReader.GetExcelContent()[0];

            List<string> documentHeaders = new List<string>();

            for (int i = 0; i < excelReportContent.Columns.Count; i++)
            {
                documentHeaders.Add(excelReportContent.Columns[i].ColumnName);
            }

            columnHeaderSelectForm = new ColumnHeaderSelectForm(this, documentHeaders, DocumentType.PurchaseReport, docHandler);
            columnHeaderSelectForm.Show();
        }

        /// <summary>
        /// Gets the path of the directory we are going to search in
        /// </summary>
        private void GetDirectoryPathButton_Click(object sender, EventArgs e)
        {
            SearchDirectoryPath = fileHandler.GetFolderPathToHandleFiles();
        }

        /// <summary>
        /// Initialises the Sales Invoice / Purchase Report Datagrids after we finish filtering/removing unwanted columns
        /// </summary>
        /// <param name="docColumnHeaders_List">Needed/Selected column headers</param>
        /// <param name="docType">the document type(Sales Invoice / Purchase Report)</param>
        public void FinishedHeaderSelection(Dictionary<string, string> docColumnHeaders_List, DocumentType docType)
        {
            if (docType == DocumentType.SalesInvoice)
            {
                InvoiceContent = excelReader.ConvertToInvoiceModel(excelInvoiceContent, docColumnHeaders_List);
                BackupInvoiceContent = InvoiceContent;
                InvoiceContentDataGridView.DataSource = null;
                InvoiceContentDataGridView.DataSource = InvoiceContent;

                string[] headers = docColumnHeaders_List.Keys.ToArray();
                cellColumnIndex = Array.IndexOf(headers, "PurchaseInvoice");

                for (int i = 0; i < InvoiceContentDataGridView.Columns.Count - 1; i++)
                {
                    InvoiceContentDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                PurchaseReportContent = excelReader.ConvertToPurchaseReportModel(excelReportContent, docColumnHeaders_List);
                PurchaseReportDataGridView.DataSource = null;
                PurchaseReportDataGridView.DataSource = PurchaseReportContent;

                for (int i = 0; i < PurchaseReportDataGridView.Columns.Count - 1; i++)
                {
                    PurchaseReportDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        /// <summary>
        /// Opens a new ReportFilterForm to select our words to exclude from searches
        /// </summary>
        private void SortFilterReportButton_Click(object sender, EventArgs e)
        {
            if (PurchaseReportContent != null && PurchaseReportContent.Count > 0)
            {
                reportWordFilterForm = new ReportFilterForm(this);
                reportWordFilterForm.Show();
            }
        }

        /// <summary>
        /// Initialises the list of words to exclude from searches in the purchasing report
        /// </summary>
        public void FilteringComplete(List<string> wordsToExclude)
        {
            WordsToExclude = wordsToExclude;
        }

        /// <summary>
        /// Sets the purchase invoice number and supplier name in the Sales Invoice content list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetPurchaseInvoicesButton_Click(object sender, EventArgs e)
        {
            if (InvoiceContent != null && PurchaseReportContent != null)
            {
                AllProductInvoices = docHandler.GetAllProductsPurchaseInvoices(InvoiceContent, WordsToExclude, PurchaseReportContent);

                docHandler.SetInvoiceModel_PurchaseInvoice(InvoiceContent, AllProductInvoices);
                docHandler.SetInvoiceModel_ProductSupplier(InvoiceContent, PurchaseReportContent);
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Moves the purchase invoices to the selected folder
        /// </summary>
        private void MovePurchasingInvoicesButton_Click(object sender, EventArgs e)
        {
            if (AllProductInvoices != null && InvoiceContent != null && SearchDirectoryPath != "" && MoveFilesDirectoryPath != "")
                fileHandler.MoveDocuments(AllProductInvoices, InvoiceContent, SearchDirectoryPath, MoveFilesDirectoryPath);

            if (InvoiceContent != null)
                DisplayMissingDocumentsText(InvoiceContent.Where(d => d.FileWasMoved == false).ToList());
        }

        /// <summary>
        /// Displays purchase documents that were not found/moved in a new MissingDocumentsForm
        /// </summary>
        private void DisplayMissingDocumentsText(List<InvoiceProductModel> missingDocuments)
        {
            missingDocumentsForm = new MissingDocumentsForm(missingDocuments, docHandler);
            missingDocumentsForm.Show();
        }

        /// <summary>
        /// Gets/Sets the path to move purchase documents/other files
        /// </summary>
        private void GetPathToMoveFilesButton_Click(object sender, EventArgs e)
        {
            MoveFilesDirectoryPath = fileHandler.GetFolderPathToHandleFiles();
            FolderToMoveFilesPathTextBox.Text = MoveFilesDirectoryPath;
        }

        /// <summary>
        /// Displays purchase documents that were not found/moved
        /// </summary>
        private void DisplayMissingDocsButton_Click(object sender, EventArgs e)
        {
            if (InvoiceContent != null)
                DisplayMissingDocumentsText(InvoiceContent.Where(d => d.FileWasMoved == false).ToList());
        }

        /// <summary>
        /// Opens the CustomsDocumentsDataForm
        /// </summary>
        private void CreateExportDocsButton_Click(object sender, EventArgs e)
        {
            if (InvoiceContent != null)
            {
                customsDocumentsDataForm = new CustomsDocumentsDataForm(InvoiceContent, new DocumentCreator(), new DocHandler(), new FileHandler());
                customsDocumentsDataForm.Show();
            }
        }
    }
}
