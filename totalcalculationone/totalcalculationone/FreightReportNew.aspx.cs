using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace totalcalculationone
{
    public partial class FreightReportNew : System.Web.UI.Page
    {
        ReportDocument report1 = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
        //    if (!IsPostBack)
       //     {
                string QuotationNumber = Request.QueryString["QuotationNumber"].ToString();

                report1.Load(Server.MapPath("~/QuotationReport.rpt"));
                report1.SetDatabaseLogon("sa", "Password@1234", "HOLTP028\\SQLEXPRESSNEW", "DMSDatabase");
                report1.SetParameterValue("@QuotationNumber", QuotationNumber);
                FreightRep.ReportSource = report1;
                FreightRep.AllowedExportFormats = (int)CrystalDecisions.Shared.ViewerExportFormats.PdfFormat;
           // }
        }

        protected void Export(object sender, EventArgs e)
        {
            ExportFormatType formatType = ExportFormatType.NoFormat;
            switch (rbFormat.SelectedItem.Value)
            {
                //case "Word":
                //    formatType = ExportFormatType.WordForWindows;
                //    break;
                case "PDF":
                    formatType = ExportFormatType.PortableDocFormat;
                    break;
                //case "Excel":
                //    formatType = ExportFormatType.Excel;
                //    break;
                //case "CSV":
                //    formatType = ExportFormatType.CharacterSeparatedValues;
                //    break;
            }
            string QuotationNumber = Request.QueryString["QuotationNumber"].ToString();
            report1.Load(Server.MapPath("~/QuotationReport.rpt"));
            report1.SetDatabaseLogon("sa", "Password@1234", "HOLTP028\\SQLEXPRESSNEW", "DMSDatabase");
            report1.SetParameterValue("@QuotationNumber", QuotationNumber);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            report1.ExportToHttpResponse(formatType, Response, true, "FreightQuotation");
            Response.End();
        }
    }
}