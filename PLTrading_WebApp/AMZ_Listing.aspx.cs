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
    public partial class AMZ_Listing : System.Web.UI.Page
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
                //txtdatepicker.Text = DateTime.Now.ToString("MM/dd/yyy");
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
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            string cstTime1 = cstTime.ToString("MM/dd/yyy");
            lblDate.Text = cstTime1;
            txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;

        }

        protected void txtSource_Link_TextChanged(object sender, EventArgs e)
        {

            if (txtsourcelink.Text == "")
            {
                txtsource.Text = "";
                rbtnWALHAY.Visible = false;
                rbtnWAL.Visible = false;
                txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
            }
            else
            {
                //if (txtSource_Link.Text.Substring(0, 200) == "https://www.walmart.com")
                if (txtsourcelink.Text.Contains("https://www.walmart.com"))
                {
                    txtsource.Text = "WAL";
                    rbtnWALHAY.Visible = true;
                    rbtnWAL.Visible = true;
                    rbtnWAL.Checked = true;
                    rbtnWALHAY.Checked = false;
                    txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;

                }
                else if (txtsourcelink.Text.Contains("https://www.homedepot.com/"))
                {
                    txtsource.Text = "HDP";
                    rbtnWALHAY.Visible = false;
                    rbtnWAL.Visible = false;
                    txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
                }

                else if (txtsourcelink.Text.Contains("https://www.overstock.com/"))
                {
                    txtsource.Text = "OVR";
                    rbtnWALHAY.Visible = false;
                    rbtnWAL.Visible = false;
                    txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
                }
                else if (txtsourcelink.Text.Contains("https://www.wayfair.com"))
                {
                    txtsource.Text = "WAY";
                    rbtnWALHAY.Visible = false;
                    rbtnWAL.Visible = false;
                    txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
                }
                else
                {
                    txtsource.Text = "";
                    rbtnWALHAY.Visible = false;
                    rbtnWAL.Visible = false;
                    txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
                }
            }
        }

        protected void txtsource_TextChanged(object sender, EventArgs e)
        {

        }
        //protected void rbtnWAL_CheckedChanged1(object sender, EventArgs e)
        //{

        //}

        //protected void rbtnWALHAY_CheckedChanged1(object sender, EventArgs e)
        //{
        //    if (rbtnWALHAY.Checked == false)
        //    {
        //        txtsource.Text = "WAL-HAY";
        //    }
        //}

        protected void txtvariant_TextChanged(object sender, EventArgs e)
        {

        }

        protected void rbtnWALHAY_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnWALHAY.Checked == true)
            {
                txtsource.Text = "WAL-HAY";
                txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
            }
            else
            {
                txtsource.Text = "WAL";
                rbtnWAL.Checked = true;
                txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
            }
        }

        protected void rbtnWAL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnWAL.Checked == true)
            {
                txtsource.Text = "WAL";
                txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
            }
            else
            {
                txtsource.Text = "WAL-HAY";
                rbtnWALHAY.Checked = true;
                txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
            //    var html = await client.GetStringAsync("https://www.walmart.com/ip/50908276");
            //    var doc = new HtmlAgilityPack.HtmlDocument();
            //    doc.LoadHtml(html);
            //    var price = doc.DocumentNode
            //                    .SelectSingleNode("//*[@data-product-price]")
            //                    .Attributes["data-product-price"]
            //                    .Value;

            //}
        }



        protected void txthandling_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtdatepicker_TextChanged1(object sender, EventArgs e)
        {
            
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            DateTime startdate = cstTime;
            DateTime enddate = txtdatepicker.Text == "" ? startdate : Convert.ToDateTime(txtdatepicker.Text);
            //string stardate1 = startdate.ToString("MM/dd/yyy");
            //string enddate1 = enddate.ToString("MM/dd/yyy");

            //lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
            if (enddate >= startdate)
            {
                int bd = 0;

                for (DateTime d = startdate; d < enddate; d = d.AddDays(1))
                {
                    if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                        bd++;

                    txthandling.Text = (bd).ToString();
                }
        
                if (bd < 9 )
                {
                    txthandling.Text = "3";
                }
                else
                {
                    txthandling.Text = (bd - 5).ToString();
                }
            }
            //else if (enddate == startdate)
            //{
            //    txthandling.Text = "3";
            //}
            else
            {
                txthandling.Text = "";
            }
        }

        protected void txtprice_TextChanged(object sender, EventArgs e)
        {

                txtsourceprice.Text = (txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text) * 1.08).ToString("0.00");
                txttotalcost.Text = (txtsourceprice.Text == "" ? 0.00 :  Convert.ToDouble(txtsourceprice.Text) + (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text))).ToString("0.00");
                txtprofit.Text = ((txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text) * 0.85) - Convert.ToDouble(txttotalcost.Text)).ToString("0.00");
                txtprofit.Text = txtamzprice.Text == "" ? "" : txtprofit.Text;
                txtprofitwotax.Text = ((txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text) * 0.85) - (txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text)) - (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text))).ToString("0.00");
                txtminlist.Text = ((txttotalcost.Text == "" ? 0.00 : Convert.ToDouble(txttotalcost.Text) * 1.29)).ToString("0.00");
                txtroiwotax.Text = (txtprofitwotax.Text == "" ? 0.00 : Convert.ToDouble(txtprofitwotax.Text) / ((txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text)) + (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text)))).ToString("0%");
                txtprofitmargin.Text = ((txtprofit.Text == "" ? 0.00 : Convert.ToDouble(txtprofit.Text)) / (txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text))).ToString("0%");
                txtprofitmarginwotax.Text = ((txtprofitwotax.Text == "" ? 0.00 : Convert.ToDouble(txtprofitwotax.Text)) / (txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text))).ToString("0%");
                txtroi.Text = ((txtprofit.Text == "" ? 0.00 : Convert.ToDouble(txtprofit.Text)) / (txttotalcost.Text == "" ? 0.00 : Convert.ToDouble(txttotalcost.Text))).ToString("0%");
        }

        protected void txtamzprice_TextChanged(object sender, EventArgs e)
        {
            txtsourceprice.Text = (txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text) * 1.08).ToString("0.00");
            txttotalcost.Text = (txtsourceprice.Text == "" ? 0.00 : Convert.ToDouble(txtsourceprice.Text) + (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text))).ToString("0.00");
            txtprofit.Text = ((txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text) * 0.85) - Convert.ToDouble(txttotalcost.Text)).ToString("0.00");
            txtprofit.Text = txtamzprice.Text == "" ? "" : txtprofit.Text;
            txtprofitwotax.Text = ((txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text) * 0.85) - (txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text)) - (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text))).ToString("0.00");
            txtminlist.Text = ((txttotalcost.Text == "" ? 0.00 : Convert.ToDouble(txttotalcost.Text) * 1.29)).ToString("0.00");
            txtroiwotax.Text = (txtprofitwotax.Text == "" ? 0.00 : Convert.ToDouble(txtprofitwotax.Text) / ((txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text)) + (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text)))).ToString("0%");
            txtprofitmargin.Text = ((txtprofit.Text == "" ? 0.00 : Convert.ToDouble(txtprofit.Text)) / (txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text))).ToString("0%");
            txtprofitmarginwotax.Text = ((txtprofitwotax.Text == "" ? 0.00 : Convert.ToDouble(txtprofitwotax.Text)) / (txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text))).ToString("0%");
            txtroi.Text = ((txtprofit.Text == "" ? 0.00 : Convert.ToDouble(txtprofit.Text)) / (txttotalcost.Text == "" ? 0.00 : Convert.ToDouble(txttotalcost.Text))).ToString("0%");
        }

        protected void txtshippingcost_TextChanged(object sender, EventArgs e)
        {
            txtsourceprice.Text = (txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text) * 1.08).ToString("0.00");
            txttotalcost.Text = (txtsourceprice.Text == "" ? 0.00 : Convert.ToDouble(txtsourceprice.Text) + (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text))).ToString("0.00");
            txtprofit.Text = ((txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text) * 0.85) - Convert.ToDouble(txttotalcost.Text)).ToString("0.00");
            txtprofit.Text = txtamzprice.Text == "" ? "" : txtprofit.Text;
            txtprofitwotax.Text = ((txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text) * 0.85) - (txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text)) - (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text))).ToString("0.00");
            txtminlist.Text = ((txttotalcost.Text == "" ? 0.00 : Convert.ToDouble(txttotalcost.Text) * 1.29)).ToString("0.00");
            txtroiwotax.Text = (txtprofitwotax.Text == "" ? 0.00 : Convert.ToDouble(txtprofitwotax.Text) / ((txtprice.Text == "" ? 0.00 : Convert.ToDouble(txtprice.Text)) + (txtshippingcost.Text == "" ? 0.00 : Convert.ToDouble(txtshippingcost.Text)))).ToString("0%");
            txtprofitmargin.Text = ((txtprofit.Text == "" ? 0.00 : Convert.ToDouble(txtprofit.Text)) / (txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text))).ToString("0%");
            txtprofitmarginwotax.Text = ((txtprofitwotax.Text == "" ? 0.00 : Convert.ToDouble(txtprofitwotax.Text)) / (txtamzprice.Text == "" ? 0.00 : Convert.ToDouble(txtamzprice.Text))).ToString("0%");
            txtroi.Text = ((txtprofit.Text == "" ? 0.00 : Convert.ToDouble(txtprofit.Text)) / (txttotalcost.Text == "" ? 0.00 : Convert.ToDouble(txttotalcost.Text))).ToString("0%");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtitemNum_TextChanged(object sender, EventArgs e)
        {
            txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (lblDate.Text == "" || lblLister.Text == "" || txtSKU.Text == "" || txtsourcelink.Text == "" || txtsource.Text == "" ||
            //    txtprice.Text == "" || txtshippingcost.Text == "" || DropDownList1.Text == "" ||
            //    txtqty.Text == "" || txthandling.Text == "" || txtamzprodname.Text == "" || txtbrand.Text == "" || txtASIN.Text == "" ||
            //    DropDownList3.Text == "" || DropDownList2.Text == "" || txtamzprice.Text == "" || txtsalesrank.Text == "")
            //{
            //    if (txtsourcelink.Text == "")
            //    {
            //        lblSave.Text = "Please input source link!";
            //    }
            //    if (txtprice.Text == "")
            //    {
            //        lblSave.Text = "Please input source price!";
            //    }
            //    //if (txtshippingcost.Text == "")
            //    //{
            //    //    lblSave.Text = "Please input shipping cost!";
            //    //}
            //    if (DropDownList1.Text == "")
            //    {
            //        lblSave.Text = "Please select shipping type!";
            //    }
            //    //if (txtvariant.Text == "")
            //    //{
            //    //    lblSave.Text = "Please input source link!";
            //    //}
            //    if (txtqty.Text == "")
            //    {
            //        lblSave.Text = "Please input quantity!";
            //    }
            //    if (txthandling.Text == "")
            //    {
            //        lblSave.Text = "Please select date of delivery!";
            //    }
            //    if (txtamzprodname.Text == "")
            //    {
            //        lblSave.Text = "Please input amazon product name!";
            //    }
            //    if (txtbrand.Text == "")
            //    {
            //        lblSave.Text = "Please input brand name!";
            //    }
            //    if (txtASIN.Text == "")
            //    {
            //        lblSave.Text = "Please input ASIN!";
            //    }
            //    if (DropDownList3.Text == "")
            //    {
            //        lblSave.Text = "Please select type of seller!";
            //    }
            //    if (DropDownList2.Text == "")
            //    {
            //        lblSave.Text = "Please select position!";
            //    }
            //    if (txtamzprice.Text == "")
            //    {
            //        lblSave.Text = "Please input amazon price!";
            //    }
            //    if (txtsalesrank.Text == "")
            //    {
            //        lblSave.Text = "Please input sales rank!";
            //    }

            //    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Record Saved" + "');", true);                
            //}
            //else
            //{


                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost; Initial Catalog=PLTrading; Integrated Security = True;"))
                {
                    sqlCon.Open();

                    string queryCheck = "SELECT count(*) FROM dbo.[Amazon_Listings] WHERE ASIN = @asin"; 
                    SqlCommand sqlCmd1 = new SqlCommand(queryCheck, sqlCon);
                    sqlCmd1.Parameters.AddWithValue("@asin", txtASIN.Text.Trim());
                    int count = Convert.ToInt32(sqlCmd1.ExecuteScalar());
                    if (count == 1)
                    {
                        
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "ASIN ALREADY EXIST" + "');", true);
                        //Session["username"] = txtUserName.Text.Trim();
                        //Session["password"] = txtPassword.Text.Trim();
                        //Response.Redirect("Dashboard.aspx");

                    }
                    else
                //else { lblErrMsg1.Visible = true; }
                    {

                    string query = "INSERT INTO dbo.[Amazon_Listings] (list_date, lister, sku, source_link, source, source_price, shipping_cost, " +
                        "shipping, vendor_variant, qty, handling_time, amz_prod_name, amz_brand, ASIN, amz_type, amz_position, amz_price, " +
                        "amz_sales_rank, profit, profit_margin, roi, profit_wotax, profit_margin_wotax, roi_wotax, source_price_tax, total_cost," +
                        "min_list_price, bsr, bsr_category, date_created) VALUES (@list_date,@lister,@sku,@sourcelink,@source,@source_price," +
                        "@shipping_cost,@shipping,@vendor_variant,@qty,@handling_time,@amz_prod_name,@amz_brand,@ASIN,@amz_type,@amz_position,@amz_price,@amz_sales_rank,@profit," +
                        "@profit_margin,@roi,@profit_wotax,@profit_margin_wotax,@roi_wotax,@source_price_tax,@total_cost,@min_list_price,@bsr,@bsr_category,@date_created)";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@list_date", lblDate.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@lister", lblLister.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@sku", txtSKU.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@sourcelink", txtsourcelink.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@source", txtsource.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@source_price", Convert.ToDouble(txtprice.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@shipping_cost", Convert.ToDouble(txtshippingcost.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@shipping", DropDownList1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@vendor_variant", txtvariant.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@qty", txtqty.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@handling_time", txthandling.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@amz_prod_name", txtamzprodname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@amz_brand", txtbrand.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ASIN", txtASIN.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@amz_type", DropDownList3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@amz_position", DropDownList2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@amz_price", Convert.ToDouble(txtamzprice.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@amz_sales_rank", txtsalesrank.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@profit", Convert.ToDouble(txtprofit.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@profit_margin", txtprofitmargin.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@roi", txtroi.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@profit_wotax", Convert.ToDouble(txtprofitwotax.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@profit_margin_wotax", txtprofitmarginwotax.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@roi_wotax", txtroiwotax.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@source_price_tax", Convert.ToDouble(txtsourceprice.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@total_cost", Convert.ToDouble(txttotalcost.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@min_list_price", Convert.ToDouble(txtminlist.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@bsr", txtsalesrank.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@bsr_category", txtsalesrank.Text.Trim());
                    DateTime timeUtc = DateTime.UtcNow;
                    TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                    DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                    sqlCmd.Parameters.AddWithValue("@date_created", cstTime.ToString());

                    sqlCmd.ExecuteNonQuery();
                    lblSave.Text = "Record Saved!";
                    }
                }
            //}
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //lblLister.Text = "";
            //txtSKU.Text = "";
            txtsourcelink.Text = "";
            txtsource.Text = "";
            txtprice.Text = "";
            txtshippingcost.Text = "";
            DropDownList1.Text = "";
            txtvariant.Text = "";
            txtqty.Text = "";
            txthandling.Text = "";
            txtamzprodname.Text = "";
            txtbrand.Text = "";
            txtASIN.Text = "";
            DropDownList3.Text = "";
            DropDownList2.Text = "";
            txtamzprice.Text = "";
            txtsalesrank.Text = "";
            txtprofit.Text = "";
            txtprofitmargin.Text = "";
            txtroi.Text = "";
            txtroiwotax.Text = "";
            txtprofitmarginwotax.Text = "";
            txtroiwotax.Text = "";
            txtsourceprice.Text = "";
            txttotalcost.Text = "";
            txtminlist.Text = "";
            txtsalesrank.Text = "";
            txtsalesrank.Text = "";
            txtprofitwotax.Text = "";
            txtitemNum.Text = "";
            txtdatepicker.Text = "";
            txtSKU.Text = txtsource.Text + "-" + lblLister.Text + "-" + Convert.ToDateTime(lblDate.Text).ToString("MMddyyy") + "-" + txtitemNum.Text;
            lblSave.Text = "";
        }

        protected void btnClear_Unload(object sender, EventArgs e)
        {

        }
    }
}
