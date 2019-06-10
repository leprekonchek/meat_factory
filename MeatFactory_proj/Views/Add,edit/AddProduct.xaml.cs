using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views.Add_edit
{
    public partial class AddProduct : INavigatable
    {
        public AddProduct()
        {
            InitializeComponent();
            DataContext = new AddProductViewModel();
        }
    }
}
