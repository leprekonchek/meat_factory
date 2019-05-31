using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class ProductView : INavigatable
    {
        public ProductView()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }
    }
}
