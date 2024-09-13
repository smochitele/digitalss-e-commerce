using DSS_Website.DSS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSS_Website
{
    public class ShoppingCart
    {
        private readonly DSSWebServiceClient service = new DSSWebServiceClient();
        public ShoppingCart()
        {
            products = new List<SVCProduct>();
        }

        private readonly List<SVCProduct> products;
        private decimal _CartTotal;

        public int NumberOfItems
        {
            get
            {
                int total = 0;
                foreach(SVCProduct product in products)
                {
                    total += (int)product.QuantityBought;
                }
                return total;
            }
        }

        public decimal SubTotal
        {
            get
            {
                decimal total = 0;
                foreach(SVCProduct product in products)
                {
                    total += (decimal)(product.Price * product.QuantityBought);
                }
                return total;
            }
        }

        public decimal CartTotal
        {
            get
            {
                decimal total = 0;
                foreach(SVCProduct product in products)
                {
                    total += CalculateTAX(CalculateItemDiscount(((decimal)(product.Price * product.QuantityBought)), (float)product.Discount));
                }
                _CartTotal = total;
                return _CartTotal;
            }
            set
            {
                _CartTotal = value;
            }
        }

        public int PrepationTime
        {
            get
            {
                int time = 0;
                foreach (SVCProduct item in products)
                {
                    time += (int)((item.PrepationTime * item.QuantityBought) / products.Count);
                }
                return time;
            }
        }
        public int PointsGained
        {
            get
            {
                return CalculatePointsGained();
            }
        }

        public void AddToCart(string productID)
        {
            SVCProduct item = service.GetProduct(productID);
            foreach(SVCProduct product in products)
            {
                if(product.ProductID.Equals(Convert.ToInt32(productID)))
                {
                    product.QuantityBought++;
                    return;
                }
            }
            if(item != null)
            {
                item.QuantityBought = 1;
                products.Add(item);
            }
            RefreshCart();
        }

        public void AddToCart(string productID, int quantityBought)
        {
            SVCProduct item = service.GetProduct(productID);
            foreach (SVCProduct product in products)
            {
                if (product.ProductID.Equals(Convert.ToInt32(productID)))
                {
                    product.QuantityBought += quantityBought;
                    RefreshCart();
                    return;
                }
            }
            if (item != null)
            {
                item.QuantityBought = quantityBought;
                products.Add(item);
            }
            RefreshCart();
        }

        public void RemoveFromCart(string productID)
        {
            foreach(SVCProduct product in products)
            {
                if(product.ProductID.Equals(Convert.ToInt32(productID)))
                {
                    products.Remove(product);
                    RefreshCart();
                    return;
                }
            }
        }

        public void AlterQuantity(string productID, int quanity)
        {
            if(quanity > 0)
            {
                foreach (SVCProduct product in products)
                {
                    if (product.ProductID.Equals(Convert.ToInt32(productID)))
                    {
                        product.QuantityBought = quanity;
                        return;
                    }
                }
            }
            else if(quanity <= 0)
            {
                foreach (SVCProduct product in products)
                {
                    if (product.ProductID.Equals(Convert.ToInt32(productID)))
                    {
                        products.Remove(product);
                        return;
                    }
                }
            }
        }

        public List<SVCProduct> GetProducts()
        {
            return products;
        }
        private decimal CalculateTAX(decimal priceBeforeTax)
        {
            decimal price = (priceBeforeTax + (priceBeforeTax * (decimal)service.GetTax()));
            return price;
        }

        private decimal CalculateItemDiscount(decimal price, float discount)
        {
            decimal amountDue = price - (price * (decimal)discount);
            return amountDue;
        }

        private int CalculatePointsGained()
        {
            int points = (int)Math.Floor(CartTotal / 100);
            return points;
        }
        private void RefreshCart()
        {
            foreach (SVCProduct item in products)
            {
                if (item == null || item.QuantityBought <= 0)
                {
                    products.Remove(item);
                }
            }
        }
    }
}