<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DSS_Website.Home" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Home | DigitalSS
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
    <div class="sliding">
        <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
                <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="images/header3.jpg" class="w-100" alt="...">
                    <div class="carousel-caption">
                        <h1>Order Here And Have It Delivered To You</h1>
                        <p>Specials are available</p>
                        <a href="#start" class="our-btn explore">CHECK THEM</a>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="images/header4.jpg" class="w-100" alt="...">
                    <div class="carousel-caption">
                        <h1>Convenient Shopping For Students</h1>
                        <p>Get your food delivered to you.</p>
                        <a href="#start" class="our-btn explore">EXPLORE</a>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="images/header2.jpg" class="w-100" alt="...">
                    <div class="carousel-caption">
                        <h1>Doing Grocery Has Never Been Easier</h1>
                        <p>Order food on the go</p>
                        <a href="#start" class="our-btn explore">BUY NOW </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
    <!-- Our Category Section with the most popular or availabe products in store -->
    <div class="products my-5" id="start">
        <div class="heads">
            <h1 class="text-center">Popular Meals</h1>
            <hr />
        </div>
        <div class="container px-0">
            <div class="row">
                <div class="col-md-4">
                    <div class="cards">
                        <a href="Catalog.aspx"><img src="https://images.unsplash.com/photo-1517093728432-a0440f8d45af?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1014&q=80" alt=""></a>
                    </div> 
                </div>
                <div class="col-md-4">
                    <div class="cards">
                        <a href="Catalog.aspx"><img src="https://images.unsplash.com/photo-1506354666786-959d6d497f1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80" alt=""></a>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="cards">
                         <a href="Catalog.aspx"><img src="https://images.unsplash.com/photo-1549892898-79ac97b31fb2?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80" alt=""></a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
