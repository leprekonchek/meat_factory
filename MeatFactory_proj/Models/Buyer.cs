namespace MeatFactory_proj.Models
{
    //EDRPOU Name Phone  IsLegal Street  BuildingNumber Town PostCode
    //EDRPOU_buyer Buyer_name Buyer_phone Buyer_is_legal Buyer_street Buyer_building_number  Buyer_town Buyer_post_code 

    class Buyer
    {
        // EDRPOU, Name, Phone, IsLegal, Street, BuildingNumber, Town, PostCode
        public string EDRPOU { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool  IsLegal { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }
}
