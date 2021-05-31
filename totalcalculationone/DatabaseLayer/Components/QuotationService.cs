using System;
using System.Data;
using Entities;
using System.Collections.Generic;
using DataObjects;
using DataObjects.AdoNet;

namespace DatabaseLayer.Components
{
    public class QuotationService : BaseDAComponent, IQuotationService
    {
        public Quotation GenerateQuotationNumber()
        {
            string sql = GetFullName("spGenerateQuotationNumber");
            List<Quotation> quotations= Db.ReadList(sql, MakeUnitMasters, null, CommandType.StoredProcedure);
            Quotation quotation =  quotations.Count > 0 ? quotations[0] : new Quotation() { };
            if (String.IsNullOrEmpty(quotation.QuotationNumber))
            {
                quotation.QuotationNumber = "Quot00001";
            }
            else
            {
                string num = "0000";
                if(quotation.QuotationId >= 10)
                {
                    if(quotation.QuotationId >= 100 && quotation.QuotationId < 1000)
                    {
                        num = "00";
                    }
                    else
                    {
                        num = "000";
                    }
                }
                // quotation.QuotationNumber = $"Quot{num}{++quotation.QuotationId}";
                quotation.QuotationNumber = $"Quot{num}{++quotation.QuotationId}";
            }
            return quotation;
        }

        public Response SaveQuotation(Quotation quotation, int UserId, out List<ErrorData> errors)
        {
            string sql = GetFullName("spSaveQuotations");
            DataSet dsOutput;
            object[] parms = { "@quotations", Quotations(new List<Quotation>() { quotation }), "@quotationDetails", QuotatonDetails(quotation.QuotationDetails), "@intUserId", UserId};

            Response response;

            dsOutput = Db.ReadMultipleRecordSet(sql, parms, CommandType.StoredProcedure);
            base.MakeErrorResponse(dsOutput, out response, out errors);
            dsOutput = null;

            return response;
        }

