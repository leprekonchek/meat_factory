using System;


namespace MeatFactory_proj.Models
{
    //_date  Number EDRPOU DateDB IsPaid
    //Purchase_agreement_number Date_pa Is_paid EDRPOU_provisioner
    class PurchaseAgreement
    {
        private string _date;
        public string Number { get; set; }
        public string EDRPOU { get; set; }
        public DateTime DateDB { get; set; }
        public bool IsPaid { get; set; }

        public string Date
        {
            get
            {
                _date = DateDB.Date.ToString("dd/MM/yyyy");
                return _date;
            }
            set => _date = value;
        }
    }
}