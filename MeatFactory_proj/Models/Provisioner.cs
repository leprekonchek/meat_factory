namespace MeatFactory_proj.Models
{
    class Provisioner
    {
        // EDRPOU, Name, Phone, IsLegal, Street, BuildingNumber, Town, PostCode
        public string EDRPOU { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsLegal { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }
}