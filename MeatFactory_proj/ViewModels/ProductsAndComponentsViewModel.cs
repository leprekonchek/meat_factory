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

        private Product _selectedProductRecipe;
        // products
        private RelayCommand<object> _addProductCommand;
        private RelayCommand<object> _editProductCommand;
        private RelayCommand<object> _deleteProductCommand;
        // components
        private RelayCommand<object> _addComponentCommand;
        private RelayCommand<object> _editComponentCommand;
        private RelayCommand<object> _deleteComponentCommand;
        // recipe
        private RelayCommand<object> _addComponentToRecipeCommand;
        private RelayCommand<object> _deleteComponentFromRecipeCommand;

        #endregion

        #region Properties

        public List<Product> Products { get; set; }
        public List<Product> ProductsRecipe { get; set; }
        public List<Component> Components { get; set; }
        public List<Component> ComponentsRecipe { get; set; }

        public Component SelectedComponent { get; set; }
        public Product SelectedProduct { get; set; }

        public Component SelectedComponentRecipe { get; set; }
        public Product SelectedProductRecipe
        {
            get => _selectedProductRecipe;
            set
            {
                _selectedProductRecipe = value;
                UpdateComponentsRecipeList();
            }
        }

        #endregion

        public ProductsAndComponentsViewModel()
        {
            Products = StationManager.DataStorage.selectAllProducts();
            ProductsRecipe = StationManager.DataStorage.selectProductNameType();
            Components = StationManager.DataStorage.selectAllComponents();
        }

        #region Commands

        // recipe commands
        public RelayCommand<object> AddComponentToRecipe =>
            _addComponentToRecipeCommand ?? (_addComponentToRecipeCommand = new RelayCommand<object>(o => AddComponentToRecipeImplementation()));

        public RelayCommand<object> DeleteComponentFromRecipe =>
            _deleteComponentFromRecipeCommand ?? (_deleteComponentFromRecipeCommand = new RelayCommand<object>(o => DeleteComponentFromRecipeImplementation(), o => CanExecuteRecipe()));

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

        #region Recipes Implementation

        // RECIPES
        private void AddComponentToRecipeImplementation()
        {
            StationManager.CurrentComponentRecipe = new Component();
            StationManager.CurrentProductRecipe = SelectedProductRecipe;
            AddComponentToRecipe win = new AddComponentToRecipe();
            win.ShowDialog();
            UpdateComponentsRecipeList();
        }

        private void DeleteComponentFromRecipeImplementation()
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені?",
                $"Видалити цю компоненту {SelectedComponentRecipe.Name} з рецепту цього продукту {SelectedProductRecipe.Name}?",
                MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteComponentFromRecipe(SelectedComponentRecipe.Code, SelectedProductRecipe.Barcode);
            UpdateComponentsRecipeList();
        }

        #endregion

        #region Products Implementation

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
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити продукт", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteProduct(SelectedProduct.Barcode);
            UpdateProductsList();
        }

        #endregion

        #region Components Implementation

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
            MessageBoxResult result = MessageBox.Show("Ви впевнені?", "Видалити компоненту", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes) StationManager.DataStorage.deleteProduct(SelectedComponent.Code);
            UpdateComponentsList();
        }

        #endregion

        #region Open Windows

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

        #endregion

        #region CanExecute

        private bool CanExecuteProduct() => SelectedProduct != null;
        private bool CanExecuteComponent() => SelectedComponent != null;
        private bool CanExecuteRecipe() => SelectedProductRecipe != null && SelectedComponentRecipe != null;

        #endregion

        #region Update Lists

        public void UpdateComponentsList()
        {
            Components = StationManager.DataStorage.selectAllComponents();
            OnPropertyChanged("Components");
        }

        public void UpdateProductsList()
        {
            Products = StationManager.DataStorage.selectAllProducts();
            ProductsRecipe = StationManager.DataStorage.selectAllProducts();
            OnPropertyChanged("Products");
            OnPropertyChanged("ProductsRecipe");
        }

        public void UpdateComponentsRecipeList()
        {
            /*if (SelectedProductRecipe != null) */
            ComponentsRecipe = StationManager.DataStorage.selectComponentByProductId(SelectedProductRecipe.Barcode);
            OnPropertyChanged("ComponentsRecipe");
        }

        #endregion

    }
}
