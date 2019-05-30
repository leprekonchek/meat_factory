using System;

namespace MeatFactory_proj.Models
{
    class Product
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string MeasureType { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
