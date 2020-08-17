using ExportDocsHandler_WPF.Commands;
using ExportDocsHandler_WPF.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.ViewModels
{
    public class ReportWordFilterViewModel : ViewModelBase
    {
        private DocumentHandlerViewModel documentHandlerViewModel;
        private string wordToAdd;
        private string wordToRemove;


        public ReportWordFilterViewModel(DocumentHandlerViewModel documentHandlerViewModel)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
            WordsToFilter = new ObservableCollection<string>();
            UpdateWordsToFilterListCommand = new UpdateWordsToFilterListCommand(this);
            FinishWordFilteringCommand = new FinishWordFilteringCommand(this);
        }

        //Properties
        public string WordToAdd
        {
            get { return wordToAdd; }
            set
            {
                wordToAdd = value;
                OnPropertyChanged(nameof(WordToAdd));
            }
        }
        public string WordToRemove
        {
            get { return wordToRemove; }
            set
            {
                wordToRemove = value;
                OnPropertyChanged(nameof(WordToRemove));
            }
        }
        public ObservableCollection<string> WordsToFilter { get; set; }


        //Commands
        public ICommand UpdateWordsToFilterListCommand { get; set; }
        public ICommand FinishWordFilteringCommand { get; set; }


        /// <summary>
        /// Adds 
        /// </summary>
        public void AddToWordList(string word)
        {
            if (!string.IsNullOrEmpty(word) && !string.IsNullOrWhiteSpace(word))
                WordsToFilter.Add(word);
        }

        /// <summary>
        /// Removesthe selected word from the words to filter list
        /// </summary>
        public void RemoveFromWordList(string word)
        {
            if (!string.IsNullOrEmpty(word) && !string.IsNullOrWhiteSpace(word))
                WordsToFilter.Remove(word);
        }

        /// <summary>
        /// Sends back the list with words to filter to the calling viewmodel, and closes the current window
        /// </summary>
        public void FinishWordFiltering(ICloseable window)
        {
            if(WordsToFilter != null)
                documentHandlerViewModel.FinishReportWordFiltering(WordsToFilter.ToList());

            if (window != null)
                window.Close();
        }


    }
}
