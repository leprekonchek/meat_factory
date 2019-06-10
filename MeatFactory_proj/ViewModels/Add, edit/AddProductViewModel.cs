using System;
using System.Windows;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class AddProductViewModel
    {
        private static Product Product { get; set; }
        private bool AddProduct { get; }

        #region Commands

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddProductViewModel()
        {
            Product = StationManager.CurrentProduct;
            AddProduct = Product == null;
        }

        public ICommand CancelCommand =>
            _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));

        public ICommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation));

        public bool CanExecute() => !String.IsNullOrEmpty(Product.Barcode);

        private void SaveImplementation(Window win)
        {
            if (AddProduct)
            {
                StationManager.DataStorage.insertNewProduct(Product);
                win?.Close();
            }
            else
                StationManager.DataStorage.updateProduct(Product);
        }
    }
}

