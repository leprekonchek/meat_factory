using System.Collections.Generic;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class ProductViewModel
    {
        public List<Product> Products { get; set; }

        public ProductViewModel()
        {
            Products = StationManager.DataStorage.selectAllProducts();
        }
    }
}
