using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PLTrading_WebApp
{
    public partial class WAL_Listing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null && Session["password"] == null)
            {
                Response.Redirect("Login.aspx");
                //lblWelcomeUser.Text = "Hello! " + Session["username"];
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost; Initial Catalog=PLTrading; Integrated Security = True;"))
                {
                    sqlCon.Open();
                    string sql = "SELECT initial FROM UserTable WHERE username=@username and password=@password";
                    SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@username", Session["username"]);
                    sqlCmd.Parameters.AddWithValue("@password", Session["password"]);
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    rdr.Read();
                    {
                        lblLister.Text = rdr.GetString(0);
                    }
                }
            }
            lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }
    }
}