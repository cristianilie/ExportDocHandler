using ExportDocsHandler_WPF.Views;

namespace ExportDocsHandler_WPF.ViewModels.Factories
{
    /// <summary>
    /// Creates a new <see cref="MissingInvoicesWindow"/>
    /// </summary>
    public class MissingInvoicesWindowCreator : ISimpleWindowCreator<MissingInvoicesWindow>
    {
        private DocumentHandlerViewModel documentHandlerViewModel;

        public MissingInvoicesWindowCreator(DocumentHandlerViewModel documentHandlerViewModel)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
        }

        public MissingInvoicesWindow CreateWindow()
        {
            return new MissingInvoicesWindow() { DataContext = new MissingInvoicesViewModel(documentHandlerViewModel) };
        }
    }
}