        private DataTable Quotations(List<Quotation> quotations)
        {
            DataTable dtblQuotations = new DataTable();
            DataRow drowQuotations;
            dtblQuotations.Columns.Add("QuotationNumber");
            dtblQuotations.Columns.Add("intCustomerId");
            dtblQuotations.Columns.Add("intShipperId");
            dtblQuotations.Columns.Add("intConsigneeId");
            dtblQuotations.Columns.Add("intDepartureId");
            dtblQuotations.Columns.Add("intDestinationId");
            dtblQuotations.Columns.Add("DeliveryTo");
            dtblQuotations.Columns.Add("NoofPackages");
            dtblQuotations.Columns.Add("IncoTermsId");
            dtblQuotations.Columns.Add("Commodity");
            dtblQuotations.Columns.Add("ActualWeight");
            dtblQuotations.Columns.Add("ChargeableWeight");
            dtblQuotations.Columns.Add("QuotationDate");
            dtblQuotations.Columns.Add("KWERefNo");
            dtblQuotations.Columns.Add("UserId");
            dtblQuotations.Columns.Add("Validity");
            dtblQuotations.Columns.Add("POL");
            dtblQuotations.Columns.Add("POU");
            dtblQuotations.Columns.Add("ServiceType");
            dtblQuotations.Columns.Add("MovementTypeId");
            dtblQuotations.Columns.Add("DimensionId");
            dtblQuotations.Columns.Add("ModeId");
            dtblQuotations.Columns.Add("CargoPickup");
            dtblQuotations.Columns.Add("Dimension");
            dtblQuotations.Columns.Add("CustomerReference");
            dtblQuotations.Columns.Add("TopLoadableYes");
            dtblQuotations.Columns.Add("TopLoadableNo");
            dtblQuotations.Columns.Add("StackableYes");
            dtblQuotations.Columns.Add("StackableNo");
            dtblQuotations.Columns.Add("LoadCapLowerDeck");
            dtblQuotations.Columns.Add("LoadCapMainDeck");
            dtblQuotations.Columns.Add("DGRPax");
            dtblQuotations.Columns.Add("DGRCao");
            dtblQuotations.Columns.Add("TypeofCont20DC");
            dtblQuotations.Columns.Add("TypeofCont40DC");
            dtblQuotations.Columns.Add("TypeofCont40HC");
            dtblQuotations.Columns.Add("TypeofCont20OTFR");
            dtblQuotations.Columns.Add("TypeofCont40OTFR");
            

            foreach (Quotation quotation in quotations)
            {
                drowQuotations = dtblQuotations.NewRow();
                drowQuotations["QuotationNumber"] = GenerateQuotationNumber().QuotationNumber.AsString();
                drowQuotations["intCustomerId"]=quotation.intConsigneeId.AsInt();
                drowQuotations["intShipperId"]=quotation.intShipperId.AsInt();
                drowQuotations["intConsigneeId"]=quotation.intConsigneeId.AsInt();
                drowQuotations["intDepartureId"]=quotation.intDepartureId.AsInt();
                drowQuotations["intDestinationId"]=quotation.intDestinationId.AsInt();
                drowQuotations["DeliveryTo"] = quotation.DeliveryTo.AsString();
                drowQuotations["NoofPackages"]=quotation.NoofPackages.AsInt();
                drowQuotations["IncoTermsId"]=quotation.IncoTermsId.AsInt();
                drowQuotations["Commodity"]=quotation.Commodity.AsString();
                drowQuotations["ActualWeight"]=quotation.ActualWeight.AsString();
                drowQuotations["ChargeableWeight"]=quotation.ChargeableWeight.AsDouble();
                drowQuotations["QuotationDate"]=quotation.QuotationDate.AsFormatDateTime();
                drowQuotations["KWERefNo"]=quotation.KWERefNo.AsString();
                drowQuotations["UserId"]=quotation.UserId.AsString();
                drowQuotations["Validity"] = quotation.Validity.AsFormatDateTime();
                drowQuotations["POL"]=quotation.POL.AsInt();
                drowQuotations["POU"]=quotation.POU.AsInt();
                drowQuotations["ServiceType"]=quotation.ServiceType.AsString();
                drowQuotations["MovementTypeId"]=quotation.MovementTypeId.AsInt();
                drowQuotations["DimensionId"]=quotation.DimensionId.AsInt();
                drowQuotations["ModeId"] = quotation.ModeId.AsInt();
                drowQuotations["CargoPickup"] = quotation.CargoPickUp.AsString();
                drowQuotations["Dimension"] = quotation.Dimension.AsString();
                drowQuotations["CustomerReference"] = quotation.CustomerReference.AsString();

                drowQuotations["TopLoadableYes"] = quotation.TopLoadableYes;
                drowQuotations["TopLoadableNo"] = quotation.TopLoadableNo ;
                drowQuotations["StackableYes"] = quotation.StackableYes ;
                drowQuotations["StackableNo"] = quotation.StackableNo ;
                drowQuotations["LoadCapLowerDeck"] = quotation.LoadCapLowerDeck ;
                drowQuotations["LoadCapMainDeck"] = quotation.LoadCapMainDeck ;
                drowQuotations["DGRPax"] = quotation.DGRPax ;
                drowQuotations["DGRCao"] = quotation.DGRCao ;
                drowQuotations["TypeofCont20DC"] = quotation.TypeofCont20DC ;
                drowQuotations["TypeofCont40DC"] = quotation.TypeofCont40DC ;
                drowQuotations["TypeofCont40HC"] = quotation.TypeofCont40HC ;
                drowQuotations["TypeofCont20OTFR"] = quotation.TypeofCont40OTFR ;
                drowQuotations["TypeofCont40OTFR"] = quotation.TypeofCont40OTFR ;

                dtblQuotations.Rows.Add(drowQuotations);
            }
            return dtblQuotations;
        }
        private DataTable QuotatonDetails(List<QuotationDetails> quotationDetails)
        {
            double grandtotal = 0;
            foreach(QuotationDetails qouat in quotationDetails)
            {
                grandtotal = grandtotal + qouat.Total.AsDouble();
            }
            DataTable quotationTable = new DataTable();
            DataRow quotationRow;
             quotationTable.Columns.Add("QuotationId");
	         quotationTable.Columns.Add("SlNo");
	         quotationTable.Columns.Add("ChargeCodeId");
	         quotationTable.Columns.Add("UnitId");
	         quotationTable.Columns.Add("CurrencyId");
	         quotationTable.Columns.Add("Cost");
	         quotationTable.Columns.Add("Price");
	         quotationTable.Columns.Add("Qty");
	         quotationTable.Columns.Add("Total");
	         quotationTable.Columns.Add("grandTotal");
	         quotationTable.Columns.Add("Remarks");

            foreach(QuotationDetails quotationDetail in quotationDetails)
            {
                quotationRow = quotationTable.NewRow();
                quotationRow["QuotationId"] = quotationDetail.QuotationId.AsId();
                quotationRow["SlNo"] = quotationDetail.SlNo.AsId();
                quotationRow["ChargeCodeId"] = quotationDetail.ChargeCodeId.AsId();
                quotationRow["UnitId"] = quotationDetail.UnitId.AsString();
                quotationRow["CurrencyId"] = quotationDetail.CurrencyId.AsId();
                quotationRow["Cost"] = quotationDetail.Cost.AsDouble();
                quotationRow["Price"] = quotationDetail.Price.AsDouble();
                quotationRow["Qty"] = quotationDetail.Qty.AsDouble();
                quotationRow["Total"] = quotationDetail.Total.AsDouble();
                quotationRow["grandTotal"] = grandtotal;
                quotationRow["Remarks"] = quotationDetail.Remarks.AsString();
                quotationTable.Rows.Add(quotationRow);
            }

            return quotationTable;
    }

