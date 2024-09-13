<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="DSS_Website.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="data" runat="server">
        <div class="heads">
            <h2 class="text-center">Add User</h2>
            <hr />
        </div>
             <div class="add-user">
                <form runat="server">
                    <div class="input-register">
                        <label for="name">First Name</label>
                        <input type="text" name="name" id="name" runat="server">
                    </div>
                    <div class="input-register">
                        <label for="lastname">Last Name</label>
                        <input type="text" name="lastname" id="lastname" runat="server">
                    </div>
                    <div class="input-register">
                        <label for="email">Email</label>
                        <input type="email" name="email" id="email" runat="server">
                    </div>
                    <div class="input-register">
                        <label for="password">Password</label>
                        <input type="password" name="password" id="password" runat="server">
                    </div>
                    <div class="input-add">
                        <label for="">Type</label>
                        <select name="Type" id="type" runat="server">
                            <option value="0">Choose</option>
                            <option value="1">Customer</option>
                            <option value="2">Employee</option>
                            <option value="3">Admin</option>
                        </select>
                    </div>
                    <br>
                    <div class="input-register">
                        <asp:Button class="btnChanges" ID="btnAddUser" runat="server" Text="ADD USER" OnClick="btnAddUser_Click" />
                    </div>
                </form>
          </div>
</asp:Content>
