using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class AllTransport 
    {
        public AllTransport()
        {
            InitializeComponent();
            DataContext = new AllTransportViewModel();
        }
    }
}
