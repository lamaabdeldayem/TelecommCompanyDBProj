using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using static System.Net.Mime.MediaTypeNames;

namespace Database_Milestone3
{
    public partial class AdminDashboard2 : Page
    {
        string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["Milestone2DB_24"].ToString();

        protected void Page_Load1(object sender, EventArgs e)
        {
        }

        protected void btnViewPaymentPoints_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtPhoneNumber.Text.Trim();
            if (mobileNumber.Length != 11 || !mobileNumber.All(char.IsDigit))
            {
                lblErrorMessage.Text = "Please enter a valid 11-digit phone number."; lblErrorMessage.Visible = true;
              //  gvPaymentPoints.Visible = false;
                return;
            }
            if (!DoesMobileNumberExistInCustomerAccount(mobileNumber))
            {
                lblErrorMessage.Text = "Sorry, this phone doesn't have an account, Enter a valid Phone Number."; return;
            }
            try
            {
                GetAccountPaymentPoints(mobileNumber);
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = $"Error occurred: {ex.Message}"; 
            }
        }

        
    


        private void GetAccountPaymentPoints(string mobileNumber)
        {
            string procedureName = "Account_Payment_Points";
            using (SqlConnection conn = new SqlConnection(connectionString1))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mobile_num", mobileNumber));
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            gvPaymentPoints.DataSource = dt;
                            gvPaymentPoints.DataBind();
                           
                        }
                        else
                        {
                            gvPaymentPoints.EmptyDataText = "No data available,insert new data or wait for data to be inserted";
                            gvPaymentPoints.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnUpdatePoints_Click(object sender, EventArgs e)
        {
            try
            {
                string mobileNumber = txtPointsMobileNumber.Text;
                if (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length != 11 || !mobileNumber.All(char.IsDigit))
                {
                    lblOldPoints.Text = "You entered a wrong Format, Please enter a valid 11-digit mobile number.";
                    lblNewPoints.Text = string.Empty; return;
                }
                if (!DoesMobileNumberExistInCustomerAccount(mobileNumber))
                {
                    lblOldPoints.Text = "Sorry, this phone doesn't have an account, Enter a valid Phone Number.";
                    lblNewPoints.Text = string.Empty;
                    lblNewPoints.Text = string.Empty; return;
                }
                if (!DoesMobileNumberExistinPayment(mobileNumber))
                {
                    lblOldPoints.Text = "No Data Found For this Input Account, Enter a valid Phone Number.";
                    lblNewPoints.Text = string.Empty; return;
                }
                (int oldPoints, int newPoints) = UpdatePoints(mobileNumber);
                lblOldPoints.Text = "Old Points: " + oldPoints.ToString();
                lblNewPoints.Text = "New Points: " + newPoints.ToString();
            }
            catch (Exception ex)
            {
                lblOldPoints.Text = "Error occurred: " + ex.Message;
                lblNewPoints.Text = string.Empty;
            }
        }
    


private bool DoesMobileNumberExistinPayment(string mobileNumber)
        {

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                string query = @"
            SELECT COUNT(*)
            FROM Points_group pg
            INNER JOIN Payment p ON pg.paymentId = p.paymentID
            WHERE p.mobileNo = @mobileNumber";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@mobileNumber", mobileNumber);

                    con.Open();
                    int count = (int)command.ExecuteScalar(); 
                    return count > 0; 
                }
            }
        }

        protected void btnCheckWalletLink_Click(object sender, EventArgs e)
        {
            try
            {
                string mobileNumber = txtMobileNumber.Text;

                if (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length != 11 || !mobileNumber.All(char.IsDigit))
                {
                    lblWalletLinkStatus.Text = "You entered a wrong Format, Please enter a valid 11-digit mobile number.";
                    return; 
                }

                if (!DoesMobileNumberExistInCustomerAccount(mobileNumber))
                {
                    lblWalletLinkStatus.Text = "Sorry, this phone doesn't have an account, Enter a valid Phone Number.";
                    return; 
                }

              
                bool isLinked = CheckWalletLink(mobileNumber);

                if (isLinked)
                {
                    lblWalletLinkStatus.Text = "Linked";
                }
                else
                {
                    lblWalletLinkStatus.Text = "Not Linked";
                }
            }
            catch (Exception ex)
            {
                lblWalletLinkStatus.Text = "Error occurred: " + ex.Message;
            }
        }
        private bool DoesMobileNumberExistInCustomerAccount(string mobileNumber)
        {
            bool exists = false;

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                string query = "SELECT COUNT(1) FROM customer_account WHERE mobileNo = @mobileNo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@mobileNo", mobileNumber);
                    con.Open();
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }

            return exists;
        }


        protected void btnViewAvgTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                int walletID = int.Parse(txtWalletIDTransfer.Text);
                DateTime startDate = DateTime.Parse(txtStartDate.Text);
                DateTime endDate = DateTime.Parse(txtEndDate.Text);

                if (!DoesWalletExist(walletID))
                {
                    lblAvgTransferAmount.Text = "No Wallets Available for this Wallet ID.";
                    return; 
                }

                if (!HasWalletTransfers(walletID))
                {
                    lblAvgTransferAmount.Text = "No money transfers were made by this wallet.";
                    return; 
                }

                int avgTransferAmount = GetAvgTransferAmount(walletID, startDate, endDate);

                lblAvgTransferAmount.Text = "Average Transfer Amount: " + avgTransferAmount;
            }
            catch (FormatException)
            {
                lblAvgTransferAmount.Text = "Please enter valid numeric values for Wallet ID and valid dates in yyyy-mm-dd format.";
            }
            catch (Exception ex)
            {
                lblAvgTransferAmount.Text = "Error occurred: " + ex.Message;
            }
        }

       
        private bool HasWalletTransfers(int walletID)
        {
            bool hasTransfers = false;

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                string query = "SELECT COUNT(1) FROM transfer_money WHERE walletID1 = @walletID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@walletID", walletID);
                    con.Open();
                    hasTransfers = (int)cmd.ExecuteScalar() > 0;
                }
            }

            return hasTransfers;
        }



        protected void btnViewCashbackAmount_Click(object sender, EventArgs e)
        {
            try
            {
                int walletID = int.Parse(txtWalletID.Text);
                int planID = int.Parse(txtPlanID.Text);

                if (!DoesWalletExist(walletID))
                {
                    lblCashbackAmount.Text = "No wallet found for this Wallet ID. Please enter a valid Wallet ID.";
                    return; 
                }

                if (!DoesPlanExist(planID))
                {
                    lblCashbackAmount.Text = "No service plan found for this Plan ID. Please enter a valid Plan ID.";
                    return; 
                }

                if (!HasCashbackData(walletID, planID))
                {
                    lblCashbackAmount.Text = "No cashback data found for the provided Wallet ID and Plan ID. Please verify your inputs.";
                    return; 
                }

                int cashbackAmount = GetCashbackAmount(walletID, planID);

                lblCashbackAmount.Text = "Total Cashback Amount: " + cashbackAmount;
            }
            catch (FormatException)
            {
                lblCashbackAmount.Text = "Please enter valid numeric values for Wallet ID and Plan ID.";
            }
            catch (Exception ex)
            {
                lblCashbackAmount.Text = "Error occurred: " + ex.Message;
            }
        }
        private bool DoesWalletExist(int walletID)
        {
            bool exists = false;

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                string query = "SELECT COUNT(1) FROM Wallet WHERE walletID = @walletID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@walletID", walletID);
                    con.Open();
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }

            return exists;
        }
        private bool DoesPlanExist(int planID)
        {
            bool exists = false;

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                string query = "SELECT COUNT(1) FROM service_plan WHERE planID = @planID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@planID", planID);
                    con.Open();
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }

            return exists;
        }
        private bool HasCashbackData(int walletID, int planID)
        {
            bool hasData = false;

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                string query = @"
            SELECT COUNT(1)
            FROM Cashback c
            INNER JOIN plan_provides_benefits pb ON c.benefitID = pb.benefitID
            WHERE c.walletID = @walletID AND pb.planID = @planID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@walletID", walletID);
                    cmd.Parameters.AddWithValue("@planID", planID);
                    con.Open();
                    hasData = (int)cmd.ExecuteScalar() > 0;
                }
            }

            return hasData;
        }


        protected void btnViewWallets_Click(object sender, EventArgs e)
        {
            GetWalletDetails();
             }

        protected void btnViewEShopVouchers_Click(object sender, EventArgs e)
        {
            GetEShopVouchers();
           }

        protected void btnViewPayments_Click(object sender, EventArgs e)
        {
            GetPayments();
          }

        protected void btnViewCashback_Click(object sender, EventArgs e)
        {
            GetCashback();
        }


        private void GetWalletDetails()
        {
            string query = "SELECT * FROM CustomerWallet";
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvWalletDetails.DataSource = dt;
                    gvWalletDetails.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        gvWalletDetails.DataSource = dt;
                        gvWalletDetails.DataBind();
                    }
                    else
                    {
                        gvWalletDetails.EmptyDataText = "No data available,insert new data or wait for data to be inserted";
                        gvWalletDetails.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        private void GetEShopVouchers()
        {
            string query = "SELECT * FROM E_shopVouchers";
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvEShopVouchers.DataSource = dt;
                        gvEShopVouchers.DataBind();
                    }
                    else
                    {
                        gvEShopVouchers.EmptyDataText = "No data available,insert new data or wait for data to be inserted";
                        gvEShopVouchers.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
        }


        private void GetPayments()
        {
            string query = "SELECT * FROM AccountPayments";
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0) { 
                    gvPayments.DataSource = dt;
                    gvPayments.DataBind();
                }
                    else
                {
                    gvPayments.EmptyDataText = "No data available,insert new data or wait for data to be inserted";
                    gvPayments.DataBind();
                }
            }
                catch (Exception ex)
                {
                Response.Write("Error: " + ex.Message);
            }

        }
        }

        private void GetCashback()
        {
            string query = "SELECT * FROM Num_of_cashback";
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                SqlCommand cmd = new SqlCommand(query, con);
              try{  con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                    if (dt.Rows.Count > 0) {
                        gvCashback.DataSource = dt;
                        gvCashback.DataBind(); }
                    else
                    {
                        gvCashback.EmptyDataText = "No data available,insert new data or wait for data to be inserted";
                        gvCashback.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }


            }
        }
        private int GetCashbackAmount(int walletID, int planID)
        {
            int cashbackAmount = 0;
            string query = "SELECT dbo.Wallet_Cashback_Amount(@walletID, @planID)";

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@walletID", walletID);
                cmd.Parameters.AddWithValue("@planID", planID);

                con.Open();
                cashbackAmount = (int)cmd.ExecuteScalar();
            }

            return cashbackAmount;
        }
        private int GetAvgTransferAmount(int walletID, DateTime startDate, DateTime endDate)
        {
            int avgTransferAmount = 0;

            string query = "SELECT dbo.Wallet_Transfer_Amount(@walletID, @start_date, @end_date)";

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@walletID", walletID);
                cmd.Parameters.AddWithValue("@start_date", startDate);
                cmd.Parameters.AddWithValue("@end_date", endDate);

                con.Open();
                object result = cmd.ExecuteScalar();
                avgTransferAmount = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }

            return avgTransferAmount;
        }
        private bool CheckWalletLink(string mobileNumber)
        {
            bool isLinked = false;

            string query = "SELECT dbo.Wallet_MobileNo(@mobile_num)";

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);

                con.Open();

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    isLinked = Convert.ToBoolean(result);
                }
            }

            return isLinked;
        }
        private (int oldPoints, int newPoints) UpdatePoints(string mobileNumber)
        {
            int oldPoints = 0;
            int newPoints = 0;

            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        string queryOldPoints = "SELECT points FROM customer_account WHERE mobileNo = @mobile_num";
                        using (SqlCommand cmdOld = new SqlCommand(queryOldPoints, con, transaction))
                        {
                            cmdOld.Parameters.AddWithValue("@mobile_num", mobileNumber);
                            object result = cmdOld.ExecuteScalar();
                            oldPoints = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                        }

                        string procedureQuery = "EXEC Total_Points_Account @mobile_num";
                        using (SqlCommand cmdProcedure = new SqlCommand(procedureQuery, con, transaction))
                        {
                            cmdProcedure.Parameters.AddWithValue("@mobile_num", mobileNumber);
                            cmdProcedure.ExecuteNonQuery();
                        }
                        string queryNewPoints = "SELECT points FROM customer_account WHERE mobileNo = @mobile_num";
                        using (SqlCommand cmdNew = new SqlCommand(queryNewPoints, con, transaction))
                        {
                            cmdNew.Parameters.AddWithValue("@mobile_num", mobileNumber);
                            object result = cmdNew.ExecuteScalar();
                            newPoints = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return (oldPoints, newPoints);
        }
        protected void txtWalletID_TextChanged(object sender, EventArgs e)
        {

        }
        public void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdminDashboard.aspx");

        }

    }
}