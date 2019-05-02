<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="logInForm.aspx.cs" Inherits="Views_logInForm" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div class="form-group">
        <label for="email">Email address:</label>
        <input type="email" class="form-control" id="email" />
    </div>
    <div class="form-group">
        <label for="pwd">Password:</label>
        <input type="password" class="form-control" id="pwd" />
    </div>
    <div class="checkbox">
        <label>
            <input type="checkbox" />
            Remember me</label>
    </div>
    <button type="submit" class="btn btn-default">Submit</button>
</asp:Content>

