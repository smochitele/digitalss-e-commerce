<%@ Page Title="Products | DigitalSS" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="DSS_Website.Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Catalog | DigitalSS
</asp:Content>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/main.css">
    <link rel="stylesheet" href="../css/login.css">
    <script src="../script/scripts.js"></script>
    <link rel="stylesheet" href="css/imagehover.min.css">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <form id="buttons" runat="server">
        <asp:ScriptManager id="logManager" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <asp:UpdatePanel id="productsPanel" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                   <div class="row">
                       <div class="col-md-2">
                           <br/>
                           <br/>
                           <br/>
                           <h2 class="categories"> Categories</h2>
                           <div class="menu-items" runat="server">
                               <asp:LinkButton id ="btnBurgers" runat="server" text ="<i class='fas fa-hamburger' ></i>  Burgers" OnClick="btnBurgers_Click" class="btnItem"></asp:LinkButton>
                               <br />
                               <asp:LinkButton id = "btnPizzas" runat="server" text ="<i class='fas fa-pizza-slice'></i>  Pizzas" OnClick="btnPizzas_Click" class="btnItem"></asp:LinkButton>
                               <br />
                                <asp:LinkButton id ="btnDrinks" runat="server" text="<i class='fas fa-cocktail'></i>  Drinks" OnClick="btnDrinks_Click" class="btnItem"></asp:LinkButton>
                               <br />
                                <asp:LinkButton id ="btnSnack" runat="server" text=" <i class='fas fa-cookie-bite'></i>  Snacks" OnClick="btnSnack_Click" class="btnItem"></asp:LinkButton>
                                <br />
                              <asp:LinkButton id ="btnOthers" runat="server" text="<i class='fas fa-utensils'></i>  Others" OnClick="btnOthers_Click" class="btnItem"></asp:LinkButton>
                               <br />
                              <asp:LinkButton id ="btnViewAll" runat="server" text="<i class='fas fa-utensils'></i>  All Products" OnClick="btnViewAll_Click" class="btnItem"></asp:LinkButton>
                              <!--Adding and Removing from cart textfields-->
                              <asp:TextBox ID="txtAddToCart" runat="server" Visible="true" OnTextChanged="txtAddToCart_TextChanged" Style="width:0px; border-width:0px;"></asp:TextBox>
                           </div>
                       </div>
                       <div class="col-md-10">
                           <div class="container-fluid taps" id="burgers">
                               <br />
                               <br />
                               <br />
                               <br />
                               <div class="heads">
                                   <h2 class="text-center" id ="title" runat="server"> </h2>
                                   <div class="heads">
                                    <hr>
                                    
                                       <asp:DropDownList ID="ourdropdown" runat="server" class="btn btn-add sort" OnSelectedIndexChanged="ourdropdown_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="0">Sort By</asp:ListItem>
                                            <asp:ListItem Value="1"> Price Asc </asp:ListItem>
                                            <asp:ListItem Value="2"> Price Desc </asp:ListItem>
                                            <asp:ListItem Value="3"> Name A-Z</asp:ListItem>
                                            <asp:ListItem Value="4"> Name Z-A</asp:ListItem>
                                       </asp:DropDownList>
                                   
                               </div>
                               <br />
                               <div class="row" id="items" runat="server">
                              </div>
                            </div>
                        </div>
                   </div>
                </div>
                <script>
                    function addToCart(product) {
                        var string = product + '';
                        var tokens = string.split(".");
                        var ID = tokens[0];
                        var Qty = tokens[1];
                        document.getElementById('<%= txtAddToCart.ClientID %>').value = ID;
                        alert("Item has been added to cart...\nProduct ID: " + ID + "\nQuantity: " + Qty);
                    }
                </script>
             </ContentTemplate>
       </asp:UpdatePanel>
   </form>
</asp:Content>
