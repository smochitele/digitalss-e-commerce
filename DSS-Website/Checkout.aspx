<%@ Page Title="" Language="C#" MasterPageFile="~/RootLayout.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="DSS_Website.Checkout"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Checkout | DigitalSS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/main.css">
    <link rel="stylesheet" href="../css/admin.css">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src="../script/scripts.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="checkout-page">
        <div class="container">
            <div class="row">
                <div class="col-md-7">
                    <h3>Your Billing Details</h3>
                    <div class="form-add">
                        <form action="">
                            <div class="input-add">
                                <label for="">First Name</label>
                                <input type="text" name="name" id="firstname" runat="server" readonly>
                            </div>
                            <div class="input-add">
                                <label for="">Last Name</label>
                                <input type="text" name="lastname" id="lastname" runat="server" readonly>
                            </div>
                            <div class="input-add">
                                <label for="">Email</label>
                                <input type="email" name="email" id="email" runat="server" readonly>
                            </div>
                            <div class="input-add">
                                <label for="">Location</label>
                                <select name="locationType" id="type" runat="server">
                                    <option value="-1">Choose</option>
                                    <option value="0">A Block</option>
                                    <option value="1">B Block</option>
                                    <option value="2">C Block</option>
                                    <option value="3">D Block</option>
                                    <option value="4">E Block</option>
                             
                                </select>
                                <input type="text" name="location" id="location" placeholder="Specify(e.g E Les Foyer)" runat="server">
                            </div>
                        </form>
                    </div>
                </div>
                <div class="col-md-5">
                    <h3 id="totalHead" runat="server">Cart Total</h3>
                    <div class="cart-total">
                        <table>
                            <thead class="text">
                                <tr>
                                    <th>Products</th>
                                    <th>Price</th>
                                </tr>
                                <tbody class="text p-4">
                                    <div id="tableProducts" runat="server">
                                        <tr>
                                            <td>
                                                Pizza Cheese Burger x 2
                                            </td>
                                            <td>R200</td>
                                        </tr>
                                    </div>
                                    <br/>
                                    <div id="costs" runat="server">

                                    </div>
                                </tbody>
                            </thead>
                        </table>
                    </div>
                    <div class="payment-method my-5" style="margin-top:-50px;">
                        <h3>Payment Method</h3>
                        <form runat="server">
                        <div class="input-payment">
                            <asp:CheckBox ID="chkPaymentMethodCash" runat="server" />
                            Cash on Delivery
                        </div>
                        <div class="input-payment">
                            
                           <!-- <button id="fundi" data-toggle="modal" data-target="#ouraddmodal">Fundi</button> -->
                        </div>
                        <!-- The modal for getting from user related to the Fundi card -->
                        <div class="modal fade" id="ouraddmodal" tabindex="-1" role="dialog" aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-scrollable" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalScrollableTitle">Add Card</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                              </button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-add">
                                            <form action="">
                                                <div class="input-add">
                                                    <label for="">First Name</label>
                                                    <input type="text" name="name" id="name" runat="server">
                                                </div>
                                                <div class="input-add">
                                                    <label for="">Fundi Card Number</label>
                                                    <input type="text" name="cardnumber" id="cardnumber" runat ="server">
                                                </div>
                                                <div class="input-add">
                                                    <label for="">Pin </label>
                                                    <input type="password" name="pin" id="pin" runat="server">
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-add" data-dismiss="modal">Add Card</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br>
                          <div class="input-payment">
                            <button class="order" onclick="order();">Place Order</button>
                          </div>
                      </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
