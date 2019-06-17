using System.Collections.Generic;
using System.Windows;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Views.Add_edit;

namespace MeatFactory_proj.ViewModels
{
    class AllTransportViewModel : PropertyChangedVM
    {
        private RelayCommand<object> _addTransportCommand;
        private RelayCommand<object> _editTransportCommand;
        private RelayCommand<object> _deleteTransportCommand;

        public Transport SelectedTransport { get; set; }

        public List<Transport> Transports { get; set; }

        public AllTransportViewModel()
        {
            Transports = StationManager.DataStorage.selectAllTransports();
        }

        public RelayCommand<object> AddTransport =>
            _addTransportCommand ?? (_addTransportCommand = new RelayCommand<object>(o => AddTransportImplementation()));

        public RelayCommand<object> EditTransport =>
            _editTransportCommand ?? (_editTransportCommand = new RelayCommand<object>(o => EditTransportImplementation(), o => CanExecute()));

        public RelayCommand<object> DeleteTransport =>
            _deleteTransportCommand ?? (_deleteTransportCommand = new RelayCommand<object>(o => DeleteTransportImplementation(), o => CanExecute()));

        private void AddTransportImplementation()
        {
            StationManager.CurrentTransport = new Transport();
            AddTransport win = new AddTransport();
            win?.ShowDialog();
            UpdateTransportsList();
        }

        private void EditTransportImplementation()
        {
            StationManager.CurrentTransport = SelectedTransport;
            AddTransport win = new AddTransport();
            win?.ShowDialog();
            UpdateTransportsList();
        }

        private void DeleteTransportImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити транспорт", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteTransport(SelectedTransport.AutoNumber);
            UpdateTransportsList();
        }

        private bool CanExecute() => SelectedTransport != null;

        private void UpdateTransportsList()
        {
            Transports = StationManager.DataStorage.selectAllTransports();
            OnPropertyChanged("Transports");
        }
    }
}
