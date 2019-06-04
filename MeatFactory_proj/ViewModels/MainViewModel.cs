using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeatFactory_proj.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private bool _isControlEnabled = true;

        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainViewModel() { }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
