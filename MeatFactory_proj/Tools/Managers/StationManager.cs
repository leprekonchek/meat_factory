using System.Windows.Controls;
using MeatFactory_proj.Database;
using MeatFactory_proj.Models;

namespace MeatFactory_proj.Tools.Managers
{
    class StationManager
    {
        public static IDataStorage DataStorage { get; } = new Database.Database();

        public static PasswordBox Password { get; set; }

        public static User CurrentUser { get; set; }
        public static Product CurrentProduct { get; set; }
        public static Component CurrentComponent { get; set; }
        public static Component CurrentComponentRecipe { get; set; }
        public static Product CurrentProductRecipe { get; set; }
        public static Buyer CurrentBuyer { get; set; }
        public static Provisioner CurrentProvisioner { get; set; }
        public static SaleAgreement CurrentSaleAgreement { get; set; }
        public static PurchaseAgreement CurrentPurchaseAgreement { get; set; }
    }
}
