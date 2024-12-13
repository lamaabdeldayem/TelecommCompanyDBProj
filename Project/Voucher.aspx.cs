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
    public partial class Voucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Redeem(object sender, EventArgs e)
        {

            string mobileNo = MobileNo_TextBox.Text.Trim();
            string voucherIdx = VoucherID_TextBox.Text.Trim();


            if (string.IsNullOrEmpty(mobileNo) || string.IsNullOrEmpty(voucherIdx))
            {
                lblMessage.Text = "Please enter both mobile number and voucher ID.";
                return;
            }


            int voucherID;
            if (!int.TryParse(voucherIdx, out voucherID))
            {
                lblMessage.Text = "Invalid Voucher ID.";
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"]?.ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand c = new SqlCommand("SELECT COUNT(voucherID) FROM Voucher", conn);
            int voucherCount = (int)c.ExecuteScalar();
            bool isRedeemed = false;
            if (voucherID <= voucherCount)
            {
                isRedeemed = RedeemVoucherPoints(mobileNo, voucherID);
            }
            if (isRedeemed)
            {
                lblMessage.Text = "Voucher redeemed successfully!";
            }
            else
            {
                lblMessage.Text = "Voucher redemption failed. Please check your points or voucher details.";
            }
        }
        private bool RedeemVoucherPoints(string mobileNo, int voucherID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"]?.ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("Redeem_voucher_points", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mobile_num", mobileNo);
                        cmd.Parameters.AddWithValue("@voucher_id", voucherID);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                return false;
            }
        }
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}










