using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class AllSA
    {
        public AllSA()
        {
            InitializeComponent();
            DataContext = new AllSAViewModel();
        }
    }
}
