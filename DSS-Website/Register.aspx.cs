using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Register : System.Web.UI.Page
    {
        private const int SUCCESS = 1;
        private const int FAIL = -1;
        DSS_Service.DSSWebServiceClient serivce = new DSS_Service.DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if(firstname.Value.Equals("") || lastname.Value.Equals("") || email.Value.Equals("") || password.Value.Equals("") || password_1.Value.Equals(""))
            {
                MessageToClient("Missing information");
                if (firstname.Value.Equals(""))
                    ChangeLabelColour(lblFirstName, "red");
                if (lastname.Value.Equals(""))
                    ChangeLabelColour(lblLastName, "red");
                if (email.Value.Equals(""))
                    ChangeLabelColour(lblEmail, "red");
                if (password.Value.Equals(""))
                    ChangeLabelColour(lblPassword, "red");
                if (password_1.Value.Equals(""))
                    ChangeLabelColour(lblConfirmPass, "red");
            }
            else
            {
                if(password.Value.Equals(password_1.Value))
                {
                    SVCUser user = new SVCUser()
                    {
                        FirstName = firstname.Value,
                        LastName = lastname.Value,
                        UserType = "client",
                        Email = email.Value,
                        IsActive = 1,
                        Password = password.Value,
                        Points = 0,
                        Credit = 100,
                        NumberOfTransactions = 0,
                    };
                    if (serivce.AddUser(user).Equals(SUCCESS))
                    {
                        MessageToClient("Welcome " + firstname.Value + " " + lastname.Value);
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        MessageToClient("An error occured while registering");
                    }
                }
                else
                {
                    MessageToClient("Passwords do not match");
                    ChangeLabelColour(lblPassword, "red");
                    ChangeLabelColour(lblConfirmPass, "red");
                }
            }
        }

        private void ChangeLabelColour(HtmlGenericControl lbl, string colour)
        {
            lbl.Attributes["Style"] = $"color:{colour}";
        }

        private void MessageToClient(string message)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
        }
    }
}