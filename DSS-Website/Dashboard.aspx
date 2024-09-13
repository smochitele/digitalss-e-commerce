<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DSS_Website.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="data" runat="server">
     <div class="heads">
        <h2 class="text-center">Dashboard</h2>
        <hr />
    </div>
    <br />
    <div class="container">
        <form id="menuDrop" runat="server">
           <div class="row">
               <div class="col-md-4">
                   <div class="dash-card text-center">        
                       <i class="fas fa-money-bill-wave"></i>
                       <asp:DropDownList ID="revenueMenu" runat="server" class="dropdowntype" OnSelectedIndexChanged="revenueMenu_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Enabled="true" Text="Revenue" Value="-1" class="dropList"></asp:ListItem>
                            <asp:ListItem Text="Today" Value="1" class="dropList"></asp:ListItem>
                            <asp:ListItem Text="Last 7 Days" Value="2" class="dropList"></asp:ListItem>
                            <asp:ListItem Text="Last 30 days" Value="3" class="dropList"></asp:ListItem>
                           <asp:ListItem Text="Last 365 days" Value="4" class="dropList"></asp:ListItem>
                        </asp:DropDownList>
                   
                       <hr>
                       <h6 class="text-center" id="revenueDisplay" runat="server"></h6>
                   </div>
               </div>
               <div class="col-md-4">
                   <div class="dash-card text-center">
                       <i class="fas fa-paste"></i>
                            <asp:DropDownList ID="ordersMenu" runat="server" class="dropdowntype" OnSelectedIndexChanged="ordersMenu_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Enabled="true" Text="Orders" Value="-1" class="dropList"></asp:ListItem>
                            <asp:ListItem Text="Today" Value="1" class="dropList"></asp:ListItem>
                            <asp:ListItem Text="Last 7 days" Value="2" class="dropList"></asp:ListItem>
                            <asp:ListItem Text="Last 30 days" Value="3" class="dropList"></asp:ListItem>
                           <asp:ListItem Text="Last 365 days" Value="4" class="dropList"></asp:ListItem>
                        </asp:DropDownList>
                   
                       <hr>
                       <h6 class="text-center" id="ordersDisplay" runat="server"></h6>
                   </div>
               </div>
               <div class="col-md-4">
                   <div class="dash-card" style="padding: 8.5px 0px !important;">
                       <h5 class="text-center" style="font-size: 18px !important;"><i class="fas fa-user"></i>Users</h5>
                       <hr>
                       <h6 class="text-center" id="users" runat="server"></h6>
                   </div>
               </div>
           </div>
       </form>
    </div>
   <div class="row">
        <div class="col-md-6 ">
            <canvas id="revenue" class="shadow-sm"></canvas>
        </div>
        <div class="col-md-6">
            <canvas id="orders" class="shadow-sm"></canvas>
        </div>
        <div class="col-md-6">
            <canvas id="topselling" class="shadow-sm"></canvas>
        </div>
        <div class="col-md-6">
            <p>Category Sales Contribution(%)</p>
            <canvas id="active" class="shadow-sm">
                
            </canvas>
        </div>
     </div>
    <div id="chartsDisplay" runat="server">

    </div>
</asp:Content>
