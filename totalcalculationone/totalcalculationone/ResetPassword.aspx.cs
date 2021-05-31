using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace totalcalculationone
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);
           SqlCommand cmd = new SqlCommand();
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
               
                 
                    SqlDataReader dr;
                    try
                    {
                    //Here we will check from the passed querystring that if the email id/username and generated unique code is same then the panel for resetting password will be visible otherwise not
                    cmd = new SqlCommand("select Name,Email,UniqueCode from UserRegistration        where UniqueCode=@uniqueCode and (Email=@emailid or Name=@username)", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                    cmd.Parameters.AddWithValue("@emailid", Convert.ToString(Request.QueryString["Email"]));
                    cmd.Parameters.AddWithValue("@username", Convert.ToString(Request.QueryString["uName"]));



                    if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            ResetPwdPanel.Visible = true;
                        }
                        else
                        {
                            ResetPwdPanel.Visible = false;
                            lblExpired.Text = "Reset password link has expired.It was for one time use only";
                            return;
                        }
                        dr.Close();
                        dr.Dispose();
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error Occured: " + ex.Message.ToString();
                    }
                    finally
                    {
                        cmd.Dispose();
                        con.Close();
                    }

        //        Response.Redirect("Login.aspx");
                }
            }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {   // Here we will update the new password and also set the unique code to null so that it can be used only for once.
                cmd = new SqlCommand("update UserRegistration set UniqueCode='',Password=@pwd where  UniqueCode=@uniqueCode and (Email=@emailid)", con);
                cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                cmd.Parameters.AddWithValue("@emailid", Convert.ToString(Request.QueryString["Email"]));
                cmd.Parameters.AddWithValue("@username", Convert.ToString(Request.QueryString["uName"]));
                cmd.Parameters.AddWithValue("@pwd", Encrypt(txtNewPwd.Text.Trim()));
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                lblStatus.Text = "Your password has been updated successfully.";
                txtNewPwd.Text = string.Empty;
                txtConfirmPwd.Text = string.Empty;
               
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error Occured : " + ex.Message.ToString();
            }
            finally
            {
              //  cmd.Dispose();
                con.Close();
              //  Session.Abandon();
            }
        }
        private string Decrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Login.aspx");
        //}
    }
    }
 