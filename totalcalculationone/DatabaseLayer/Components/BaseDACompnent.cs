using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using DataObjects.AdoNet;
using DataObjects;
using Entities;

namespace DatabaseLayer.Components
{
    public class BaseDAComponent
    {
        protected string GetFullName(string dbObjectName)
        {
            return string.Format("{0}{1}", ConfigurationManager.AppSettings.Get("dbo"), dbObjectName);
        }

        private static Func<IDataReader, Response> MakeResponse = reader =>
           new Response
           {
               Type = reader[0].AsString()[0],
               Code = reader.FieldCount > 1 ? reader[1].AsString() : ""
           };

        private Response Success()
        {
            return new Response { Type = 'S', Code = "" };
        }

        protected void MakeErrorResponse(DataSet dsOutput, out Response response, out List<ErrorData> errors)
        {
            ErrorData error;

            response = new Response();
            response.Type = dsOutput.Tables[0].Rows[0][0].AsString()[0];
            response.Code = dsOutput.Tables[0].Columns.Count > 1 ? dsOutput.Tables[0].Rows[0][1].AsString() : "";

            errors = new List<ErrorData>();
            if (response.Type == 'E' && dsOutput.Tables.Count > 1)
                foreach (DataRow errorrow in dsOutput.Tables[1].Rows)
                {
                    error = new ErrorData();
                    error.Item1 = errorrow[0].AsString();
                    error.Item2 = dsOutput.Tables[1].Columns.Count > 1 ? errorrow[1].AsString() : "";
                    error.Item3 = dsOutput.Tables[1].Columns.Count > 2 ? errorrow[2].AsString() : "";
                    errors.Add(error);
                    error = null;
                }
        }
    }

    
}
