using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.ViewModels.Add__edit;

namespace MeatFactory_proj.Views.Add_edit
{
    public partial class AddComponent : INavigatable
    {
        public AddComponent()
        {
            InitializeComponent();
            DataContext = new AddComponentViewModel();
        }
    }
}
