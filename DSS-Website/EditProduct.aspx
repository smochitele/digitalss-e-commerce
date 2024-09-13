<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="DSS_Website.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="data" runat="server">
         <div class="heads">
        <h2 class="text-center">Edit Product</h2>
        <hr />
     </div>

      <div class="add-user">
         <form runat="server">
             <div class="input-register">
                 <label for="name">Name</label>
                 <input type="text" name="name" id="name" runat="server">
             </div>

             <div class="input-register">
                 <label for="price">Price</label>
                 <input type="number" name="price" id="price" runat="server">
             </div>
             <div class="input-register">
                 <label for="quantity">Quantity</label>
                 <input type="number" name="quantity" id="quantity" runat="server">
             </div>
             <div class="input-register">
                 <label for="discount">Discount</label>
                 <input type="number" name="discount" id="discount" runat="server">
             </div>
             <div class="input-register">
                 <label for="healthiniess">Healthiness</label>
                 <input type="number" name="healthiness" id="healthiness" runat="server">
             </div>
             <div class="input-register">
                 <label for="tags">Tags</label>
                 <input type="text" name="tags" id="tags" runat="server">
             </div>
             <div class="input-register">
                 <label for="preparation">Preparation Time</label>
                 <input type="text" name="preparation" id="preparation" runat="server">
             </div>
             <div class="input-add">
                 <label for="">Category</label>
                 <select name="Type" id="type" runat="server">
                     <option value="0">Choose</option>
                     <option value="1">Pizza</option>
                     <option value="2">Burger</option>
                     <option value="3">Drinks</option>
                     <option value="4">Snack</option>
                     <option value="5">Other</option>
                     
                 </select>
             </div>
             <div class="input-register">
                 <label for="description">Description</label>
                 <input type="text" name="description" id="description" runat="server">
             </div>

             <div class="input-register">
                 <label for="image">Choose image</label>
                 <input type="file" name="image" id="image" runat="server">
             </div>

             <br>
             <div class="input-register">
                <asp:Button  class="btnChanges" ID="btnSubmit" runat="server" Text="SUBMIT CHANGES" OnClick="btnSubmit_Click" />
             </div>
         </form>
     </div>
</asp:Content>
