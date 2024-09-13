<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.master" AutoEventWireup="true" CodeBehind="WishingCustomers.aspx.cs" Inherits="DSS_Website.WishingCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="data" runat="server">
    <div class="heads">
        <h3 class="text-center" >Customers Wished for "<span id="wishedItem" runat="server">Burger Cheese</span>"</h3>
        <hr />
        <a href="h" class="btn btn-add"  id="contactAll" runat="server"><i class="fas fa-paper-plane"></i>Contact All</a>
        <br />
    </div>
     <br />
    <table class="our-table">
         <thead>
             <tr>
                 <th>Client Name</th>
                 <th>Client Email</th>
                 <th>Action</th>
             </tr>
         </thead>
         <tbody>
             <div id="wishingCustomers" runat="server">

             </div>
         </tbody>
      </table>
</asp:Content>
