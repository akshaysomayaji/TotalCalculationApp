using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MasterData
    {
        public List<ChargeCodeMaster> chargeCodeMasters { get; set; }
        public List<MovementTypeMaster> movementTypeMasters { get; set; }
        public List<CurrencyMaster> currencyMasters { get; set; }
        public List<UnitMaster> UnitMasters { get; set; }
        public List<Customer> customers { get; set; }
        public List<PortMaster> portMasters { get; set; }
        public List<IncoTerms> IncoTerms { get; set; }

        public List<ModeMaster> Modemaster { get; set; }

    }
    public class ChargeCodeMaster
    {
        public int ChargeCodeId { get; set; }
        public string charge_code { get; set; }
        public string description { get; set; }
        public string gl_revenue_acct_code { get; set; }
        public string impnote { get; set; }
        public string saccode { get; set; }
        public string dept { get; set; }
        public string remarks { get; set; }
    }

    public class MovementTypeMaster
    {
        public int MovementTypeId { get; set; }
        public string MovementTypeName { get; set; }
    }

    public class CurrencyMaster
    {
        public int CurrencyId { get; set; }
        public string CountryCode { get; set; }
        public string Currency { get; set; }
        public string AlphabeticCode { get; set; }
        public string NumericCode { get; set; }
    }

    public class UnitMaster
    {
        public int UnitId { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
    }

    public class PortMaster
    {
        public int PortId { get; set; }
        public string Port_Name { get; set; }
        public string Country_Code { get; set; }
        public string Airport_Name { get; set; }
        public string ISO_Region { get; set; }
        public string City_Name { get; set; }
        public string Local_Code { get; set; }
    }

    public class IncoTerms
    {
        public int IncoTermsId { get; set; }
        public string IncoTermsCode { get; set; }
        public string Description { get; set; }
    }

    public class ModeMaster
    {
        public int ModeId { get; set; }
        public string Mode { get; set; }
         
    }
}
