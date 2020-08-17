using System.Windows;

namespace ExportDocsHandler_WPF.ViewModels.Services
{
    /// <summary>
    /// Copy/Paste to/from clipboard
    /// </summary>
    public class ClipboardService : IClipboardService
    {
        public void SetText(string value)
        {
            Clipboard.SetText(value);
        }

        public string GetText()
        {
            return Clipboard.GetText();
        }
    }
}
