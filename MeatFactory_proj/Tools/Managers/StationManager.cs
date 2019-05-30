using MeatFactory_proj.Database;

namespace MeatFactory_proj.Tools.Managers
{
    class StationManager
    {
        private static IDataStorage _dataStorage = new Database.Database();

        public static IDataStorage DataStorage => _dataStorage;
    }
}
