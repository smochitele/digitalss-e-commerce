<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.master" AutoEventWireup="true" CodeBehind="ProductsAvailable.aspx.cs" Inherits="DSS_Website.ProductsAvailable" %>
<asp:Content ID="products" ContentPlaceHolderID="data" runat="server">
    <div class="heads">
        <h2 class="text-center">Products In Store</h2>
        
        <hr />
        <a href="AddProduct.aspx" class="btn btn-add"><i class="fas fa-cart-plus"></i>Add Product</a>
    </div>
    <br />
   <table class="our-table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Category</th>
                    <th>Bought</th>
                    <th>Remainig</th>
                    <th>On Sale</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <div id="productsAvail" runat="server">

                </div>
            </tbody>
        </table>    
</asp:Content>
