<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="userLogInForm.aspx.cs" Inherits="logInForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div runat="server" id="messageBox" class="alert alert-warning">this is an alert messaage.</div>
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
        <label>Remember me</label>
        <input type="checkbox" runat="server" id="rememberMe" />
    </div>
    <asp:Button runat="server" type="submit" CssClass="btn btn-default"></asp:Button>
</asp:Content>

