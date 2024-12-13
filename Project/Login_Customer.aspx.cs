using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database_Milestone3
{
    public partial class Login_Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string mobileNum = UserName.Text;
            string password = Password.Text;
            bool isvalid = ValidateLogin(mobileNum, password);
            if (isvalid)
            {
                Response.Redirect("CustomerDashboard.aspx");
            }
            else
            {
                Label1.Text = "Invalid mobile number or password. Please rey again.";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }

        private bool ValidateLogin(string mobileNum, string password)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.AccountLoginValidation(@mobile_num, @pass)", conn))
                {
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNum);
                    cmd.Parameters.AddWithValue("@pass", password);

                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        return false;
                    }
                    return result.Equals(true);
                }
            }
        }

        public void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("LoginAs.aspx");

        }
    }
}