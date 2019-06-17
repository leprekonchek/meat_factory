using System.Collections.Generic;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class AllPAViewModel : PropertyChangedVM
    {
        public List<PurchaseAgreement> PA { get; set; }

        public AllPAViewModel()
        {
            PA = StationManager.DataStorage.selectAllPurchaseAgreements();
        }
    }
}
