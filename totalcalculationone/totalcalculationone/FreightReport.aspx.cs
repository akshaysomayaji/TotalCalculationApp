using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Entities;

namespace totalcalculationone
{
    public partial class FreightReport : System.Web.UI.Page
    {
        ReportDocument report1 = new ReportDocument();
        //ReportDocument rprt = new ReportDocument();
        //ParameterField paramField = new ParameterField();
        //ParameterFields paramFields = new ParameterFields();
        //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string QuotationNumber = Request.QueryString["QuotationNumber"].ToString();
 
                report1.Load(Server.MapPath("~/QuotationReport.rpt"));
     
                report1.SetDatabaseLogon("sa", "Password@1234", "HOLTP028\\SQLEXPRESSNEW", "DMSDatabase");
             report1.SetParameterValue("@QuotationNumber", QuotationNumber);
               
                QuotRep.ReportSource = report1;
                QuotRep.PrintMode = PrintMode.Pdf;
                //      report1.ExportToDisk(ExportFormatType.PortableDocFormat, "E:\\report.pdf");



                //string QuotationNumber = Request.QueryString["QuotationNumber"].ToString();
                ////       rprt.Load(Server.MapPath("~/CrystalReport2.rpt"));

                //           SqlConnection con = new SqlConnection(@"Data Source=HOLTP028\SQLEXPRESSNEW;Initial Catalog=DMSDatabase;Persist Security Info=True;User ID=sa;Password=Password@1234");
                //           SqlCommand cmd = new SqlCommand("spDMSGetQuotationDetailsforreport", con);
                //           cmd.CommandType = CommandType.StoredProcedure;
                //           cmd.Parameters.AddWithValue("@QuotationNumber", QuotationNumber);
                //           //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //           //DataSet ds = new DataSet();
                //           //sda.Fill(ds, "spDMSGetQuotationDetailsforreport;1");
                //           //rprt.SetDataSource(ds);
                //     //          QuotRep.ReportSource = rprt;
                //           ReportDocument Report = new ReportDocument();
                ////           Report.SetParameterValue("@QuotationNumber", QuotationNumber);
                //           Report.Load(Server.MapPath("~/QuotationReport.rpt"));
                //           Report.SetDatabaseLogon("sa", "Password@1234", "HOLTP028\\SQLEXPRESSNEW", "DMSDatabase");
                //    //       
                //           QuotRep.ReportSource = Report;
            }

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
            report1.ExportToHttpResponse(formatType, Response, true, "FreightReport");
            Response.End();

         
        }
    }
}
           
          

                
            
           
    
