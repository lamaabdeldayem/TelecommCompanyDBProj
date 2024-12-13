using System;
using System.Web.UI;

namespace Database_Milestone3
{
    public partial class Login : Page
    {
        // ana el hatahom so Hardcoded admin credentials
        private const string AdminUsername = "admin123";
        private const string AdminPassword = "password123";

        protected void Login_Click(object sender, EventArgs e)
        {
            string username = UserNamee.Text; // bet retrieves the text input for the password from the form
            string password = Passwordd.Text;

            if (username == AdminUsername && password == AdminPassword)
            {
                // Login successful
                Response.Redirect("AdminDashboard.aspx");
                //Label1.Text = "Correct credentials!";
            }
            else
            {
               
                Label11.Text = "Invalid username or password. Please try again.";
            }





        }

        public void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("LoginAs.aspx");

        }

    }
}
