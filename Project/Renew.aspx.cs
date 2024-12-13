using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Subscribe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RenewSubscription(object sender, EventArgs e)
        {

            string mobileNo = mobileNo_TextBox.Text.Trim();
            string amountx = amount_TextBox.Text.Trim();
            string planIdx = planId_TextBox.Text.Trim();
            string method = Method_TextBox.Text.Trim();



            if (string.IsNullOrEmpty(mobileNo) || string.IsNullOrEmpty(amountx) || string.IsNullOrEmpty(planIdx))
            {
                feedbackLabel.Text = "All fields are required.";
                return;
            }


            if (!decimal.TryParse(amountx, out decimal amount))
            {
                feedbackLabel.Text = "Please enter a valid amount.";
                return;
            }

            if (!int.TryParse(planIdx, out int planId))
            {
                feedbackLabel.Text = "Please enter a valid Plan ID.";
                return;
            }


            string connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"]?.ConnectionString;
            if (string.IsNullOrEmpty(connStr))
            {
                feedbackLabel.Text = "Connection string is missing or incorrect.";
                return;
            }


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {

                    conn.Open();


                    SqlCommand cmd = new SqlCommand("Initiate_plan_payment", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };


                    cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@payment_Method", method);
                    cmd.Parameters.AddWithValue("@plan_ID", planId);

                    cmd.ExecuteNonQuery();

                    feedbackLabel.Text = "Subscription renewal was successful.";
                    feedbackLabel.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {

                    feedbackLabel.Text = "Error: " + ex.Message;
                    feedbackLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }

}
