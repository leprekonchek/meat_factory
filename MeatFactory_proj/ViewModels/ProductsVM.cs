using System.Collections.Generic;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class ProductsVM
    {
        public List<Product> Products { get; set; }

        public ProductsVM()
        {
            Products = StationManager.DataStorage.selectAllProducts();
        }
    }
}
