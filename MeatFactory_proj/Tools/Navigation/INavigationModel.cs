namespace MeatFactory_proj.Tools.Navigation
{
    internal enum ViewType
    {
        StartView,
        ProductView,
        ProductsAndComponentsView,
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
