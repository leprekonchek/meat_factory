using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools.Managers;
using Component = MeatFactory_proj.Models.Component;

namespace MeatFactory_proj.ViewModels
{
    class ProductsAndComponentsViewModel : INotifyPropertyChanged
    {
        public List<Product> Products { get; set; }
        public List<Component> Components { get; set; }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                UpdateComponentsList();
            }
        }

        public ProductsAndComponentsViewModel()
        {
            Products = StationManager.DataStorage.selectAllProducts();
            //Components = StationManager.DataStorage.selectComponentByProductId(SelectedProduct.Barcode);
        }

        public void UpdateComponentsList()
        {
            if (SelectedProduct != null) Components = StationManager.DataStorage.selectComponentByProductId(SelectedProduct.Barcode);
            OnPropertyChanged("Components");
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
