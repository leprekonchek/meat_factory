using System;

namespace MeatFactory_proj.Models
{
    class SaleAgreementAndProduct
    {
        public string Sale_agreement_number { get; set; }
        public string Barcode { get; set; }
        public int SAP_quantity { get; set; }
        public bool Is_returned { get; set; }
    }
}
