using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database_Milestone3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void enter1(object sender, EventArgs e)
        {
            try
            {
                // Connection
                string connectionString = ConfigurationManager.ConnectionStrings["WebApplication2"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // el SQL command di bet el data mn el view
                    SqlCommand command = new SqlCommand("SELECT * FROM allBenefits", connection);

                    connection.Open();

                    // Execute the query and fill a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // put whats in the DataTable to the GridView 
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                LabelError.Text = "An error occurred. Please try again later.";
                LabelError.Visible = true;
            }
        }

        protected void enter2(object sender, EventArgs e)
        {
            // ( connection string )
            String connStr = WebConfigurationManager.ConnectionStrings["WebApplication2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                // Bygib el National ID mn el input textbox
                String national_id = nationalid.Text;

                // Create the SqlCommand &  bydakhal el parameters lel proc
                SqlCommand numberoftechnicalsupporttickets = new SqlCommand("Ticket_Account_Customer", conn);
                numberoftechnicalsupporttickets.CommandType = System.Data.CommandType.StoredProcedure;
                numberoftechnicalsupporttickets.Parameters.Add(new SqlParameter("@NID", national_id));


                conn.Open();

                // Execute el proc and get the result
                int ticketCount = (int)numberoftechnicalsupporttickets.ExecuteScalar();

                // Display the result to the user
                ticketCountLabel.Text = $"Number of unresolved tickets: {ticketCount}";
                ticketCountLabel.Visible = true; // Ensure the label is visible
            }
            catch (Exception ex)
            {

                errorLabel.Text = $"An error occurred: {ex.Message}";
                errorLabel.Visible = true; // Ensure the error label is visible
            }
            finally
            {

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        protected void enter3(object sender, EventArgs e)
        {
            // Get the mobile number from the input textbox
            String mobileenumber = mobno.Text.Trim();

            // byshof lw the phone valid (must be exactly 11 digits)
            if (!System.Text.RegularExpressions.Regex.IsMatch(mobileenumber, @"^\d{11}$"))
            {
                // Display an error and stop further processing lw el phone no. not exactly 11 match it with the regular expression
                Label3.Text = "Invalid mobile number. Please enter exactly 11 digits.";
                Label3.Visible = true;
                voucherIDLabel.Visible = false; // Hide the voucher output label
                return;
            }

            // Clear any previous error messages
            Label3.Visible = false;

            // connection string
            String connStr = WebConfigurationManager.ConnectionStrings["WebApplication2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                //  call el proc w bydkhlha el input
                SqlCommand voucherWithTheHighestValue = new SqlCommand("Account_Highest_Voucher", conn);
                voucherWithTheHighestValue.CommandType = System.Data.CommandType.StoredProcedure;
                voucherWithTheHighestValue.Parameters.Add(new SqlParameter("@mobile_num", mobileenumber));

                // by read el result 
                conn.Open();
                SqlDataReader reader = voucherWithTheHighestValue.ExecuteReader();

                // Check if there are results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //by Display el result
                        string voucherID = reader["voucherID"].ToString();
                        voucherIDLabel.Text = $"Voucher ID with the highest value: {voucherID}";
                        voucherIDLabel.Visible = true;
                    }
                }
                else
                {
                    voucherIDLabel.Text = "No vouchers found for the given mobile number, pls enter other mobile no. ";
                    voucherIDLabel.Visible = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {

                Label3.Text = $"An error occurred: {ex.Message}";
                Label3.Visible = true;
                voucherIDLabel.Visible = false;
            }
            finally
            {

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        protected void enter4(object sender, EventArgs e)
        {
            // connection 
            String connStr = WebConfigurationManager.ConnectionStrings["WebApplication2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            // Get inputs
            String mobileenumber = mobno2.Text.Trim();
            String planname = plan.Text.Trim();

            try
            {

                if (!System.Text.RegularExpressions.Regex.IsMatch(mobileenumber, @"^\d{11}$"))
                {
                    // Display error for invalid mobile number(not 11 digits)
                    errorLabel4.Text = "Invalid mobile number. Please enter exactly 11 digits.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false; // Hide any previous results
                    return;
                }

                // Clear previous error messages
                errorLabel4.Visible = false;

                // (Open database connection)
                conn.Open();

                // Check if the mobile number exists in the customer_account table
                SqlCommand checkMobile = new SqlCommand("SELECT COUNT(*) FROM customer_account WHERE mobileNo = @mobile_num", conn);
                checkMobile.Parameters.Add(new SqlParameter("@mobile_num", mobileenumber));
                int mobileExists = (int)checkMobile.ExecuteScalar();

                // Check if the plan name exists in the service_plan table (note: the column is 'name')
                SqlCommand checkPlan = new SqlCommand("SELECT COUNT(*) FROM service_plan WHERE name = @plan_name", conn);
                checkPlan.Parameters.Add(new SqlParameter("@plan_name", planname));
                int planExists = (int)checkPlan.ExecuteScalar();

                if (mobileExists == 0 && planExists == 0)
                {
                    // Mobile number not found
                    errorLabel4.Text = "Mobile no. and plan not found in the system, Please Enter A Valid Mobile Number then a valid plan name.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false;
                    return;
                }

                if (mobileExists == 0)
                {
                    // Mobile number not found
                    errorLabel4.Text = "Mobile number not found in the system, Please Enter A Valid Mobile Number.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false;
                    return;
                }

                if (planExists == 0)
                {
                    // Plan name not found
                    errorLabel4.Text = "Plan name not found in the system ,Please Enter A Valid Plan Name.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false;
                    return;
                }

                // Both mobile number and plan name exist; call the SQL function
                SqlCommand Remainingplanamount = new SqlCommand("SELECT dbo.Remaining_plan_amount(@mobile_num, @plan_name)", conn);
                Remainingplanamount.CommandType = System.Data.CommandType.Text;
                Remainingplanamount.Parameters.Add(new SqlParameter("@mobile_num", mobileenumber));
                Remainingplanamount.Parameters.Add(new SqlParameter("@plan_name", planname));

                // Execute the function and retrieve the result
                object result = Remainingplanamount.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int remainingAmount))
                {
                    // Display the function output to the user
                    resultLabel.Text = $"Remaining plan amount: {remainingAmount}";
                    resultLabel.Visible = true;
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                errorLabel4.Text = $"An error occurred: {ex.Message}";
                errorLabel4.Visible = true;
                resultLabel.Visible = false;
            }
            finally
            {

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        protected void enter5(object sender, EventArgs e)
        {
            // Retrieve the connection string from Web.config
            String connStr = WebConfigurationManager.ConnectionStrings["WebApplication2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            // Get input values
            String mobileenumber5 = mobno2.Text.Trim();
            String planname5 = plan.Text.Trim();  // The correct name for the plan

            try
            {
                // Validate the mobile number
                if (!System.Text.RegularExpressions.Regex.IsMatch(mobileenumber5, @"^\d{11}$"))
                {
                    // Display error for invalid mobile number
                    errorLabel4.Text = "Invalid mobile number. Please enter exactly 11 digits.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false; // Hide any previous results
                    return;
                }

                // Clear previous error messages
                errorLabel4.Visible = false;

                // Open the database connection
                conn.Open();

                // Check if the mobile number exists in the customer_account table
                SqlCommand checkMobile = new SqlCommand("SELECT COUNT(*) FROM customer_account WHERE mobileNo = @mobile_num", conn);
                checkMobile.Parameters.Add(new SqlParameter("@mobile_num", mobileenumber5));
                int mobileExists = (int)checkMobile.ExecuteScalar();

                // Check if the plan name exists in the service_plan table (note: the column is 'name')
                SqlCommand checkPlan = new SqlCommand("SELECT COUNT(*) FROM service_plan WHERE name = @plan_name", conn);
                checkPlan.Parameters.Add(new SqlParameter("@plan_name", planname5));
                int planExists = (int)checkPlan.ExecuteScalar();

                if (mobileExists == 0 && planExists == 0)
                {
                    // Mobile number not found
                    errorLabel4.Text = "Mobile and plan not found in the system, Please Enter A Valid Mobile then a valid plan name.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false;
                    return;
                }


                if (mobileExists == 0)
                {
                    // Mobile number not found
                    errorLabel4.Text = "Mobile number not found in the system, Please Enter A Valid Mobile Number.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false;
                    return;
                }

                if (planExists == 0)
                {
                    // Plan name not found
                    errorLabel4.Text = "this Plan name isnot found in the system ,Please Enter A Valid Plan Name.";
                    errorLabel4.Visible = true;
                    resultLabel.Visible = false;
                    return;
                }

                // Both mobile number and plan name exist; call the SQL function
                SqlCommand extraplanamount = new SqlCommand("SELECT dbo.Extra_plan_amount(@mobile_num, @plan_name)", conn);
                extraplanamount.CommandType = System.Data.CommandType.Text;
                extraplanamount.Parameters.Add(new SqlParameter("@mobile_num", mobileenumber5));
                extraplanamount.Parameters.Add(new SqlParameter("@plan_name", planname5));

                // Execute the function and retrieve the result
                object result = extraplanamount.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int extraAmount))
                {
                    // Display the function output to the user
                    resultLabel.Text = $"Extra plan amount: {extraAmount}";
                    resultLabel.Visible = true;
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                errorLabel4.Text = $"An error occurred: {ex.Message}";
                errorLabel4.Visible = true;
                resultLabel.Visible = false;
            }
            finally
            {
                // Close the database connection
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        protected void enter6(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["WebApplication2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            String mobileenumber6 = mobno6.Text.Trim();

            try
            {

                if (!System.Text.RegularExpressions.Regex.IsMatch(mobileenumber6, @"^\d{11}$"))
                {

                    errorLabel6.Text = "Invalid mobile number. Please enter exactly 11 digits.";
                    errorLabel6.Visible = true;
                    paymentGridView.Visible = false; // Hide the table if present
                    return;
                }

                // Clear any previous error messages
                errorLabel6.Visible = false;

                //  call the stored procedure w send el input no.
                SqlCommand top10 = new SqlCommand("Top_Successful_Payments", conn);
                top10.CommandType = System.Data.CommandType.StoredProcedure;
                top10.Parameters.Add(new SqlParameter("@mobile_num", mobileenumber6));


                conn.Open();

                // Execute the stored procedure and bind the results to a DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(top10);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Check if there are any rows
                if (dt.Rows.Count > 0)
                {
                    // Bind the DataTable to the GridView and display it
                    paymentGridView.DataSource = dt;
                    paymentGridView.DataBind();
                    paymentGridView.Visible = true;
                }
                else
                {
                    // Display a message if no data is found
                    errorLabel6.Text = "No successful payments found for the given mobile number,enter other number";
                    errorLabel6.Visible = true;
                    paymentGridView.Visible = false; // Hide the table
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                errorLabel6.Text = $"An error occurred: {ex.Message}";
                errorLabel6.Visible = true;
                paymentGridView.Visible = false;
            }
            finally
            {
                // Close the database connection
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void MainPage(object sender, EventArgs e)
        {

            Response.Redirect("MainPage.aspx");

        }

        public void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("CustomerDashBoard.aspx");

        }

    }
}