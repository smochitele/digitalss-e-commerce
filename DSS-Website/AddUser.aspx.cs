using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class AddUser : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string userType = "";
            switch(type.Value.ToString())
            {
                case "1":
                    userType = "client";
                    break;
                case "2":
                    userType = "employee";
                    break;
                case "3":
                    userType = "admin";
                    break;
                default:
                    userType = "client";
                    break;
            }
            SVCUser user = new SVCUser()
            {
                FirstName = name.Value,
                LastName = lastname.Value,
                UserType = userType,
                Email = email.Value,
                IsActive = 1,
                Password = password.Value,
                Points = 0,
                Credit = 100,
                NumberOfTransactions = 0
            };
            service.AddUser(user);
            Response.Redirect("Customers.aspx");
        }
    }
}