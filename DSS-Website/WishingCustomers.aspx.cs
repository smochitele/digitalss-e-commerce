using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class WishingCustomers : System.Web.UI.Page
    {
        dynamic users = null;
        SVCProduct product = null;
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["ProdID"] == null)
            {
                Response.Redirect("Reports.aspx");
            }
            else
            {
                product = service.GetProduct(Request.QueryString["ProdID"].ToString());
                users = service.GetProspectiveBuyers(Request.QueryString["ProdID"].ToString());
                wishedItem.InnerText = product.ProductName;
                DisplayUsers();
                AllocateMailRecipients();
            }
        }

        private void DisplayUsers()
        {
            string display = "";
            foreach (SVCUser user in users)
            {
                display += "<tr>";
                display += $"<td>{user.FirstName} {user.LastName}</td>";
                display += $"<td>{user.Email}</td>";
                display += $"<td><a href='mailto:{user.Email}' class='edit'>Contact Client</a></td>";
                display += "</tr>";
            }
            wishingCustomers.InnerHtml = display;
        }

        private void AllocateMailRecipients()
        {
            contactAll.HRef = "mailto:";
            foreach (SVCUser user in users)
            {
                contactAll.HRef += $"{user.Email},";
            }
        }
    }
}