using DSS_Website.DSS_Service;
using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DSS_Website
{
    public partial class Invoice : System.Web.UI.Page
    {
        ShoppingCart cart = null;
        SVCUser user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["Cart"] != null && Session["User"] != null)
                {
                    cart = (ShoppingCart)Session["Cart"];
                    user = (SVCUser)Session["User"];
                    DisplayItems();
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        private void DisplayItems()
        {
            string display = "";
            foreach (SVCProduct item in cart.GetProducts())
            {
                display += "<tr>";
                display += $"<td class='remove'>{item.ProductID}</td>";
                display += "<td class='product-image'>";
                display += $"<img src = '../{item.Picture}' alt=''>";
                display += "</td>";
                display += "<td class='product text-center'>";
                display += $"<h4>{item.ProductName}</h4>";
                display += $"<p>{item.Description}</p>";
                display += "</td>";
                display += "<td class='price text-center'>";
                display += $"{string.Format("{0:C}", item.Price)}";
                display += "</td>";
                display += "<td class='price-input text-center'>";
                display += $"<input type='number' name='' id='' min='1' max=5' value='{item.QuantityBought}' readonly>";
                display += "</td>";
                display += "<td class='total text-center'>";
                display += $"{string.Format("{0:C}", item.Price * item.QuantityBought)}";
                display += "</td>";
                display += "</tr>";
            }
            items.InnerHtml = display;
            total.InnerText = string.Format("{0:C}", Checkout.total);
            points.InnerText = cart.PointsGained.ToString();
            tax.InnerText = string.Format("{0:C}", cart.CartTotal - cart.SubTotal);
            PrintInvoice();
            CleanTransaction();
        }

        private void PrintInvoice()
        {
            string fileName = $"DSS_Invoice_{user.FirstName}_{user.LastName}";
            Document document = new Document(PageSize.A4, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{fileName}.pdf", FileMode.Create));
            document.Open();
            string invoice = "DigitalSS Customer Invoice\n\n";
            invoice += $"Date: {DateTime.Now}\n\n";
            invoice += $"Client Name(s): {user.FirstName} {user.LastName}\n\n";
            invoice += $"Client ID: {user.UserID}\n\n\n";
            invoice += "Items Bought:\n\n";
      
            foreach (var item in cart.GetProducts())
            {
                invoice += $"Product Name: {item.ProductName}\n";
                invoice += $"Quantity Bought: {item.QuantityBought}\n";
                invoice += $"Price: {string.Format("{0:C}", item.Price * item.QuantityBought)}\n\n\n";
            }

            invoice += $"Estimated Preparation Time: {cart.PrepationTime} minute(s)\n\n";
            invoice += $"Sub Total: {string.Format("{0:C}",cart.SubTotal)}\n\n";
            invoice += $"Total: {string.Format("{0:C}", Checkout.total)}\n\n";
            invoice += $"VAT Charged: {string.Format("{0:C}",cart.CartTotal - cart.SubTotal)}";
            Paragraph paragraph = new Paragraph(invoice);
            document.Add(paragraph);
            document.Close();
        }

        private void CleanTransaction()
        {
            cart.GetProducts().Clear();
            cart = null;
            Session["Cart"] = null;
        }
    }
}