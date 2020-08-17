using EDH.Library;
using ExportDocHandles;
using ExportDocsHandler_WPF.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.ViewModels
{
    public class DocumentHandlerViewModel : ViewModelBase
    {
        private ObservableCollection<InvoiceProductModel> invoiceContent;
        private ObservableCollection<PurchaseReportModel> purchaseReportContent;

        #region Properties

        public DataTable InvoiceDataTableContent { get; set; }
        public DataTable PurchaseReportDataTableContent { get; set; }
        public List<string> WordsToExclude { get; set; }
        public ObservableCollection<InvoiceProductModel> InvoiceContent
        {
            get => invoiceContent;
            set
            {
                invoiceContent = value;
                OnPropertyChanged(nameof(InvoiceContent));
            }
        }
        public ObservableCollection<PurchaseReportModel> PurchaseReportContent
        {
            get => purchaseReportContent;
            set
            {
                purchaseReportContent = value;
                OnPropertyChanged(nameof(PurchaseReportContent));
            }
        }
        public Dictionary<string, List<string>> AllProductInvoices { get; set; }

        public string SearchDirectory { get; set; }
        public string FolderToMoveFiles { get; set; }

        //File/Document Handlers
        public IExcelReader ExcelReader { get; set; }
        public IDocHandler DocHandler { get; set; }
        public IFileHandler FileHandler { get; set; }

        #endregion

        #region Commands
        
        public ICommand LoadExcelContentCommand { get; set; }
        public ICommand GetFolderPathCommand { get; set; }
        public ICommand OpencolumnSelectionWindowCommand { get; set; }
        public ICommand GetPurchaseInvoicesCommand { get; set; }
        public ICommand OpenReportWordFilterWindowCommand { get; set; }
        public ICommand MoveFilesCommand { get; set; }
        public ICommand OpenMissingInvoicesWindowCommand { get; set; }

        #endregion

        public DocumentHandlerViewModel()
        {
            ExcelReader = new ExcelReader();
            LoadExcelContentCommand = new LoadExcelContentCommand(this);
            GetFolderPathCommand = new GetFolderPathCommand(this);
            GetPurchaseInvoicesCommand = new GetPurchaseInvoicesCommand(this);
            OpenReportWordFilterWindowCommand = new OpenReportWordFilterWindowCommand(this);
            MoveFilesCommand = new MoveFilesCommand(this);
            OpenMissingInvoicesWindowCommand = new OpenMissingInvoicesWindowCommand(this);
        }

        /// <summary>
        /// Loads excel content and adds it to the datatable property that matches the document type
        /// </summary>
        public void LoadExcelContent(DocumentType DocumentType, IExcelReader excelReader)
        {
            if (DocumentType == DocumentType.SalesInvoice)
            {
                InvoiceDataTableContent = GetExcelContent(excelReader, DocumentType);
            }
            else
            {
                PurchaseReportDataTableContent = GetExcelContent(excelReader, DocumentType);
            }
        }

        /// <summary>
        /// Opens the excel file, retrieves the content as datatable, and opens the column selection window
        /// according to the document type
        /// </summary>
        public DataTable GetExcelContent(IExcelReader excelReader, DocumentType DocumentType)
        {
            DataTable documentContent = excelReader.GetExcelContent()[0];

            var tempDocumentContent = documentContent;
            List<string> documentHeaders = new List<string>();
            for (int i = 0; i < tempDocumentContent.Columns.Count; i++)
            {
                documentHeaders.Add(tempDocumentContent.Columns[i].ColumnName);
            }

            OpencolumnSelectionWindowCommand = new OpencolumnSelectionWindowCommand(this, documentHeaders, DocumentType);
            OpencolumnSelectionWindowCommand.Execute(null);
            return documentContent;
        }

        /// <summary>
        /// Converts the data table content to a collection of document type related models and initializes the property representing document 
        /// after we have selected the required columns
        /// </summary>
        public void FinishDocumentLoading(Dictionary<string, string> docColumnHeaders_List, DocumentType docType)
        {
            if (docType == DocumentType.SalesInvoice)
            {
                InvoiceContent = new ObservableCollection<InvoiceProductModel>(ExcelReader.ConvertToInvoiceModel(InvoiceDataTableContent, docColumnHeaders_List).ToList());
            }
            else
            {
                PurchaseReportContent = new ObservableCollection<PurchaseReportModel>(ExcelReader.ConvertToPurchaseReportModel(PurchaseReportDataTableContent, docColumnHeaders_List).ToList());
            }
        }

        /// <summary>
        /// Retrieves the list of strings we selected to exclude from the purchase invoice number
        /// </summary>
        public void FinishReportWordFiltering(List<string> wordsToFilter)
        {
            WordsToExclude = wordsToFilter;
        }

        /// <summary>
        /// Retrieves a dictionary of a product in the sales invoice/all the purchase invoices related to the product
        /// Updates the purchase invoice/supplier name fields in the (Sales) InvoiceContent collection
        /// </summary>
        public Dictionary<string, List<string>>  GetPurchaseInvoices(IDocHandler docHandler, ObservableCollection<InvoiceProductModel> invoiceContent, ObservableCollection<PurchaseReportModel> purchaseReportContent, List<string> wordsToExclude)
        {
            Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();
            if (invoiceContent != null && PurchaseReportContent != null)
            {
                output = docHandler.GetAllProductsPurchaseInvoices(invoiceContent.ToList(), wordsToExclude, purchaseReportContent.ToList());

                docHandler.SetInvoiceModel_PurchaseInvoice(invoiceContent.ToList(), output);
                docHandler.SetInvoiceModel_ProductSupplier(invoiceContent.ToList(), purchaseReportContent.ToList());
            }

            return output;
        }

        /// <summary>
        /// Moves the first match found of the searched purchase invoices to the selected folder, updates the "WasMoved" property in the InvoiceContent collection
        /// and initialises the <see cref="SalesInvoiceContent"/> static collection in the MainViewModel"/>
        /// </summary>
        public void MovePurchasingInvoices(IFileHandler fileHandler, Dictionary<string, List<string>> allProductInvoices, 
                                ObservableCollection<InvoiceProductModel> invoiceContent, string searchDirectory,string folderToMoveFiles)
        {
            if (allProductInvoices != null && invoiceContent != null && searchDirectory != "" && folderToMoveFiles != "")
                fileHandler.MoveDocuments(allProductInvoices, invoiceContent.ToList(), searchDirectory, folderToMoveFiles);

            MainViewModel.SalesInvoiceContent = invoiceContent.ToList();
        }

    }
}