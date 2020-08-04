using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExportDocHandles
{
    public partial class ReportFilterForm : Form
    {
        private IWordsToExcludeRequester callingForm;
        public List<string> WordsToExcludeFromInvoiceNameSearchList { get; set; }

        //Constructor
        public ReportFilterForm(IWordsToExcludeRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            WordsToExcludeFromInvoiceNameSearchList = new List<string>();
        }

        /// <summary>
        /// Initialises the WordsToExcludeListBox
        /// </summary>
        /// <param name="words">The list of words to filter the report by</param>
        private void InitializeWordsToExcludeListBox(List<string> words)
        {
            WordsToExcludeListBox.DataSource = null;
            WordsToExcludeListBox.DataSource = words;
        }

        /// <summary>
        /// Finishes the process of creating a list of words to exclude from searches(@ the purchase invoice number) in the 
        /// purchase report; Closes the form.
        /// </summary>
        private void FinishButton_Click(object sender, EventArgs e)
        {
            if (WordsToExcludeFromInvoiceNameSearchList != null)
                callingForm.FilteringComplete(WordsToExcludeFromInvoiceNameSearchList);

            this.Close();
        }

        /// <summary>
        /// Adds a word to the "words to exclude list" and initialises the WordsToExcludeListBox
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (WordsToExcludeTextBox.Text.Count() > 2)
            {
                WordsToExcludeFromInvoiceNameSearchList.Add(WordsToExcludeTextBox.Text.ToString());
                InitializeWordsToExcludeListBox(WordsToExcludeFromInvoiceNameSearchList);
                WordsToExcludeTextBox.Text = "";
            }
        }

        /// <summary>
        /// Removes a word from the "words to exclude list" and initialises the WordsToExcludeListBox
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (WordsToExcludeListBox.SelectedItem != null)
            {
                WordsToExcludeFromInvoiceNameSearchList.Remove(WordsToExcludeListBox.SelectedItem.ToString());

                if (WordsToExcludeFromInvoiceNameSearchList != null)
                    InitializeWordsToExcludeListBox(WordsToExcludeFromInvoiceNameSearchList);
            }
        }

        /// <summary>
        /// Closes the current form
        /// </summary>
        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
