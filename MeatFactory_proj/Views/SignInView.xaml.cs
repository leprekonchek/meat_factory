using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class SignInView : INavigatable
    {
        public SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
