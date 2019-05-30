using System.Collections.Generic;
using MeatFactory_proj.Models;

namespace MeatFactory_proj.Database
{
    interface IDataStorage
    {
        List<Product> selectAllProducts();
        List<Buyer> selectAllBuyers();
        List<Component> selectAllComponents();
        List<Provisioner> selectAllProvisioners();
        List<Transport> selectAllTransports();
    }
}
