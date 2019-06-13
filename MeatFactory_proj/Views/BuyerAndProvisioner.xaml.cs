using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class BuyerAndProvisioner 
    {
        public BuyerAndProvisioner()
        {
            InitializeComponent();
            DataContext = new BuyerAndProvisionerViewModel();
        }
    }
}
