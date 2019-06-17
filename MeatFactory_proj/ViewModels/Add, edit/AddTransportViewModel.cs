using System;
using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels.Add__edit
{
    class AddTransportViewModel
    {

        #region Properties and Commands

        public Transport Transport { get; set; }
        private bool AddTransport { get; }

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddTransportViewModel()
        {
            Transport = StationManager.CurrentTransport;
            AddTransport = Transport.AutoNumber == null;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, o => CanExecute()));

        public bool CanExecute() => !String.IsNullOrEmpty(Transport.AutoNumber) && !String.IsNullOrEmpty(Transport.Type)
                                                                                && !String.IsNullOrEmpty(Transport.Driver);

        private void SaveImplementation(Window win)
        {
            if (AddTransport) StationManager.DataStorage.insertNewTransport(Transport);
            else StationManager.DataStorage.updateTransport(Transport);
            win?.Close();
        }
    }
}
