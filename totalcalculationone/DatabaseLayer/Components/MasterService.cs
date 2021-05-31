using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatabaseLayer.Interfaces;
using Entities;
using DataObjects;
using DataObjects.AdoNet;

namespace DatabaseLayer.Components
{
    public class MasterService : BaseDAComponent, IMasterService
    {

        public List<UnitMaster> GetUnitMasters()
        {
            string sql = GetFullName("spDMSGetsUOM");
            return Db.ReadList(sql, MakeUnitMasters, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, UnitMaster> MakeUnitMasters = reader =>
         new UnitMaster
         {
             UnitId = reader["UnitId"].AsInt(),
             UOM = reader["UOM"].AsString(),
         };

        public List<CurrencyMaster> GetCurrencyMasters()
        {
            string sql = GetFullName("spDMSGetsCurrency");
            return Db.ReadList(sql, MakeCurrencyMaster, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, CurrencyMaster> MakeCurrencyMaster = reader =>
 new CurrencyMaster
 {
     CurrencyId = reader["CurrencyId"].AsInt(),
     Currency = reader["currency"].AsString(),

 };


        public List<ChargeCodeMaster> GetCodeMasters()
        {
            string sql = GetFullName("spDMSGetschargecode");
            return Db.ReadList(sql, MakeChargeCodeMaster, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, ChargeCodeMaster> MakeChargeCodeMaster = reader =>
 new ChargeCodeMaster
 {
     ChargeCodeId = reader["ChargeCodeId"].AsInt(),
     description = reader["description"].AsString(),
 };
        public List<PortMaster> GetPortMasters()
        {
            string sql = GetFullName("spDMSGetDepartureList");
            return Db.ReadList(sql, MakeLocation, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, PortMaster> MakeLocation = reader =>
new PortMaster
{
    PortId = reader["PortId"].AsInt(),
    Port_Name = reader["Port_Name"].AsString(),
    Country_Code = reader["Country_Code"].AsString(),
    Airport_Name = reader["Airport_Name"].AsString(),
    ISO_Region = reader["ISO_Region"].AsString(),
    City_Name = reader["City_Name"].AsString(),
    Local_Code = reader["Local_Code"].AsString(),

};

        public List<IncoTerms> GetIncoTerms()
        {
            string sql = GetFullName("spDMSGetincoterms");
            return Db.ReadList(sql, MakeIncoTerms, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, IncoTerms> MakeIncoTerms = reader =>
new IncoTerms
{
    IncoTermsId = reader["IncoTermsId"].AsInt(),
    IncoTermsCode = reader["IncoTermsCode"].AsString(),
    Description = reader["Description"].AsString(),

};


        public List<MovementTypeMaster> GetMovementTypeMasters()
        {
            string sql = GetFullName("spDMSGetmovementtype");
            return Db.ReadList(sql, MakeMovementTypeMaster, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, MovementTypeMaster> MakeMovementTypeMaster = reader =>
new MovementTypeMaster
{
   MovementTypeId = reader["MovementTypeId"].AsInt(),
   MovementTypeName = reader["MovementTypeName"].AsString(),

};

        public List<ModeMaster> GetModeMasters()
        {
            string sql = GetFullName("spDMSGetsMode");
            return Db.ReadList(sql, MakeModemaster, null, CommandType.StoredProcedure);
        }

        private static Func<IDataReader, ModeMaster> MakeModemaster = reader =>
new ModeMaster
{
ModeId = reader["ModeId"].AsInt(),
    Mode = reader["Mode"].AsString(),

};
    }
}
