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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
