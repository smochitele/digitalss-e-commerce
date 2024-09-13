<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="AboutProduct.aspx.cs" Inherits="DSS_Website.AboutProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    About Product | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/main.css">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
    <div class="about-product">
        <div class="container">
            <div class="row">
                <div class="col-md-7" id="productImage" runat="server">
                    <img src="../images/chicken.jpg" alt="" class="about-image">
                </div>
                <div class="col-md-5">
                    <div id="productInfo" runat="server">

                    </div>
                    <div>
                        <input type="number" name="quantity" id="quantity" min="1" max="5" value="1" runat="server">
                         Quantity
                        <hr>
                        <div class="buy-wish">
                            <asp:LinkButton id="buy" runat="server" class="addtocart" OnClick="buy_Click" text=" <i class='fa fa-shopping-cart'></i>  Add to Cart"></asp:LinkButton>
                            <asp:LinkButton id="wish" runat="server" class="addtowish" OnClick="wish_Click" text="<i class='fas fa-heart'></i>  Add To Wishlist"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <br>
        <div class="container">
            <br>
            <h4 class="display-5">What You May Also Like</h4>
            <div class="row" id="productSuggestions" runat="server">
  
            </div>
          </div>
    </form>
</asp:Content>
