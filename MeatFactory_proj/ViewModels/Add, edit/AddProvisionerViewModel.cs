using System;
using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels.Add__edit
{
    class AddProvisionerViewModel
    {
        #region Properties and Commands

        public Provisioner Provisioner { get; set; }
        private bool AddProvisioner { get; }

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddProvisionerViewModel()
        {
            Provisioner = StationManager.CurrentProvisioner;
            AddProvisioner = Provisioner.EDRPOU == null;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation/*, o => CanExecute()*/));

        //public bool CanExecute() => !String.IsNullOrEmpty(Provisioner.Name) && !String.IsNullOrEmpty(Provisioner.Phone) &&
        //                            !String.IsNullOrEmpty(Provisioner.BuildingNumber) && !String.IsNullOrEmpty(Provisioner.PostCode) &&
        //                            !String.IsNullOrEmpty(Provisioner.EDRPOU) && !String.IsNullOrEmpty(Provisioner.Street) &&
        //                            !String.IsNullOrEmpty(Provisioner.Town);

        private void SaveImplementation(Window win)
        {
            if (AddProvisioner) StationManager.DataStorage.insertNewProvisioner(Provisioner);
            else StationManager.DataStorage.updateProvisioner(Provisioner);
            win?.Close();
        }
    }
}
