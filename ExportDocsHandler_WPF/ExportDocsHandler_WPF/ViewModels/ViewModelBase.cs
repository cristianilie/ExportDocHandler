using System.ComponentModel;

namespace ExportDocsHandler_WPF.ViewModels
{
    /// <summary>
    /// Base ViewModel class implementing the <see cref="INotifyPropertyChanged"/> interface
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
