using MeatFactory_proj.ViewModels.Add__edit;

namespace MeatFactory_proj.Views.Add_edit
{
    public partial class AddComponentToRecipe
    {
        public AddComponentToRecipe()
        {
            InitializeComponent();
            DataContext = new AddComponentToRecipeViewModel();
        }
    }
}
