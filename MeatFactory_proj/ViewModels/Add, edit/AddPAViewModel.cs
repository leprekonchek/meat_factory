using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels.Add__edit
{
    class AddPAViewModel
    {
        #region Properties and Commands

        public PurchaseAgreement PurchaseAgreement { get; set; }
        private bool AddPA { get; }
        public List<string> ProvisonersList { get; set; }

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddPAViewModel()
        {
            PurchaseAgreement = StationManager.CurrentPurchaseAgreement;
            AddPA = PurchaseAgreement.Number == null;
            ProvisonersList = StationManager.DataStorage.selectAllProvisionersName();
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, o => CanExecute()));

        public bool CanExecute() => !String.IsNullOrEmpty(PurchaseAgreement.Number) &&
                                    !String.IsNullOrEmpty(PurchaseAgreement.Date) &&
                                    !String.IsNullOrEmpty(PurchaseAgreement.EDRPOU);

        private void SaveImplementation(Window win)
        {
            if (AddPA) StationManager.DataStorage.insertNewPurchaseAgreement(PurchaseAgreement);
            else StationManager.DataStorage.updatePurchaseAgreement(PurchaseAgreement);
            win?.Close();
        }
    }
}
