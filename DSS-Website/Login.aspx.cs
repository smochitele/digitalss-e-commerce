using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Login : System.Web.UI.Page
    {
        DSS_Service.DSSWebServiceClient service = new DSS_Service.DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DSS_Service.SVCUser user = service.GetUser(username.Value, password.Value);
            if(user == null)
            {
                MessageToClient("Invalid username or password");
                lblPassword.Attributes["Style"] = "color:red;";
                lblUsername.Attributes["Style"] = "color:red;";
            }
            else
            {
                Session["User"] = user;
                Session["Password"] = password.Value;
                Session["Email"] = user.Email;
                if(Request.QueryString["From"] != null)
                {
                    Response.Redirect(Request.QueryString["From"]);
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }

        }

        private void MessageToClient(string message)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
        }
    }
}