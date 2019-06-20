<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="forgotPasswordForm.aspx.cs" Inherits="forgotPasswordForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">

    <div runat="server" id="messageBox" class="alert alert-warning" visible="false">This is an Alert message</div>
    <h1>User Log-In</h1>
    <div class="form-group">
        <label for="email">Email address:</label>
        <input type="email" class="form-control" id="email" runat="server" />
    </div>
    <div class="form-group">
        <label for="favouriteBook">Favourite Book Ever:</label>
        <input type="text" class="form-control" id="favouriteBook" runat="server" />
    </div>
    <div class="form-group">
        <label for="pwd">Password:</label>
        <input type="password" class="form-control" id="pwd" runat="server" />
    </div>
    <div class="form-group">
        <label for="cpwd">Confirm Password:</label>
        <input type="password" class="form-control" id="cpwd" runat="server" />
    </div>
    <asp:Button runat="server" OnClick="UserResetPassword" CssClass="btn btn-default" Text="Reset Password"></asp:Button>

</asp:Content>

