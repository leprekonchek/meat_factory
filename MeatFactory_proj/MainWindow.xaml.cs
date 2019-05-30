using MeatFactory_proj.ViewModels;

namespace MeatFactory_proj
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ProductsVM();
        }
    }
}
