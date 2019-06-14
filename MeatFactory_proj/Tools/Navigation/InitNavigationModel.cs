using System;
using MeatFactory_proj.Views;
using MeatFactory_proj.Views.Add_edit;

namespace MeatFactory_proj.Tools.Navigation
{
    internal class InitNavigationModel : NavigationModel
    {
        public InitNavigationModel(IContentOwner contentOwner) : base(contentOwner) { }
        
        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.StartView:
                    ViewsDictionary.Add(viewType, new SignInView());
                    break;
                case ViewType.ProductView:
                    ViewsDictionary.Add(viewType, new ProductView());
                    break;
                //case ViewType.ProductsAndComponentsView:
                //    ViewsDictionary.Add(viewType, new ProductsAndComponents());
                    break;
                case ViewType.AddProductView:
                    ViewsDictionary.Add(viewType, new AddProduct());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
