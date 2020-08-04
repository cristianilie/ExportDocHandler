using EDH.Library;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExportDocHandles
{
    public partial class CustomsDocumentsDataForm : Form
    {
        private string pathToSaveFiles;
        private List<InvoiceProductModel> salesInvoiceContent;

        private IDocumentCreator documentCreator;
        private IDocHandler docHandler;
        private IFileHandler fileHandler;

        //Constructor
        public CustomsDocumentsDataForm(List<InvoiceProductModel> _salesInvoiceContent, IDocumentCreator _documentCreator, IDocHandler _docHandler, IFileHandler _fileHandler)
        {
            InitializeComponent();
            salesInvoiceContent = _salesInvoiceContent;

            documentCreator = _documentCreator;
            docHandler = _docHandler;
            fileHandler = _fileHandler;

            InitializeExportPurchaseDocumentsContent(salesInvoiceContent);

        }

        /// <summary>
        /// Initialises the ExporterPurchaseDocumentsRichTextBox with the purchase invoices/supplier info
        /// </summary>
        /// <param name="salesInvoiceContent">The Sales Invoice content</param>
        private void InitializeExportPurchaseDocumentsContent(List<InvoiceProductModel> salesInvoiceContent)
        {
            ExporterPurchaseDocumentsRichTextBox.Text = docHandler.GetPurchaseDocumentsAs_SupplierPurchaseInvoicesGrouping(salesInvoiceContent);
        }

        /// <summary>
        /// Saves the current form's fields content to text files
        /// </summary>
        private void SaveFieldsAsTextFileButton_Click(object sender, EventArgs e)
        {
            pathToSaveFiles = fileHandler.GetFolderPathToHandleFiles();

            if (pathToSaveFiles != "")
            {
                if (CompanyInformationRichTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(CompanyInformationRichTextBox.Text.Split('\r', '\n'), CompanyInformationRichTextBox.Name.Replace("RichTextBox", "Text"), pathToSaveFiles);

                if (BuyerInformationRichTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(BuyerInformationRichTextBox.Text.Split('\r', '\n'), BuyerInformationRichTextBox.Name.Replace("RichTextBox", "Text"), pathToSaveFiles);

                if (ExporterStatementTitleTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(new string[] { ExporterStatementTitleTextBox.Text }, ExporterStatementTitleTextBox.Name.Replace("TextBox", "Text"), pathToSaveFiles);

                if (AffidavitTitleTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(new string[] { AffidavitTitleTextBox.Text }, AffidavitTitleTextBox.Name.Replace("TextBox", "Text"), pathToSaveFiles);

                if (ExporterStatementContent1RichTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(ExporterStatementContent1RichTextBox.Text.Split('\r', '\n'), ExporterStatementContent1RichTextBox.Name.Replace("RichTextBox", "Text"), pathToSaveFiles);

                if (ExporterStatementContent2RichTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(ExporterStatementContent2RichTextBox.Text.Split('\r', '\n'), ExporterStatementContent2RichTextBox.Name.Replace("RichTextBox", "Text"), pathToSaveFiles);

                if (ExporterPurchaseDocumentsRichTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(ExporterPurchaseDocumentsRichTextBox.Text.Split('\r', '\n'), ExporterPurchaseDocumentsRichTextBox.Name.Replace("RichTextBox", "Text"), pathToSaveFiles);

                if (AffidavitContentRichTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(AffidavitContentRichTextBox.Text.Split('\r', '\n'), AffidavitContentRichTextBox.Name.Replace("RichTextBox", "Text"), pathToSaveFiles);

                if (SalesAgentNameTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(new string[] { SalesAgentNameTextBox.Text }, SalesAgentNameTextBox.Name.Replace("TextBox", "Text"), pathToSaveFiles);

                if (StampSignaturePathTextBox.Text != string.Empty)
                    fileHandler.WriteToFile(new string[] { StampSignaturePathTextBox.Text }, StampSignaturePathTextBox.Name.Replace("TextBox", "Text"), pathToSaveFiles);
            }
        }

        #region LOAD CONTENT FROM TEXT FILES
        private void LoadExporterPurchaseDocsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExporterPurchaseDocumentsRichTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadExPorterStatementContentLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExporterStatementContent1RichTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadExporterStatementTitleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExporterStatementTitleTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadCompanyInformationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompanyInformationRichTextBox.Text = fileHandler.LoadSelectedTextFile();
            
        }

        private void LoadBuyerInformationLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuyerInformationRichTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadAffidavitTitleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AffidavitTitleTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadAffidavitContentLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AffidavitContentRichTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadSalesAgentNameLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SalesAgentNameTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadStampAndSignatureImagePathLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StampSignaturePathTextBox.Text = fileHandler.LoadSelectedTextFile();
        }

        private void LoadExPorterStatementContent2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExporterStatementContent2RichTextBox.Text = fileHandler.LoadSelectedTextFile();
        }
        #endregion

        /// <summary>
        /// Create Exporter Statement
        /// </summary>
        private void ExporterStatementButton_Click(object sender, EventArgs e)
        {
            pathToSaveFiles = fileHandler.GetFolderPathToHandleFiles();
            if (documentCreator.ValidateFields(CompanyInformationRichTextBox.Text,ExporterStatementTitleTextBox.Text, 
                ExporterStatementContent1RichTextBox.Text, ExporterPurchaseDocumentsRichTextBox.Text,
                ExporterStatementContent2RichTextBox.Text, SalesAgentNameTextBox.Text, StampSignaturePathTextBox.Text, pathToSaveFiles))
            {
                documentCreator.CreateExporterStatement(CompanyInformationRichTextBox.Text, ExporterStatementTitleTextBox.Text,
                                        ExporterStatementContent1RichTextBox.Text, ExporterPurchaseDocumentsRichTextBox.Text, 
                                        ExporterStatementContent2RichTextBox.Text,
                                        SalesAgentNameTextBox.Text, StampSignaturePathTextBox.Text, pathToSaveFiles);
            }
        }

        /// <summary>
        /// Create Affidavit Statement
        /// </summary>
        private void AffidavitButton_Click(object sender, EventArgs e)
        {
            pathToSaveFiles = fileHandler.GetFolderPathToHandleFiles();

            if (documentCreator.ValidateFields(AffidavitTitleTextBox.Text, AffidavitContentRichTextBox.Text, SalesAgentNameTextBox.Text, 
                                                                                        StampSignaturePathTextBox.Text, pathToSaveFiles))
            {
                DocumentCreator createExporterStatement = new DocumentCreator();
                createExporterStatement.CreateWordDocument("","",AffidavitTitleTextBox.Text, AffidavitContentRichTextBox.Text,"","", SalesAgentNameTextBox.Text,
                                                                                                                StampSignaturePathTextBox.Text, pathToSaveFiles);
            }
        }
        /// <summary>
        /// Create Packing List
        /// </summary>
        private void PackingListButton_Click(object sender, EventArgs e)
        {
            pathToSaveFiles = fileHandler.GetFolderPathToHandleFiles();
            if (salesInvoiceContent != null && salesInvoiceContent.Count > 0 &&
                documentCreator.ValidateFields(CompanyInformationRichTextBox.Text,BuyerInformationRichTextBox.Text,PalletsTextBox.Text, BoxesTextBox.Text, 
                                                                                                                        WeightTextBox.Text, pathToSaveFiles))
            {
                documentCreator.CreatePackingList(salesInvoiceContent, CompanyInformationRichTextBox.Text, BuyerInformationRichTextBox.Text, 
                                                                    PalletsTextBox.Text, BoxesTextBox.Text, WeightTextBox.Text, pathToSaveFiles);
            }
        }

        /// <summary>
        /// Gets the Path to the Stamp & Signature image
        /// </summary>
        private void GetPathToStampImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png" })
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    StampSignaturePathTextBox.Text = dialog.FileName;
                }
            }
        }

        /// <summary>
        /// Exits the form
        /// </summary>
        private void FinishButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears the form fields
        /// </summary>
        private void ClearFieldsButton_Click(object sender, EventArgs e)
        {
            CompanyInformationRichTextBox.Text = "";
            ExporterStatementTitleTextBox.Text = "";
            ExporterStatementContent1RichTextBox.Text = "";
            ExporterStatementContent2RichTextBox.Text = "";
            ExporterPurchaseDocumentsRichTextBox.Text = "";
            BuyerInformationRichTextBox.Text = "";
            AffidavitTitleTextBox.Text = "";
            AffidavitContentRichTextBox.Text = "";
            SalesAgentNameTextBox.Text = "";
            StampSignaturePathTextBox.Text = "";
            PalletsTextBox.Text = "";
            BoxesTextBox.Text = "";
            WeightTextBox.Text = "";
        }
    }
}
