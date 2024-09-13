using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Profile : System.Web.UI.Page
    {
        DSSWebServiceClient service = new DSSWebServiceClient();
        SVCUser user;
        dynamic orders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("Home.aspx");
            else
            {
                user = (SVCUser)Session["User"];
                if(!IsValidUser(user))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    user = service.GetUser(user.Email, Session["Password"].ToString());
                    if(!IsValidUser(user))
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        orders = service.GetUserOrders(user.UserID.ToString());
                        displayFirstName.InnerText = $"{user.FirstName} {user.LastName}";
                        displayLastName.InnerText = user.Email;
                        displayPoints.InnerText = user.Points.ToString();
                        displayCredit.InnerText = string.Format("{0:C}", user.Credit);
                        displayTransactions.InnerText = user.NumberOfTransactions.ToString();
                        firstname.Value = user.FirstName;
                        lastname.Value = user.LastName;
                        DisplayTransactionHistory();
                        DisplayWishlist();
                    }
                }
            }
            if (Request.QueryString["SignOut"] != null)
            {
                Session["User"] = null;
                Session["Password"] = null;
                if (Session["Cart"] != null)
                {
                    ShoppingCart cart = (ShoppingCart)Session["Cart"];
                    cart.GetProducts().Clear();
                    Session["Cart"] = null;
                }
                Response.Redirect("Home.aspx");
            }
        }
        private bool IsValidUser(SVCUser user)
        {
            if (user != null)
                return true;
            else
                return false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if(password1.Value.Equals(password2.Value))
            {
                if(!password1.Value.Equals("") && !password2.Value.Equals(""))
                {
                    if (service.ChangeUserPassword(user.Email, Session["Password"].ToString(), password1.Value) > 0)
                    {
                        MessageToClient("Successfully updated profile...");
                        Session["Password"] = password2.Value;
                        Session["User"] = service.GetUser(Session["Email"].ToString(), Session["Password"].ToString());
                    }
                    else
                    {
                        MessageToClient("Could not update profile...");
                    }
                }
                else
                {
                    MessageToClient("Missing text fields...");
                }
            }
            else
            {
                MessageToClient("Passwords do not match...");
            }
        }

        private void DisplayTransactionHistory()
        {
            string display = "";
            foreach (SVCOrder item in orders)
            {
                display += "<tr>";
                display += $"<td>{item.OrderID}</td>";
                display += $"<td>{Convert.ToDateTime(item.Date).ToShortDateString()}</td>";
                display += "<td>";
                display += "<ul>";
                dynamic products = service.GetOrderItems(item.OrderID.ToString());
                foreach (SVCProduct product in products)
                {
                    display += $"<li>{product.ProductName}</li>";
                }
                display += "</ul>";
                display += "</td>";
                display += $"<td>{string.Format("{0:C}", item.AmountDue)}</td>";
                display += "</tr>";
            }
            transHistory.InnerHtml = display;
        }

        private void MessageToClient(string message)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
        }

        private void DisplayWishlist()
        {
            dynamic wishlist = service.GetUserWishlist(user.UserID.ToString());
            string display = "";
            int counter = 0;
            if(wishlist != null)
            {
                foreach (SVCProduct item in wishlist)
                {
                    counter++;
                    display += "<tr>";
                    display += $"<td>{counter}</td>";
                    display += $"<td>{item.ProductName}</td>";
                    display += $"<td>{string.Format("{0:C}", item.Price)}</td>";
                    display += "</tr>";
                }
                wishItems.InnerHtml = display; 
            }
        }
    }
}