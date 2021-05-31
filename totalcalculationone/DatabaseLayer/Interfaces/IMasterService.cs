using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DatabaseLayer.Interfaces
{
    public interface IMasterService
    {
        List<UnitMaster> GetUnitMasters();
        List<PortMaster> GetPortMasters();
        List<CurrencyMaster> GetCurrencyMasters();
        List<ChargeCodeMaster> GetCodeMasters();
        List<IncoTerms> GetIncoTerms();
        List<MovementTypeMaster> GetMovementTypeMasters();

        List<ModeMaster> GetModeMasters();
    }
}
