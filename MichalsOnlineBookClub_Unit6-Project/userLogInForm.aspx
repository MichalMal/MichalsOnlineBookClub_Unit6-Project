<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="userLogInForm.aspx.cs" Inherits="logInForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div runat="server" id="messageBox" class="alert alert-warning" visible="false">This is an Alert message</div>
    <h1>User Log-In</h1>
    <div class="form-group">
        <label for="email">Email address:</label>
        <input type="email" class="form-control" id="email" runat="server" />
    </div>
    <div class="form-group">
        <label for="pwd">Password:</label>
        <input type="password" class="form-control" id="pwd" runat="server" />
    </div>
    <div class="checkbox">
        <label><input type="checkbox" runat="server" id="rememberMe" />Remember me</label>
    </div>
    <asp:Button runat="server" OnClick="UserLoginSubmit" CssClass="btn btn-default" Text="Log In"></asp:Button>
    <a runat="server" href="~/forgotPasswordForm.aspx" class="btn btn-warning">Forgot Password?</a>

</asp:Content>

