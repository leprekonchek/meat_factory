using System.Windows.Controls;
using MeatFactory_proj.Tools.Managers;
using MeatFactory_proj.Tools.Navigation;
using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj
{
    public partial class MainWindow : IContentOwner
    {
        public ContentControl ContentControl => _contentControl;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            NavigationManager.Instance.Initialize(new InitNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.StartView);
        }
    }
}
