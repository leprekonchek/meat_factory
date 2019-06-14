using System;
using System.Globalization;

namespace MeatFactory_proj.Models
{
    // Barcode, Name, Type, Quantity, Weight, MeasureType, Price, ExpirationDate
    // Barcode, Product_name, Product_type, Product_quantity, Weight, Product_measure_type, Product_price, Expiration_date
    class Product
    {
        private string _date;
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string MeasureType { get; set; }
        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }
        public string Date
        {
            get
            {
                _date = ExpirationDate.Date.ToString("dd/MM/yyyy");
                return _date;
            }
            set => _date = value;
        }
    }
}
