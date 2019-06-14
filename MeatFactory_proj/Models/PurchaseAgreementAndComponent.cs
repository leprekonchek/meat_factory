using System;

namespace MeatFactory_proj.Models
{
    //Component_сode  Purchase_agreement_number PAC_quantity PAC_measure_type
    
    class PurchaseAgreementAndComponent
    {

        public string Component_сode { get; set; }
        public string Purchase_agreement_number { get; set; }
        public int PAC_quantity { get; set; }
        public string PAC_measure_type { get; set; }
    }
}
