<%@ Page Title="Login | DigitalSS" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DSS_Website.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Login | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/login.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
     <div class="login-section">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12 login-bg">
                    <form runat="server" class="login-form m-auto">
                        <h2 id="loginTitle" runat="server">Login</h2>
                        <div class="input-login">
                            <label for="username" id="lblUsername" runat="server">Username</label>
                            <input type="text" name="username" id="username" placeholder="Enter your email" runat="server">
                        </div>
                        <div class="input-login">
                            <label for="password" id="lblPassword" runat="server">Password</label>
                            <input type="password" name="password" id="password" placeholder="Enter your password" runat="server">
                        </div>
                        <span id="register"><a href="Register.aspx">Don't have account? Register</a></span>
                        <div class="input-login">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </div>
                        <div class="media">
                            <br />
                        </div>
                    </form>
                </div>
            </div>
        </div>
     </div>
</asp:Content>
