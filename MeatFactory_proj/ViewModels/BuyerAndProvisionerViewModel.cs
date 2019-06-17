using System.Collections.Generic;
using System.Windows;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Views;
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
        // other
        private RelayCommand<object> _transport;
        private RelayCommand<object> _allSA;
        private RelayCommand<object> _allPA;

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
        public RelayCommand<object> AddProvisioner =>
            _addProvisionerCommand ?? (_addProvisionerCommand = new RelayCommand<object>(o => AddProvisonerImplementation()));
        public RelayCommand<object> UpdateProvisioner =>
            _editProvisionerCommand ?? (_editProvisionerCommand = new RelayCommand<object>(o => UpdateProvisonerImplementation(), o => CanExecuteProvisioner()));
        public RelayCommand<object> DeleteProvisioner =>
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

        // side buttons
        //transport
        public RelayCommand<object> OpenTransportWindow =>
            _transport ?? (_transport = new RelayCommand<object>(o => TransportImplementation()));
        // all sa
        public RelayCommand<object> OpenAllSA =>
            _allSA ?? (_allSA = new RelayCommand<object>(o => AllSAImplementation()));
        // all pa
        public RelayCommand<object> OpenAllPA =>
            _allPA ?? (_allPA = new RelayCommand<object>(o => AllPAImplementation()));

        #endregion

        #region Buyer Implemetnation

        private void AddBuyerImplementation()
        {
            StationManager.CurrentBuyer = new Buyer();
            OpenAddBuyerWindow();
        }

        private void UpdateBuyerImplementation()
        {
            StationManager.CurrentBuyer = SelectedBuyer;
            OpenAddBuyerWindow();
        }

        private void DeleteBuyerImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити покупця", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteBuyer(SelectedBuyer.EDRPOU);
            UpdateBuyersList();
        }

        #endregion

        #region Provisioner Implementation

        private void AddProvisonerImplementation()
        {
            StationManager.CurrentProvisioner = new Provisioner();
            OpenAddProvisionerWindow();
        }

        private void UpdateProvisonerImplementation()
        {
            StationManager.CurrentProvisioner = SelectedProvisioner;
            OpenAddProvisionerWindow();
        }

        private void DeleteProvisonerImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити постачальника", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteProvisioner(SelectedProvisioner.EDRPOU);
            UpdateProvisionersList();
        }

        #endregion

        #region SA Implementation

        private void AddSAImplementation()
        {
            StationManager.CurrentSaleAgreement = new SaleAgreement();
            OpenAddSAWindow();
        }

        private void UpdateSAImplementation()
        {
            StationManager.CurrentSaleAgreement = SelectedSaleAgreement;
            OpenAddSAWindow();
        }

        private void DeleteSAImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити договір на продаж", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteSaleAgreement(SelectedSaleAgreement.Number);
            UpdateSaleAgreementsList();
        }

        private void AllSAImplementation()
        {
            AllSA win = new AllSA();
            win?.ShowDialog();
        }

        #endregion

        #region PA Implementation

        private void AddPAImplementation()
        {
            StationManager.CurrentPurchaseAgreement = new PurchaseAgreement();
            OpenAddPAWindow();
        }

        private void UpdatePAImplementation()
        {
            StationManager.CurrentPurchaseAgreement = SelectedPurchaseAgreement;
            OpenAddPAWindow();
        }

        private void DeletePAImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити договір на купівлю", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deletePurchaseAgreement(SelectedPurchaseAgreement.Number);
            UpdatePurchaseAgreementsList();
        }

        private void AllPAImplementation()
        {
            AllPA win = new AllPA();
            win?.ShowDialog();
        }

        #endregion

        #region Transport

        private void TransportImplementation()
        {
            AllTransport win = new AllTransport();
            win?.ShowDialog();
        }

        #endregion

        #region Open Windows

        private void OpenAddBuyerWindow()
        {
            AddBuyer win = new AddBuyer();
            win.ShowDialog();
            UpdateBuyersList();
        }

        private void OpenAddProvisionerWindow()
        {
            AddProvisioner win = new AddProvisioner();
            win.ShowDialog();
            UpdateProvisionersList();
        }

        private void OpenAddSAWindow()
        {
            AddSA win = new AddSA();
            win.ShowDialog();
            UpdateSaleAgreementsList();
        }

        private void OpenAddPAWindow()
        {
            AddPA win = new AddPA();
            win.ShowDialog();
            UpdatePurchaseAgreementsList();
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
            if (SelectedBuyer != null) SaleAgreements = StationManager.DataStorage.selectSAbyBuyerID(SelectedBuyer.EDRPOU);
            OnPropertyChanged("SaleAgreements");
        }

        private void UpdatePurchaseAgreementsList()
        {
            if (SelectedProvisioner != null) PurchaseAgreements = StationManager.DataStorage.selectPAbyProvisionerID(SelectedProvisioner.EDRPOU);
            OnPropertyChanged("PurchaseAgreements");
        }

        #endregion

    }
}
