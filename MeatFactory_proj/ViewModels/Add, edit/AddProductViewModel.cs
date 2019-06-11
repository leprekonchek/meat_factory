using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class AddProductViewModel
    {
        #region Properties and Commands

        public Product Product { get; set; }
        private bool AddProduct { get; }
        public List<String> MeasureTypes { get; set; }


        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddProductViewModel()
        {
            Product = StationManager.CurrentProduct;
            AddProduct = Product.Barcode == null;
            MeasureTypes = new List<string> { "кг", "шт" };
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, o => CanExecute()));

        public bool CanExecute() => !String.IsNullOrEmpty(Product.Barcode) && !String.IsNullOrEmpty(Product.Name) && !String.IsNullOrEmpty(Product.Type);

        private void SaveImplementation(Window win)
        {
            if (AddProduct) StationManager.DataStorage.insertNewProduct(Product);
            else StationManager.DataStorage.updateProduct(Product);
            win?.Close();
        }
    }
}