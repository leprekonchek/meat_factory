using System.Windows.Controls;
using MeatFactory_proj.Database;
using MeatFactory_proj.Models;

namespace MeatFactory_proj.Tools.Managers
{
    class StationManager
    {
        private static IDataStorage _dataStorage = new Database.Database();

        public static IDataStorage DataStorage => _dataStorage;

        public static PasswordBox Password { get; set; }

        public static User CurrentUser { get; set; }

        public static Product CurrentProduct { get; set; }
    }
}
