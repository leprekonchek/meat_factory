using MeatFactory_proj.ViewModels.Add__edit;

namespace MeatFactory_proj.Views.Add_edit
{
    public partial class AddPA
    {
        public AddPA()
        {
            InitializeComponent();
            DataContext = new AddPAViewModel();
        }
    }
}
