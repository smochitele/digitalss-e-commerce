using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Checkout : System.Web.UI.Page
    {
        ShoppingCart cart = null;
        SVCUser user = null;
        public static decimal total = 0;
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            totalHead.Attributes["Style"] = "color:white";
            if(!IsPostBack)
            {
                cart = (ShoppingCart)Session["Cart"];
                if(cart.GetProducts().Count <= 0)
                {
                    Response.Redirect("Catalog.aspx");
                }
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx?From=Checkout.aspx");
                }
                else
                {
                    user = (SVCUser)Session["User"];
                    firstname.Value = user.FirstName;
                    lastname.Value = user.LastName;
                    email.Value = user.Email;
                    name.Value = $"{user.FirstName} {user.LastName}";
                    DisplayInvoice();
                }
                if(Request.QueryString["Transact"] != null)
                {
                    Transact();
                }
            }
        }
        private void DisplayInvoice()
        {
            string display = "";
            total = cart.CartTotal;
            foreach(SVCProduct product in cart.GetProducts())
            {
                display += "<tr>";
                display += "<td>";
                display += $"{product.ProductName} x {product.QuantityBought}";
                display += "</td>";
                display += $"<td>{string.Format("{0:C}", product.Price * product.QuantityBought)}</td>";
                display += "</tr>";
            }                                      
            tableProducts.InnerHtml = display;
            display = "";
            display += "<tr>";
            display += "<td style='padding-left: 30px; font-weight: 800;' > Sub Total </td>";
            display += $"<td> {string.Format("{0:C}", cart.SubTotal)} </td >";
            display += "</tr>";
            display += "<tr>";
            display += "<td style='padding-left: 30px; font-weight: 800;' > VAT Charged </td>";
            display += $"<td> {string.Format("{0:C}", cart.CartTotal - cart.SubTotal)} </td>";
            display += "</tr>";
            display += "<tr>";
            if(user.Points > 10)
            {
                if(cart.CartTotal > user.Credit)
                {
                    if ((total - (user.Credit + user.Points)) > 0)
                    {
                        total -= (decimal)user.Points;
                    }
                }
                else
                {
                    if((total - user.Points) > 0)
                    {
                        total -= (decimal)user.Points;
                    }
                }
            }
            if(cart.CartTotal > user.Credit)
            {
                display += "<td style = 'padding-left: 30px; font-weight: 800;' > Total </td>";
                total = cart.CartTotal - (decimal)user.Credit;
                display += $"<td> {string.Format("{0:C}", total)} </td>";
                display += "<tr>";
                display += "<td style = 'padding-left: 30px; font-weight: 800;' > Discount </td>";
                display += $"<td> {string.Format("{0:C}", user.Credit)} </td>";
                display += "</tr>";
                user.Credit = 0;
            }
            else
            {
                total = cart.CartTotal;
                display += "<td style = 'padding-left: 30px; font-weight: 800;' > Total </td>";
                display += $"<td> {string.Format("{0:C}", total)} </td>";
                display += "<tr>";
            }
            display += "</tr>";
            display += "<tr>";
            display += "<td style='padding-left: 30px; font-weight: 800;' > Points Gained </td>";
            display += $"<td> {cart.PointsGained} </td>";
            display += "</tr>";
            display += "<tr>";
            display += "<td style='padding-left: 30px; font-weight: 800;' > Estimated Preparation Time </td>";
            display += $"<td> {cart.PrepationTime} minute(s)</td>";
            display += "</tr>";
            user.Points = cart.PointsGained;
            costs.InnerHtml = display;
            if(total < 0)
            {
                decimal creditToUser = (-1 * total);
                user.Credit = creditToUser;
            }
        }

        private void Transact()
        {
            string delivery;
            string paymentMethod;
            foreach (SVCProduct item in cart.GetProducts())
            {
                if(item.QuantityBought > service.GetProduct((item.ProductID).ToString()).Quantity)
                {
                    MessageToClient($"Could not process transaction due to insufficient stock..\nDecrese quantity of {item.ProductName}");
                    return;
                }
            }
            if(!type.Value.Equals("Choose") && !type.Value.Equals("") && !location.Value.Equals(""))
            {
                delivery = $"Delivery. Loc: {type.Value} {location.Value}";
            }
            else
            {
                delivery = "Collection Order";
            }
            if(chkPaymentMethodCash.Checked == true)
            {
                paymentMethod = "EFT on delivery";
            }
            else
            {
                paymentMethod = "Cash";
            }

            if(service.Transact(user, Products(cart.GetProducts()), (float)(total), paymentMethod, delivery) > 0)
            {
                MessageToClient($"Thank you for shopping with us\nEnjoy your day {user.FirstName} {user.LastName}");
                Response.Redirect("Invoice.aspx");
            }
            else
            {
                MessageToClient("Sorry, we couldn't process this transaction");
            }
        }

        private void MessageToClient(string message)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
        }

        private SVCProduct[] Products(List<SVCProduct> products)
        {
            SVCProduct[] items = new SVCProduct[products.Count];
            for(int i = 0; i < items.Length; i++)
            {
                items[i] = products[i];
            }
            return items;
        }
    }
}