        public Quotation GetQuotation(string QuotationNumber)
        {
            string sql_string_quottion = $"select * from [dbo].[tblQuotation] where QuotationNumber = '{QuotationNumber}' and flgActive = 1";
            Quotation quotation =  Db.Read(sql_string_quottion, MakeQuotation, null, CommandType.Text);
            string sql_string_quottiondetals = $"select * from [dbo].[tblQuotationDetails] where QuotationId = {quotation.QuotationId} and flgActive = 1";
            quotation.QuotationDetails = Db.ReadList(sql_string_quottiondetals, MakeQuotationDetails, null, CommandType.Text);
            return quotation;
        }

        private static Func<IDataReader, Quotation> MakeUnitMasters = reader =>
       new Quotation
       {
           QuotationId = reader["QuotationId"].AsInt(),
           QuotationNumber = reader["QuotationNumber"].AsString(),
       };

        private static Func<IDataReader, Quotation> MakeQuotation = reader =>
      new Quotation
      {
          QuotationId = reader["QuotationId"].AsInt(),
          QuotationNumber = reader["QuotationNumber"].AsString(),
          intCustomerId = reader["intCustomerId"].AsInt(),
          intShipperId = reader["intShipperId"].AsInt(),
          intConsigneeId = reader["intConsigneeId"].AsInt(),
          intDepartureId = reader["intDepartureId"].AsInt(),
          intDestinationId = reader["intDestinationId"].AsInt(),
          DeliveryTo = reader["DeliveryTo"].AsString(),
          NoofPackages = reader["NoofPackages"].AsInt(),
          IncoTermsId = reader["IncoTermsId"].AsId(),
          Commodity = reader["Commodity"].AsString(),
          ActualWeight = reader["ActualWeight"].AsDouble(),
          ChargeableWeight = reader["ChargeableWeight"].AsDouble(),
          QuotationDate = reader["QuotationDate"].AsDateTime(),
          KWERefNo = reader["KWERefNo"].AsString(),
          UserId = reader["UserId"].AsString(),
          Validity = reader["Validity"].AsDateTime(),
          POL = reader["POL"].AsInt(),
          POU = reader["POU"].AsInt(),
          ServiceType = reader["ServiceType"].AsString(),
          MovementTypeId = reader["MovementTypeId"].AsInt(),
          DimensionId = reader["DimensionId"].AsInt(),
          ModeId = reader["ModeId"].AsInt(),
          CargoPickUp=reader["CargoPickUp"].AsString(),
          Dimension=reader["Dimension"].AsString(),
          CustomerReference = reader["CustomerReference"].AsString(),
          TopLoadableYes = reader["TopLoadableYes"].AsBool(),
          TopLoadableNo = reader["TopLoadableNo"].AsBool(),
          StackableYes = reader["StackableYes"].AsBool(),
          StackableNo = reader["StackableNo"].AsBool(),
          LoadCapLowerDeck = reader["LoadCapLowerDeck"].AsBool(),
          LoadCapMainDeck = reader["LoadCapMainDeck"].AsBool(),
          DGRPax = reader["DGRPax"].AsBool(),
          DGRCao = reader["DGRCao"].AsBool(),
          TypeofCont20DC = reader["TypeofCont20DC"].AsBool(),
          TypeofCont40DC = reader["TypeofCont40DC"].AsBool(),
          TypeofCont40HC = reader["TypeofCont40HC"].AsBool(),
          TypeofCont20OTFR = reader["TypeofCont20OTFR"].AsBool(),
          TypeofCont40OTFR = reader["TypeofCont40OTFR"].AsBool(),
      };

