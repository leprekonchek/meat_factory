using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class BuyerAndProvisionerViewModel : PropertyChangedVM
    {
        #region Fields and Commands

        private Buyer _selectedBuyer;
        private Provisioner _selectedProvisioner;

        // buyers 
        private RelayCommand<object> _addBuyerCommand;
        private RelayCommand<object> _editBuyerCommand;
        private RelayCommand<object> _deleteBuyerCommand;
        // provisioners 
        private RelayCommand<object> _addProvisionerCommand;
        private RelayCommand<object> _editProvisionerCommand;
        private RelayCommand<object> _deleteProvisionerCommand;
        // sale agreements 
        private RelayCommand<object> _addSaleAgreementCommand;
        private RelayCommand<object> _editSaleAgreementCommand;
        private RelayCommand<object> _deleteSaleAgreementCommand;
        // purchase agreements 
        private RelayCommand<object> _addPurchaseAgreementCommand;
        private RelayCommand<object> _editPurchaseAgreementCommand;
        private RelayCommand<object> _deletePurchaseAgreementCommand;

        #endregion

        #region Properties and Commads

        public List<Buyer> Buyers { get; set; }
        public List<Provisioner> Provisioners { get; set; }
        public List<SaleAgreement> SaleAgreements { get; set; }
        public List<PurchaseAgreement> PurchaseAgreements { get; set; }

        public Buyer SelectedBuyer
        {
            get => _selectedBuyer;
            set
            {
                _selectedBuyer = value;
                UpdateSaleAgreementsList();
            }
        }

        public Provisioner SelectedProvisioner
        {
            get => _selectedProvisioner;
            set
            {
                _selectedProvisioner = value;
                UpdatePurchaseAgreementsList();
            }
        }

        public SaleAgreement SelectedSaleAgreement { get; set; }
        public PurchaseAgreement SelectedPurchaseAgreement { get; set; }

        #endregion

        public BuyerAndProvisionerViewModel()
        {
            Buyers = StationManager.DataStorage.selectAllBuyers();
            Provisioners = StationManager.DataStorage.selectAllProvisioners();
        }

        private void UpdateSaleAgreementsList()
        {
            SaleAgreements = StationManager.DataStorage.selectSAbyBuyerID(SelectedBuyer.EDRPOU);
            OnPropertyChanged("SaleAgreements");
        }

        private void UpdatePurchaseAgreementsList()
        {
            PurchaseAgreements = StationManager.DataStorage.selectPAbyProvisionerID(SelectedProvisioner.EDRPOU);
            OnPropertyChanged("PurchaseAgreements");
        }

    }
}
