<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="userRegistrationForm.aspx.cs" Inherits="userRegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">

     <div runat="server" id="messageBox" class="alert alert-warning" visible="false">This is an Alert message</div>
    <h1>User Registration</h1>
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label for="fName">First Name:</label>
                <input type="text" class="form-control" id="fName" runat="server" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label for="lName">Last Name:</label>
                <input type="text" class="form-control" id="lName" runat="server" />
            </div>
        </div>
    </div>
    <div class="form-group">
        <label for="email">Email address:</label>
        <input type="email" class="form-control" id="email" runat="server" />
    </div>
    <div class="form-group">
        <label for="favouriteBook">Favourite Book:</label>
        <input type="text" class="form-control" id="favouriteBook" runat="server" />
    </div>
    <div class="form-group">
        <label for="dob">Date of Birth:</label>
        <input type="date" class="form-control" id="dob" runat="server" />
    </div>

    <div class="form-group">
        <label for="country">Country:</label>
        <select class="form-control" id="country" runat="server">
            <option value="" disabled="disabled" selected="selected">Choose your option</option>
            <option value="0">South Africa</option>
            <option value="1">USA</option>
            <option value="2">Germany</option>
            <option value="3">France</option>
            <option value="3">Poland</option>
            <option value="3">Japan</option>
        </select>
    </div>
    <asp:RadioButtonList ID="gender" runat="server" required="required">
        <asp:ListItem Value="M">Male</asp:ListItem>
        <asp:ListItem Value="M">Female</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />

    <div class="form-group">
        <label for="pwd">Password:</label>
        <input type="password" class="form-control" id="pwd" runat="server" />
    </div>
    <div class="form-group">
        <label for="cpwd">Confirm   Password:</label>
        <input type="password" class="form-control" id="cpwd" runat="server" />
    </div>
    <asp:button runat="server" cssClass="btn btn-default" text="Submit" OnClick="UserRegistrationSubmit" />
</asp:Content>

