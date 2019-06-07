using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class ProductsAndComponents : INavigatable
    {
        public ProductsAndComponents()
        {
            InitializeComponent();
            DataContext = new ProductsAndComponentsViewModel();
        }
    }
}
