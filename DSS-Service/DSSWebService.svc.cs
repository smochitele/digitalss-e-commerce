using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DSS_Service
{
    public class DSSWebService : IDSSWebService
    {
        public const int INSERT_SUCCESS = 1;
        public const int INSERT_FAIL = -1;
        private double Tax;
        readonly DatabaseAccessDataContext db = new DatabaseAccessDataContext();

        public int AddProduct(SVCProduct product)
        {
            try
            {
                Product dbProduct = new Product()
                {
                    ProductName = product.ProductName,
                    Category = product.Category,
                    Description = product.Description,
                    Price = product.Price,
                    Discount = product.Discount,
                    Quantity = product.Quantity,
                    QuantityBought = product.QuantityBought,
                    PrepationTime = product.PrepationTime,
                    Picture = product.Picture,
                    Rating = product.Rating,
                    Healthiness = product.Healthiness,
                    IsActive = product.IsActive,
                    Tags = product.Tags
                };
                db.Products.InsertOnSubmit(dbProduct);
                db.SubmitChanges();
                return INSERT_SUCCESS;
            }
            catch(Exception e)
            {
                PrintError(e);
                return INSERT_FAIL;
            }
        }

        public int AddUser(SVCUser user)
        {
            try
            {
                User dbUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserType = user.UserType,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Password = Secrecy.HashPassword(user.Password),
                    Credit = user.Credit,
                    Points = user.Points,
                    NumberOfTransactions = user.NumberOfTransactions,
                };
                db.Users.InsertOnSubmit(dbUser);
                db.SubmitChanges();
                return INSERT_SUCCESS;
            }
            catch(Exception e)
            {
                PrintError(e);
                return INSERT_FAIL;
            }
        }

        public int DisableProduct(string productID)
        {
            var product = (from p in db.Products
                           where p.ProductID.Equals(productID)
                           select p).FirstOrDefault();

            if(product != null)
            {
                try
                {
                    product.IsActive = -1;
                    db.SubmitChanges();
                    return INSERT_SUCCESS;
                }
                catch (Exception e)
                {
                    PrintError(e);
                    return INSERT_FAIL;
                }
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public int EnableProduct(string productID)
        {
            var product = (from p in db.Products
                           where p.ProductID.Equals(productID)
                           select p).FirstOrDefault();

            if (product != null)
            {
                try
                {
                    product.IsActive = 1;
                    db.SubmitChanges();
                    return INSERT_SUCCESS;
                }
                catch (Exception e)
                {
                    PrintError(e);
                    return INSERT_FAIL;
                }
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public int DisableUser(string userID)
        {
            var user = (from u in db.Users
                        where u.UserID.Equals(userID)
                        select u).FirstOrDefault();
            if(user != null)
            {
                user.IsActive = -1;
                db.SubmitChanges();
                return INSERT_SUCCESS;
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public int EditProduct(SVCProduct product)
        {
            var dbProduct = (from p in db.Products
                             where p.ProductID.Equals(product.ProductID)
                             select p).FirstOrDefault();
            if(dbProduct != null)
            {
                try
                {
                    dbProduct.ProductName = product.ProductName;
                    dbProduct.Category = product.Category;
                    dbProduct.Description = product.Description;
                    dbProduct.Price = product.Price;
                    dbProduct.Discount = product.Discount;
                    dbProduct.Quantity = product.Quantity;
                    dbProduct.QuantityBought = product.QuantityBought;
                    dbProduct.PrepationTime = product.PrepationTime;
                    dbProduct.Picture = product.Picture;
                    dbProduct.Rating = product.Rating;
                    dbProduct.Healthiness = product.Healthiness;
                    dbProduct.Tags = product.Tags;

                    db.SubmitChanges();
                    return INSERT_SUCCESS;
                }
                catch(Exception e)
                {
                    PrintError(e);
                    return INSERT_FAIL;
                }
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public int EditUser(SVCUser user)
        {
            var dbUser = (from u in db.Users
                          where u.UserID.Equals(user.UserID)
                          select u).FirstOrDefault();
            if(dbUser != null)
            {
                try
                {
                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.UserType = user.UserType;
                    dbUser.Email = user.Email;
                    dbUser.IsActive = user.IsActive;
                    dbUser.Password = user.Password;
                    dbUser.Points = user.Points;
                    dbUser.Credit = user.Credit;

                    db.SubmitChanges();
                    return INSERT_SUCCESS;
                }
                catch(Exception e)
                {
                    PrintError(e);
                    return INSERT_FAIL;
                }
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public List<SVCProduct> GetAllProducts()
        {
            List<SVCProduct> products = new List<SVCProduct>();
            dynamic dbProducts = (from prods in db.Products
                                 select prods);
            foreach(Product p in dbProducts)
            {
                products.Add(new SVCProduct()
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    Description = p.Description,
                    Price = p.Price,
                    Discount = p.Discount,
                    Quantity = p.Quantity,
                    QuantityBought = p.QuantityBought,
                    PrepationTime = p.PrepationTime,
                    Picture = p.Picture,
                    Rating = p.Rating,
                    Healthiness = p.Healthiness,
                    IsActive = p.IsActive,
                    Tags = p.Tags
                });
            }
            return products;
        }

        public List<SVCUser> GetAllUsers()
        {
            List<SVCUser> users = new List<SVCUser>();
            dynamic dbUsers = (from u in db.Users
                               select u);
            foreach(User user in dbUsers)
            {
                users.Add(new SVCUser()
                {
                    UserID = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserType = user.UserType,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Password = user.Password,
                    Points = user.Points,
                    Credit = user.Credit,
                    NumberOfTransactions = user.NumberOfTransactions,
                });
            }
            return users;
        }

        public SVCProduct GetProduct(string productID)
        {
            var p = (from prod in db.Products
                           where prod.ProductID.Equals(Convert.ToInt32(productID))
                           select prod).FirstOrDefault();
            return new SVCProduct()
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Category = p.Category,
                Description = p.Description,
                Price = p.Price,
                Discount = p.Discount,
                Quantity = p.Quantity,
                QuantityBought = p.QuantityBought,
                PrepationTime = p.PrepationTime,
                Picture = p.Picture,
                Rating = p.Rating,
                Healthiness = p.Healthiness,
                IsActive = p.IsActive,
                Tags = p.Tags
            };
        }
        public List<SVCProduct> GetProducts(string category)
        {
            List<SVCProduct> products = new List<SVCProduct>();
            dynamic items = (from prod in db.Products
                             where prod.Category.Equals(category)
                             select prod);
            foreach (Product p in items)
            {
                products.Add(new SVCProduct()
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    Description = p.Description,
                    Price = p.Price,
                    Discount = p.Discount,
                    Quantity = p.Quantity,
                    QuantityBought = p.QuantityBought,
                    PrepationTime = p.PrepationTime,
                    Picture = p.Picture,
                    Rating = p.Rating,
                    Healthiness = p.Healthiness,
                    IsActive = p.IsActive,
                    Tags = p.Tags
                });
            }
            return products;
        }

        public SVCUser GetUser(string email, string password)
        {
            const int USER_ACTIVE = 1;
            var user = (from u in db.Users
                        where u.Email.Equals(email)  && u.IsActive.Equals(USER_ACTIVE) && u.Password.Equals(Secrecy.HashPassword(password))
                        select u).FirstOrDefault();
            if(user != null)
            {
                return new SVCUser()
                {
                    UserID = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserType = user.UserType,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Password = user.Password,
                    Points = user.Points,
                    Credit = user.Credit,
                    NumberOfTransactions = user.NumberOfTransactions
                };
            }
            else
            {
                return null;
            }
        }

        public SVCUser GetUserByID(string userID)
        {
            var user = (from u in db.Users
                        where u.UserID.Equals(Convert.ToInt32(userID))
                        select u).FirstOrDefault();
            if(user != null)
            {
                return new SVCUser
                {
                    UserID = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
            }
            else
            {
                return null;
            }
        }

        public int RemoveProduct(string productID)
        {
            var product = (from p in db.Products
                           where p.ProductID.Equals(productID)
                           select p).FirstOrDefault();

            if (product != null)
            {
                try
                {
                    product.IsActive = -1;
                    db.SubmitChanges();
                    return INSERT_SUCCESS;
                }
                catch (Exception e)
                {
                    PrintError(e);
                    return INSERT_FAIL;
                }
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public int RemoveUser(string userID)
        {
            var user = (from u in db.Users
                        where u.UserID.Equals(userID)
                        select u).FirstOrDefault();
            if(user != null)
            {
                try
                {
                    db.Users.DeleteOnSubmit(user);
                    db.SubmitChanges();
                    return INSERT_SUCCESS;
                }
                catch(Exception e)
                {
                    PrintError(e);
                    return INSERT_FAIL;
                }
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public List<SVCProduct> Search(string[] tags)
        {
            List<SVCProduct> serachResults = new List<SVCProduct>();
            dynamic products = (from prod in db.Products
                                where prod.IsActive > 0
                                select prod);
            foreach(string tag in tags)
            {
                string smallCaseTag = tag.ToLower();
                foreach(Product prod in products)
                {
                    string[] dbTags = prod.Tags.Split(' ');
                    foreach(var dbTag in dbTags)
                    {
                        string smallCaseDbTag = dbTag.ToLower();
                        if(smallCaseDbTag.Contains(smallCaseTag))
                        {
                            serachResults.Add(new SVCProduct()
                            {
                                ProductID = prod.ProductID,
                                ProductName = prod.ProductName,
                                Category = prod.Category,
                                Description = prod.Description,
                                Price = prod.Price,
                                Discount = prod.Discount,
                                Quantity = prod.Quantity,
                                QuantityBought = prod.QuantityBought,
                                PrepationTime = prod.PrepationTime,
                                Picture = prod.Picture,
                                Rating = prod.Rating,
                                Healthiness = prod.Healthiness,
                                IsActive = prod.IsActive,
                                Tags = prod.Tags
                            });
                        }
                    }
                }
            }
            if (serachResults.Count <= 0)
                return null;
            else
                return serachResults;
        }

        public SVCProduct LeastSellingProduct(string categoty)
        {
            List<SVCProduct> items = new List<SVCProduct>();
            dynamic products = (from prod in db.Products
                               where prod.Category.Equals(categoty)
                               orderby prod.QuantityBought ascending
                               select prod);
            foreach (Product item in products)
            {
                items.Add(new SVCProduct
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Description = item.Description,
                    Category = item.Category,
                    Picture = item.Picture,
                    Quantity = item.Quantity,
                    Rating = item.Rating,
                });
                return items[0];
            }
            return items[0];
        }

        public SVCProduct MostSellingProduct(string category)
        {
            List<SVCProduct> items = new List<SVCProduct>();
            dynamic products = (from prod in db.Products
                                where prod.Category.Equals(category)
                                orderby prod.QuantityBought descending
                                select prod);
            foreach (Product item in products)
            {
                items.Add(new SVCProduct
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Description = item.Description,
                    Category = item.Category,
                    Picture = item.Picture,
                    Quantity = item.Quantity,
                    Rating = item.Rating,
                });
                return items[0];
            }
            return items[0];
        }

        private void PrintError(Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }

        public double GetTax()
        {
            var getTax = (from row in db.CommonTypes
                          where row.Name.Equals("TAX")
                          select row.Value).FirstOrDefault();
            Tax = Convert.ToDouble(getTax);
            return Tax;
        }

        public void SetTax(double TAX)
        {
            if(TAX > 1)
                TAX /= 100;

            var getTax = (from row in db.CommonTypes
                          where row.Name.Equals("TAX")
                          select row).FirstOrDefault();
            try
            {
                getTax.Value = TAX;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int Transact(SVCUser user, List<SVCProduct> products, float price, string paymentMethod, string delivery)
        {
            try
            {
                UpdateUser(user);
                UpdateOrder(user, products, paymentMethod, delivery, price);
                UpdateProducts(products);
                db.SubmitChanges();
                return INSERT_SUCCESS;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return INSERT_FAIL;
            }
        }

        public int ChangeUserPassword(string username, string oldPassword,string newPassword)
        {
            User user = db.Users.FirstOrDefault(u => u.Email == username);
            user.Password = Secrecy.HashPassword(newPassword);
            try
            {
               db.SubmitChanges();
               return INSERT_SUCCESS;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return INSERT_FAIL;
            }
        }

        private int GetNumberOfCartItems(List<SVCProduct> items)
        {
            int counter = 0;
            foreach (SVCProduct item in items)
            {
                counter += (int)item.QuantityBought;
            }
            return counter;
        }

        private void UpdateUser(User user)
        {
            try
            {
                User dbUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (dbUser.NumberOfTransactions != null)
                    dbUser.NumberOfTransactions++;
                else
                    dbUser.NumberOfTransactions = 1;
                if (dbUser.Points != null)
                    dbUser.Points += user.Points;
                else
                    dbUser.Points = user.Points;

                dbUser.Credit = user.Credit;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void UpdateOrder(User user, List<SVCProduct> products, string paymentMethod, string delivery, float price)
        {
            try
            {
                Order order = new Order()
                {
                    UserID = user.UserID,
                    NumItems = GetNumberOfCartItems(products),
                    Date = DateTime.Today,
                    PaymentMethod = paymentMethod,
                    Delivery = delivery,
                    AmountDue = price,
                };
                db.Orders.InsertOnSubmit(order);
                db.SubmitChanges();

                foreach (var item in products)
                {
                    OrderProductJoin orderProductJoin = new OrderProductJoin
                    {
                        OrderID = order.OrderID,
                        ProductID = item.ProductID,
                        Quantity = item.QuantityBought
                    };
                    db.OrderProductJoins.InsertOnSubmit(orderProductJoin);
                }
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void UpdateProducts(List<SVCProduct> products)
        {
            try
            {
                foreach (SVCProduct item in products)
                {
                    var product = (from prod in db.Products
                                   where prod.ProductID.Equals(item.ProductID)
                                   select prod).FirstOrDefault();

                    product.Quantity -= (int)item.QuantityBought;

                    if (product.QuantityBought != null)
                        product.QuantityBought += item.QuantityBought;
                    else
                        product.QuantityBought = item.QuantityBought;
                }
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetPointsDiscount()
        {
            return 10;
        }

        public int EnableUser(string userID)
        {
            var user = (from u in db.Users
                        where u.UserID.Equals(userID)
                        select u).FirstOrDefault();
            if (user != null)
            {
                user.IsActive = 1;
                db.SubmitChanges();
                return INSERT_SUCCESS;
            }
            else
            {
                return INSERT_FAIL;
            }
        }

        public List<SVCOrder> GetAllOrders()
        {
            List<SVCOrder> allOrders = new List<SVCOrder>();
            dynamic orders = (from order in db.Orders
                              select order);
            foreach (Order item in orders)
            {
                allOrders.Add(new SVCOrder
                {
                    OrderID = item.OrderID,
                    UserID = item.UserID,
                    NumItems = item.NumItems,
                    Date = item.Date,
                    PaymentMethod = item.PaymentMethod,
                    Delivery = item.Delivery,
                    AmountDue = item.AmountDue
                });
            }
            return allOrders;
        }

        public List<SVCOrder> GetUserOrders(string userID)
        {
            List<SVCOrder> allOrders = new List<SVCOrder>();
            dynamic orders = (from order in db.Orders
                              where order.UserID.Equals(userID)
                              select order);
            foreach (Order item in orders)
            {
                allOrders.Add(new SVCOrder
                {
                    OrderID = item.OrderID,
                    UserID = item.OrderID,
                    NumItems = item.NumItems,
                    Date = item.Date,
                    PaymentMethod = item.PaymentMethod,
                    Delivery = item.Delivery,
                    AmountDue = item.AmountDue,
                });
            }
            return allOrders;
        }

        public List<SVCProduct> GetOrderItems(string orderID)
        {
            dynamic orderProductJoin = (from row in db.OrderProductJoins
                                        select row);

            List<SVCProduct> products = new List<SVCProduct>();
            foreach (OrderProductJoin row in orderProductJoin)
            {
                if(row.OrderID.Equals(Convert.ToInt32(orderID)))
                {
                    var product = GetProduct(row.ProductID.ToString());
                    product.QuantityBought = row.Quantity;
                    products.Add(product);
                }

            }
            return products;
        }

        public SVCProduct OverallMostSellingProduct()
        {
            List<SVCProduct> items = new List<SVCProduct>();
            dynamic products = (from prod in db.Products
                                orderby prod.QuantityBought descending
                                select prod);

            foreach (Product item in products)
            {
                items.Add(new SVCProduct
                {
                    ProductName = item.ProductName,
                    Picture = item.Picture,
                    Description = item.Description,
                    Price = item.Price,
                    QuantityBought = item.QuantityBought
                });
            }
            return items[0];
        }

        public SVCProduct OverallLeastSellingProduct()
        {
            List<SVCProduct> items = new List<SVCProduct>();
            dynamic products = (from prod in db.Products
                                orderby prod.QuantityBought ascending
                                select prod);

            foreach (Product item in products)
            {
                items.Add(new SVCProduct
                {
                    ProductName = item.ProductName,
                    Picture = item.Picture,
                    Description = item.Description,
                    Price = item.Price,
                    QuantityBought = item.QuantityBought
                });
            }
            return items[0];
        }

        public double GetCategoryPerfomance(string category)
        {
            List<SVCProduct> products = GetProducts(category);
            double totalItems = 0;
            double totalSold = 0;
            foreach (var item in products)
            {
                totalItems += item.Quantity;
                if (item.QuantityBought != null)
                {
                    totalSold += (double)item.QuantityBought;
                }
            }
            double performance = totalSold / totalItems;
            return performance * 100;
        }

        public SVCUser GetWorstBuyer()
        {
            List<SVCUser> users = new List<SVCUser>();
            dynamic dbUsers = (from u in db.Users
                               orderby u.NumberOfTransactions ascending
                               select u);
            foreach (User user in dbUsers)
            {
                users.Add(new SVCUser
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Points = user.Points,
                    NumberOfTransactions = user.NumberOfTransactions,
                });
                return users[0];
            }
            return null;
        }

        public SVCUser GetBestBuyer()
        {
            List<SVCUser> users = new List<SVCUser>();
            dynamic dbUsers = (from u in db.Users
                               orderby u.NumberOfTransactions descending
                               select u);
            foreach (User user in dbUsers)
            {
                users.Add(new SVCUser
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Points = user.Points,
                    NumberOfTransactions = user.NumberOfTransactions,
                });
                return users[0];
            }
            return null;
        }

        public int GetNumberOfSales(string category)
        {
            int numSales = 0;
            dynamic products = (from prod in db.Products
                                where prod.Category.Equals(category)
                                select prod);
            foreach (Product item in products)
            {
                if(item.QuantityBought != null)
                    numSales += (int)item.QuantityBought;
            }
            return numSales;
        }

        public double SalesContribution(string category)
        {
            List<SVCProduct> products = GetAllProducts();
            int totalSales = 0;
            foreach (var item in products)
            {
                if(item.QuantityBought != null)
                    totalSales += (int)item.QuantityBought;
            }
            int salesInCategory = 0;
            List<SVCProduct> categoryItems = GetProducts(category);
            foreach (var item in categoryItems)
            {
                if(item.QuantityBought != null)
                    salesInCategory += (int)item.QuantityBought;
            }
            double contribution = (Convert.ToDouble(salesInCategory)/Convert.ToDouble(totalSales))*100;
            return contribution;
        }

        public List<double> RevenuePerTransaction()
        {
            List<double> container = new List<double>();
            List<SVCOrder> orders = GetAllOrders();
            foreach (var item in orders)
            {
                container.Add(item.AmountDue);
            }
            return container;
        }

        public double GetRevenue()
        {
            double revenue = 0;
            string today = Convert.ToDateTime(DateTime.Today).ToShortDateString();
            foreach (var item in GetAllOrders())
            {
                string date = Convert.ToDateTime(item.Date).ToShortDateString();
                if (date.Equals(today))
                {
                    revenue += item.AmountDue;
                }
            }
            return revenue;
        }

        public int GetTotalOrders()
        {
            int counter = 0;
            string today = Convert.ToDateTime(DateTime.Today).ToShortDateString();
            foreach (var item in GetAllOrders())
            {
                string date = Convert.ToDateTime(item.Date).ToShortDateString();
                if (date.Equals(today))
                {
                    counter++;
                }
            }
            return counter;
        }

        public int GetTotalUsers()
        {
            return GetAllUsers().Count;
        }

        public List<SVCProduct> TopFiveSelling()
        {
            List<SVCProduct> items = new List<SVCProduct>();
            dynamic products = (from prod in db.Products
                                orderby prod.QuantityBought descending
                                select prod);
            int counter = 0;
            foreach(Product prod in products)
            {
                if(counter < 5)
                {
                    counter++;
                    items.Add(new SVCProduct
                    {
                        ProductID = prod.ProductID,
                        ProductName = prod.ProductName,
                        Category = prod.Category,
                        Description = prod.Description,
                        Price = prod.Price,
                        Discount = prod.Discount,
                        Quantity = prod.Quantity,
                        QuantityBought = prod.QuantityBought,
                        PrepationTime = prod.PrepationTime,
                        Picture = prod.Picture,
                        Rating = prod.Rating,
                        Healthiness = prod.Healthiness,
                        IsActive = prod.IsActive,
                        Tags = prod.Tags
                    });
                }
                else
                {
                    break;
                }
            }
            return items;
        }

        public List<SVCProduct> SortByPriceAsc()
        {
            dynamic Items = (from u in db.Products orderby u.Price ascending select u);
            List<SVCProduct> SortedItems = new List<SVCProduct>();
            foreach (Product pro in Items)
            {
                SortedItems.Add(new SVCProduct
                {
                    ProductName = pro.ProductName,
                    Category = pro.Category,
                    Description = pro.Description,
                    Discount = pro.Discount,
                    Healthiness = pro.Healthiness,
                    IsActive = pro.IsActive,
                    Picture = pro.Picture,
                    PrepationTime = pro.PrepationTime,
                    Price = pro.Price,
                    ProductID = pro.ProductID,
                    Quantity = pro.Quantity,
                    QuantityBought = pro.QuantityBought,
                    Rating = pro.Rating,
                    Tags = pro.Tags
                });
            }
            return SortedItems;
        }

        public List<SVCProduct> SortByPriceADesc()
        {
            dynamic Items = (from u in db.Products orderby u.Price descending select u);
            List<SVCProduct> SortedItems = new List<SVCProduct>();
            foreach (Product pro in Items)
            {
                SortedItems.Add(new SVCProduct
                {
                    ProductName = pro.ProductName,
                    Category = pro.Category,
                    Description = pro.Description,
                    Discount = pro.Discount,
                    Healthiness = pro.Healthiness,
                    IsActive = pro.IsActive,
                    Picture = pro.Picture,
                    PrepationTime = pro.PrepationTime,
                    Price = pro.Price,
                    ProductID = pro.ProductID,
                    Quantity = pro.Quantity,
                    QuantityBought = pro.QuantityBought,
                    Rating = pro.Rating,
                    Tags = pro.Tags

                });
            }
            return SortedItems;
        }

        public List<SVCProduct> SortByNameAZ()
        {
            dynamic Items = (from u in db.Products orderby u.ProductName ascending select u);
            List<SVCProduct> SortedItems = new List<SVCProduct>();
            foreach (Product pro in Items)
            {
                SortedItems.Add(new SVCProduct
                {
                    ProductName = pro.ProductName,
                    Category = pro.Category,
                    Description = pro.Description,
                    Discount = pro.Discount,
                    Healthiness = pro.Healthiness,
                    IsActive = pro.IsActive,
                    Picture = pro.Picture,
                    PrepationTime = pro.PrepationTime,
                    Price = pro.Price,
                    ProductID = pro.ProductID,
                    Quantity = pro.Quantity,
                    QuantityBought = pro.QuantityBought,
                    Rating = pro.Rating,
                    Tags = pro.Tags

                });
            }
            return SortedItems;
        }

        public List<SVCProduct> SortByNameZA()
        {
            dynamic Items = (from u in db.Products orderby u.ProductName descending select u);
            List<SVCProduct> SortedItems = new List<SVCProduct>();
            foreach (Product pro in Items)
            {
                SortedItems.Add(new SVCProduct
                {
                    ProductName = pro.ProductName,
                    Category = pro.Category,
                    Description = pro.Description,
                    Discount = pro.Discount,
                    Healthiness = pro.Healthiness,
                    IsActive = pro.IsActive,
                    Picture = pro.Picture,
                    PrepationTime = pro.PrepationTime,
                    Price = pro.Price,
                    ProductID = pro.ProductID,
                    Quantity = pro.Quantity,
                    QuantityBought = pro.QuantityBought,
                    Rating = pro.Rating,
                    Tags = pro.Tags
                });
            }
            return SortedItems;
        }

        public double AverageUsersPerDay()
        {
            return Convert.ToDouble(GetAllUsers().Count) / 365.25;
        }

        public int FilterOrders(string timeframe)
        {
            const int WEEK_INTERVAL = 7;
            const int MONTH_INTERVAL = 30;
            const int YEAR_INTERVAL = 365;
            TimeSpan date;
            int counter = 0;
            switch (timeframe)
            {
                case "today":
                    return GetTotalOrders();
                case "week":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= WEEK_INTERVAL)
                        {
                            counter++;
                        }
                    }
                    return counter;
                case "month":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= MONTH_INTERVAL)
                        {
                            counter++;
                        }
                    }
                    return counter;
                case "year":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= YEAR_INTERVAL)
                        {
                            counter++;
                        }
                    }
                    return counter;
                default:
                    return counter;
            }
        }

        public double FilterRevenue(string timeframe)
        {
            const int WEEK_INTERVAL = 7;
            const int MONTH_INTERVAL = 30;
            const int YEAR_INTERVAL = 365;
            TimeSpan date;
            double counter = 0;
            switch (timeframe)
            {
                case "today":
                    return GetRevenue();
                case "week":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if(date.TotalDays <= WEEK_INTERVAL)
                        {
                            counter += item.AmountDue;
                        }
                    }
                    return counter;
                case "month":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= MONTH_INTERVAL)
                        {
                            counter += item.AmountDue;
                        }
                    }
                    return counter;
                case "year":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= YEAR_INTERVAL)
                        {
                            counter += item.AmountDue;
                        }
                    }
                    return counter;
                default:
                    return counter;
            }
        }

        public List<SVCOrder> GetFilteredOrders(string timeframe)
        {
            List<SVCOrder> orders = new List<SVCOrder>();
            const int WEEK_INTERVAL = 7;
            const int MONTH_INTERVAL = 30;
            const int YEAR_INTERVAL = 365;
            TimeSpan date;
            switch (timeframe)
            {
                case "today":
                    foreach (var item in GetAllOrders())
                    {
                        string today = DateTime.Now.ToShortDateString();
                        if (today.Equals(Convert.ToDateTime(item.Date).ToShortDateString()))
                        {
                            orders.Add(item);
                        }
                    }
                    return orders;
                case "week":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= WEEK_INTERVAL)
                        {
                            orders.Add(item);
                        }
                    }
                    return orders;
                case "month":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= MONTH_INTERVAL)
                        {
                            orders.Add(item);
                        }
                    }
                    return orders;
                case "year":
                    foreach (var item in GetAllOrders())
                    {
                        date = DateTime.Now.Subtract((DateTime)item.Date);
                        if (date.TotalDays <= YEAR_INTERVAL)
                        {
                            orders.Add(item);
                        }
                    }
                    return orders;
                default:
                    return null;
            }
        }

        public int AddToWishList(string productID, string userID)
        {
            try
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductID.Equals(Convert.ToInt32(productID)));
                if (product.NumberOfWishes == null)
                {
                    product.NumberOfWishes = 1;
                    db.SubmitChanges();
                }
                else
                {
                    product.NumberOfWishes++;
                    db.SubmitChanges();
                }
                Wishlist wishlist = new Wishlist
                {
                    UserID = Convert.ToInt32(userID),
                };
                db.Wishlists.InsertOnSubmit(wishlist);
                db.SubmitChanges();

                WishlistProductJoin wishlistProductJoin = new WishlistProductJoin
                {
                    WishlistID = wishlist.WishlistID,
                    ProductID = Convert.ToInt32(productID)
                };
                db.WishlistProductJoins.InsertOnSubmit(wishlistProductJoin);
                db.SubmitChanges();
                return INSERT_SUCCESS;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return INSERT_FAIL;
            }
        }

        public List<SVCProduct> GetUserWishlist(string userID)
        {
            List<SVCProduct> products = new List<SVCProduct>();
            dynamic wishlist = (from user in db.Wishlists
                                where user.UserID.Equals(Convert.ToInt32(userID))
                                select user);

            dynamic rows = (from row in db.WishlistProductJoins
                            select row);

            foreach (WishlistProductJoin item in rows)
            {
                foreach (Wishlist wish in wishlist)
                {
                    if(item.WishlistID.Equals(wish.WishlistID))
                    {
                        products.Add(GetProduct(item.ProductID.ToString()));
                    }
                }
            }
            List<SVCProduct> filteredProducts = new List<SVCProduct>();
            foreach (var item in products)
            {
                if (!ProductIsInList(item, filteredProducts))
                    filteredProducts.Add(item);
            }
            return filteredProducts;
        }
        
        public List<SVCProduct> TopFiveMostWishedItems()
        {
            List<SVCProduct> items = new List<SVCProduct>();
            dynamic products = (from prod in db.Products
                                orderby prod.NumberOfWishes descending
                                select prod);
            int counter = 0;
            foreach (Product item in products)
            {
                if(counter < 5)
                {
                    items.Add(new SVCProduct
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        NumberOfWishes = item.NumberOfWishes,
                        Price = item.Price
                    });
                    counter++;
                }
                else
                {
                    return items;
                }
            }
            return items;
        }

        public List<SVCUser> GetProspectiveBuyers(string productID)
        {
            List<SVCUser> users = new List<SVCUser>();
            dynamic wishlist = (from user in db.Wishlists
                                select user);

            dynamic rows = (from row in db.WishlistProductJoins
                            where row.ProductID.Equals(Convert.ToInt32(productID))
                            select row);

            foreach (WishlistProductJoin item in rows)
            {
                foreach (Wishlist wish in wishlist)
                {
                    if(wish.WishlistID.Equals(item.WishlistID))
                    {
                        users.Add(GetUserByID(wish.UserID.ToString()));
                    }
                }
            }

            List<SVCUser> filteredUsers = new List<SVCUser>();
            foreach (var item in users)
            {
                if (!UserIsInList(item, filteredUsers))
                    filteredUsers.Add(item);
            }
            return filteredUsers;
        }

        private bool UserIsInList(SVCUser user, List<SVCUser> users)
        {
            foreach (var item in users)
            {
                if (user.UserID.Equals(item.UserID))
                    return true;
            }
            return false;
        }

        private bool ProductIsInList(SVCProduct product, List<SVCProduct> products)
        {
            foreach (var item in products)
            {
                if (product.ProductID.Equals(item.ProductID))
                    return true;
            }
            return false;
        }

        public bool VerifyUser(string email)
        {
            var user = (from u in db.Users where u.Email.Equals(email) select u).FirstOrDefault();

            if (user != null)
                return true;
            else
                return false;
        }

        public List<double> GetProfitInterval(string interval)
        {
            switch(interval)
            {
                case "week":
                    return GetWeeklyProfit();
                 
                case "day":
                    return GetDailyProfit();
                    
                case "month":
                    return GetMonthlyProfit();
                    
                case "year":
                    return GetYearlyProfit();
            }
            return null;
        }

        private List<double> GetMonthlyProfit()
        {
            List<double> profit = new List<double>();
            foreach (var item in GetAllOrders())
            {
                //var date = DateTime.Now.Subtract((DateTime)item.Date);
                //if (date.TotalDays <= WEEK_INTERVAL)
                //{
                //    //profit.Add(item.);
                //}
            }
            return null;
        }

        private List<double> GetDailyProfit()
        {
            return null;
        }

        private List<double> GetWeeklyProfit()
        {
            return null;
        }

        private List<double> GetYearlyProfit()
        {
            return null;
        }
    }
}
