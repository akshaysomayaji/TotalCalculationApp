using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace totalcalculationone
{
    public partial class test : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          

            string sm = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(sm);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = "spDMSGetQuotationDetails";
            sqlconn.Open();
            DataTable dt = new DataTable();
            SqlDataReader dr = sqlcomm.ExecuteReader();
            dt.Load(dr);
           
            

        }

         
    }
}