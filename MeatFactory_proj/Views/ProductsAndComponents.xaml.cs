using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class ProductsAndComponents
    {
        public ProductsAndComponents()
        {
            InitializeComponent();
            DataContext = new ProductsAndComponentsViewModel();
        }
    }
}
