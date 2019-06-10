namespace MeatFactory_proj.Tools.Navigation
{
    internal enum ViewType
    {
        StartView,
        ProductView,
        ProductsAndComponentsView,
        AddProductView,
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
