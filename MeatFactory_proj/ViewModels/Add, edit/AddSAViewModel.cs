using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels.Add__edit
{
    class AddSAViewModel
    {
        #region Properties and Commands

        public SaleAgreement SaleAgreement { get; set; }
        private bool AddSA { get; }
        public List<string> BuyersList { get; set; }

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddSAViewModel()
        {
            SaleAgreement = StationManager.CurrentSaleAgreement;
            AddSA = SaleAgreement.Number == null;
            BuyersList = StationManager.DataStorage.selectAllBuyersName();
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, o => CanExecute()));

        public bool CanExecute() => !String.IsNullOrEmpty(SaleAgreement.Number) &&
                                    !String.IsNullOrEmpty(SaleAgreement.Date) &&
                                    !String.IsNullOrEmpty(SaleAgreement.EDRPOU);

        private void SaveImplementation(Window win)
        {
            if (AddSA) StationManager.DataStorage.insertNewSaleAgreement(SaleAgreement);
            else StationManager.DataStorage.updateSaleAgreement(SaleAgreement);
            win?.Close();
        }
    }
}
