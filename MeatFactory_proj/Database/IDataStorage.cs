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

        // buyer
        void insertNewBuyer(Buyer buyer);
        void updateBuyer(Buyer buyer);
        void deleteBuyer(string EDRPOU_buyer);

        // provisioner
        void insertNewProvisioner(Provisioner provisioner);
        void updateProvisioner(Provisioner provisioner);
        void deleteProvisioner(string EDRPOU_provisioner);

        // transport
        void insertNewTransport(Transport transport);
        void updateTransport(Transport transport);
        void deleteTransport(string Auto_number);

        //PurchaseAgreement
        void insertNewPurchaseAgreement(PurchaseAgreement purchaseAgreement);
        void updatePurchaseAgreement(PurchaseAgreement purchaseAgreement);
        void deletePurchaseAgreement(string Purchase_agreement_number);

        //PurchaseAgreement
        void insertNewSaleAgreement(PurchaseAgreement saleAgreement);
        void updateSaleAgreement(PurchaseAgreement saleAgreement);
        void deleteSaleAgreement(string Sale_agreement_number);


        //PurchaseAgreementAndComponent
        void insertNewPurchaseAgreementAndComponentt(PurchaseAgreementAndComponent saleAgreement);
        void updatePurchaseAgreementAndComponent(PurchaseAgreementAndComponent saleAgreement);
        void deletePurchaseAgreementAndComponent(string Component_сode, string Purchase_agreement_number);



        //SaleAgreementAndProduct
        void insertNewSaleAgreementAndProduct(SaleAgreementAndProduct saleAgreement);
        void updateSaleAgreementAndProduct(SaleAgreementAndProduct saleAgreement);
        void deleteSaleAgreementAndProduct(string SaleAgreementAndProduct, string Barcode;


    }
}
