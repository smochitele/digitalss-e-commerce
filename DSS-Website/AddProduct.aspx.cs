using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class AddProduct : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(NoMissingFields())
            {
                string category;
                switch(type.Value.ToString())
                {
                    case "1":
                        category = "pizza";
                        break;
                    case "2":
                        category = "burger";
                        break;
                    case "3":
                        category = "drink";
                        break;
                    case "4":
                        category = "snack";
                        break;
                    case "5":
                        category = "other";
                        break;
                    default:
                        category = "other";
                        break;
                }
                SVCProduct product = new SVCProduct()
                {
                    ProductName = name.Value,
                    Category = category,
                    Description = description.Value,
                    Price = Convert.ToDecimal(price.Value),
                    Discount = Convert.ToDouble(discount.Value),
                    Quantity = Convert.ToInt32(quantity.Value),
                    QuantityBought = 0,
                    PrepationTime = Convert.ToInt32(preparation.Value),
                    Picture = $"products/{image.Value}",
                    Rating = 0,
                    Healthiness = Convert.ToInt32(healthiness.Value),
                    IsActive = 1,
                    Tags = tags.Value
                };
                if (service.AddProduct(product) > 0)
                {
                    Response.Redirect("ProductsAvailable.aspx");
                }
                else
                {
                    MessageToClient("Unable to add product...");
                }
            }
            else
            {
                MessageToClient("Missing Product Details...");
            }
        }

        private bool NoMissingFields()
        {
            if(!(name.Value.Equals("") || type.Value.Equals("") || description.Value.Equals("") || 
                price.Value.Equals("") || discount.Value.Equals("") || quantity.Value.Equals("") || preparation.Value.Equals("") ||
                healthiness.Value.Equals("") || tags.Value.Equals("")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MessageToClient(string message)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + message + "');</script>");
        }
    }
}