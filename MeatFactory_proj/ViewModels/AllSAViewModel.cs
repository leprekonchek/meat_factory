using System.Collections.Generic;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class AllSAViewModel
    {
        public List<SaleAgreement> SA { get; set; }

        public AllSAViewModel()
        {
            SA = StationManager.DataStorage.selectAllSaleAgreements();
        }
    }
}
