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
    public partial class RootLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SVCUser user = (SVCUser)Session["User"];
            ShoppingCart cart = null;
            if(Session["Cart"] == null)
            {
                Session["Cart"] = new ShoppingCart();
            }
            else
            {
                cart = (ShoppingCart)Session["Cart"];
                items.InnerHtml = DisplayCart();
                cartTotal.InnerText = "Cart Total: " + string.Format("{0:C}", cart.CartTotal);
                
            }
            if (Session["User"] == null)
            {
                management.Visible = false;
                lblLogin.InnerText = "Login";
                lblLogin.HRef = "Login.aspx";
            }
            else
            {
                lblLogin.InnerText = $"{user.FirstName} {user.LastName}";
                lblLogin.HRef = "Profile.aspx";
                if (user.UserType.Equals("client"))
                    management.Visible = false;
                else
                    management.Visible = true;
            }
        }
        public string DisplayCart()
        {
            string display = "";
            ShoppingCart cartItems = (ShoppingCart)HttpContext.Current.Session["Cart"];
            foreach (SVCProduct item in cartItems.GetProducts())
            {
                display += "<div class='container-fluid'>";
                display += "<div class='row'>";
                display += "<div class='col-md-6' style='padding: 0 0 0 30px;'>";
                display += $"<a href = 'AboutProduct.aspx?prodID={item.ProductID}'><img src = '../{item.Picture}'></a>";
                display += "</div>";
                display += "<div class='col-md-6' style='padding: 0;'>";
                display += $"<p>{item.ProductName}</p>";
                display += $"<p>{string.Format("{0:C}", item.Price)}</p>";
                display += "<div>";
                display += $"<input type = 'number' name='items' id='{item.ProductID}' value='{item.QuantityBought}' min='1' max='5'>";
                display += $"<button onclick='updateQuanity({item.ProductID})'; class='btnUpdate'>Update Quantity</button>";
                display += $"<button onclick='deleteItem({item.ProductID});'><i class='fas fa-trash-alt'></i></button>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "<hr>";
            }
            return display;
        }
    }
}