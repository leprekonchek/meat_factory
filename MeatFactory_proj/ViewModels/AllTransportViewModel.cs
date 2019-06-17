using System.Collections.Generic;
using MeatFactory_proj.Models;
using MeatFactory_proj.Tools.Managers;

namespace MeatFactory_proj.ViewModels
{
    class AllTransportViewModel
    {
        public List<Transport> Transports { get; set; }

        public AllTransportViewModel()
        {
            Transports = StationManager.DataStorage.selectAllTransports();
        }
    }
}
