<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="DSS_Website.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Search Results | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
        <div class="container" id="burgers">
            <br />
            <br />
            <br />
            <br />
            <div class="heads">
                <h2 class="text-center" id ="title" runat="server">Search Results</h2>
                    
                <hr>
            </div>
            <br />
            <div class="row" id="items" runat="server">
                <form runat="server">
                    <!--Adding and Removing from cart textfields-->
                <asp:TextBox ID="txtAddToCart" runat="server" Visible="true" OnTextChanged="txtAddToCart_TextChanged" Style="width:0px; border-width:0px;"></asp:TextBox>
                </form>
                
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
</asp:Content>
