namespace MeatFactory_proj.Models
{
    //EDRPOU Name Phone  IsLegal Street  BuildingNumber Town PostCode
    //EDRPOU_provisioner Provisioner_name Provisioner_phone Provisioner_is_legal Provisioner_street Provisioner_building_number  Provisioner_town Provisioner_post_code 
    class Provisioner
    {
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