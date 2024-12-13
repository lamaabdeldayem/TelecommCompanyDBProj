using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database_Milestone3
{//
    public partial class AdminDashboard : Page
    {
        // private readonly string connectionString = "Milestone2DB_24";
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void Customer_profiles(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [allCustomerAccounts]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    GridViewCustomerProfiles.DataSource = dt;
                    GridViewCustomerProfiles.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                }
            }
        }

        protected void Physical_shops(object sender, EventArgs e)
        {
            string query = "Select * from [PhysicalStoreVouchers]";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewPhysical.DataSource = dt;
                    GridViewPhysical.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                }

            }

        }

        protected void resolved_tickets(object sender, EventArgs e)
        {
            string query = "Select * from allResolvedTickets";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewresolved_tickets.DataSource = dt;
                    GridViewresolved_tickets.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                }
            }

        }

        protected void Accounts(object sender, EventArgs e)
        {
            string query = "Exec Account_Plan"; //di procedure betet3emel zay el view??
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewAccounts.DataSource = dt;
                    GridViewAccounts.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                }
            }

        }

        protected void GetAccounts(object sender, EventArgs e)
        {

            int planID;
            DateTime subDate;


            if (!int.TryParse(TxtPlanID.Text, out planID))
            {
                Response.Write("<script>alert('Invalid Plan ID');</script>");
                return;
            }

            if (!DateTime.TryParse(TxtSubDate.Text, out subDate))
            {
                Response.Write("<script>alert('Invalid Subscription Date');</script>");
                return;
            }
            if (!DateTime.TryParseExact(TxtSubDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out subDate))
            {
                Response.Write("<script>alert('Invalid Date. Please use the format yyyy-MM-dd');</script>");
                return;
            }

            string query = "SELECT * FROM [Account_Plan_date](@sub_date, @plan_id)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sub_date", subDate);
                    cmd.Parameters.AddWithValue("@plan_id", planID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewGetAcc.DataSource = dt;
                    GridViewGetAcc.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }

        }

        protected void Usage(object sender, EventArgs e)
        {

            string mobile_num = Txtmobile_num.Text;
            DateTime start_date;


            if (string.IsNullOrEmpty(mobile_num) || mobile_num.Length != 11)
            {
                Response.Write("<script>alert('Invalid Mobile Number');</script>");
                return;
            }

            if (!DateTime.TryParse(TxtStartDate.Text, out start_date))
            {
                Response.Write("<script>alert('Invalid Start Date');</script>");
                return;
            }
            if (!DateTime.TryParseExact(TxtStartDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out start_date))
            {
                Response.Write("<script>alert('Invalid Start Date. Please use the format yyyy-MM-dd');</script>");
                return;
            }
            string query = "SELECT * FROM [Account_Usage_Plan](@mobile_num, @start_date)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mobile_num", mobile_num);
                    cmd.Parameters.AddWithValue("@start_date", start_date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewUsage.DataSource = dt;
                    GridViewUsage.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }

        protected void Remove_benefits(object sender, EventArgs e)
        {

            string mobileNum = TxtMob_num.Text;
            int planID;


            if (mobileNum.Length != 11 || !long.TryParse(mobileNum, out _))
            {
                Result1.Text = "Invalid Mobile Number. Must be 11 digits.";
                return;
            }

            if (!int.TryParse(TxtPlanID.Text, out planID))
            {
                Result1.Text = "Invalid Plan ID.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Benefits_Account", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };


                    cmd.Parameters.AddWithValue("@mobile_num", mobileNum);
                    cmd.Parameters.AddWithValue("@plan_id", planID);


                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        Result1.ForeColor = System.Drawing.Color.Green;
                        Result1.Text = "Benefits successfully removed.";
                    }
                    else
                    {
                        Result1.Text = "No matching benefits found for the given inputs.";
                    }
                }
                catch (Exception ex)
                {

                    Result1.Text = $"Error: {ex.Message}";
                }
            }

        }

        protected void SMS_offered(object sender, EventArgs e)
        {
            string mobileNum = Mobile_number_in.Text.Trim();

            if (mobileNum.Length != 11 || !long.TryParse(mobileNum, out _))
            {
                SMS_Res.Text = "Invalid Mobile Number. Must be 11 digits.";
                return;
            }

            string query = "select * from dbo.Account_SMS_Offers (@mobile_num)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNum);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridViewSMSOffers.DataSource = dt;
                        GridViewSMSOffers.DataBind();
                        SMS_Res.Text = ""; // Clear message
                    }
                    else
                    {
                        GridViewSMSOffers.DataSource = null;
                        GridViewSMSOffers.DataBind();
                        SMS_Res.Text = $"No SMS offers found for mobile number {mobileNum}."; // Updated message
                    }
                }
                catch (Exception ex)
                {
                    SMS_Res.Text = $"Error: {ex.Message}";
                }
            }
        }

        public void btnNext_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdminDashboard2.aspx");

        }

        public void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");

        }


    }
}