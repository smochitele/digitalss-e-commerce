using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Dashboard : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            revenueDisplay.InnerText = string.Format("{0:C}", service.GetRevenue());
            ordersDisplay.InnerText = service.GetTotalOrders().ToString();
            users.InnerText = service.GetTotalUsers().ToString();
            DisplayCharts();
        }

        private void DisplayCharts()
        {
            dynamic topFiveRaw = service.TopFiveSelling();
            dynamic rawOrders = service.GetAllOrders();
            List<SVCOrder> orders = ConvertOrdersToList(rawOrders);
            orders.Reverse();
            List<SVCProduct> topFiveFiltered = ConvertToList(topFiveRaw);
            string display = "<script>";
            display += "var orders2D = document.getElementById('orders').getContext('2d');";
            display += "var topselling = document.getElementById('topselling').getContext('2d');";
            display += "var revenue2D = document.getElementById('revenue').getContext('2d');";
            display += "var customers2D = document.getElementById('active').getContext('2d');";
            display += "var orders = new Chart(orders2D, {";
            display += "type: 'bar',";
            display += "data: {";
            display += $"labels: ['Pizzas', 'Burgers', 'Drinks', 'Snacks', 'Others'],";
            display += "datasets: [{";
            display += "label: 'Number Of Sales Per Category',";
            display += $"data: [{service.GetNumberOfSales("pizza")}, {service.GetNumberOfSales("burger")}, {service.GetNumberOfSales("drink")}, {service.GetNumberOfSales("snack")}, {service.GetNumberOfSales("other")}],";
            display += "backgroundColor: [";
            display += "'rgb(53, 172, 12)',";
            display += "'rgb(53, 172, 0)',";
            display += "'rgb(53, 172, 120)',";
            display += "'rgb(53, 88, 12)',";
            display += "'rgb(0, 172, 12)'";
            display += "],";
            display += "borderColor: [";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)'";
            display += "],";
            display += "borderWidth: 0";
            display += "}]";
            display += "},";
            display += "options: {";
            display += "scales: {";
            display += "yAxes: [{";
            display += "ticks: {";
            display += "beginAtZero: true";
            display += "},";
            display += "gridLines: {";
            display += "display: false";
            display += "}";
            display += "}],";
            display += "xAxes: [{";
            display += "gridLines: {";
            display += "display: false";
            display += "}";
            display += "}]";
            display += "}";
            display += "}";
            display += "});";
            display += "var myChart = new Chart(revenue2D, {";
            display += "type: 'line',";
            display += "data: {";
            display += $"labels: ['Order {orders[0].OrderID}', 'Order {orders[1].OrderID}', 'Order {orders[2].OrderID}', 'Order {orders[3].OrderID}', 'Order {orders[4].OrderID}'],";
            display += "datasets: [{";
            display += "label: 'Revenue For The Last Five Transactions',";
            display += $"data: [{Math.Floor(orders[0].AmountDue)}, {Math.Floor(orders[1].AmountDue)}, {Math.Floor(orders[2].AmountDue)}, {Math.Floor(orders[3].AmountDue)}, {Math.Floor(orders[4].AmountDue)}],";
            display += "backgroundColor: [";
            display += "'rgb(39, 133, 10, 0)',";
            display += "],";
            display += "fill: 'false',";
            display += "borderColor: [";
            display += "'rgb(39, 133, 10)'";
            display += "],";
            display += "}],";
            display += "backgroundColor: 'red'";
            display += "},";
            display += "options: {";
            display += "scales: {";
            display += "yAxes: [{";
            display += "ticks: {";
            display += "beginAtZero: true";
            display += "},";
            display += "gridLines: {";
            display += "display: false";
            display += "}";
            display += "}],";
            display += "xAxes: [{";
            display += "gridLines: {";
            display += "display: false";
            display += "}";
            display += "}]";
            display += "}";
            display += "}";
            display += " });";
            display += "var users = new Chart(topselling, {";
            display += "type: 'bar',";
            display += "data: {";
            display += $"labels: ['{topFiveFiltered[0].ProductName}', '{topFiveFiltered[1].ProductName}', '{topFiveFiltered[2].ProductName}', '{topFiveFiltered[3].ProductName}', '{topFiveFiltered[4].ProductName}'],";
            display += "datasets: [{";
            display += "label: 'Top 5 Selling Items',";
            display += $"data: [{topFiveFiltered[0].QuantityBought}, {topFiveFiltered[1].QuantityBought}, {topFiveFiltered[2].QuantityBought}, {topFiveFiltered[3].QuantityBought}, {topFiveFiltered[4].QuantityBought}],";
            display += "backgroundColor: [";
            display += "'rgb(22, 172, 98)',";
            display += "'rgb(22, 0, 98)',";
            display += "'rgb(22, 100, 98)',";
            display += "'rgb(90, 172, 98)',";
            display += "'rgb(22, 172, 0)'";
            display += "],";
            display += "borderColor: [";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)',";
            display += "'rgb(0, 131, 11)'";
            display += "],";
            display += "borderWidth: 0";
            display += "}]";
            display += "},";
            display += "options: {";
            display += "scales: {";
            display += "yAxes: [{";
            display += "ticks: {";
            display += "beginAtZero: true";
            display += "},";
            display += "gridLines: {";
            display += "display: false";
            display += "}";
            display += "}],";
            display += "xAxes: [{";
            display += "gridLines: {";
            display += "display: false";
            display += "}";
            display += "}]";
            display += "}";
            display += "}";
            display += "});";
            display += "var active = new Chart(customers2D, {";
            display += "type: 'pie',";
            display += "data: {";
            display += $"labels: ['Pizzas', 'Burgers', 'Drinks', 'Snacks', 'Others'],";
            display += "datasets: [{";
            display += "label: 'Sales Contribution',";
            display += $"data: [{Math.Floor(service.SalesContribution("pizza"))}, {Math.Floor(service.SalesContribution("burger"))}, {Math.Floor(service.SalesContribution("drink"))}, {Math.Floor(service.SalesContribution("snack"))}, {Math.Floor(service.SalesContribution("other"))}],";
            display += "backgroundColor: [";
            display += "'rgb(129, 50, 168)',";
            display += "'rgb(129, 100, 233)',";
            display += "'rgb(30, 50, 168)',";
            display += "'rgb(129, 50, 90)',";
            display += " 'rgb(222, 122, 20)'";
            display += "]";
            display += "}]";
            display += "}";
            display += "});";
            display += " </script>";

            chartsDisplay.InnerHtml = display;
        }
        private List<SVCProduct> ConvertToList(dynamic list)
        {
            List<SVCProduct> items = new List<SVCProduct>();
            foreach (SVCProduct item in list)
            {
                items.Add(item);
            }
            return items;
        }

        private List<SVCOrder> ConvertOrdersToList(dynamic list)
        {
            List<SVCOrder> items = new List<SVCOrder>();
            foreach (var item in list)
            {
                items.Add(item);
            }
            return items;
        }

        protected void ordersMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //today, this week, this month, this year
            if(ordersMenu.SelectedValue.Equals("1"))
            {
                ordersDisplay.InnerText = Convert.ToString(service.FilterOrders("today"));
            }
            if (ordersMenu.SelectedValue.Equals("2"))
            {
                ordersDisplay.InnerText = Convert.ToString(service.FilterOrders("week"));
            }
            if (ordersMenu.SelectedValue.Equals("3"))
            {
                ordersDisplay.InnerText = Convert.ToString(service.FilterOrders("month"));
            }
            if (ordersMenu.SelectedValue.Equals("4"))
            {
                ordersDisplay.InnerText = Convert.ToString(service.FilterOrders("year"));
            }
        }

        protected void revenueMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (revenueMenu.SelectedValue.Equals("1"))
            {
                revenueDisplay.InnerText = string.Format("{0:C}", service.FilterRevenue("today"));
            }
            if (revenueMenu.SelectedValue.Equals("2"))
            {
                revenueDisplay.InnerText = string.Format("{0:C}", service.FilterRevenue("week"));
            }
            if (revenueMenu.SelectedValue.Equals("3"))
            {
                revenueDisplay.InnerText = string.Format("{0:C}", service.FilterRevenue("month"));
            }
            if (revenueMenu.SelectedValue.Equals("4"))
            {
                revenueDisplay.InnerText = string.Format("{0:C}", service.FilterRevenue("year"));
            }
        }
    }
}