using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace totalcalculationone
{
    public partial class QuotationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }

        }
          private void BindGrid()
            {
                string constr = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("spDMSGetQuotationDetails"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                            grdQuotationList.DataSource = dt;
                            grdQuotationList.DataBind();
                            }
                        }
                    }
                }
            }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            grdQuotationList.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void grdQuotationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdQuotationList.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }



        //protected void btnShow_Click(object sender, EventArgs e)
        //{

        //    //ReportDocument crystalReport = new ReportDocument();
        //    //crystalReport.Load(Server.MapPath("~/QuotationReport.rpt"));
        //    //foreach (GridViewRow row in grdQuotationList.Rows)
        //    //{


        //    //    CheckBox ChkCancel = row.FindControl("chkSelect") as CheckBox;
        //    //    if (ChkCancel.Checked)
        //    //    {
        //    //        GridView grdQuotationList = sender as GridView;


        //    //        GridViewRow gvr = grdQuotationList.SelectedRow;
        //    //        string temp = gvr.Cells[1].Text;

        //    //    }
        //    //}

        //    //DataTable _datatable = new DataTable();
        //    //for (int i = 0; i < grdQuotationList.Columns.Count; i++)
        //    //{
        //    //    _datatable.Columns.Add(grdQuotationList.Columns[i].ToString());
        //    //}
        //    //foreach (GridViewRow row in grdQuotationList.Rows)
        //    //{
        //    //    DataRow dr = _datatable.NewRow();
        //    //    for (int j = 0; j < grdQuotationList.Columns.Count; j++)
        //    //    {
        //    //        if (!row.Cells[j].Text.Equals("&nbsp;"))
        //    //            dr[grdQuotationList.Columns[j].ToString()] = row.Cells[j].Text;
        //    //    }

        //    //    _datatable.Rows.Add(dr);
        //    //}
        //    //ExportDataTableToPDF(_datatable);


        //}





    }
}