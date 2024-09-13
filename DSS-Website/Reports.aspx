<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="DSS_Website.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="data" runat="server">
    <div class="heads">
        <h2 class="text-center">Store Reports</h2>
        <hr />
        <br />
        <form id="invoicesForm" runat="server">
            <asp:DropDownList ID="itemPerfomance" runat="server" class="btn btn-add perfomance sort" AutoPostBack="true" OnSelectedIndexChanged="itemPerfomance_SelectedIndexChanged">
                <asp:ListItem Value="-1">Item Perfomance</asp:ListItem>
                <asp:ListItem Value="1">Most/Least Selling - Overall</asp:ListItem>
                <asp:ListItem Value="2">Most/Least Selling - Burger</asp:ListItem>
                <asp:ListItem Value="3">Most/Least Selling - Pizza</asp:ListItem>
                <asp:ListItem Value="4">Most/Least Selling - Drink</asp:ListItem>
                <asp:ListItem Value="5">Most/Least Selling - Snack</asp:ListItem>
                <asp:ListItem Value="6">Most/Least Selling - Other</asp:ListItem>
            </asp:DropDownList>      
        </form>    
    </div>
    <br />
    
    <div class="container">
        <div class="row">
           <div class="col-md-6">
               <div class="card mb-3 similar-product">
                   <div class="row no-gutters">
                       <div class="col-md-4" id="mostselling" runat="server">

                       </div>
                   </div>
               </div>
           </div>

           <div class="col-md-6">
              <div class="card mb-3 similar-product">
                <div class="row no-gutters">
                   <div class="col-md-4" id="worstselling" runat="server">
                       
                   </div>
                   </div>
               </div>
          </div>
        </div>
        <br />
        <h4>Wishlisted Items</h4>
        <div class="row">
            
            <div class="col-md-6">
                <canvas id="wishedItems">

                </canvas>
            </div>
            <div class="col-md-6">
                <table class="our-table reports-table">
                    <thead>
                        <tr>
                            <th>Product Name</th>
                            <th>Price</th>
                            <th>Wishes</th>
                            <th>Wished By</th>
                        </tr>
                    </thead>
                    <tbody id="top5selling" runat="server">

                    </tbody>
                </table>
            </div>
        </div>
        <br />

        
        <div class="row">
          <div class="col-md-12">
               <h4>Category Perfomance</h4>
               <div class="performance">

                   <div class="progress" style="height: 30px;" id="drinksPeformance" runat="server">
                       
                   </div>
               </div>
               <br>
               <div class="performance">
                   <div class="progress" style="height: 30px;" id="pizzasPerfomance" runat="server">
                       
                   </div>
               </div>
               <br>
               <div class="performance">
                   <div class="progress" style="height: 30px;" id="burgersPerfomance" runat="server">
                       
                   </div>
               </div>
               <br>
               <div class="performance">
                   <div class="progress" style="height: 30px;" id="snacksPerformance" runat="server">
                       
                   </div>
               </div>
               <br>
               <div class="performance">
                   <div class="progress" style="height:30px;" id="othersPerformance" runat="server">
                       
                   </div>
               </div>
           </div>
        <div class="container">
            <div class="row">
                
               <div class="col-md-12">
                   <br />
                    <h4 id="averageUsers" runat="server">Average Users Per Day: </h4>
                   </div>
            </div>
        </div>
         </div>
           <div class="row">
                <div class="col-md-6">
                    <div class="buying-user">
                        <h5>Top Buyer</h5>
                        <h6 id="topBuyerName" runat="server">Khutso Lebea</h6>
                        <p id="topBuyerEmail" runat="server">email@email.com</p>
                        <hr>
                        <div class="row">
                            <div class="col-md-6">
                                <h6 id="info">Transactions</h6>
                                <p id="topBuyerTransactions" runat="server">5</p>
                            </div>
                            <div class="col-md-6">
                                <h6 id="info">Points</h6>
                                <p id="topBuyerPoints" runat="server">R123</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="buying-user">
                        <h5>Worst Buyer</h5>
                        <h6 id="worstBuyerName" runat="server">Khutso Lebea</h6>
                        <p id="worstBuyerEmail" runat="server">email@email.com</p>
                        <hr class="text-center">
                        <div class="row">
                            <div class="col-md-6">
                                <h6 id="info">Transactions</h6>
                                <p id="worstBuyerTransactions" runat="server">5</p>
                            </div>
                            <div class="col-md-6">
                                <h6 id="info">Points</h6>
                                <p id="worstBuyerPoints" runat="server">R123</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    <div id="top5Items" runat="server">

    </div>

    <%--<script>
        var wishes = document.getElementById("wishedItems").getContext("2d");
        var wishedItems = new Chart(wishes, {
                type: 'bar',
                data: {
                    labels: ['Burger Cheese', 'Pizza Chesse', 'Coke', 'Fries', 'Cakes'],
                    datasets: [{
                        label: 'Most Wished Items',
                        data: [23, 10, 17, 30, 20],
                        backgroundColor: [
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)'
                        ],
                        borderColor: [
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)',
                            'rgb(39, 133, 10)'
                        ],
                        borderWidth: 0
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            },
                            gridLines: {
                                display: false
                            }
                        }],
                        xAxes: [{
                            gridLines: {
                                display: false
                            }
                        }]
                    }
                }
            });
    </script>--%>

</asp:Content>
