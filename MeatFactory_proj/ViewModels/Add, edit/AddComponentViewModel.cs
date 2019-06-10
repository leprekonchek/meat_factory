using System;
using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels.Add__edit
{
    class AddComponentViewModel
    {
        #region Properties and Commands

        public Component Component { get; set; }
        private bool AddComponent { get; }

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddComponentViewModel()
        {
            Component = StationManager.CurrentComponent;
            AddComponent = Component.Code == null;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, o => CanExecute()));

        public bool CanExecute() => !String.IsNullOrEmpty(Component.Code) && !String.IsNullOrEmpty(Component.Name) && !String.IsNullOrEmpty(Component.Type);

        private void SaveImplementation(Window win)
        {
            if (AddComponent) StationManager.DataStorage.insertNewComponent(Component);
            else StationManager.DataStorage.updateComponent(Component);
            win?.Close();
        }
    }
}
