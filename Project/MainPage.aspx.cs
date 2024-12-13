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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private readonly string connStr = WebConfigurationManager.ConnectionStrings["Milestone2DB_24"].ConnectionString;
        protected void AllShops(object sender, EventArgs e)
        {
            Response.Redirect("Shops.aspx");

        }
        protected void SubscribedPlans(object sender, EventArgs e)
        {
            Response.Redirect("SubscribedPlans.aspx");

        }
        protected void RenewSub(object sender, EventArgs e)
        {
            Response.Redirect("Renew.aspx");
        }
        protected void GetCB(object sender, EventArgs e)
        {
            Response.Redirect("Cashback.aspx");
        }
        protected void RB(object sender, EventArgs e)
        {
            Response.Redirect("Recharge.aspx");
        }
        protected void RV(object sender, EventArgs e)
        {
            Response.Redirect("Voucher.aspx");
        }
        public void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebForm2.aspx");

        }

    }
}

