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
    public partial class Dashboard : System.Web.UI.Page
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
                    string sql = "SELECT name FROM UserTable WHERE username=@username and password=@password";
                    SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@username", Session["username"]);
                    sqlCmd.Parameters.AddWithValue("@password", Session["password"]);
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    rdr.Read();
                    {
                        lblWelcomeUser.Text = "Hello " + rdr.GetString(0) + "!";
                    }
                }
            }


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");


        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (Menu1.SelectedValue)
            {
                case "Amazon Listing":
                    MultiView1.ActiveViewIndex = 0;
                    
                    break;
                case "Walmart Listing":
                    MultiView1.ActiveViewIndex = 1;
                    
                    break;
            }
        }
    }
}