using EDH.Library;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExportDocHandles
{
    public partial class ColumnHeaderSelectForm : Form
    {
        private IColumnHeaderRequester callingForm;
        private DocumentType documentType;
        private IDocHandler docHandler;

        public List<string> AllHeadersList { get; set; }
        public List<string> SelectedHeadersList { get; set; }
        public Dictionary<string, string> DocumentModel_ColumnHeaders_List { get; set; }

        //Constructor
        public ColumnHeaderSelectForm(IColumnHeaderRequester caller, List<string> allHeadersList, DocumentType docType, IDocHandler _docHandler)
        {
            InitializeComponent();
            callingForm = caller;
            AllHeadersList = allHeadersList;
            SelectedHeadersList = new List<string>();
            InitializeAllHeadersListBox(AllHeadersList);
            documentType = docType;
            ChangeUIElementsByDocType(documentType);
            docHandler = _docHandler;
        }

        /// <summary>
        /// Initializes the listbox containing all headers
        /// </summary>
        /// <param name="allHeadersList">All document headers</param>
        private void InitializeAllHeadersListBox(List<string> allHeadersList)
        {
            AllHeadersListBox.DataSource = null;
            AllHeadersListBox.DataSource = allHeadersList;
        }

        /// <summary>
        /// Initializes the listbox containing the selected headers
        /// </summary>
        /// <param name="selectedHeadersList">The selected document headers</param>
        private void InitializeSelectedHeadersListBox(List<string> selectedHeadersList)
        {
            SelectedHeadersListbox.DataSource = null;
            SelectedHeadersListbox.DataSource = selectedHeadersList;
        }


        /// <summary>
        /// Adds a header(selected Item) from AllHeadersListBox to the SelectedHeadersListBox
        /// And removes it from AllHeadersListBox
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (AllHeadersListBox.SelectedItem != null)
            {
                string selectedHeader = AllHeadersListBox.SelectedItem.ToString();
                SelectedHeadersList.Add(selectedHeader);
                AllHeadersList.Remove(selectedHeader);
                InitializeSelectedHeadersListBox(SelectedHeadersList);
                InitializeAllHeadersListBox(AllHeadersList);
            }
        }

        /// <summary>
        /// Removes a header/SelectedItem from the SelectedHeadersListBox and adds it to AllHeadersListBox
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (AllHeadersListBox.SelectedItem != null)
            {
                string selectedHeader = SelectedHeadersListbox.SelectedItem.ToString();
                SelectedHeadersList.Remove(selectedHeader);
                AllHeadersList.Add(selectedHeader);
                InitializeAllHeadersListBox(AllHeadersList);
                InitializeSelectedHeadersListBox(SelectedHeadersList);
            }
        }

        /// <summary>
        /// Changest the UI elements by document type(sales invoice/purchase report)
        /// </summary>
        /// <param name="documentType">The document type(sales invoice/purchase report)</param>
        private void ChangeUIElementsByDocType(DocumentType documentType)
        {
            if (documentType == DocumentType.SalesInvoice)
            {
                SelectDocumentLabel.Text = "[Document type: Invoice]";
                ProductCodeLabel.Text = "Product Code";
                PurchasedQuantityLabel.Text = " Quantity";
                DocumentDateLabel.Text = "Product Name";
                SupplierNameLabel.Text = "Country Of Origin";
                PurchaseInvoiceLabel.Visible = false;
            }
            else
            {
                PurchaseInvoiceLabel.Visible = true;

                SelectDocumentLabel.Text = "[Document type: Purchase Report]";
                ProductCodeLabel.Text = "Product Code";
                PurchasedQuantityLabel.Text = "Purchased Quantity";
                DocumentDateLabel.Text = "Document Date";
                SupplierNameLabel.Text = "Supplier Name";
                PurchaseInvoiceLabel.Text = "Purchase Invoice";
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
        /// Finishes the header selection process, sends back the selected headers to the calling form and closes
        /// the current one
        /// </summary>
        private void FinishHeaderSelectionButton_Click(object sender, EventArgs e)
        {
            if (documentType == DocumentType.PurchaseReport)
                DocumentModel_ColumnHeaders_List = docHandler.InitializeReportModelMapping(SelectedHeadersList);
            else
                DocumentModel_ColumnHeaders_List = docHandler.InitializeInvoiceModelMapping(SelectedHeadersList);

            callingForm.FinishedHeaderSelection(DocumentModel_ColumnHeaders_List, documentType);
            this.Close();
        }
    }
}
