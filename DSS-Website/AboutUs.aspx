<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="DSS_Website.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="css/login.css">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="about-us">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>ABOUT US</h2>
                </div>
            </div>
        </div>
    </div>

    <div class="content-us ">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <img src="../images/about.jpg" alt="">
                </div>
                <div class="col-md-6 my-5">
                    <div class="info">
                        <h1>ABOUT US</h1>
                        <h2>Get A Glimpse of What We Do</h2>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex blanditiis consequuntur unde beatae magnam culpa repellat doloremque quasi quas officiis!</p>

                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex blanditiis consequuntur unde beatae magnam culpa repellat doloremque quasi quas officiis!</p>
                        <p>Lorem ipsum dolor si Expedita laudantium fugiat magni iusto</p>
                    </div>
                    <div class="media">
                        <h5>Follow Us</h5>
                        <a href=""><i class="fab fa-google-plus"></i></a>
                        <a href=""><i class="fab fa-facebook"></i></a>
                        <a href=""><i class="fab fa-twitter"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
