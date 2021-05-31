using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class QuotationDetails : CommonData
    {
        public int QuotationDetailsId { get; set; }
        public int QuotationId { get; set; }
        public int SlNo { get; set; }
        public int ChargeCodeId { get; set; }
        public string UnitId { get; set; }
        public int CurrencyId { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public double Qty { get; set; }
        public double Total { get; set; }
        public double grandTotal { get; set; }
        public string Remarks { get; set; }
    }
}
