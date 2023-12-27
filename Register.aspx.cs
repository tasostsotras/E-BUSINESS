using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text.Encodings.Web;

namespace E_BUSINESS
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBUSINESSConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from Christes3 where Username= '" + TextBox1.Text + "'";
                SqlCommand entoli = new SqlCommand(checkuser, conn);
                int prosorini = Convert.ToInt32(entoli.ExecuteScalar().ToString());
                if (prosorini == 1)
                {
                    Response.Write("O xrhsths hdh yparx");
                }
                conn.Close();
            }
        }
        Random tyxaion = new Random();

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Guid newGUID = Guid.NewGuid();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBUSINESSConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from Christes3 where Username= '" + TextBox1.Text + "'";
                SqlCommand entoli = new SqlCommand(checkuser, conn);
                int prosorini = Convert.ToInt32(entoli.ExecuteScalar().ToString());
                if (prosorini == 1)
                {
                    Response.Write("O xrhsths hdh yparx");
                }
                else if (prosorini == 0)
                {
                    string insertQuery = "insert into Christes3 (Username,Password,UserType,HashedPassword,Telephone,Email) values (@Username,@Password,@UserType,@HashedPassword,@Telephone,@Email)";
                    SqlCommand com1 = new SqlCommand(insertQuery, conn);
                    com1.Parameters.AddWithValue("@Username", TextBox1.Text);
                    string password = TextBox2.Text;
                    System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                    byte[] saltBytes = new byte[36];
                    rng.GetBytes(saltBytes);
                    string salt = Convert.ToBase64String(saltBytes);
                    byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
                    byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);
                    string hashString = Convert.ToBase64String(hashBytes);
                    com1.Parameters.AddWithValue("@Password", password);
                    com1.Parameters.AddWithValue("@UserType", DropDownList1.SelectedItem.ToString());
                    com1.Parameters.AddWithValue("@HashedPassword", salt);
                    com1.Parameters.AddWithValue("@Telephone", TextBox5.Text);
                    com1.Parameters.AddWithValue("@Email", TextBox4.Text);
                    com1.ExecuteNonQuery();
                    Response.Write("Epityxhs eggrafh");
                    Response.Redirect("Welcome.aspx");
                    conn.Close();


                }
            }
            catch (Exception ex)
            {
                Response.Write("Sfalma:" + ex.ToString());
            }
        }

        
    }
}