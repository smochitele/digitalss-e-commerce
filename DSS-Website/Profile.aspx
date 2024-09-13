<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DSS_Website.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Your Profile | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/main.css">
    <link rel="stylesheet" href="../css/admin.css">
    <link rel="stylesheet" href="../css/user.css">
    <link rel="stylesheet" href="css/imagehover.min.css">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src="../script/scripts.js"></script>
    <link rel="stylesheet" href="../css/login.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <br />
    <section class="container">
        <div class="user-left">
            <div class="user-card" style="height:435.5px;">
                <img src="../images/user.png" alt="">
                <h3 id="displayFirstName" runat="server">name</h3>
                <h5 id ="displayLastName" runat="server">lastname</h5>
                <hr>
                <div class="container my-3">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Transactions<i class="fas fa-chart-pie"></i></p>
                            <p id ="displayTransactions" runat="server">nTransactions</p>
                        </div>
                        <div class="col-md-4">
                            <p>Points<i class="fas fa-coins"></i></p>
                            <p id="displayPoints" runat="server">20</p>
                        </div>
                        <div class="col-md-4">
                            <p>Credit<i class="fas fa-credit-card"></i></p>
                            <p id="displayCredit" runat="server">R123</p>
                        </div>
                    </div>
                    <div class="input-info">
                        <button class="our-btn" ID="btnSignOut" runat="server" onclick="signOut();">SIGN OUT</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="user-right" style="height:20px;">
            <div class="container">
                <div class="user-options">
                    <div class="taps-buttons">
                        <button onclick="openTab('settings')">Edit My Profile</button>
                        <button onclick="openTab('transactions')">Transaction History</button>
                        <button onclick="openTab('wishlist')">My Wishlist</button>
                    </div>
                    <div id="settings" class="taps">
                      <form  runat="server">
                        <div class="user-info"> 
                                <div class="input-info">
                                    <label for="name">First Name</label>
                                    <input type="text" name="name" id="firstname" runat="server" readonly>
                                </div>
                                <div class="input-info">
                                    <label for="lastname">Last Name</label>
                                    <input type="text" name="lastname" id="lastname" runat="server" readonly>
                                </div>
                                <div class="input-info">
                                    <label for="password">Change Password</label>
                                    <input type="password" name="password" id="password1" runat="server">
                                </div>
                                   <div class="input-info">
                                    <label for="password">Confirm New Password</label>
                                    <input type="password" name="password" id="password2" runat="server">
                                </div>
                                <div class="input-info">
                                        <asp:Button class="our-btn updateButton" ID="btnUpdate" runat="server" Text="UPDATE PROFILE"  OnClick="btnUpdate_Click"/>
                                </div>
                            </div>
                      </form>
                    </div>
                    <div id="transactions" class="taps" style="display: none;">
                         <div class="container">
                            <div class="row">
                                <div class="col-md-12">
                                    <br>
                                    <table class="user-table" id="our_table">
                                        <thead>
                                            <tr>
                                                <th>Order ID</th>
                                                <th>Date</th>
                                                <th>Items Bought</th>
                                                <th>Total Cost</th>
                                            </tr>
                                        </thead>
                                        <tbody id="transHistory" runat="server">

                                        </tbody>
                                    </table>
                             </div>
                        </div>
                    </div>
                </div>
                <div id="wishlist" class="taps" style="display: none;">
                       <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <br>
                                <table class="user-table" id="our_table">
                                    <thead>
                                        <tr>
                                            <th>No</th>
                                            <th>Product</th>
                                            <th>Price</th>
                                        </tr>
                                    </thead>
                                    <tbody id="wishItems" runat="server">

                                    </tbody>
                                </table>
                            </div>
                        </div>
                       </div>
                    </div>
            </div>
        </div>
    </section>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
