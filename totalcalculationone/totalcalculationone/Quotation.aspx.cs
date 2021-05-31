using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Components;
using Entities;
using DataObjects;
 

namespace totalcalculationone
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["Username"].ToString()))
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                IMasterService masterService = new MasterService();
                ICustomerService customerService = new CustomerService();                
                SetInitialRow();
                populatedestinationlist(masterService.GetPortMasters());
              //  populatededeliveryto(masterService.GetPortMasters());
                populatedepartureto(masterService.GetPortMasters());
                populatePOL(masterService.GetPortMasters());
                populatePOU(masterService.GetPortMasters());
                incotermslist(masterService.GetIncoTerms());
                movementtypelist(masterService.GetMovementTypeMasters());
                customerlist(customerService.GetCustomers());
                shipperlist(customerService.GetCustomers());
                consigneelist(customerService.GetCustomers());
                GetUOMlist(masterService.GetUnitMasters());
                GetModeList(masterService.GetModeMasters());
                TextBox12.Text = Session["Username"].ToString();
                txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                textdatevalidity.Text = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
                 



            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            txtDate.Text = Request.Form[txtDate.UniqueID];
            textdatevalidity.Text = Request.Form[textdatevalidity.UniqueID];
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values

                         
                        DropDownList box1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("DropDownList7");
                        DropDownList box2 = (DropDownList)GridView1.Rows[rowIndex].Cells[2].FindControl("DropDownList8");
                        DropDownList box3 = (DropDownList)GridView1.Rows[rowIndex].Cells[3].FindControl("DropDownList9");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtcost");
                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtPrice");

                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                   
                    //   Label box7 = ((Label)GridView1.Rows[rowIndex].Cells[7].FindControl("lblTotal"));

                        string lbl = ((Label)GridView1.Rows[rowIndex].Cells[7].FindControl("lblTotal")).Text;

                        //     string total = GridView1.SelectedRow.FindControl("lblTotal").ToString();
                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("TextBox7");
                    

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["SlNo"] = i + 1;
                        drCurrentRow["ChargesDescription"] = box1.Text;
                        drCurrentRow["UOM"] = box2.Text;
                        drCurrentRow["Currency"] = box3.Text;                        
                        drCurrentRow["Cost"] = box4.Text;    
                        drCurrentRow["Price"] = box5.Text;
                        drCurrentRow["Quantity"] = box6.Text;
                        drCurrentRow["Total"] = box6.Text.AsDouble()*box5.Text.AsDouble();
                        drCurrentRow["Remarks"] = box8.Text;
                        rowIndex++;

                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
 
          SetPreviousData();
        }
        public void populatedestinationlist(List<PortMaster> portMasters)
        {
            DropDownList5.Items
               .AddRange(portMasters
                .Select(p => new ListItem()
                {
                    Text = p.Port_Name
                   ,
                    Value = p.PortId.ToString()
                   ,
                    Selected = false
                }).ToArray());
        }
        //public void populatededeliveryto(List<PortMaster> portMasters)
        //{
        //    DropDownList6.Items
        //       .AddRange(portMasters
        //        .Select(p => new ListItem()
        //        {
        //            Text = p.Port_Name
        //           ,
        //            Value = p.PortId.ToString()
        //           ,
        //            Selected = false
        //        }).ToArray());
        //}
        public void incotermslist(List<IncoTerms> incoTerms)
        {
            DropDownList10.Items
              .AddRange(incoTerms
               .Select(p => new ListItem()
               {
                   Text = p.IncoTermsCode
                  ,
                   Value = p.IncoTermsId.ToString()
                  ,
                   Selected = false
               }).ToArray());
        }
        public void movementtypelist(List<MovementTypeMaster> movementTypeMasters)
        {
            DropDownList13.Items
             .AddRange(movementTypeMasters
              .Select(p => new ListItem()
              {
                  Text = p.MovementTypeName
                 ,
                  Value = p.MovementTypeId.ToString()
                 ,
                  Selected = false
              }).ToArray());
        }
        public void populatedepartureto(List<PortMaster> portMasters)
        {
            DropDownList4.Items
              .AddRange(portMasters
               .Select(p => new ListItem()
               {
                   Text = p.Port_Name
                  ,
                   Value = p.PortId.ToString()
                  ,
                   Selected = false
               }).ToArray());
        }
        public void populatePOL(List<PortMaster> portMasters)
        {
            DropDownList11.Items
              .AddRange(portMasters
               .Select(p => new ListItem()
               {
                   Text = p.Port_Name
                  ,
                   Value = p.PortId.ToString()
                  ,
                   Selected = false
               }).ToArray());
        }
        public void populatePOU(List<PortMaster> portMasters)
        {
            DropDownList12.Items
               .AddRange(portMasters
                .Select(p => new ListItem()
                {
                    Text = p.Port_Name
                   ,
                    Value = p.PortId.ToString()
                   ,
                    Selected = false
                }).ToArray());
        }
        public void customerlist(List<Customer> customers)
        {
            DropDownList1.Items
              .AddRange(customers
               .Select(p => new ListItem()
               {
                   Text = p.customer_name
                  ,
                   Value = p.intCustomerId.ToString()
                  ,
                   Selected = false
               }).ToArray());
        }
        public void shipperlist(List<Customer> customers)
        {
            DropDownList2.Items
                .AddRange(customers
                 .Select(p => new ListItem()
                 {
                     Text = p.customer_name
                    ,
                     Value = p.intCustomerId.ToString()
                    ,
                     Selected = false
                 }).ToArray());
        }
        public void consigneelist(List<Customer> customers)
        {
            DropDownList3.Items
              .AddRange(customers
               .Select(p => new ListItem()
               {
                   Text = p.customer_name
                  ,
                   Value = p.intCustomerId.ToString()
                  ,
                   Selected = false
               }).ToArray());
        }
        public void GetUOMlist(List<UnitMaster> unitMasters)
        {
            DropDownList14.Items
              .AddRange(unitMasters
               .Select(p => new ListItem()
               {
                   Text = p.UOM
                  ,
                   Value = p.UnitId.ToString()
                  ,
                   Selected = false
               }).ToArray());
        }
        public void GetModeList(List<ModeMaster> Modemasters)
        {
            DdlModelist.Items
              .AddRange(Modemasters
               .Select(p => new ListItem()
               {
                   Text = p.Mode
                  ,
                   Value = p.ModeId.ToString()
                  ,
                   Selected = false
               }).ToArray());
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("SlNo", typeof(string)));
            dt.Columns.Add(new DataColumn("ChargesDescription", typeof(string)));
            dt.Columns.Add(new DataColumn("UOM", typeof(string)));
            dt.Columns.Add(new DataColumn("Currency", typeof(string)));
            dt.Columns.Add(new DataColumn("Cost", typeof(float)));
            dt.Columns.Add(new DataColumn("Price", typeof(float)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(float)));
            dt.Columns.Add(new DataColumn("Total", typeof(float)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dr = dt.NewRow();
            dr["SlNo"] = 1;
            //dr["ChargesDescription"] = string.Empty;
            //dr["UOM"] = string.Empty;
            //dr["Currency"] = string.Empty;
            dr["Cost"] = 0;
            dr["Price"] = 0;
            dr["Quantity"] = 0;
            dr["Total"] = 0;
            dr["Remarks"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            ViewState["CurrentTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        DropDownList box1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("DropDownList7");
                        DropDownList box2 = (DropDownList)GridView1.Rows[rowIndex].Cells[2].FindControl("DropDownList8");
                        DropDownList box3 = (DropDownList)GridView1.Rows[rowIndex].Cells[3].FindControl("DropDownList9");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtcost");
                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtPrice");

                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                      Label box7 = (Label)GridView1.Rows[rowIndex].Cells[7].FindControl("lblTotal");
 
                        //   TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txttotal");
                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("TextBox7");

                        box1.Text = dt.Rows[i]["ChargesDescription"].ToString();
                        box2.Text = dt.Rows[i]["UOM"].ToString();
                        box3.Text = dt.Rows[i]["Currency"].ToString();
                        box4.Text = dt.Rows[i]["Cost"].ToString();
                        box5.Text = dt.Rows[i]["Price"].ToString();

                        box6.Text = dt.Rows[i]["Quantity"].ToString();
                        box7.Text = dt.Rows[i]["Total"].ToString();
                        box8.Text = dt.Rows[i]["Remarks"].ToString();
                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }       
        protected void Button1_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            List<QuotationDetails> listQuotationDetails = new List<QuotationDetails>();
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        QuotationDetails quotationDetails = new QuotationDetails();
                        DropDownList box1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("DropDownList7");
                        DropDownList box2 = (DropDownList)GridView1.Rows[rowIndex].Cells[2].FindControl("DropDownList8");
                        DropDownList box3 = (DropDownList)GridView1.Rows[rowIndex].Cells[3].FindControl("DropDownList9");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtcost");
                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtPrice");
                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        Label box7 = (Label)GridView1.Rows[rowIndex].Cells[7].FindControl("lblTotal");
                        //TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txttotal");
                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("TextBox7");
                        sc.Add(box1.Text + "," + box2.Text + "," + box3.Text + "," + box4.Text + "," + box5.Text + "," + box6.Text + "," + box7.Text);
                        quotationDetails.SlNo = i;
                        quotationDetails.ChargeCodeId = box1.SelectedValue.AsInt();
                        quotationDetails.UnitId = box2.SelectedValue.AsString();
                        quotationDetails.CurrencyId = box3.SelectedValue.AsInt();
                        quotationDetails.Cost = box4.Text.AsDouble();
                        quotationDetails.Price = box5.Text.AsDouble();
                        quotationDetails.Qty = box6.Text.AsDouble();
                        quotationDetails.Total = box6.Text.AsDouble() * box5.Text.AsDouble();
                        quotationDetails.Remarks = box8.Text.AsString();
                        listQuotationDetails.Add(quotationDetails);
                        rowIndex++;
                    }
                    Quotation quotation = GetQuotation(listQuotationDetails);
                    InsertRecords(quotation );
                }
            }
        }
        private void InsertRecords(Quotation quotation)
        {

            IQuotationService quotationService = new QuotationService();
            try
            {
                List<ErrorData> errorDatas = new List<ErrorData>();
                Response res = quotationService.SaveQuotation(quotation, 1, out errorDatas);
                if(res.Type == 's')
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Successfully created quotation');", true);
                    Response.Redirect("QuotationList.aspx");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('"+msg+"');", true);

            }
            finally
            {
            }
        }
        private string GetConnectionString()
        {
            
            return System.Configuration.ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
        }
        public DataTable ChargeCodelist()
        {


            string sm = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(sm);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = "spDMSGetschargecode";
            DataTable dt = new DataTable();


            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcomm;
            da.Fill(dt);
            return dt;

        }
        public DataTable UOMList()
        {


            string sm = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(sm);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = "spDMSGetsUOM";
            DataTable dt = new DataTable();


            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcomm;
            da.Fill(dt);
            return dt;

        }
        public DataTable CurrencyList()
        {
            string sm = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(sm);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = "spDMSGetsCurrency";
            DataTable dt = new DataTable();


            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcomm;
            da.Fill(dt);
            return dt;

        }
        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string price = Convert.ToString(e.Row.Cells[5].Text.Trim());
                string unit = Convert.ToString(e.Row.Cells[6].Text.Trim());

                DropDownList cmbCharge = (DropDownList)e.Row.FindControl("DropDownList7");
                DropDownList cmbUOM = (DropDownList)e.Row.FindControl("DropDownList8");
                DropDownList cmbCurrency = (DropDownList)e.Row.FindControl("DropDownList9");
                if (cmbCharge != null && cmbUOM != null && cmbCurrency != null)
                {
                    cmbCharge.DataSource = ChargeCodelist();
                    cmbCharge.DataTextField = "description";
                    cmbCharge.DataValueField = "ChargeCodeId";
                    
                    cmbCharge.DataBind();
                    cmbCharge.Items.Add(new ListItem("Select", "0"));

                    cmbUOM.DataSource = UOMList();
                    cmbUOM.DataTextField = "UOM";
                    cmbUOM.DataValueField = "UnitId";
                    cmbUOM.DataBind();
                    cmbUOM.Items.Add(new ListItem("Select", "0"));

                    cmbCurrency.DataSource = CurrencyList();
                    cmbCurrency.DataTextField = "currency";
                    cmbCurrency.DataValueField = "CurrencyId";

                    cmbCurrency.DataBind();
                    cmbCurrency.Items.Add(new ListItem("Select", "0"));

                    Label lbl1 = (Label)e.Row.FindControl("lblTotal");
                    string date = lbl1.Text;

                }
            }
        }

        private Quotation GetQuotation(List<QuotationDetails> quotationDetails)
        {
            return new Quotation
            {
                intCustomerId = DropDownList1.SelectedValue.AsInt(),
                intShipperId = DropDownList2.SelectedValue.AsInt(),
                intConsigneeId = DropDownList3.SelectedValue.AsInt(),
                intDepartureId = DropDownList4.SelectedValue.AsInt(),
                intDestinationId = DropDownList5.SelectedValue.AsInt(),
                DeliveryTo = txtdeliveryto.Text,
                NoofPackages = txtnoofpackages.Text.AsInt(),
                IncoTermsId = DropDownList10.SelectedValue.AsInt(),
                Commodity = TextBox1.Text,
                ChargeableWeight = TextBox3.Text.AsDouble(),
                QuotationDate = GetDate(Request.Form[txtDate.UniqueID]),
                UserId = TextBox12.Text,
                KWERefNo = TextBox9.Text,
                Validity = GetDate(Request.Form[textdatevalidity.UniqueID]),
                POL = DropDownList11.SelectedValue.AsInt(),
                POU = DropDownList12.SelectedValue.AsInt(),
                ServiceType = TextBox10.Text,
                MovementTypeId = DropDownList13.SelectedValue.AsInt(),
                ActualWeight = TextBox2.Text.AsDouble(),
                DimensionId = DropDownList14.SelectedValue.AsInt(),
                ModeId = DdlModelist.SelectedValue.AsInt(),
                CargoPickUp = Txtcargopickup.Text,
                Dimension = txtdimension.Text,
                CustomerReference = txtcustreference.Text,
                TopLoadableYes = ChkYes.Checked,
                TopLoadableNo=ChkNo.Checked,
                StackableYes=ChkYesStack.Checked,
                StackableNo=ChkNoStack.Checked,
                LoadCapMainDeck=ChkMainDeck.Checked,
                LoadCapLowerDeck=ChkLowerDeck.Checked,
                DGRPax=ChkPax.Checked,
                DGRCao=ChkCao.Checked,
                TypeofCont20DC=chk20.Checked,
                TypeofCont40DC=chk40dc.Checked,
                TypeofCont40HC=chk40hc.Checked,
                TypeofCont20OTFR=chk20otfr.Checked,
                TypeofCont40OTFR=chk40otfr.Checked,
                
                QuotationDetails = quotationDetails
            };
        }

        private DateTime GetDate(string date)
        {
            string[] years = new string[12] { "Jan", "Feb", "March", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            string[] words = date.Split('-');
            string month = years[words[1].AsInt()-1];
            string updatedDate = $"{words[0]}-{month}-{words[2]}";
            return DateTime.Parse(updatedDate);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }       
}