using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels.Add__edit
{
    class AddComponentToRecipeViewModel
    {
        #region Properties and Commands

        public Component Component { get; set; }
        public Product Product { get; set; }

        public List<string> ProductsList => StationManager.DataStorage.selectAllProductsName();
        public List<string> ComponentsList => StationManager.DataStorage.selectAllComponentsName();

        private ICommand _saveCommand;
        private ICommand _cancelCommand;

        #endregion

        public AddComponentToRecipeViewModel()
        {
            Product = StationManager.CurrentProductRecipe;
            Component = null;
        }

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close()));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, o => CanExecute()));

        public bool CanExecute() => !String.IsNullOrEmpty(Component.Name);

        private void SaveImplementation(Window win)
        {
            Component = StationManager.DataStorage.getComponentByName(Component.Name);
            StationManager.DataStorage.insertNewComponentToRecipe(Component.Code, Product.Barcode);
            win?.Close();
        }
    }
}
