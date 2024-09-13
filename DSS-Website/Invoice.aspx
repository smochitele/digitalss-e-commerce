<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="DSS_Website.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Invoice | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/main.css">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src="../script/scripts.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="cart-header">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>Products In Your Cart. Enjoy!</h2>
                </div>
            </div>
        </div>
    </div>
    <div class="items-selected">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <p>A copy of your invoice can be found on your desktop</p>
                    <table>
                        <thead class="table-card">
                            <tr class="text-center">
                                <th>ID</th>
                                <th>&nbsp;</th>
                                <th>Product</th>
                                <th>Price</th>
                                <th>Quantity</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <div id="items" runat="server">

                            </div>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="cart-money">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <h4>Points Gained</h4>
                    <hr>
                    <h5 id="points" runat="server"></h5>
                </div>
                <div class="col-md-4">
                    <h4>Tax Charged</h4>
                    <hr>
                    <h5 id="tax" runat="server"></h5>
                </div>
                <div class="col-md-4">
                    <h4> Cart Summary</h4>
                    <hr>
                    <h5 id="total" runat="server"></h5>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-6">
                    <a href="Home.aspx" id="checkout">Go Back Home</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
