using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] != null)
            {
                SVCUser user = (SVCUser)Session["User"];
                names.Value = $"{user.FirstName} {user.LastName}";
                email.Value = $"{user.Email}";
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if(names.Value != "" && email.Value != "" && subject.Value != "" && message.Value != "")
            {
                ClientMessage query = new ClientMessage(names.Value, email.Value, subject.Value, message.Value);
                query.SendQuery();
                names.Value = "";
                email.Value = "";
                subject.Value = "";
                message.Value = "";
                MessageToClient("Message sent...\nWe'll reply to your query ASAP");
            }
            else
            {
                MessageToClient("Missing information in the text fields");
            }
        }
        private void MessageToClient(string message)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
        }
    }
}