        private static Func<IDataReader, QuotationDetails> MakeQuotationDetails = reader =>
     new QuotationDetails
     {
         QuotationDetailsId = reader["QuotationDetailsId"].AsInt(),
         QuotationId = reader["QuotationId"].AsInt(),
         SlNo = reader["SlNo"].AsInt(),
         ChargeCodeId = reader["ChargeCodeId"].AsInt(),
         UnitId = reader["UnitId"].AsString(),
         CurrencyId = reader["CurrencyId"].AsInt(),
         Cost = reader["Cost"].AsDouble(),
         Price = reader["Price"].AsDouble(),
         Qty = reader["Qty"].AsDouble(),
         Total = reader["Total"].AsDouble(),
         grandTotal = reader["grandTotal"].AsDouble(),
         Remarks = reader["Remarks"].AsString()
     };

        public Response UpdateQuotation(Quotation quotation, int UserId, out List<ErrorData> errors)
        {
            List<string> sqlQueries = generateQuery(quotation.QuotationDetails, UserId);
            foreach(string sqlQuery in sqlQueries)
            {
                Db.ReadMultipleRecordSet(sqlQuery, null, CommandType.Text);
            }
            string sql_Query = getQuotation(quotation, UserId);
            DataSet dsOutput;Response response;
            dsOutput = Db.ReadMultipleRecordSet(sql_Query, null, CommandType.Text);
            base.MakeErrorResponse(dsOutput, out response, out errors);
            dsOutput = null;
            return response;
        }

        public List<string> generateQuery(List<QuotationDetails> quotationDetailsList, int UserID)
        {
            List<string> sqlQuery = new List<string>();
            foreach (QuotationDetails quotationDetails in quotationDetailsList)
            {
                if (quotationDetails.QuotationDetailsId != 0)
                {
                    sqlQuery.Add($"update [dbo].[tblQuotationDetails] set " +
                    $" QuotationId = {quotationDetails.QuotationId}," +
                    $"SlNo = {quotationDetails.SlNo}," +
                    $" ChargeCodeId = {quotationDetails.ChargeCodeId}," +
                    $"UnitId = {quotationDetails.UnitId}," +
                    $"CurrencyId={quotationDetails.CurrencyId}, Cost={quotationDetails.Cost}," +
                    $"Price = {quotationDetails.Price}, Qty={quotationDetails.Qty}," +
                    $"Total={quotationDetails.Total}, grandTotal={quotationDetails.grandTotal}," +
                    $"Remarks='{quotationDetails.Remarks}',intModifiedBy={UserID}," +
                    $"dtModifiedOn=GETDATE()" +
                    $"Where QuotationDetailsId= {quotationDetails.QuotationDetailsId}" +
                    $"and flgActive = 1" +
                    $"select 'S','Upated Successfully!!!!'");
                }
                else
                {
                    sqlQuery.Add($"insert into [dbo].[tblQuotationDetails](QuotationId,SlNo,ChargeCodeId,UnitId,CurrencyId," +
                   $"Cost,Price,Qty,Total,grandTotal,Remarks,flgActive,dtAddedOn,intAddedBy,dtModifiedOn,intModifiedBy)" +
                   $"values({quotationDetails.QuotationId}," +
                   $"{quotationDetails.SlNo}," +
                   $"{quotationDetails.ChargeCodeId}," +
                   $"{quotationDetails.UnitId}," +
                   $"{quotationDetails.CurrencyId},{quotationDetails.Cost}," +
                   $"{quotationDetails.Price},{quotationDetails.Qty}," +
                   $"{quotationDetails.Total},{quotationDetails.grandTotal}," +
                   $"'{quotationDetails.Remarks}',1," +
                   $"GETDATE(),{UserID},GETDATE(),{UserID})");
                }

            }
            return sqlQuery;
        }

