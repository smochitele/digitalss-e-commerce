using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Catalog : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        private static string currentCategory = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["Products"] == null)
                {
                    Session["Products"] = service.GetAllProducts();
                }
                if (currentCategory == "")
                    DisplayCategory("burger");
                else if (currentCategory == "all")
                    ViewAllProducts();
                else
                    DisplayCategory(currentCategory);
                if(Request.QueryString["Del"] != null)
                {
                    ShoppingCart cart = (ShoppingCart)Session["Cart"];
                    cart.RemoveFromCart(Request.QueryString["Del"]);
                }
                if(Request.QueryString["prodID"] != null && Request.QueryString["prodQty"] != null)
                {
                    ShoppingCart cart = (ShoppingCart)Session["Cart"];
                    cart.AlterQuantity(Request.QueryString["prodID"], Convert.ToInt32(Request.QueryString["prodQty"]));
                }
            }
            else
            {
                ourdropdown_SelectedIndexChanged(sender, e);
               //Response.Redirect("Catalog.aspx");
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            currentCategory = "all";
            ViewAllProducts();
        }

        protected void btnSnack_Click(object sender, EventArgs e)
        {
            currentCategory = "snack";
            DisplayCategory("snack");
        }

        protected void btnDrinks_Click(object sender, EventArgs e)
        {
            currentCategory = "drink";
            DisplayCategory("drink");
        }

        protected void btnPizzas_Click(object sender, EventArgs e)
        { 
            currentCategory = "pizza";
            DisplayCategory("pizza");
        }

        protected void btnBurgers_Click(object sender, EventArgs e)
        {
            currentCategory = "burger";
            DisplayCategory("burger");
        }

        protected void btnOthers_Click(object sender, EventArgs e)
        {
            currentCategory = "other";
            DisplayCategory("other");
        }
        private void DisplayCategory(string categotyType)
        {
            string display = "";
            List<SVCProduct> customProducts = new List<SVCProduct>();
            dynamic products = Session["Products"];
            foreach (SVCProduct product in products)
            {
                if (product.Category.Equals(categotyType))
                    customProducts.Add(product);
            }
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string heading = textInfo.ToTitleCase(categotyType);
            title.InnerHtml = $"{heading + 's'} <img src='../images/{categotyType}.svg'>";
            foreach (SVCProduct product in customProducts)
            {
                if(product.IsActive > 0)
                {
                    display += $"<div class='col-md-3'>";
                    display += "<div class='our-card'>";
                    if (product.Picture == null || product.Picture.Equals(""))
                    {
                        display += $"<a href='AboutProduct.aspx?prodID={product.ProductID}&category={product.Category}' ><img src = 'https://image.flaticon.com/icons/svg/1046/1046772.svg' alt=''></a>";
                    }
                    else
                    {
                        display += $"<a href='AboutProduct.aspx?prodID={product.ProductID}&category={product.Category}'><img src = '../{product.Picture}'alt=''></a>";
                    }
                    display += $"<h5>{product.ProductName}</h5>";
                    display += $"<p id='{product.ProductID}'><img src='data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAkFBMVEX/////pQD/owD/oAD/nwD/pgD/+Oz///v//Pb///3/y4H//PT/qAD/9OP/8t3/6cr/tD7/9uj/rB7/79f/2aP/sTP/v2H/uVD/7dL/5sL/ryn/1pv/x3j/0Y7/2KH/3Kz/wG3/xGr/yID/uln/tEn/sCb/4bb/vl3/37L/ulP/7c7/6cX/t0L/5sj/vWT/z5ThUsp1AAAIJklEQVR4nO2diXaqOhSG607AEQecB6rWHm1te/r+b3ejnt6KgiQkO5uw+F6A/OsnIWQPeXqqqKioqKioqKhQZHDcHwfUg8CjMQo5Z5yHowb1UHAYjhnUTgAfd6kHg0EAF31njRBQDweBxa9AIXFBPRzzLFntGrakHpBpGiHEFEJYttXmOW6hMPGZekhmubWwfCaObi0UJo6oB2WUzq2FwsQO9aBMsr63UJi4ph6WOZoJFp5MbFIPzBgJs7BcJtYXSRaeNjZ16qEZInEWlsnENAvLY+IbTxFYq/E36sEZIXEh/VlOqQdngnW6hSUxMXUWXmYi9fD02actpBfYnnqAujT7jywUJvZd39jsH83C80x03cTxYwuFiWPqIeoxz7JQmDinHqQWf7IsdH05zVhILzi9nGYspP9M7FMPMz9zGQuFie7OxE8ZC4WJn9QDzYvEQnqB96iHmhOpWXg20dGZ+CFrobMmSlvoqok9uYX0AnPRxKm8hcLEd+rhqqNkoZMmKlnoookz+YX0Ap9RD1kRye3MlYlT6iGrcVS10DkT31UtFCbuqAetwkxdoJDokomHXAon1MOWZ6b2LfyBDakHLk0uC10ysau+kF7griT05bRQmHigHrocw3yz8ARzw8RtXguFiVvqwcvQzS9QSHTBRA0L3TCxm38WniUWP3lYy0IXTAzyfgt/4EUvVtC0UJi4oZbwmEBXYOFn4sqAwhW1iEcYsLDgJhqwsNgm+iYECok+tZAU2kfthfSfwu2xTS0mRtsfrqPNGDg3I/BU+sVr4020HvrESuvBcB9tpiFwxsCUuh+RAIxxCKebaD8M7Kehtmfz5ba/8NhJmmFt90KZt+hvl/OZDUObze7+eTWusYs0TG0JQlmtv3red5somXB1P5gvX3Yh49iuZQrlLNy9LOeBb+rVbQ+/Rqtdv4P+QspzcbTT361GX0OdVzf4WLemixrYfSGlgbNQqC2mrbcPpW1Qs+H3Rt+HU1FyMaXFuQjlPDx8j3p+I2OODobr1uazI7QVX9ktJ6Gcdz43rfUw7Rdz9Oo54dojLo56r0mVf6dacpe1XSNUju9iIMPSyLsAcCOx7ZVLoJDoxb8jLb0zwCLCWtcC/VrZLDyZeP2b+VU+C4WJX1cKl6VUeN22oVW+l1S8ptcTMaVQ121iBf/ln4f1u6YO7gNh7AcyKp+JLIpvahRSlt3gLrHaf1Ct6yLQuTtWDkolEToJ/4h+iVYbCBMDA+WRCGHK+ZT/sOzaHWCRGtppl0IiLB6cMDYyy3aLD4wfNqByXyLrZ3TYavfd3t1kChRb1E+XJbKpRDSjOXVXIpMr2qi/uyqR7STjUfWdmxLZQT6yOHFRIlNK+tu6J1FNoIMSmXKe0cotieoCHZOYR6BTsYx4jEJBom6+ry14ToFPT5EbEnmULSVVogsv6u2xYekk6vbNXhb9ReXajcELHngz0W/5rhN3gQAzDaULHHoz1eJ1bSz51yxgrnPmGyuiRDDZBm1fwHwiAKN93vaFe1HBdA+0XsFeVGBHswKfnj4K9aICIHTs6RVIIorAUzuPoki8Szw0RVEyNKGGVvE9LESOJnQQS9q7BZAIHmrNfkAuETzkUmjqlA0I0Wu9A9J8BggtlNAOCF1MySIxTZvMxdQsEtP4RMF+GFsrEKaRCH2LFdADEoU2S7xzdZzTVmiz2Zlko26zWG37TXIUrnd6r0iOxo/6WO11RrOWWrwJY0Cy/07M+0VCo+ecDhb71aVepIas0N7lUERlUpA7mK3MXyKFf20JbEjcHoOi0NpVe22yvydb7WqUu5GbwlpDbLKQqbUrhF/I3tIXSwqVO8obU2jryh2y0nao2RHo06XYcDu/+R90uRn8w4pCol3pCUsXCBvqrJcHSy0VCUuj7PwE1wnDT+DZ2Jlq9evWlmjjJ5i0/0KsTwIWpOmYuumyUhAupZbafb+SKnzFF0hb024jRBrQ5tMy/Cg3SVDmSiF+eIa4PsFCeGZDnG2ywRbYJC7YhzH2bfN18pwo7J1p7rucTIF+J9QbdfEFenjmm1zhN7JCkvj2NegXlpJ3k4IOrsAG9UIjlprM5iVaHDWnITBPt3DDfKFFjL2WQqFvVB9pajRZ7ZSATnxb6Lv8oS+1NCLHuhVvar6GedFPgLMdefnfBeSLg3M3AwPWuv539Vu5bYQFpsDAy6tve5vtM9jm1ehh/gTnuyQWYJI0qGCSrwaHYca688S3gR3ShjTb5fERNTyjfmMV8P6j79exr166iRqe2SkOB9g461xlPlb1EfMCb8U6BGALma/zfqGmEbMmQenWMWDhWu5/vL4OlTQiprT35PfdwGApf6LSXIKCRo5SQHpGOigjNmiR2nlKPZLfyiGGZ2RThVitpf4i+S3ZzyNi4pBcqhDwVb5dR7CS+3QgJg7JPB9Y4gZGjuAg9aqCQU0xBtkLjdjA6FW2DGW2OWg36mYGZYBN9Ze53jRTI1p4JqMXD/CFmSfPFxnzkT0bec49k0fPldzAyJGxzYGJsSfFeZDeLfSZ3fE/3ObAH6PP+iX9rJR1nk2f8TWeO6mTAu3MNCUZChhbYpxhNiKW4iN4CI87kXxIA7UW1hltu5WcrIt2VJN0lAiwwqy3GqyStnJoB4rHuy8+8C12bkR3e//p4GjH3of4s4C920ik695uARBLLWNNMcQGBjeC8MsxphG1DrH7/woOvG8n5/rC/PfEioWoL46/Ot9Ryvgfm4XVJ/bhvydPsPO+gvX2cxLZLI3/YRZNpq21vUrZioqKioqKiooC8R9m/Jhpz9+liwAAAABJRU5ErkJggg==' style='width: 15px; height:15px;'> {string.Format("{0:P}", (product.Rating * 10) / 100)}</p>";
                    display += $"<h6>{string.Format("{0:C}", product.Price)}</h6>";
                    display += $"<button onclick='addToCart({product.ProductID}.1);'><i class='fas fa-shopping-basket'></i>Add to Cart</button>";
                    display += "</div>";
                    display += "</br></br>";
                    display += "</div>";
                }
            }
            items.InnerHtml = display;
        }
        private void ViewAllProducts()
        {
            dynamic products = Session["Products"];
            title.InnerHtml = "All Products";
            string display = "";
            foreach (SVCProduct product in products)
            {
                if(product.IsActive > 0)
                {
                    display += "<div class='col-md-3'>";
                    display += "<div class='our-card'>";
                    if (product.Picture == null || product.Picture.Equals(""))
                    {
                        display += $"<a href='AboutProduct.aspx?prodID={product.ProductID}&category={product.Category}'><img src = 'https://image.flaticon.com/icons/svg/1046/1046772.svg'alt=''></a>";
                    }
                    else
                    {
                        display += $"<a href='AboutProduct.aspx?prodID={product.ProductID}&category={product.Category}'><img src = '../{product.Picture}'alt=''></a>";
                    }
                    display += $"<h5>{product.ProductName}</h5>";
                    display += $"<p><img src='data:image/png;base64,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' style='width: 15px; height:15px;'> {string.Format("{0:P}", (product.Rating * 10) / 100)}</p>";
                    display += $"<h6>{string.Format("{0:C}", product.Price)}</h6>";
                    display += $"<button onclick='addToCart({product.ProductID}.1);'><i class='fas fa-shopping-basket'></i>Add to Cart</button>";
                    display += "</div>";
                    display += "</br></br>";
                    display += "</div>";
                }
            }
            items.InnerHtml = display;
        }

        protected void txtAddToCart_TextChanged(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                cart.AddToCart(txtAddToCart.Text.ToString());
                Response.Redirect("Catalog.aspx");
            }
        }

        private void SortPriceASC()
        {
            Session["Products"] = service.SortByPriceAsc();
        }
        private void SortPriceDesc()
        {
            Session["Products"] = service.SortByPriceADesc();
        }
        private void SortNameAZ()
        {
            Session["Products"] = service.SortByNameAZ();
        }
        private void SortNameZA()
        {
            Session["Products"] = service.SortByNameZA();
        }
        protected void ourdropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ourdropdown.SelectedValue.Equals("1"))
            {
                SortPriceASC();
                currentCategory = "burger";
                DisplayCategory("burger");
            }
            if(ourdropdown.SelectedValue.Equals("2"))
            {
                SortPriceDesc();
                currentCategory = "burger";
                DisplayCategory("burger");
            }
            if(ourdropdown.SelectedValue.Equals("3"))
            {
                SortNameAZ();
                currentCategory = "burger";
                DisplayCategory("burger");
            }
            if(ourdropdown.SelectedValue.Equals("4"))
            {
                SortNameZA();
                currentCategory = "burger";
                DisplayCategory("burger");
            }
            //Response.Redirect("Catalog.aspx");
        }
    }
}