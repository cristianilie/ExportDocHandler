namespace ExportDocsHandler_WPF.ViewModels.Services
{
    public interface IClipboardService
    {
        string GetText();
        void SetText(string value);
    }
}