﻿namespace MeatFactory_proj.Tools.Navigation
{
    internal enum ViewType
    {
        StartView,
        ProductView,
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}