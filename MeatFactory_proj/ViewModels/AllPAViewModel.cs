using System.Collections.Generic;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class AllPAViewModel
    {
        public List<PurchaseAgreement> PA { get; set; }

        public AllPAViewModel()
        {
            PA = StationManager.DataStorage.selectAllPurchaseAgreements();
        }
    }
}
