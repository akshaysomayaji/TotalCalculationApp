using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Components;
using Entities;
using DataObjects;

namespace totalcalculationone
{
    public partial class EditQuotation : System.Web.UI.Page
    {
        Quotation quotation = new Quotation();
        int quotationId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string QuotationNumber = "";
            if (String.IsNullOrEmpty(Session["Username"].ToString()))
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                QuotationNumber = Request.QueryString.Get("QuotationNumber").AsString();
                IMasterService masterService = new MasterService();
                ICustomerService customerService = new CustomerService();
                IQuotationService quotationService = new QuotationService();
                quotation = quotationService.GetQuotation(QuotationNumber);
                quotationId = quotation.QuotationId;
                SetInitialRow(quotation.QuotationDetails.Count);
                populatedestinationlist(masterService.GetPortMasters(), quotation.intDestinationId);
                //  populatededeliveryto(masterService.GetPortMasters());
                populatedepartureto(masterService.GetPortMasters(), quotation.intDepartureId);
                populatePOL(masterService.GetPortMasters(),quotation.POL);
                populatePOU(masterService.GetPortMasters(),quotation.POU);
                incotermslist(masterService.GetIncoTerms());
                movementtypelist(masterService.GetMovementTypeMasters());
                customerlist(customerService.GetCustomers(),quotation.intCustomerId);
                shipperlist(customerService.GetCustomers(),quotation.intShipperId);
                consigneelist(customerService.GetCustomers(),quotation.intConsigneeId);
                GetUOMlist(masterService.GetUnitMasters());
                GetModeList(masterService.GetModeMasters());
                TextBox12.Text = Session["Username"].ToString();
                txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                textdatevalidity.Text = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
                SetValue(quotation);
            }
        }

        public void populatedestinationlist(List<PortMaster> portMasters, int selectedValue)
        {
            DestinationList.Items
               .AddRange(portMasters
                .Select(p => new ListItem()
                {
                    Text = p.Port_Name
                   ,
                    Value = p.PortId.ToString()
                   ,
                    Selected = false,
                }).ToArray());
            if (selectedValue != 0)
                DestinationList.Items.FindByValue(selectedValue.ToString()).Selected = true;
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
        public void incotermslist(List<IncoTerms> incoTerms, int selectedValue = 0)
        {
            ShippingTermsList.Items
              .AddRange(incoTerms
               .Select(p => new ListItem()
               {
                   Text = p.IncoTermsCode
                  ,
                   Value = p.IncoTermsId.ToString()
                  ,
                   Selected = false
               }).ToArray());
            if (selectedValue != 0)
                ShippingTermsList.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void movementtypelist(List<MovementTypeMaster> movementTypeMasters, int selectedValue = 0)
        {
            MovementTypeList.Items
             .AddRange(movementTypeMasters
              .Select(p => new ListItem()
              {
                  Text = p.MovementTypeName
                 ,
                  Value = p.MovementTypeId.ToString()
                 ,
                  Selected = false
              }).ToArray());
            if (selectedValue != 0)
                MovementTypeList.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void populatedepartureto(List<PortMaster> portMasters, int selectedValue = 0)
        {
            DepartureList.Items
              .AddRange(portMasters
               .Select(p => new ListItem()
               {
                   Text = p.Port_Name
                  ,
                   Value = p.PortId.ToString()
                  ,
                   Selected = false
               }).ToArray());
            if (selectedValue != 0)
                DepartureList.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void populatePOL(List<PortMaster> portMasters, int selectedValue = 0)
        {
            POLList.Items
              .AddRange(portMasters
               .Select(p => new ListItem()
               {
                   Text = p.Port_Name
                  ,
                   Value = p.PortId.ToString()
                  ,
                   Selected = false
               }).ToArray());
            if(selectedValue != 0)
            {
                POLList.Items.FindByValue(selectedValue.ToString()).Selected = true;
            }
          
        }
        public void populatePOU(List<PortMaster> portMasters, int selectedValue = 0)
        {
            POUList.Items
               .AddRange(portMasters
                .Select(p => new ListItem()
                {
                    Text = p.Port_Name
                   ,
                    Value = p.PortId.ToString()
                   ,
                    Selected = false
                }).ToArray());
            if (selectedValue != 0)
                POUList.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void customerlist(List<Customer> customers, int selectedValue = 0)
        {
            CustomerList.Items
              .AddRange(customers
               .Select(p => new ListItem()
               {
                   Text = p.customer_name
                  ,
                   Value = p.intCustomerId.ToString()
                  ,
                   Selected = false
               }).ToArray());
            if (selectedValue != 0)
                CustomerList.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void shipperlist(List<Customer> customers, int selectedValue = 0)
        {
            ShipperCustomerList.Items
                .AddRange(customers
                 .Select(p => new ListItem()
                 {
                     Text = p.customer_name
                    ,
                     Value = p.intCustomerId.ToString()
                    ,
                     Selected = false
                 }).ToArray());
            if (selectedValue != 0)
                ShipperCustomerList.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void consigneelist(List<Customer> customers, int selectedValue = 0)
        {
            ConsigneeList.Items
              .AddRange(customers
               .Select(p => new ListItem()
               {
                   Text = p.customer_name
                  ,
                   Value = p.intCustomerId.ToString()
                  ,
                   Selected = false
               }).ToArray());
            if (selectedValue != 0)
                ConsigneeList.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void GetUOMlist(List<UnitMaster> unitMasters, int selectedValue = 0)
        {
            UOMLists.Items
              .AddRange(unitMasters
               .Select(p => new ListItem()
               {
                   Text = p.UOM
                  ,
                   Value = p.UnitId.ToString()
                  ,
                   Selected = false
               }).ToArray());
            if (selectedValue != 0)
                UOMLists.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        public void GetModeList(List<ModeMaster> Modemasters, int selectedValue = 0)
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
            if (selectedValue != 0)
                DdlModelist.Items.FindByValue(selectedValue.ToString()).Selected = true;
        }
        private void SetInitialRow(int rows = 1)
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
            dt.Columns.Add(new DataColumn("quotationDetailsId", typeof(string)));
            for(int i = 0; i<rows;i++)
            {
                dr = dt.NewRow();
                dr["SlNo"] = i+1;
                //dr["ChargesDescription"] = string.Empty;
                //dr["UOM"] = string.Empty;
                //dr["Currency"] = string.Empty;
                dr["Cost"] = 0;
                dr["Price"] = 0;
                dr["Quantity"] = 0;
                dr["Total"] = 0;
                dr["Remarks"] = string.Empty;
                dr["quotationDetailsId"] = 0;
                dt.Rows.Add(dr);
            }
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
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList box1 = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ChargeDescriptionList");
                        DropDownList box2 = (DropDownList)GridView1.Rows[rowIndex].Cells[2].FindControl("UOMs_List");
                        DropDownList box3 = (DropDownList)GridView1.Rows[rowIndex].Cells[3].FindControl("CurrencyList");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtcost");
                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtPrice");
                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        Label box7 = (Label)GridView1.Rows[rowIndex].Cells[7].FindControl("lblTotal");
                        //   TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txttotal");
                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("TextBox7");
                        Label lblId = (Label)GridView1.Rows[rowIndex].Cells[9].FindControl("quotationDetailsId");
                        box1.Text = dt.Rows[i]["ChargesDescription"].ToString();
                        box2.Text = dt.Rows[i]["UOM"].ToString();
                        box3.Text = dt.Rows[i]["Currency"].ToString();
                        box4.Text = dt.Rows[i]["Cost"].ToString();
                        box5.Text = dt.Rows[i]["Price"].ToString();
                        box6.Text = dt.Rows[i]["Quantity"].ToString();
                        box7.Text = dt.Rows[i]["Total"].ToString();
                        box8.Text = dt.Rows[i]["Remarks"].ToString();
                        lblId.Text = dt.Rows[i]["quotationDetailsId"].ToString();
                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            //SetInitialRow();
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
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox 
                        DropDownList box1 = (DropDownList)GetGridView(rowIndex, "ChargeDescriptionList", 1);
                        DropDownList box2 = (DropDownList)GetGridView(rowIndex, "UOMs_List", 2);
                        DropDownList box3 = (DropDownList)GetGridView(rowIndex, "CurrencyList", 3);
                        TextBox box4 = (TextBox)GetGridView(rowIndex, "txtcost", 4);
                        TextBox box5 = (TextBox)GetGridView(rowIndex, "txtPrice", 5);
                        TextBox box6 = (TextBox)GetGridView(rowIndex, "txtQuantity", 6);
                        Label box7 = (Label)GetGridView(rowIndex, "lblTotal", 7);
                        //TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txttotal");
                        TextBox box8 = (TextBox)GetGridView(rowIndex, "TextBox7", 8);
                        Label lblId = (Label)GetGridView(rowIndex, "quotationDetailsId", 9);
                        drCurrentRow = dtCurrentTable.Rows[i];
                        drCurrentRow["SlNo"] = rowIndex+1;
                        drCurrentRow["ChargesDescription"] = box1.Text;
                        drCurrentRow["UOM"] = box2.Text;
                        drCurrentRow["Currency"] = box3.Text;
                        drCurrentRow["Cost"] = box4.Text;
                        drCurrentRow["Price"] = box5.Text;
                        drCurrentRow["Quantity"] = box6.Text;
                        drCurrentRow["Total"] = box6.Text.AsDouble() * box5.Text.AsDouble();
                        drCurrentRow["Remarks"] = box8.Text;
                        drCurrentRow["quotationDetailsId"] = lblId.Text;
                        rowIndex++;
                    }
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["SlNo"] = rowIndex + 1;
                    drCurrentRow["Cost"] = 0;
                    drCurrentRow["Price"] = 0;
                    drCurrentRow["Quantity"] = 0;
                    drCurrentRow["quotationDetailsId"] = 0;
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            IQuotationService quotationService = new QuotationService();
            quotation = quotationService.GetQuotation(Request.QueryString.Get("QuotationNumber").AsString());
            quotationId = quotation.QuotationId;
            int rowIndex = 0;
            double grandTotal = 0;
            List<QuotationDetails> listQuotationDetails = new List<QuotationDetails>();
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        QuotationDetails quotationDetails = new QuotationDetails();
                        DropDownList box1 = (DropDownList)GetGridView(rowIndex, "ChargeDescriptionList", 1);
                        DropDownList box2 = (DropDownList)GetGridView(rowIndex, "UOMs_List", 2);
                        DropDownList box3 = (DropDownList)GetGridView(rowIndex, "CurrencyList", 3);
                        TextBox box4 = (TextBox)GetGridView(rowIndex, "txtcost", 4);
                        TextBox box5 = (TextBox)GetGridView(rowIndex, "txtPrice", 5);
                        TextBox box6 = (TextBox)GetGridView(rowIndex, "txtQuantity", 6);
                        Label box7 = (Label)GetGridView(rowIndex, "lblTotal", 7);
                        //TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txttotal");
                        TextBox box8 = (TextBox)GetGridView(rowIndex, "TextBox7", 8);
                        Label lblId = (Label)GetGridView(rowIndex, "quotationDetailsId", 9);
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
                        quotationDetails.QuotationDetailsId = lblId.Text.AsInt();
                        quotationDetails.QuotationId = quotationId;
                        grandTotal = grandTotal + quotationDetails.Total;
                        listQuotationDetails.Add(quotationDetails);
                        rowIndex++;
                    }
                    foreach(QuotationDetails details in listQuotationDetails)
                    {
                        details.grandTotal = grandTotal;
                    }
                    Quotation quotation = GetQuotation(listQuotationDetails);
                    UpdateRecords(quotation);
                }
            }
        }

        private void UpdateRecords(Quotation quotation)
        {

            IQuotationService quotationService = new QuotationService();
            try
            {
                List<ErrorData> errorDatas = new List<ErrorData>();
                Response res = quotationService.UpdateQuotation(quotation, 1, out errorDatas);
                if (res.Type == 's')
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Successfully updated quotation');", true);
                    Response.Redirect("QuotationList.aspx");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('" + msg + "');", true);

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

                DropDownList cmbCharge = (DropDownList)e.Row.FindControl("ChargeDescriptionList");
                DropDownList cmbUOM = (DropDownList)e.Row.FindControl("UOMs_List");
                DropDownList cmbCurrency = (DropDownList)e.Row.FindControl("CurrencyList");
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
        private DateTime GetDate(string date)
        {
            string[] years = new string[12] { "Jan", "Feb", "March", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            string[] words = date.Split('-');
            string month = years[words[1].AsInt() - 1];
            string updatedDate = $"{words[0]}-{month}-{words[2]}";
            return DateTime.Parse(updatedDate);
        }
        private Quotation GetQuotation(List<QuotationDetails> quotationDetails)
        {
            return new Quotation
            {
                intCustomerId = CustomerList.SelectedValue.AsInt(),
                intShipperId = ShipperCustomerList.SelectedValue.AsInt(),
                intConsigneeId = ConsigneeList.SelectedValue.AsInt(),
                intDepartureId = DepartureList.SelectedValue.AsInt(),
                intDestinationId = DestinationList.SelectedValue.AsInt(),
                DeliveryTo = txtdeliveryto.Text,
                NoofPackages = txtnoofpackages.Text.AsInt(),
                IncoTermsId = ShippingTermsList.SelectedValue.AsInt(),
                Commodity = TextBox1.Text,
                ChargeableWeight = TextBox3.Text.AsDouble(),
                QuotationDate = GetDate(Request.Form[txtDate.UniqueID]),
                UserId = TextBox12.Text,
                KWERefNo = TextBox9.Text,
                Validity = GetDate(Request.Form[textdatevalidity.UniqueID]),
                POL = POLList.SelectedValue.AsInt(),
                POU = POUList.SelectedValue.AsInt(),
                ServiceType = TextBox10.Text,
                MovementTypeId = MovementTypeList.SelectedValue.AsInt(),
                ActualWeight = TextBox2.Text.AsDouble(),
                DimensionId = UOMLists.SelectedValue.AsInt(),
                ModeId = DdlModelist.SelectedValue.AsInt(),
                CargoPickUp = Txtcargopickup.Text,
                Dimension = txtdimension.Text,
                CustomerReference = txtcustreference.Text,
                TopLoadableYes = ChkYes.Checked,
                TopLoadableNo = ChkNo.Checked,
                StackableYes = ChkYesStack.Checked,
                StackableNo = ChkNoStack.Checked,
                LoadCapMainDeck = ChkMainDeck.Checked,
                LoadCapLowerDeck = ChkLowerDeck.Checked,
                DGRPax = ChkPax.Checked,
                DGRCao = ChkCao.Checked,
                TypeofCont20DC = chk20.Checked,
                TypeofCont40DC = chk40dc.Checked,
                TypeofCont40HC = chk40hc.Checked,
                TypeofCont20OTFR = chk20otfr.Checked,
                TypeofCont40OTFR = chk40otfr.Checked,
                QuotationId = quotationId,
                QuotationDetails = quotationDetails,
                QuotationNumber = Request.QueryString.Get("QuotationNumber").AsString()
            };
        }

        private void SetValue(Quotation quotation)
        {
            txtdeliveryto.Text = quotation.DeliveryTo;
            txtnoofpackages.Text = quotation.NoofPackages.AsString();
            TextBox1.Text = quotation.Commodity;
            TextBox3.Text = quotation.ChargeableWeight.ToString();
            txtDate.Text = quotation.QuotationDate.ToString("dd-M-yy");
            TextBox9.Text = quotation.KWERefNo;
            textdatevalidity.Text = quotation.Validity.ToString("dd-M-yy"); ;
            TextBox10.Text = quotation.ServiceType;
            TextBox2.Text = quotation.ActualWeight.ToString();
            Txtcargopickup.Text = quotation.CargoPickUp.ToString();
            txtdimension.Text = quotation.Dimension.ToString();
            txtcustreference.Text = quotation.CustomerReference;
            ChkYes.Checked = quotation.TopLoadableYes;
            ChkNo.Checked = quotation.TopLoadableNo;
            ChkYesStack.Checked = quotation.StackableYes;
            ChkNoStack.Checked = quotation.StackableNo;
            ChkMainDeck.Checked = quotation.LoadCapMainDeck;
            ChkLowerDeck.Checked = quotation.LoadCapLowerDeck;
            ChkPax.Checked = quotation.DGRPax;
            ChkCao.Checked = quotation.DGRCao;
            chk20.Checked = quotation.TypeofCont20DC;
            chk40dc.Checked = quotation.TypeofCont40DC;
            chk40hc.Checked = quotation.TypeofCont40HC;
            chk20otfr.Checked = quotation.TypeofCont20OTFR;
            chk40otfr.Checked = quotation.TypeofCont40OTFR;

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    foreach(QuotationDetails quotationDetails in quotation.QuotationDetails)
                    {
                        DropDownList box1 = (DropDownList)GetGridView(rowIndex, "ChargeDescriptionList", 1);
                        DropDownList box2 = (DropDownList)GetGridView(rowIndex, "UOMs_List", 2);
                        DropDownList box3 = (DropDownList)GetGridView(rowIndex, "CurrencyList", 3);
                        TextBox box4 = (TextBox)GetGridView(rowIndex, "txtcost", 4);
                        TextBox box5 = (TextBox)GetGridView(rowIndex, "txtPrice", 5);
                        TextBox box6 = (TextBox)GetGridView(rowIndex, "txtQuantity", 6);
                        Label box7 = (Label)GetGridView(rowIndex, "lblTotal", 7);
                        //TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txttotal");
                        TextBox box8 = (TextBox)GetGridView(rowIndex, "TextBox7", 8);
                        Label lblId = (Label)GetGridView(rowIndex, "quotationDetailsId", 9);
                        box1.ClearSelection(); box2.ClearSelection(); box3.ClearSelection();
                        box1.Items.FindByValue(quotationDetails.ChargeCodeId.ToString()).Selected = true;
                        box2.Items.FindByValue(quotationDetails.UnitId.ToString()).Selected = true;
                        box3.Items.FindByValue(quotationDetails.CurrencyId.ToString()).Selected = true;
                        box4.Text = quotationDetails.Cost.ToString();
                        box5.Text = quotationDetails.Price.ToString();
                        box6.Text = quotationDetails.Qty.ToString();
                        box7.Text = quotationDetails.Total.ToString();
                        box8.Text = quotationDetails.Remarks.ToString();
                        lblId.Text = quotationDetails.QuotationDetailsId.ToString();
                        rowIndex = rowIndex + 1;
                    }
                }
            }
        }

        private Control GetGridView(int rowIndex, string rowName, int i)
        {
            var column = GridView1.Rows[rowIndex].Cells[i].FindControl(rowName);
            return column;
        }

        protected void QuotationList_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuotationList.aspx");
        }
    }
}