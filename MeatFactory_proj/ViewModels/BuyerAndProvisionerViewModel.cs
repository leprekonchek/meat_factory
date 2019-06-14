using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Views.Add_edit;

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

        #region Properties

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

        #region Commands

        // buyers commands
        public RelayCommand<object> AddBuyer =>
            _addBuyerCommand ?? (_addBuyerCommand = new RelayCommand<object>(o => AddBuyerImplementation()));
        public RelayCommand<object> UpdateBuyer =>
            _editBuyerCommand ?? (_editBuyerCommand = new RelayCommand<object>(o => UpdateBuyerImplementation(), o => CanExecuteBuyer()));
        public RelayCommand<object> DeleteBuyer =>
            _deleteBuyerCommand ?? (_deleteBuyerCommand = new RelayCommand<object>(o => DeleteBuyerImplementation(), o => CanExecuteBuyer()));

        // provisioner commands
        public RelayCommand<object> AddProvisoner =>
            _addProvisionerCommand ?? (_addProvisionerCommand = new RelayCommand<object>(o => AddProvisonerImplementation()));
        public RelayCommand<object> UpdateProvisoner =>
            _editProvisionerCommand ?? (_editProvisionerCommand = new RelayCommand<object>(o => UpdateProvisonerImplementation(), o => CanExecuteProvisioner()));
        public RelayCommand<object> DeleteProvisoner =>
            _deleteProvisionerCommand ?? (_deleteProvisionerCommand = new RelayCommand<object>(o => DeleteProvisonerImplementation(), o => CanExecuteProvisioner()));

        // sale agreement commands
        public RelayCommand<object> AddSA =>
            _addSaleAgreementCommand ?? (_addSaleAgreementCommand = new RelayCommand<object>(o => AddSAImplementation()));
        public RelayCommand<object> UpdateSA =>
            _editSaleAgreementCommand ?? (_editSaleAgreementCommand = new RelayCommand<object>(o => UpdateSAImplementation(), o => CanExecuteSA()));
        public RelayCommand<object> DeleteSA =>
            _deleteSaleAgreementCommand ?? (_deleteSaleAgreementCommand = new RelayCommand<object>(o => DeleteSAImplementation(), o => CanExecuteSA()));

        // purchase agreement commands
        public RelayCommand<object> AddPA =>
            _addPurchaseAgreementCommand ?? (_addPurchaseAgreementCommand = new RelayCommand<object>(o => AddPAImplementation()));
        public RelayCommand<object> UpdatePA =>
            _editPurchaseAgreementCommand ?? (_editPurchaseAgreementCommand = new RelayCommand<object>(o => UpdatePAImplementation(), o => CanExecutePA()));
        public RelayCommand<object> DeletePA =>
            _deletePurchaseAgreementCommand ?? (_deletePurchaseAgreementCommand = new RelayCommand<object>(o => DeletePAImplementation(), o => CanExecutePA()));

        #endregion

        #region Buyer Implemetnation

        private void AddBuyerImplementation()
        {

        }

        private void UpdateBuyerImplementation()
        {

        }

        private void DeleteBuyerImplementation()
        {

        }

        #endregion

        #region Provisioner Implementation

        private void AddProvisonerImplementation()
        {

        }

        private void UpdateProvisonerImplementation()
        {

        }

        private void DeleteProvisonerImplementation()
        {

        }

        #endregion

        #region SA Implementation

        private void AddSAImplementation()
        {

        }

        private void UpdateSAImplementation()
        {

        }

        private void DeleteSAImplementation()
        {

        }

        #endregion
        
        #region PA Implementation

        private void AddPAImplementation()
        {

        }

        private void UpdatePAImplementation()
        {

        }

        private void DeletePAImplementation()
        {

        }

        #endregion

        #region Open Windows

        private void OpenAddProductWindow()
        {
            //AddBuyer win = new AddBuyer();
          //  win.ShowDialog();
            UpdateBuyersList();
        }

        private void OpenAddComponentWindow()
        {
            //AddProvisioner win = new AddProvisioner();
           // win.ShowDialog();
            UpdateProvisionersList();
        }

        private void OpenAddSAWindow()
        {
            //AddSA win = new AddSA();
           // win.ShowDialog();
            UpdateBuyersList();
        }

        private void OpenAddPAWindow()
        {
            //AddPA win = new AddPA();
           // win.ShowDialog();
            UpdateProvisionersList();
        }

        #endregion

        #region CanExecute

        private bool CanExecuteBuyer() => SelectedBuyer != null;
        private bool CanExecuteProvisioner() => SelectedProvisioner != null;
        private bool CanExecuteSA() => SelectedSaleAgreement != null;
        private bool CanExecutePA() => SelectedPurchaseAgreement != null;

        #endregion

        #region Update Lists

        private void UpdateBuyersList()
        {
            Buyers = StationManager.DataStorage.selectAllBuyers();
            OnPropertyChanged("Buyers");
        }

        private void UpdateProvisionersList()
        {
            Provisioners = StationManager.DataStorage.selectAllProvisioners();
            OnPropertyChanged("Provisioners");
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

        #endregion


    }
}
