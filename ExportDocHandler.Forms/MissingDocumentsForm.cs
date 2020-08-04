using EDH.Library;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExportDocHandles
{
    public partial class MissingDocumentsForm : Form
    {
        private IDocHandler docHandler;
        public List<InvoiceProductModel> MissingDocuments { get; set; }

        //Constructor
        public MissingDocumentsForm(List<InvoiceProductModel> missingDocuments, IDocHandler _docHandler)
        {
            InitializeComponent();
            MissingDocuments = missingDocuments;
            docHandler = _docHandler;

            if (MissingDocuments != null)
                InitializeMissingDocsRichTextBox(docHandler.GetPurchaseDocumentsAs_SupplierPurchaseInvoicesGrouping(MissingDocuments));
        }

        /// <summary>
        /// Display the names of the missing documents in the MissingDocumentsRichTextBox
        /// </summary>
        private void InitializeMissingDocsRichTextBox(string _missingDocuments)
        {
            MissingDocumentsRichTextBox.Text = _missingDocuments;
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Copies to clipboard the missing document names
        /// </summary>
        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (MissingDocumentsRichTextBox.Text != "")
                System.Windows.Forms.Clipboard.SetText(MissingDocumentsRichTextBox.Text);
        }
    }
}
