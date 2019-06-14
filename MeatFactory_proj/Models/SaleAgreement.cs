using System;


namespace MeatFactory_proj.Models
{
    //_date Number EDRPOU DateDB IsPaid
    //Sale_agreement_number EDRPOU_buyer Date_sa Is_paid
    class SaleAgreement
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