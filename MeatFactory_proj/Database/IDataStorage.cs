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
        List<string> selectAllProductsName();
        List<string> selectAllComponentsName();

        // user
        bool userExists(String login);
        String getPassword(string login);
        User getUser(string login);
        void insertNewUser(string login, string password, string role);

        // component
        List<Component> selectComponentByProductId(string barcode);
        void insertNewComponent(Component component);
        void updateComponent(Component component);
        void deleteComponent(string code);
        Component getComponentByName(string name);

        // component and product
        void deleteComponentFromRecipe(string code, string barcode);
        void insertNewComponentToRecipe(string code, string barcode);

        // product
        void insertNewProduct(Product product);
        void updateProduct(Product product);
        void deleteProduct(string barcode);
        List<Product> selectProductNameType();

        // buyer
        List<PurchaseAgreement> selectPAbyProvisionerID(string id);

        // provisioner
        List<SaleAgreement> selectSAbyBuyerID(string id);
    }
}
