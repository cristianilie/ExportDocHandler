using EDH.Library;
using ExportDocHandles;
using ExportDocsHandler_WPF.Commands;
using ExportDocsHandler_WPF.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.ViewModels
{
    public class ColumnHeaderSelectorViewModel : ViewModelBase
    {
        #region Fields

        private DocumentHandlerViewModel documentHandlerViewModel;
        private DocumentType DocumentType;
        private List<string> documentRelatedHeadersList;
        private string selectedItemAllHeadersList;
        private string selectedItemSelectedHeadersList;

        #endregion

        public ColumnHeaderSelectorViewModel(DocumentHandlerViewModel documentHandlerViewModel, List<string> allColumnHeaders, DocumentType DocumentType)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
            AllHeadersList = new ObservableCollection<string>(allColumnHeaders);
            this.DocumentType = DocumentType;

            DocumentRelatedHeadersList = InitialiseExampleListView(DocumentType);
            SelectedHeadersList = new ObservableCollection<string>();

            AddHeaderCommand = new AddHeaderCommand(this);
            RemoveHeaderCommand = new RemoveHeaderCommand(this);
            FinishHeaderSelectionCommand = new FinishHeaderSelectionCommand(this, documentHandlerViewModel);
        }

        #region Properties

        //All column headers the current document has
        public ObservableCollection<string> AllHeadersList { get; set; }

        //The required column headers required to parse the excel document into a collection of related model objects
        public ObservableCollection<string> SelectedHeadersList { get; set; }

        //Selected Item from "AllHeadersList"
        public string SelectedItemAllHeadersList
        {
            get => selectedItemAllHeadersList;
            set
            {
                selectedItemAllHeadersList = value;
                OnPropertyChanged(nameof(SelectedItemAllHeadersList));
            }
        }

        //Selected Item from "SelectedHeadersList"
        public string SelectedItemSelectedHeadersList
        {
            get => selectedItemSelectedHeadersList;
            set
            {
                selectedItemSelectedHeadersList = value;
                OnPropertyChanged(nameof(SelectedItemSelectedHeadersList));
            }
        }

        //List of the needed headers and their order according to the current document
        public List<string> DocumentRelatedHeadersList
        {
            get => documentRelatedHeadersList;
            set
            {
                documentRelatedHeadersList = value;
                OnPropertyChanged(nameof(DocumentRelatedHeadersList));
            }
        }

        //The mapping of selected headers from the document matching the model properties
        public Dictionary<string, string> DocumentolumnHeaders { get; set; }

        //Commands
        public ICommand AddHeaderCommand { get; set; }
        public ICommand RemoveHeaderCommand { get; set; }
        public ICommand FinishHeaderSelectionCommand { get; set; }

        #endregion

        
        /// <summary>
        /// Returns a list of example headers/order according to the current document type
        /// </summary>
        private List<string> InitialiseExampleListView(DocumentType _DocumentType)
        {
            List<string> output = new List<string>();
            string pth = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DocumentType.ToString()}ColumnHeaders.txt").Replace(@"bin\Debug", "Helpers");

            using (StreamReader sr = new StreamReader(pth))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    output.Add($"{line}");
                }
            }

            return output;
        }

        /// <summary>
        /// Adds to the selected headers list and removes the selected item from the "all headers" list
        /// </summary>
        public void AddToSelectedHeadersList(string header)
        {
            if (header != null && header != "")
            {
                SelectedHeadersList.Add(header);
                AllHeadersList.Remove(header);
            }
        }

        /// <summary>
        /// Removes from the selected header list and adds it back to the "all headers" list
        /// </summary>
        public void RemoveFromSelectedHeadersList(string header)
        {
            if (header != null && header != "" && SelectedHeadersList != null)
            {
                AllHeadersList.Add(header);
                SelectedHeadersList.Remove(header);
            }
        }

        /// <summary>
        /// Sends back the selected column headers/model property mapping and closes the window
        /// </summary>
        public void FinishColumnHeaderSelection(ObservableCollection<string> _selectedHeadersList, ICloseable window, DocumentHandlerViewModel _documentHandlerViewModel)
        {
            if (_selectedHeadersList != null && _selectedHeadersList.Count() > 0)
            {
                IDocHandler docHandler = new DocHandler();

                if (DocumentType == DocumentType.SalesInvoice)
                    DocumentolumnHeaders = docHandler.InitializeInvoiceModelMapping(_selectedHeadersList.ToList());
                else
                    DocumentolumnHeaders = docHandler.InitializeReportModelMapping(_selectedHeadersList.ToList());

                _documentHandlerViewModel.FinishDocumentLoading(DocumentolumnHeaders, DocumentType);

                if (window != null)
                    window.Close();
            };
        }

    }
}
