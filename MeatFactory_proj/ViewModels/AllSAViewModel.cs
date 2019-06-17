using System.Collections.Generic;
using System.Windows;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Views.Add_edit;

namespace MeatFactory_proj.ViewModels
{
    class AllSAViewModel : PropertyChangedVM
    {
        private RelayCommand<object> _addSACommand;
        private RelayCommand<object> _editSACommand;
        private RelayCommand<object> _deleteSACommand;

        public List<SaleAgreement> SA { get; set; }
        public SaleAgreement SelectedSA { get; set; }

        public AllSAViewModel()
        {
            SA = StationManager.DataStorage.selectAllSaleAgreements();
        }
        
        /*public RelayCommand<object> AddSA => _addSACommand ?? (_addSACommand = new RelayCommand<object>(o => AddSAImplementation()));
        public RelayCommand<object> EditSA => _editSACommand ?? (_editSACommand = new RelayCommand<object>(o => EditSAImplementation(), o => CanExecute()));
        public RelayCommand<object> DeleteSA => _deleteSACommand ?? (_deleteSACommand = new RelayCommand<object>(o => DeleteSAImplementation(), o => CanExecute()));

        private void AddTransportImplementation()
        {
            StationManager.CurrentSaleAgreement = new SaleAgreement();
            AddSA win = new AddSA();
            win?.ShowDialog();
        }

        private void EditTransportImplementation()
        {
            StationManager.CurrentTransport = SelectedTransport;
            AddTransport win = new AddTransport();
            win?.ShowDialog();
        }

        private void DeleteTransportImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити транспорт", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteTransport(SelectedTransport.AutoNumber);
            Transports = StationManager.DataStorage.selectAllTransports();
            OnPropertyChanged("Transports");
        }

        private bool CanExecute() => SelectedTransport != null;*/
    }
}
