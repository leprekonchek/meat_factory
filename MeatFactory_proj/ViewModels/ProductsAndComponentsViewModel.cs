using System.Collections.Generic;
using System.Windows;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Views.Add_edit;
using Component = MeatFactory_proj.Models.Component;

namespace MeatFactory_proj.ViewModels
{
    class ProductsAndComponentsViewModel : PropertyChangedVM
    {
        #region Fields and Commands

        private Product _selectedProduct;

        private RelayCommand<object> _addProductCommand;
        private RelayCommand<object> _editProductCommand;
        private RelayCommand<object> _deleteProductCommand;

        #endregion

        #region Properties

        public List<Product> Products { get; set; }
        public List<Component> Components { get; set; }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                UpdateComponentsList();
            }
        }

        public ProductsAndComponentsViewModel() { Products = StationManager.DataStorage.selectAllProducts(); }

        public RelayCommand<object> AddProduct =>
            _addProductCommand ?? (_addProductCommand = new RelayCommand<object>(o => AddProductImplementation()));

        public RelayCommand<object> EditProduct =>
            _editProductCommand ?? (_editProductCommand = new RelayCommand<object>(o => EditProductImplementation(), o => CanExecute()));

        public RelayCommand<object> DeleteProduct =>
            _deleteProductCommand ?? (_deleteProductCommand = new RelayCommand<object>(o => DeleteProductImplementation(), o => CanExecute()));

        #endregion

        private void AddProductImplementation()
        {
            StationManager.CurrentProduct = new Product();
            OpenAddWindow();
        }

        private void EditProductImplementation()
        {
            StationManager.CurrentProduct = SelectedProduct;
            OpenAddWindow();
        }

        private void OpenAddWindow()
        {
            AddProduct win = new AddProduct();
            win.ShowDialog();
            UpdateProductsList();
        }

        private void DeleteProductImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete product", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteProduct(SelectedProduct.Barcode);
            UpdateProductsList();
        }

        private bool CanExecute() => SelectedProduct != null;

        public void UpdateComponentsList()
        {
            if (SelectedProduct != null) Components = StationManager.DataStorage.selectComponentByProductId(SelectedProduct.Barcode);
            OnPropertyChanged("Components");
        }

        public void UpdateProductsList()
        {
            Products = StationManager.DataStorage.selectAllProducts();
            OnPropertyChanged("Products");
        }
    }
}
