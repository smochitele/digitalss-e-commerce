using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Customers : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        dynamic customers = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Disable"] != null && Request.QueryString["UserID"] != null)
            {
                DisableUser(Request.QueryString["UserID"].ToString());
            }
            if(Request.QueryString["Enable"] != null && Request.QueryString["UserID"] != null)
            {
                EnableUser(Request.QueryString["UserID"].ToString());
            }

            customers = service.GetAllUsers();
            DisplayCustomers();
        }
        private void DisplayCustomers()
        {
            string display = "";
            contactAll.HRef = "mailto:";
            foreach (SVCUser item in customers)
            {
                contactAll.HRef += $"{item.Email},";
                display += "<tr>";
                display += $"<td> {item.FirstName} </td>";
                display += $"<td> {item.LastName} </td>";
                display += $"<td> {item.Email} </td>";
                if (item.IsActive > 0)
                {
                    display += "<td> Yes </td>";
                }  
                else
                {
                    display += "<td> No </td>";
                } 
                if (item.NumberOfTransactions != null)
                {
                    display += $"<td> {item.NumberOfTransactions} </td>";
                }
                else
                {
                    display += "<td> 0 </td>";
                }
                display += "<td>";
                display += $"<a href = 'Customers?Disable=true&UserID={item.UserID}' class='delete'>Disable</a>";
                display += $"<a href = 'Customers?Enable=true&UserID={item.UserID}' class='disable'>Enable</a>";
                display += $"<a href = 'mailto:{item.Email}' class='edit'>Contact</a>";
                display += "</td>";
                display += "</tr>";
            }
            clients.InnerHtml = display;
        }

        private void DisableUser(string userID)
        {
            service.DisableUser(userID);
        }

        private void EnableUser(string userID)
        {
            service.EnableUser(userID);
        }
    }
}