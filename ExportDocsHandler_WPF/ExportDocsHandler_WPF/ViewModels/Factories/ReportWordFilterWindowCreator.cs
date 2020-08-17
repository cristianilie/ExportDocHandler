using ExportDocsHandler_WPF.Views;

namespace ExportDocsHandler_WPF.ViewModels.Factories
{
    /// <summary>
    /// Creates a new <see cref="ReportWordFilterWindow"/>
    /// </summary>
    public class ReportWordFilterWindowCreator : ISimpleWindowCreator<ReportWordFilterWindow>
    {
        private DocumentHandlerViewModel documentHandlerViewModel;

        public ReportWordFilterWindowCreator(DocumentHandlerViewModel documentHandlerViewModel)
        {
            this.documentHandlerViewModel = documentHandlerViewModel;
        }

        public ReportWordFilterWindow CreateWindow()
        {
            return new ReportWordFilterWindow() { DataContext = new ReportWordFilterViewModel(documentHandlerViewModel)};
        }
    }
}
