using EDH.Library;
using ExportDocsHandler_WPF.Commands;
using ExportDocsHandler_WPF.ViewModels.Interfaces;
using ExportDocsHandler_WPF.ViewModels.Services;
using System.Linq;
using System.Windows.Input;

namespace ExportDocsHandler_WPF.ViewModels
{
    public class MissingInvoicesViewModel : ViewModelBase
    {
        private IDocHandler docHandler;
        private string missingInvoices;

        public MissingInvoicesViewModel(DocumentHandlerViewModel documentHandlerViewModel)
        {
            docHandler = new DocHandler();
            MissingInvoices = docHandler.GetPurchaseDocumentsAs_SupplierPurchaseInvoicesGrouping(
                                                documentHandlerViewModel.InvoiceContent.Where(d => d.FileWasMoved == false).ToList());

            CloseWindowCommand = new CloseWindowCommand(this);
            CopyToClipboardCommand = new CopyToClipboardCommand(this);
        }

        //Properties
        public string MissingInvoices
        {
            get => missingInvoices;
            set
            {
                missingInvoices = value;
                OnPropertyChanged(nameof(MissingInvoices));
            }
        }
        public IClipboardService ClipboardService { get; set; }

        //Commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand CopyToClipboardCommand { get; set; }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void CloseWindow(ICloseable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        /// <summary>
        /// Copies the missing invoices text to the clipboard
        /// </summary>
        public void CopyToClipboard(string text, IClipboardService clipboardService)
        {
            clipboardService.SetText(text);
        }
    }
}
