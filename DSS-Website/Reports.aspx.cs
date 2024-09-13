using System;
using DSS_Website.DSS_Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Website
{
    public partial class Reports : System.Web.UI.Page
    {
        readonly DSSWebServiceClient service = new DSSWebServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DisplayItemPerfomance();
            }
            else
            {
                itemPerfomance_SelectedIndexChanged(sender, e);
            }
            Top5WishedItems();
            DisplayCategoryPerformance();
            DisplayBuyersPerformance();
        }

        private void DisplayByCategory(string category)
        {
            string best = "";
            string worst = "";

            best += $"<img src = '../{service.MostSellingProduct(category).Picture}' class='card-img'  style='height:190px;width:190px;'>";
            best += "</div>";
            best += "<div class='col-md-8'>";
            best += "<div class='card-body body-card'>";
            best += "<h4 id = 'mostselling' >MOST SELLING</h4>";
            best += $"<h5 class='card-title'>{service.MostSellingProduct(category).ProductName}</h5>";
            best += $"<p>{service.MostSellingProduct(category).Description}</p>";
            best += $"<p>{string.Format("{0:C}", service.MostSellingProduct(category).Price)}</p>";
            best += "</div>";

            worst += $"<img src = '../{service.LeastSellingProduct(category).Picture}' class='card-img'  style='height:190px;width:190px;'>";
            worst += "</div>";
            worst += "<div class='col-md-8'>";
            worst += "<div class='card-body body-card'>";
            worst += "<h4 id = 'mostselling' >LEAST SELLING</h4>";
            worst += $"<h5 class='card-title'>{service.LeastSellingProduct(category).ProductName}</h5>";
            worst += $"<p>{service.LeastSellingProduct(category).Description}</p>";
            worst += $"<p>{string.Format("{0:C}", service.LeastSellingProduct(category).Price)}</p>";
            worst += "</div>";

            mostselling.InnerHtml = best;
            worstselling.InnerHtml = worst;
            averageUsers.InnerText = $"Average Users Per Day: {Math.Round(service.AverageUsersPerDay(), 2)}";
        }

        private void DisplayItemPerfomance()
        {
            string best = "";
            string worst = "";

            best += $"<img src = '../{service.OverallMostSellingProduct().Picture}' class='card-img'  style='height:190px;width:190px;'>";
            best += "</div>";
            best += "<div class='col-md-8'>";
            best += "<div class='card-body body-card'>";
            best += "<h4 id = 'mostselling' >MOST SELLING</h4>";
            best += $"<h5 class='card-title'>{service.OverallMostSellingProduct().ProductName}</h5>";
            best += $"<p>{service.OverallMostSellingProduct().Description}</p>";
            best += $"<p>{string.Format("{0:C}", service.OverallMostSellingProduct().Price)}</p>";
            best += "</div>";

            worst += $"<img src = '../{service.OverallLeastSellingProduct().Picture}' class='card-img'  style='height:190px;width:190px;'>";
            worst += "</div>";
            worst += "<div class='col-md-8'>";
            worst += "<div class='card-body body-card'>";
            worst += "<h4 id = 'mostselling' >LEAST SELLING</h4>";
            worst += $"<h5 class='card-title'>{service.OverallLeastSellingProduct().ProductName}</h5>";
            worst += $"<p>{service.OverallLeastSellingProduct().Description}</p>";
            worst += $"<p>{string.Format("{0:C}", service.OverallLeastSellingProduct().Price)}</p>";
            worst += "</div>";

            mostselling.InnerHtml = best;
            worstselling.InnerHtml = worst;
            averageUsers.InnerText = $"Average Users Per Day: {Math.Round(service.AverageUsersPerDay(), 2)}";
        }
        private void Top5WishedItems()
        {
            string display = "";
            display += "<script>";
            display += "var wishes = document.getElementById('wishedItems').getContext('2d');";
            display += "var wishlist = new Chart(wishes, {";
            display += "type: 'bar',";
            display += "data: {";
            display += $"labels: ['{service.TopFiveMostWishedItems()[0].ProductName}', '{service.TopFiveMostWishedItems()[1].ProductName}', '{service.TopFiveMostWishedItems()[2].ProductName}', '{service.TopFiveMostWishedItems()[3].ProductName}', '{service.TopFiveMostWishedItems()[4].ProductName}'],";
            display += "datasets: [{";
            display += "label: 'Top 5 Most Wished Items',";
            display += $"data: ['{service.TopFiveMostWishedItems()[0].NumberOfWishes}', '{service.TopFiveMostWishedItems()[1].NumberOfWishes}', '{service.TopFiveMostWishedItems()[2].NumberOfWishes}', '{service.TopFiveMostWishedItems()[3].NumberOfWishes}', '{service.TopFiveMostWishedItems()[4].NumberOfWishes}'],";
            display += "backgroundColor: [";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)'";
            display += "],";
            display += "borderColor: [";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)',";
            display += "'rgb(39, 133, 10)'";
            display += "],";
            display += "borderWidth: 0";
            display += "}]";
            display += "},";
            display += "options:{";
            display += "scales:{";
            display += "yAxes: [{";
            display += "ticks:{";
            display += "beginAtZero: true";
            display += "},";
            display += "gridLines:{";
            display += "display: false";
            display += "}";
            display += "}],";
            display += "xAxes: [{";
            display += "gridLines:{";
            display += "display: false";
            display += "}";
            display += " }]";
            display += "}";
            display += "}";
            display += "});";
            display += "</script>";

            string items = "";
            foreach(SVCProduct pro in service.TopFiveMostWishedItems())
            {

                items += "<tr>";
                items += $"<td> {pro.ProductName}</td>";
                items += $"<td>{string.Format("{0:C}", pro.Price)}</td>";
                items += $"<td class='text-center'> {pro.NumberOfWishes}</td>";
                items += $"<td> <a href='WishingCustomers.aspx?ProdID={pro.ProductID}' class='edit'>Show Clients</a></td>";
                items += "</tr>";
            }
            top5selling.InnerHtml = items;
            top5Items.InnerHtml = display;
        }
        private void DisplayCategoryPerformance()
        {
            string drinks = $"<div class='progress-bar bg-success' role='progressbar' style='width: {Math.Ceiling(service.GetCategoryPerfomance("drink"))}%'>Drinks: {Math.Round(service.GetCategoryPerfomance("drink"), 2)}%</div>";
            drinksPeformance.InnerHtml = drinks;
            string snacks = $"<div class='progress-bar bg-warning' role='progressbar' style='width: {Math.Ceiling(service.GetCategoryPerfomance("snack"))}%'>Snacks: {Math.Round(service.GetCategoryPerfomance("snack"), 2)}%</div>";
            snacksPerformance.InnerHtml = snacks;
            string burgers = $"<div class='progress-bar bg-danger' role='progressbar' style='width: {Math.Ceiling(service.GetCategoryPerfomance("burger"))}%'>Burgers: {Math.Round(service.GetCategoryPerfomance("burger"), 2)}%</div>";
            burgersPerfomance.InnerHtml = burgers;
            string pizzas = $"<div class='progress-bar bg-info' role='progressbar' style='width: {Math.Ceiling(service.GetCategoryPerfomance("pizza"))}%'>Pizzas: {Math.Round(service.GetCategoryPerfomance("pizza"), 2)}%</div>";
            pizzasPerfomance.InnerHtml = pizzas;
            string others = $"<div class=progress-bar bg-secondary' role='progressbar' style='width: {Math.Ceiling(service.GetCategoryPerfomance("other"))}%'>Others: {Math.Round(service.GetCategoryPerfomance("other"), 2)}%</div>";
            othersPerformance.InnerHtml = others;
        }

        private void DisplayBuyersPerformance()
        {
            SVCUser bestBuyer = service.GetBestBuyer();
            SVCUser worstBuyer = service.GetWorstBuyer();

            topBuyerName.InnerText = $"{bestBuyer.FirstName} {bestBuyer.LastName}";
            topBuyerEmail.InnerText = bestBuyer.Email;
            topBuyerTransactions.InnerText = bestBuyer.NumberOfTransactions.ToString();
            topBuyerPoints.InnerText = bestBuyer.Points.ToString();

            worstBuyerName.InnerText = $"{worstBuyer.FirstName} {worstBuyer.LastName}";
            worstBuyerTransactions.InnerText = worstBuyer.NumberOfTransactions.ToString();
            worstBuyerPoints.InnerText = worstBuyer.Points.ToString();
            worstBuyerEmail.InnerText = worstBuyer.Email;
        }

        protected void itemPerfomance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(itemPerfomance.SelectedValue.Equals("1"))
            {
                DisplayItemPerfomance();
            }
            if (itemPerfomance.SelectedValue.Equals("2"))
            {
                DisplayByCategory("burger");
            }
            if (itemPerfomance.SelectedValue.Equals("3"))
            {
                DisplayByCategory("pizza");
            }
            if (itemPerfomance.SelectedValue.Equals("4"))
            {
                DisplayByCategory("drink");
            }
            if (itemPerfomance.SelectedValue.Equals("5"))
            {
                DisplayByCategory("snack");
            }
            if (itemPerfomance.SelectedValue.Equals("6"))
            {
                DisplayByCategory("other");
            }
        }
    }
}