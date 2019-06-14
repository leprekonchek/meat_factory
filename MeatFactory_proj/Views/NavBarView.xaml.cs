using System.Windows.Controls;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj.Views
{
    public partial class NavBarView : INavigatable, IContentOwner
    {
        public NavBarView()
        {
            InitializeComponent();
            DataContext = new NavBarViewModel();
                //NavigationManager.Instance.Initialize(new MenuNavigationModel(this));
        }

        public ContentControl ContentControl => _contentControl;
    }
}
