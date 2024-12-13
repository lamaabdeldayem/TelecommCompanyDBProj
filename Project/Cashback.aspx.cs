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
    public partial class Cashback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GetCashback(object sender, EventArgs e)
        {
            string mobileNo = mobileNo_TextBox.Text.Trim();
            string paymentIdx = paymentId_TextBox.Text.Trim();
            string benefitIdx = benefitId_TextBox.Text.Trim();

            if (string.IsNullOrEmpty(mobileNo) || string.IsNullOrEmpty(paymentIdx) || string.IsNullOrEmpty(benefitIdx))
            {
                feedbackLabel.Text = "All fields are required.";
                return;
            }

            if (!int.TryParse(paymentIdx, out int paymentId))
            {
                feedbackLabel.Text = "Please enter a valid Payment ID.";
                return;
            }

            if (!int.TryParse(benefitIdx, out int benefitId))
            {
                feedbackLabel.Text = "Please enter a valid Benefit ID.";
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

                    SqlCommand cmd = new SqlCommand("Payment_wallet_cashback", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
                    cmd.Parameters.AddWithValue("@payment_id", paymentId);
                    cmd.Parameters.AddWithValue("@benefit_id", benefitId);
                    cmd.ExecuteNonQuery();

                    decimal cashbackAmount = GetCashbackAmount(mobileNo, paymentId, benefitId, conn);

                    if (cashbackAmount > 0)
                    {
                        feedbackLabel.Text = $"Cashback Amount: {cashbackAmount:C2}";
                        feedbackLabel.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        feedbackLabel.Text = "No successful payment found for the provided Payment ID.";
                        feedbackLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    feedbackLabel.Text = "Error: " + ex.Message;
                    feedbackLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private decimal GetCashbackAmount(string mobileNo, int paymentId, int benefitId, SqlConnection conn)
        {
            string query = @"
        SELECT 0.1 * p.amount AS CashbackAmount
        FROM Payment p
        INNER JOIN Wallet w ON p.paymentID = @payment_id
        INNER JOIN customer_account a ON w.nationalID = a.nationalID
        WHERE p.paymentID = @payment_id 
        AND p.status = 'successful' 
        AND a.mobileNo = @mobile_num
    ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
            cmd.Parameters.AddWithValue("@payment_id", paymentId);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

    }
}


