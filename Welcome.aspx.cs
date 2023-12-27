using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace E_BUSINESS
{
    public partial class Welcome : System.Web.UI.Page
    {
        public static string ID = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Random tyxaion = new Random();

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlsyndesi = new SqlConnection(ConfigurationManager.ConnectionStrings["EBUSINESSConnectionString"].ConnectionString);
            sqlsyndesi.Open();
            string elegxosxristi = "select count(*) from Christes3 where Username = '" + TextBox1.Text + "'";
            SqlCommand entoli = new SqlCommand(elegxosxristi, sqlsyndesi);
            int prosorini = Convert.ToInt32(entoli.ExecuteScalar().ToString());
            if (prosorini==1)
            {
                string checkPasswordQuery = "select Password from Christes3 where Username='" + TextBox1.Text + "'";
                SqlCommand cccc = new SqlCommand(checkPasswordQuery, sqlsyndesi);
                string Password = cccc.ExecuteScalar().ToString().Replace(" ", "");
                if (Password==TextBox2.Text)
                {
                    Session["New"] = TextBox1.Text;
                    string checkUserType = "select UserType from Christes3 where Username= '" + TextBox1.Text + "'";
                    SqlCommand entoli1 = new SqlCommand(checkUserType, sqlsyndesi);
                    string xristitypos = entoli1.ExecuteScalar().ToString();
                    SqlCommand entoli2 = new SqlCommand(checkPasswordQuery, sqlsyndesi);
                    string prosorini1 = entoli2.ExecuteScalar().ToString();
                    ID = prosorini1;
                    if (xristitypos=="Customer")
                    {
                        Response.Redirect("Customer.aspx");
                    } else
                    {
                        Response.Redirect("Seller.aspx");
                    }

                    //conn.Close();
                }
                else
                {
                    Response.Write("Password is not correct");
                }
            }
            else
            {
                Response.Write("Username is not correct");
            }

            sqlsyndesi.Close();
        

        }
      }
}
