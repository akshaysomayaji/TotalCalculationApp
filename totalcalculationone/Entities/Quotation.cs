using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Quotation : CommonData
    {
        public int QuotationId { get; set; }
        public string QuotationNumber { get; set; }
        public int intCustomerId { get; set; }
        public int intShipperId { get; set; }
        public int intConsigneeId { get; set; }
        public int intDepartureId { get; set; }
        public int intDestinationId { get; set; }
        public int intDeliveryTo { get; set; }
        public string DeliveryTo { get; set; }
        public int NoofPackages { get; set; }
        public int IncoTermsId { get; set; }
        public string Commodity { get; set; }
        public double ActualWeight { get; set; }
        public double ChargeableWeight { get; set; }
        public DateTime QuotationDate { get; set; }
        public string KWERefNo { get; set; }
        public string UserId { get; set; }
        public DateTime Validity { get; set; }
        public int POL { get; set; }
        public int POU { get; set; }
        public string ServiceType { get; set; }
        public int MovementTypeId { get; set; }
        public int DimensionId { get; set; }
        public int ModeId { get; set; }
        public string CargoPickUp { get; set; }
        public string Dimension { get; set; }
        public string CustomerReference { get; set; }

        public bool TopLoadableYes { get; set; }
        public bool TopLoadableNo { get; set; }
        public bool StackableYes { get; set; }
        public bool StackableNo { get; set; }
        public bool LoadCapLowerDeck { get; set; }
        public bool LoadCapMainDeck { get; set; }
        public bool DGRPax { get; set; }
        public bool DGRCao { get; set; }
        public bool TypeofCont20DC { get; set; }
        public bool TypeofCont40DC { get; set; }
        public bool TypeofCont40HC { get; set; }
        public bool TypeofCont20OTFR { get; set; }
        public bool TypeofCont40OTFR { get; set; }
          
        public List<QuotationDetails> QuotationDetails { get; set; }

    }
}
