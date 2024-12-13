using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database_Milestone3
{
    public partial class CustomerDashboard : System.Web.UI.Page
    {

        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Service_Plans(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [allServicePlans]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    GridViewServicePlans.DataSource = dt;
                    GridViewServicePlans.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void ConsumptionOfPlan(object sender, EventArgs e)
        {

            string planName = PlanName.Text.Trim();
            DateTime startDate, endDate;


            if (string.IsNullOrEmpty(planName))
            {
                Response.Write("<script>alert('Please enter a Plan Name');</script>");
                return;
            }

            if (!DateTime.TryParseExact(StarDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out startDate))
            {
                Response.Write("<script>alert('Invalid Start Date. Please use the format yyyy-MM-dd');</script>");
                return;
            }

            if (!DateTime.TryParseExact(EndDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out endDate))
            {
                Response.Write("<script>alert('Invalid End Date. Please use the format yyyy-MM-dd');</script>");
                return;
            }

            if (startDate > endDate)
            {
                Response.Write("<script>alert('Start Date cannot be after End Date');</script>");
                return;
            }

            string query = "select * from dbo.Consumption(@planName, @startDate, @endDate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    cmd.Parameters.AddWithValue("@planName", planName);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewConsumption.DataSource = dt;
                    GridViewConsumption.DataBind();
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine($"SQL Error: {ex.Message}");
                    Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                }
            }
        }

        protected void Plans_Not_SubTo(object sender, EventArgs e)
        {

            string mobile_num = MobileNum1.Text;



            if (string.IsNullOrEmpty(mobile_num) || mobile_num.Length != 11)
            {
                Response.Write("<script>alert('Invalid Mobile Number');</script>");
                return;
            }

            string query = "EXEC [Unsubscribed_Plans] @mobile_num";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mobile_num", mobile_num);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewNotSubscribedTo.DataSource = dt;
                    GridViewNotSubscribedTo.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }
        protected void Usage_Plan_CurrentMonth(object sender, EventArgs e)
        {

            string mobile_num = MobileNum1.Text;

            if (string.IsNullOrEmpty(mobile_num) || mobile_num.Length != 11)
            {
                Response.Write("<script>alert('Invalid Mobile Number');</script>");
                return;
            }

            string query = "select * from dbo.Usage_Plan_CurrentMonth (@mobile_num)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mobile_num", mobile_num);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridViewUsage_Plan_CurrentMonth.DataSource = dt;
                    GridViewUsage_Plan_CurrentMonth.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }

        protected void Cashback_Wallet_Customer(object sender, EventArgs e)
        {

            int nationalId;
            if (!int.TryParse(NationalID.Text.Trim(), out nationalId))
            {
                Response.Write("<script>alert('Invalid National ID. Please enter a valid integer.');</script>");
                return;
            }

            string query = "select * from dbo.Cashback_Wallet_Customer(@national_id);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@national_id", SqlDbType.Int) { Value = nationalId });

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            GridViewCashback_Wallet_Customer.DataSource = dt;
                            GridViewCashback_Wallet_Customer.DataBind();
                        }
                        else
                        {
                            GridViewCashback_Wallet_Customer.DataSource = null;
                            GridViewCashback_Wallet_Customer.DataBind();
                            Response.Write("<script>alert('No records found for the provided National ID.');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine($"SQL Error: {ex.Message}");
                    Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
                }
            }
        }


        public void Customer2(object sender, EventArgs e)
        {

            Response.Redirect("WebForm2.aspx");

        }
        public void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login_Customer.aspx");

        }
    }

}