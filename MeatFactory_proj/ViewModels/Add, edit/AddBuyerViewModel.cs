using System;
using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels.Add__edit
{
    class AddBuyerViewModel
    {
        #region Properties and Commands

        public Buyer Buyer { get; set; }
        private bool AddBuyer { get; }

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddBuyerViewModel()
        {
            Buyer = StationManager.CurrentBuyer;
            AddBuyer = Buyer.EDRPOU == null;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, o => CanExecute()));

        public bool CanExecute() => !String.IsNullOrEmpty(Buyer.Name) && !String.IsNullOrEmpty(Buyer.Phone) &&
                                    !String.IsNullOrEmpty(Buyer.BuildingNumber) && !String.IsNullOrEmpty(Buyer.PostCode) &&
                                    !String.IsNullOrEmpty(Buyer.EDRPOU) && !String.IsNullOrEmpty(Buyer.Street) &&
                                    !String.IsNullOrEmpty(Buyer.Town);

        private void SaveImplementation(Window win)
        {
            if (AddBuyer) StationManager.DataStorage.insertNewBuyer(Buyer);
            else StationManager.DataStorage.updateBuyer(Buyer);
            win?.Close();
        }
    }
}
