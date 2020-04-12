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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrMsg1.Visible = false;

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            lblcsttime.Text = "Central Standard Time: " + cstTime.ToString();
            DateTime manila = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Taipei Standard Time");
            lblutctime.Text = "Manila Time: " + manila.ToString();
            //txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text)
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost; Initial Catalog=PLTrading; Integrated Security = True;"))
            {
                sqlCon.Open();
                string query = "SELECT count(1) from UserTable WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Session["password"] = txtPassword.Text.Trim();
                    Response.Redirect("Dashboard.aspx");

                }
                else { lblErrMsg1.Visible = true; }
            }
        }
    }
}