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

        private RelayCommand<object> _addComponentCommand;
        private RelayCommand<object> _editComponentCommand;
        private RelayCommand<object> _deleteComponentCommand;

        #endregion

        #region Properties

        public List<Product> Products { get; set; }
        public List<Component> Components { get; set; }


        public Component SelectedComponent { get; set; }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                UpdateComponentsListSelect();
            }
        }
        
        public ProductsAndComponentsViewModel() { Products = StationManager.DataStorage.selectAllProducts(); }

        // products commands
        public RelayCommand<object> AddProduct =>
            _addProductCommand ?? (_addProductCommand = new RelayCommand<object>(o => AddProductImplementation()));

        public RelayCommand<object> EditProduct =>
            _editProductCommand ?? (_editProductCommand = new RelayCommand<object>(o => EditProductImplementation(), o => CanExecuteProduct()));

        public RelayCommand<object> DeleteProduct =>
            _deleteProductCommand ?? (_deleteProductCommand = new RelayCommand<object>(o => DeleteProductImplementation(), o => CanExecuteProduct()));

        // components commands
        public RelayCommand<object> AddComponent =>
            _addComponentCommand ?? (_addComponentCommand = new RelayCommand<object>(o => AddComponentImplementation()));

        public RelayCommand<object> EditComponent =>
            _editComponentCommand ?? (_editComponentCommand = new RelayCommand<object>(o => EditComponentImplementation(), o => CanExecuteComponent()));

        public RelayCommand<object> DeleteComponent =>
            _deleteComponentCommand ?? (_deleteComponentCommand = new RelayCommand<object>(o => DeleteComponentImplementation(), o => CanExecuteComponent()));

        #endregion

        // PRODUCTS
        private void AddProductImplementation()
        {
            StationManager.CurrentProduct = new Product();
            OpenAddProductWindow();
        }

        private void EditProductImplementation()
        {
            StationManager.CurrentProduct = SelectedProduct;
            OpenAddProductWindow();
        }

        private void DeleteProductImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete product", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteProduct(SelectedProduct.Barcode);
            UpdateProductsList();
        }

        // COMPONENTS
        private void AddComponentImplementation()
        {
            StationManager.CurrentComponent = new Component();
            OpenAddComponentWindow();
        }

        private void EditComponentImplementation()
        {
            StationManager.CurrentComponent = SelectedComponent;
            OpenAddComponentWindow();
        }

        private void DeleteComponentImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete component", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteProduct(SelectedComponent.Code);
            UpdateComponentsList();
        }

        private void OpenAddProductWindow()
        {
            AddProduct win = new AddProduct();
            win.ShowDialog();
            UpdateProductsList();
        }

        private void OpenAddComponentWindow()
        {
            AddComponent win = new AddComponent();
            win.ShowDialog();
            UpdateComponentsList();
        }

        private bool CanExecuteProduct() => SelectedProduct != null;
        private bool CanExecuteComponent() => SelectedComponent != null;

        public void UpdateComponentsListSelect()
        {
            if (SelectedProduct != null) Components = StationManager.DataStorage.selectComponentByProductId(SelectedProduct.Barcode);
            OnPropertyChanged("Components");
        }

        public void UpdateComponentsList()
        {
            Components = StationManager.DataStorage.selectAllComponents();
            OnPropertyChanged("Components");
        }

        public void UpdateProductsList()
        {
            Products = StationManager.DataStorage.selectAllProducts();
            OnPropertyChanged("Products");
        }
    }
}
