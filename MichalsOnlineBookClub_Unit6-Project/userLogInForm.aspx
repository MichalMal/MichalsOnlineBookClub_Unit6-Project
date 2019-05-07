<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="userLogInForm.aspx.cs" Inherits="logInForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
        <h1>User Log-In</h1>
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
    </div></asp:Content>

