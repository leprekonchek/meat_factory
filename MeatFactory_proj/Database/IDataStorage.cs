using System;
using System.Collections.Generic;
using MeatFactory_proj.Models;

namespace MeatFactory_proj.Database
{
    interface IDataStorage
    {
        // select all
        List<Product> selectAllProducts();
        List<Buyer> selectAllBuyers();
        List<Component> selectAllComponents();
        List<Provisioner> selectAllProvisioners();
        List<Transport> selectAllTransports();

        // user
        bool userExists(String login);
        String getPassword(string login);
        User getUser(string login);
        void insertNewUser(string login, string password);

        // component
        List<Component> selectComponentByProductId(string barcode);

        // product
        void insertNewProduct(Product product);
        void updateProduct(Product product);
        void deleteProduct(string barcode);
    }
}
