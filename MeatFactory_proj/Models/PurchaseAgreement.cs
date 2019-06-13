using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeatFactory_proj.Models
{
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
