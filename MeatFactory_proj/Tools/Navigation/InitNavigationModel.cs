using System;
using MeatFactory_proj.Views;

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
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
