using System.Collections.Generic;
using System.ServiceModel;

namespace DSS_Service
{
    [ServiceContract]
    public interface IDSSWebService
    {
        [OperationContract]
        SVCUser GetUser(string email, string password);

        [OperationContract]
        SVCUser GetUserByID(string userID);

        [OperationContract]
        List<SVCProduct> GetAllProducts();

        [OperationContract]
        List<SVCProduct> GetProducts(string category);

        [OperationContract]
        List<SVCUser> GetAllUsers();

        [OperationContract]
        List<SVCProduct> Search(string[] tags);

        [OperationContract]
        int AddUser(SVCUser user);

        [OperationContract]
        int RemoveUser(string userID);

        [OperationContract]
        int DisableUser(string userID);

        [OperationContract]
        int EnableUser(string UserID);

        [OperationContract]
        int EditUser(SVCUser user);

        [OperationContract]
        int AddProduct(SVCProduct product);

        [OperationContract]
        int RemoveProduct(string productID);

        [OperationContract]
        int EditProduct(SVCProduct product);

        [OperationContract]
        int DisableProduct(string productID);

        [OperationContract]
        int EnableProduct(string productID);

        [OperationContract]
        SVCProduct GetProduct(string productID);

        [OperationContract]
        SVCProduct MostSellingProduct(string category);

        [OperationContract]
        SVCProduct LeastSellingProduct(string categoty);

        [OperationContract]
        SVCProduct OverallMostSellingProduct();

        [OperationContract]
        SVCProduct OverallLeastSellingProduct();

        [OperationContract]
        double GetTax();

        [OperationContract]
        void SetTax(double TAX);

        [OperationContract]
        int Transact(SVCUser user, List<SVCProduct> products, float price, string paymentMethod, string delivery);

        [OperationContract]
        int ChangeUserPassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        int GetPointsDiscount();

        [OperationContract]
        List<SVCOrder> GetAllOrders();

        [OperationContract]
        List<SVCOrder> GetUserOrders(string userID);

        [OperationContract]
        List<SVCProduct> GetOrderItems(string orderID);

        [OperationContract]
        double GetCategoryPerfomance(string category);

        [OperationContract]
        SVCUser GetWorstBuyer();

        [OperationContract]
        SVCUser GetBestBuyer();

        [OperationContract]
        int GetNumberOfSales(string category);

        [OperationContract]
        double SalesContribution(string category);

        [OperationContract]
        List<double> RevenuePerTransaction();

        [OperationContract]
        double GetRevenue();

        [OperationContract]
        int GetTotalOrders();

        [OperationContract]
        int GetTotalUsers();

        [OperationContract]
        List<SVCProduct> TopFiveSelling();

        [OperationContract]
        List<SVCProduct> SortByPriceAsc();

        [OperationContract]
        List<SVCProduct> SortByPriceADesc();

        [OperationContract]
        List<SVCProduct> SortByNameAZ();

        [OperationContract]
        List<SVCProduct> SortByNameZA();

        [OperationContract]
        double AverageUsersPerDay();

        [OperationContract]
        int FilterOrders(string timeframe);

        [OperationContract]
        double FilterRevenue(string timeframe);

        [OperationContract]
        List<SVCOrder> GetFilteredOrders(string timeframe);

        [OperationContract]
        int AddToWishList(string productID, string userID);

        [OperationContract]
        List<SVCProduct> GetUserWishlist(string userID);

        [OperationContract]
        List<SVCProduct> TopFiveMostWishedItems();

        [OperationContract]
        List<SVCUser> GetProspectiveBuyers(string productID);

        [OperationContract]
        bool VerifyUser(string email);

        [OperationContract]
        List<double> GetProfitInterval(string interval);
    }
}
