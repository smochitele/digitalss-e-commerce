<%@ Page Title="Register | DigitalSS" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DSS_Website.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Register | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/login.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="login-section">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12 login-bg">
                    <form runat="server" class="register-form m-auto">
                        <h2>Register</h2>
                        <div class="input-register">
                            <label for="firstname" id="lblFirstName" runat="server">First Name</label>
                            <input type="text" name="firstname" id="firstname" runat="server">
                        </div>
                        <div class="input-register">
                            <label for="lastname" id ="lblLastName" runat="server">Last Name</label>
                            <input type="text" name="lastname" id="lastname" runat="server">
                        </div>
                        <div class="input-register">
                            <label for="email" id="lblEmail" runat="server">Email</label>
                            <input type="email" name="email" id="email" runat="server">
                        </div>
                        <div class="input-register">
                            <label for="password" id="lblPassword" runat="server">Password</label>
                            <input type="password" name="password" id="password" pattern= ".{10,15}" title="Passwords must be 10 to 15 characters" required runat="server">
                        </div>
                        <div class="input-register">
                            <label for="password" id="lblConfirmPass" runat="server">Confirm Password</label>
                            <input type="password" name="password_1" id="password_1" runat="server">
                        </div>
                        <div class="input-register">
                            <asp:Button ID="btnRegister" class="our-button" runat="server" Text="Register" OnClick="btnRegister_Click" />
                        </div>
                        <span id="register"><a href="Login.aspx">Have an account? Login</a></span>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
