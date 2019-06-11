using MeatFactory_proj.Tools;

namespace MeatFactory_proj.ViewModels
{
    internal class MainViewModel : PropertyChangedVM
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
    }
}
