using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class Recharge : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RechargeButton(object sender, EventArgs e)
        {
            string mobileNo = MobileNo_TextBox.Text.Trim();
            decimal amount;
            string paymentMethod = PaymentMethod_TextBox.Text.Trim();
            string planIDx = PlanID_TextBox.Text.Trim();
            if (string.IsNullOrEmpty(mobileNo) || !long.TryParse(mobileNo, out _) || mobileNo.Length != 11)
            {
                lblMessage.Text = "Please enter a valid 11-digit mobile number.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(paymentMethod))
            {
                lblMessage.Text = "Please select a payment method.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (!int.TryParse(planIDx, out int planId))
            {
                lblMessage.Text = "Please enter a valid Plan ID.";
                return;
            }

            if (decimal.TryParse(Amount_TextBox.Text.Trim(), out amount) && amount > 0)
            {
                ProcessRecharge(mobileNo, amount, paymentMethod, planIDx);
            }
            else
            {
                lblMessage.Text = "Please enter a valid amount.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ProcessRecharge(string mobileNo, decimal amount, string paymentMethod, string planID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Initiate_plan_payment", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@payment_method", paymentMethod);
                    cmd.Parameters.AddWithValue("@plan_ID", planID);
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Recharge successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}
