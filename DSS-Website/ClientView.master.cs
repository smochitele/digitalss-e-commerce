using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class ClientView : System.Web.UI.MasterPage
    {
        SVCUser user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (SVCUser)Session["User"];
            if (Session["User"] == null || !user.UserType.Equals("admin"))
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}