        public string getQuotation(Quotation quotation, int UserId)
        {
            return $"update [dbo].[tblQuotation] set QuotationNumber='{quotation.QuotationNumber}', " +
                $"intCustomerId ={quotation.intCustomerId}," +
                $"intShipperId = {quotation.intShipperId}," +
                $"intConsigneeId={quotation.intConsigneeId}," +
                $"intDepartureId={quotation.intDepartureId}," +
                $"DeliveryTo='{quotation.DeliveryTo}'," +
                $"NoofPackages={quotation.NoofPackages}," +
                $"IncoTermsId={quotation.IncoTermsId}," +
                $"Commodity='{quotation.Commodity}'," +
                $"ActualWeight={quotation.ActualWeight}," +
                $"ChargeableWeight={quotation.ChargeableWeight}," +
                $"QuotationDate='{quotation.QuotationDate}'," +
                $"KWERefNo='{quotation.KWERefNo}'," +
                $"UserId='{quotation.UserId}'," +
                $"Validity='{quotation.Validity}'," +
                $"POL={quotation.POL}," +
                $"POU={quotation.POU}," +
                $"ServiceType='{quotation.ServiceType}'," +
                $"MovementTypeId={quotation.MovementTypeId}," +
                $"DimensionId={quotation.DimensionId}," +
                $"ModeId={quotation.ModeId}," +
                $"CargoPickup='{quotation.CargoPickUp}'," +
                $"Dimension='{quotation.Dimension}'," +
                $"CustomerReference='{quotation.CustomerReference}'," +
                $"TopLoadableYes = {quotation.TopLoadableYes.AsBool1or0()}," +
                $"TopLoadableNo = { quotation.TopLoadableNo.AsBool1or0()}," +
                $"StackableYes = { quotation.StackableYes.AsBool1or0()}," +
                $"StackableNo = { quotation.StackableNo.AsBool1or0()}," +
                $"LoadCapLowerDeck = { quotation.LoadCapLowerDeck.AsBool1or0()}," +
                $"LoadCapMainDeck = {quotation.LoadCapMainDeck.AsBool1or0()}," +
                $"DGRPax = {quotation.DGRPax.AsBool1or0()}," +
                $"DGRCao = { quotation.DGRCao.AsBool1or0()}," +
                $"TypeofCont20DC = {quotation.TypeofCont20DC.AsBool1or0()}," +
                $"TypeofCont40DC = {quotation.TypeofCont40DC.AsBool1or0()}," +
                $"TypeofCont40HC = {quotation.TypeofCont40HC.AsBool1or0()}," +
                $"TypeofCont20OTFR = {quotation.TypeofCont20OTFR.AsBool1or0()}," +
                $"TypeofCont40OTFR = {quotation.TypeofCont40OTFR.AsBool1or0()}," +
                $"flgActive = 1,dtModifiedOn = GETDATE(),intModifiedBy = {UserId}" +
                $"where QuotationId = {quotation.QuotationId} and flgActive = 1" +
                $"select 's',''";
        }

    }
}
