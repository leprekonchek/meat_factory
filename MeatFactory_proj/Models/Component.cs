namespace MeatFactory_proj.Models
{
    class Component
    {
        // Code, Name, Type, Quantity, Price, IsPackage
        // Component_code, Component_name, Component_type, Component_quantity, Component_price, IsPackage
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsPackage { get; set; }

    }
}
