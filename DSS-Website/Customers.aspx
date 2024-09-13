<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="DSS_Website.Customers" %>
<asp:Content ID="Customers" ContentPlaceHolderID="data" runat="server">
        <div class="heads">
        <h2 class="text-center">Customers</h2>
        <hr />
        <a href="AddUser.aspx" class="btn btn-add"><i class="fas fa-user-plus"></i>Add User</a>
        <a href="mailto:" class="btn btn-add" id="contactAll" runat="server"><i class="fas fa-paper-plane"></i>Contact All</a>
    </div>
    <br />
    <table class="our-table" id="our_table">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Active</th>
                    <th>Transactions</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <div id="clients" runat="server">

                </div>
            </tbody>
        </table>
</asp:Content>
