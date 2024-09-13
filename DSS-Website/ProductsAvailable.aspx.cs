using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace DSS_Website
{
    public partial class ProductsAvailable : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        dynamic products = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Delete"] != null && Request.QueryString["ProductID"] != null)
            {
                DeleteProduct(Request.QueryString["ProductID"].ToString());
            }
            if(Request.QueryString["Disable"] != null && Request.QueryString["ProductID"] != null)
            {
                DisableProduct(Request.QueryString["ProductID"].ToString());
            }
            if(Request.QueryString["Enable"] != null && Request.QueryString["ProductID"] != null)
            {
                EnableProduct(Request.QueryString["ProductID"].ToString());
            }
            products = service.GetAllProducts();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string display = "";
            foreach (SVCProduct item in products)
            {
                display += "<tr>";
                display += $"<td> {item.ProductName} </td>";
                display += $"<td> {string.Format("{0:C}", item.Price)} </td>";
                display += $"<td> {textInfo.ToTitleCase(item.Category)} </td>";

                if(item.QuantityBought != null)
                    display += $"<td> {item.QuantityBought} </td>";
                else
                    display += "<td> 0 </td>";

                display += $"<td> {item.Quantity} </td>";
                if (item.IsActive > 0)
                    display += "<td> Yes </td>";
                else
                    display += "<td> No </td>";
                display += "<td>";
                display += $"<a href='EditProduct?ProductID={item.ProductID}' class='edit'>Edit</a>";
                display += $"<a href='ProductsAvailable?Disable=true&ProductID={item.ProductID}' class='delete'>Disable</a>";
                display += $"<a href='ProductsAvailable?Enable=true&ProductID={item.ProductID}' class='disable'>Enable</a>";
                display += $"<a href='ProductsAvailable?Delete=true&ProductID={item.ProductID}' class='delete'>Delete</a>";
                display += "</td>";
                display += "</tr>";
            }
            productsAvail.InnerHtml = display;
        }

        private void DeleteProduct(string productID)
        {
            service.RemoveProduct(productID);
        }

        private void DisableProduct(string productID)
        {
            service.DisableProduct(productID);
        }

        private void EnableProduct(string productID)
        {
            service.EnableProduct(productID);
        }
    }
}