using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database_Milestone3
{ //firstPage
    //yea
    public partial class LoginAs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Customer(object sender, EventArgs e)
        {
            Response.Redirect("Login_Customer.aspx");
        }
        protected void Login_Admin(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}