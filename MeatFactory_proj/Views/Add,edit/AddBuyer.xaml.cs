using MeatFactory_proj.ViewModels.Add__edit;

namespace MeatFactory_proj.Views.Add_edit
{
    public partial class AddBuyer 
    {
        public AddBuyer()
        {
            InitializeComponent();
            DataContext = new AddBuyerViewModel();
        }
    }
}
