using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace totalcalculationone
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        
        SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);

        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
 
      

  

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string uniqueCode = string.Empty;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // get the records matching the supplied username or email id.         
                cmd = new SqlCommand("select * from UserRegistration where Email COLLATE Latin1_general_CS_AS=@email", con);


                cmd.Parameters.AddWithValue("@email", Convert.ToString(txtEmail.Text.Trim()));
                dr = cmd.ExecuteReader();
                cmd.Dispose();
                if (dr.HasRows)
                {
                    dr.Read();

                    uniqueCode = Convert.ToString(System.Guid.NewGuid());

                    cmd = new SqlCommand("update UserRegistration set UniqueCode=@uniqueCode where Name=@username or Email=@emailid", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", uniqueCode);
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@emailid", txtEmail.Text.Trim());

                    StringBuilder strBody = new StringBuilder();

                  strBody.Append("<a href=http://localhost:53890/ResetPassword.aspx?email=" + txtEmail.Text + "&uName=" + txtUserName.Text + "&uCode=" + uniqueCode + ">Click here to change your password</a>");


            //      strBody.Append("<a href=http://10.33.150.106:9095/ResetPassword.aspx?email=" + txtEmail.Text + "&uName=" + txtUserName.Text + "&uCode=" + uniqueCode + ">Click here to change your password</a>");

                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("admin@kweindia.com", dr["Email"].ToString(), "Reset Your Password", strBody.ToString());


                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("admin@kweindia.com", "Kwepass01");

                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("smtp.office365.com", 587);
                    mailclient.EnableSsl = true;
                    mailclient.UseDefaultCredentials = false;
                    mailclient.Credentials = mailAuthenticaion;
                    mail.IsBodyHtml = true;
                    mailclient.Send(mail);
                    dr.Close();
                    dr.Dispose();
                    cmd.ExecuteReader();
                    cmd.Dispose();
                    con.Close();
                    lblStatus.Text = "Reset password link has been sent to your email address";
                    txtEmail.Text = string.Empty;
                    txtUserName.Text = string.Empty;
                    
                }
                else
                {
                    lblStatus.Text = "Please enter valid email address or username";
                    txtEmail.Text = string.Empty;
                    txtUserName.Text = string.Empty;
                    con.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error Occured: " + ex.Message.ToString();
            }
            finally
            {
                
                cmd.Dispose();
           //     Response.Redirect("Login.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}