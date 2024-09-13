using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class EditProduct : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        SVCProduct product = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductID"] != null)
                product = service.GetProduct(Request.QueryString["ProductID"].ToString());
            else
                Response.Redirect("ProductsAvailable.aspx");
            if (!IsPostBack)
            {
                if (Request.QueryString["ProductID"] == null)
                {
                    Response.Redirect("ProductsAvailable.aspx");
                }
                else
                {
                    name.Value = product.ProductName;
                    price.Value = product.Price.ToString();
                    quantity.Value = product.Quantity.ToString();
                    discount.Value = product.Discount.ToString();
                    healthiness.Value = product.Healthiness.ToString();
                    tags.Value = product.Tags;
                    preparation.Value = product.PrepationTime.ToString();
                    switch (product.Category)
                    {
                        case "pizza":
                            type.Value = "1";
                            break;
                        case "burger":
                            type.Value = "2";
                            break;
                        case "drink":
                            type.Value = "3";
                            break;
                        case "snack":
                            type.Value = "4";
                            break;
                        case "other":
                            type.Value = "5";
                            break;
                        default:
                            type.Value = "0";
                            break;
                    }
                    description.Value = product.Description;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(NoMissingFields())
            {
                string category;
                switch (type.Value.ToString())
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
                product.ProductName = name.Value;
                product.Category = category;
                product.Description = description.Value;
                product.Price = Convert.ToDecimal(price.Value);
                product.Discount = Convert.ToDouble(discount.Value);
                product.Quantity = Convert.ToInt32(quantity.Value);
                product.PrepationTime = Convert.ToInt32(preparation.Value);
                product.Healthiness = Convert.ToInt32(healthiness.Value);
                product.Tags = tags.Value;
                service.EditProduct(product);
                Response.Redirect("ProductsAvailable.aspx");
            }
            else
            {
                MessageToClient("Missing Product information");
            }
        }

        private bool NoMissingFields()
        {
            if (!(name.Value.Equals("") || type.Value.Equals("") || description.Value.Equals("") ||
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