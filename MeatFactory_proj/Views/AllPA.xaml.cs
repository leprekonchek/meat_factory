using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class AllPA
    {
        public AllPA()
        {
            InitializeComponent();
            DataContext = new AllPAViewModel();
        }
    }
}
