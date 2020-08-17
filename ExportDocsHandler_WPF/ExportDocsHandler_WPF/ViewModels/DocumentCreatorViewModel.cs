using EDH.Library;
using ExportDocHandles;
using ExportDocsHandler_WPF.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.ViewModels
{
    public class DocumentCreatorViewModel : ViewModelBase
    {
        #region Fields

        private string companyInformation;
        private string exporterStatementTitle;
        private string exporterStatementPart1;
        private string exporterStatementPart2;
        private string exporterStatementPart3;
        private string buyerInformation;
        private string affidavitTitle;
        private string affidavitContent;
        private string salesAgentName;
        private string pathToStampAndSignature;
        private string palletsNumber;
        private string boxesNumber;
        private string weight;

        #endregion

        #region Properties

        public string CompanyInformation
        {
            get { return companyInformation; }
            set
            {
                companyInformation = value;
                OnPropertyChanged(nameof(CompanyInformation));
            }
        }
        public string ExporterStatementTitle
        {
            get { return exporterStatementTitle; }
            set
            {
                exporterStatementTitle = value;
                OnPropertyChanged(nameof(ExporterStatementTitle));
            }
        }
        public string ExporterStatementPart1
        {
            get { return exporterStatementPart1; }
            set
            {
                exporterStatementPart1 = value;
                OnPropertyChanged(nameof(ExporterStatementPart1));
            }
        }
        public string ExporterStatementPart2
        {
            get { return exporterStatementPart2; }
            set
            {
                exporterStatementPart2 = value;
                OnPropertyChanged(nameof(ExporterStatementPart2));
            }
        }
        public string ExporterStatementPart3
        {
            get { return exporterStatementPart3; }
            set
            {
                exporterStatementPart3 = value;
                OnPropertyChanged(nameof(ExporterStatementPart3));
            }
        }
        public string BuyerInformation
        {
            get { return buyerInformation; }
            set
            {
                buyerInformation = value;
                OnPropertyChanged(nameof(BuyerInformation));
            }
        }
        public string AffidavitTitle
        {
            get { return affidavitTitle; }
            set
            {
                affidavitTitle = value;
                OnPropertyChanged(nameof(AffidavitTitle));
            }
        }
        public string AffidavitContent
        {
            get { return affidavitContent; }
            set
            {
                affidavitContent = value;
                OnPropertyChanged(nameof(AffidavitContent));
            }
        }
        public string SalesAgentName
        {
            get { return salesAgentName; }
            set
            {
                salesAgentName = value;
                OnPropertyChanged(nameof(SalesAgentName));
            }
        }
        public string PathToStampAndSignature
        {
            get { return pathToStampAndSignature; }
            set
            {
                pathToStampAndSignature = value;
                OnPropertyChanged(nameof(PathToStampAndSignature));
            }
        }
        public string PalletsNumber
        {
            get { return palletsNumber; }
            set
            {
                palletsNumber = value;
                OnPropertyChanged(nameof(PalletsNumber));
            }
        }
        public string BoxesNumber
        {
            get { return boxesNumber; }
            set
            {
                boxesNumber = value;
                OnPropertyChanged(nameof(BoxesNumber));
            }
        }
        public string Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        #endregion

        #region Commands

        public IFileHandler FileHandler { get; set; }
        public IDocumentCreator DocumentCreator { get; set; }
        public IDocHandler DocHandler { get; set; }
        public ICommand LoadTextFromFileCommand { get; set; }
        public ICommand CreateExporterStatementCommand { get; set; }
        public ICommand CreateAffidavitCommand { get; set; }
        public ICommand CreatePackingListCommand { get; set; }
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand SaveFieldsAsTextCommand { get; set; }

        #endregion

        public DocumentCreatorViewModel()
        {
            LoadTextFromFileCommand = new LoadTextFromFileCommand(this);
            CreateExporterStatementCommand = new CreateExporterStatementCommand(this);
            CreateAffidavitCommand = new CreateAffidavitCommand(this);
            CreatePackingListCommand = new CreatePackingListCommand(this);
            ClearFieldsCommand = new ClearFieldsCommand(this);
            SaveFieldsAsTextCommand = new SaveFieldsAsTextCommand(this);

            ExporterStatementPart2 = InitialiseExporterStatementPart2(DocHandler);
        }

        /// <summary>
        /// Returns a string with the Supplier/Purchase Invoice numbers if the invoice numbers have been retrieved, or empty string otherwise
        /// </summary>
        /// <param name="docHandler">DocHandler object that allows us access to<see cref="GetPurchaseDocumentsAs_SupplierPurchaseInvoicesGrouping"/> method,
        /// used to format the string</param>
        public string InitialiseExporterStatementPart2(IDocHandler docHandler)
        {
            if (MainViewModel.SalesInvoiceContent != null)
            {
                docHandler = new DocHandler();
                return docHandler.GetPurchaseDocumentsAs_SupplierPurchaseInvoicesGrouping(MainViewModel.SalesInvoiceContent);
            }
            return "";
        }

        /// <summary>
        /// Returns a string of text loaded from a text file
        /// </summary>
        /// <param name="fileHandler">FileHandler object that allows us to access LoadSelectedTextFile method in EDH library </param>
        public string LoadFromFile(IFileHandler fileHandler)
        {
            return fileHandler.LoadSelectedTextFile();
        }

        /// <summary>
        /// Creates an exporter statement(in microsoft word)
        /// </summary>
        public void CreateExporterStatement(IDocumentCreator documentCreator, IFileHandler fileHandler, string companyInformation, string exporterStatementTitle, 
            string exporterStatementContent1, string exporterStatementContent2, string exporterStatementContent3, string salesAgentName, string stampSignatureFilePath)
        {
            string folderPath = fileHandler.GetFolderPathToHandleFiles();

            if (documentCreator.ValidateFields(companyInformation, exporterStatementTitle, exporterStatementContent1, exporterStatementContent2,
                                    exporterStatementContent3, salesAgentName, stampSignatureFilePath, folderPath))
            {
                documentCreator.CreateExporterStatement(companyInformation, exporterStatementTitle, exporterStatementContent1, exporterStatementContent2,
                                    exporterStatementContent3, salesAgentName, stampSignatureFilePath, folderPath);
            }
        }

        /// <summary>
        /// Creates an affidavit statement(in microsoft word)
        /// </summary>
        public void CreateAffidavitStatement(IDocumentCreator documentCreator, IFileHandler fileHandler, string affidavitTitle, string affidavitContent,
                                                                                                            string salesAgentName, string stampSignatureFilePath)
        {
            string folderPath = fileHandler.GetFolderPathToHandleFiles();

            if (documentCreator.ValidateFields(affidavitTitle, affidavitContent, salesAgentName, stampSignatureFilePath, folderPath))
            {
                documentCreator.CreateWordDocument("", "", affidavitTitle, affidavitContent, "", "", salesAgentName, stampSignatureFilePath, folderPath);
            }
        }

        /// <summary>
        /// Creates a export packing list(in microsoft excel)
        /// </summary>
        public void CreatePackingList(IDocumentCreator documentCreator, IFileHandler fileHandler, List<InvoiceProductModel> salesInvoiceContent, string companyInformation,
            string buyerInformation, string palletsNumber, string boxesNumber, string weight)
        {
            string folderPath = fileHandler.GetFolderPathToHandleFiles();

            if (salesInvoiceContent != null && documentCreator.ValidateFields(companyInformation, buyerInformation, palletsNumber, boxesNumber, weight, folderPath))
            {
                documentCreator.CreatePackingList(salesInvoiceContent, companyInformation, buyerInformation,
                                                                    palletsNumber, boxesNumber, weight, folderPath);
            }
        }

        /// <summary>
        /// Clears the Fields and UI elements bound to them
        /// </summary>
        public void ClearFields()
        {
            CompanyInformation = "";
            ExporterStatementTitle = "";
            ExporterStatementPart1 = "";
            ExporterStatementPart2 = "";
            ExporterStatementPart3 = "";
            BuyerInformation = "";
            AffidavitTitle = "";
            AffidavitContent = "";
            SalesAgentName = "";
            PathToStampAndSignature = "";
            PalletsNumber = "";
            BoxesNumber = "";
            Weight = "";
        }

        /// <summary>
        /// Saves the fields bound to the UI related elements as text files
        /// </summary>
        /// <param name="fileHandler">File Handler object used to call the method that writes to text files</param>
        public void SaveFieldsAsTextFiles(IFileHandler fileHandler)
        {
            string pathToSaveFiles = fileHandler.GetFolderPathToHandleFiles();

            if (pathToSaveFiles != "")
            {
                if (CompanyInformation != string.Empty)
                    fileHandler.WriteToFile(CompanyInformation.Split('\r', '\n'), $"{nameof(CompanyInformation)}Text", pathToSaveFiles);

                if (BuyerInformation != string.Empty)
                    fileHandler.WriteToFile(BuyerInformation.Split('\r', '\n'), $"{nameof(BuyerInformation)}Text", pathToSaveFiles);

                if (ExporterStatementTitle != string.Empty)
                    fileHandler.WriteToFile(new string[] { ExporterStatementTitle }, $"{nameof(ExporterStatementTitle)}Text", pathToSaveFiles);

                if (AffidavitTitle != string.Empty)
                    fileHandler.WriteToFile(new string[] { AffidavitTitle }, $"{nameof(AffidavitTitle)}Text", pathToSaveFiles);

                if (ExporterStatementPart1 != string.Empty)
                    fileHandler.WriteToFile(ExporterStatementPart1.Split('\r', '\n'), $"{nameof(ExporterStatementPart1)}Text", pathToSaveFiles);

                if (ExporterStatementPart2 != string.Empty)
                    fileHandler.WriteToFile(ExporterStatementPart2.Split('\r', '\n'), $"{nameof(ExporterStatementPart2)}Text", pathToSaveFiles);

                if (ExporterStatementPart3 != string.Empty)
                    fileHandler.WriteToFile(ExporterStatementPart3.Split('\r', '\n'), $"{nameof(ExporterStatementPart3)}Text", pathToSaveFiles);

                if (AffidavitContent != string.Empty)
                    fileHandler.WriteToFile(AffidavitContent.Split('\r', '\n'), $"{nameof(AffidavitContent)}Text", pathToSaveFiles);

                if (SalesAgentName != string.Empty)
                    fileHandler.WriteToFile(new string[] { SalesAgentName }, $"{nameof(SalesAgentName)}Text", pathToSaveFiles);

                if (PathToStampAndSignature != string.Empty)
                    fileHandler.WriteToFile(new string[] { PathToStampAndSignature }, $"{nameof(PathToStampAndSignature)}Text", pathToSaveFiles);
            }
        }
    }
}
