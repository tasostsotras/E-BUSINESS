using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace E_BUSINESS
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void Button18_Click(object sender, EventArgs e)
        {
            double synoliko_kostos;
            double t1 = Double.Parse(TextBox1.Text);
            double t2 = Double.Parse(TextBox2.Text);
            double t3 = Double.Parse(TextBox3.Text);
            double t4 = Double.Parse(TextBox4.Text);
            double t5 = Double.Parse(TextBox5.Text);
            synoliko_kostos = t1 * 10 + t2 * 20 + t3 * 99.99 + t4 * 16.80 + t5 * 8.90;
            string message2 = synoliko_kostos.ToString() + " Euros .Continue?";
            string message = "The total cost is: ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message2, message, buttons);
            if (result == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EBUSINESSConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into Orders (useremail,price,whenordered,items) values (@Email,@synoliko_kostos,@datetime,@items)";
                SqlCommand com1 = new SqlCommand(insertQuery, conn);
                string t1_as_string = t1.ToString();
                string t2_as_string = t2.ToString();
                string t3_as_string = t3.ToString();
                string t4_as_string = t4.ToString();
                string t5_as_string = t5.ToString();
                string[] paraggelia = { t1_as_string,",",t2_as_string,",", t3_as_string,",",t4_as_string,",", t5_as_string };
                com1.Parameters.AddWithValue("@Email", TextBox6.Text);
                com1.Parameters.AddWithValue("@synoliko_kostos", synoliko_kostos);
                com1.Parameters.AddWithValue("@datetime", DateTime.Now);
                string joined = string.Concat(paraggelia);
                com1.Parameters.AddWithValue("@items", joined);
                com1.ExecuteNonQuery();
                Response.Redirect("EndOfTransaction.aspx");
                conn.Close();
                
            }
            

        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "0";
            TextBox2.Text = "0";
            TextBox3.Text = "0";
            TextBox4.Text = "0";
            TextBox5.Text = "0";
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}