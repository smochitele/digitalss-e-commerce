using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Invoices : System.Web.UI.Page
    {
        dynamic invoices = null;
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayInvoices("year");
            }
            else
            {
                invoicesDrop_SelectedIndexChanged(sender, e);
            }
                
        }
        
        private void DisplayInvoices(string timeframe)
        {
            if(timeframe.Equals("year"))
            {
                invoices = service.GetFilteredOrders("year");
            }
            if (timeframe.Equals("today"))
            {
                invoices = service.GetFilteredOrders("today");
            }
            if (timeframe.Equals("week"))
            {
                invoices = service.GetFilteredOrders("week");
            }
            if (timeframe.Equals("month"))
            {
                invoices = service.GetFilteredOrders("month");
            }

            string invoiceDetail = "";
            foreach (SVCOrder order in invoices)
            {
                invoiceDetail += "<tr>";
                invoiceDetail += $"<td>{order.OrderID}</td>";
                invoiceDetail += $"<td>{service.GetUserByID(order.UserID.ToString()).FirstName} {service.GetUserByID(order.UserID.ToString()).LastName}</td>";
                invoiceDetail += $"<td>{Convert.ToDateTime(order.Date).ToShortDateString()}</td>";
                invoiceDetail += $"<td>{order.PaymentMethod}</td>";
                invoiceDetail += $"<td>{order.Delivery}</td>";
                invoiceDetail += $"<td>{string.Format("{0:C}", order.AmountDue)}</td>";
                invoiceDetail += $"<td>";
                invoiceDetail += $"<p onclick='moreLess({order.OrderID})' id='myBtn'>show/hide items</p>";
                invoiceDetail += $"<span id={order.OrderID} style='display: none;'>";
                int num = service.GetOrderItems(order.OrderID.ToString()).Length;
                foreach (SVCProduct products in service.GetOrderItems(order.OrderID.ToString()))
                {
                    invoiceDetail += $"<p id='listitems'>{products.ProductName}</p>";

                }
                invoiceDetail += $"</span>";
                invoiceDetail += "</td>";
                invoiceDetail += "</tr>";
            }
            items.InnerHtml = invoiceDetail;
        }

        protected void invoicesDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (invoicesDrop.SelectedValue.Equals("1"))
                DisplayInvoices("today");
            else if (invoicesDrop.SelectedValue.Equals("2"))
                DisplayInvoices("week");
            else if (invoicesDrop.SelectedValue.Equals("3"))
                DisplayInvoices("month");
            else if (invoicesDrop.SelectedValue.Equals("4"))
                DisplayInvoices("year");
            else
                DisplayInvoices("year");
        }
    }
}