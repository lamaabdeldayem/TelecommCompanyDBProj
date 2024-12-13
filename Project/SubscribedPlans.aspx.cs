using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SubscribedPlans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ViewSubscribedPlans(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"]?.ConnectionString;
            Label1.Text = "Button clicked.";

            if (string.IsNullOrEmpty(connStr))
            {
                Label1.Text = "Connection string is missing or incorrect.";
                return;
            }

            string mobileNo = mobileNo_In.Text.Trim();
            if (string.IsNullOrEmpty(mobileNo))
            {
                Label1.Text = "Please enter a valid mobile number.";
                return;
            }

            string query = "SELECT * FROM [Subscribed_plans_5_Months](@MobileNo)";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MobileNo", mobileNo);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Label1.Text += "<br/>Rows returned: " + dt.Rows.Count;

                    if (dt.Rows.Count == 0)
                    {
                        Label1.Text += "<br/>No records found for this mobile number.";
                    }
                    else
                    {
                        GridViewPlans.DataSource = dt;
                        GridViewPlans.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = "Error: " + ex.Message;
                }
            }
        }
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

    }

}

