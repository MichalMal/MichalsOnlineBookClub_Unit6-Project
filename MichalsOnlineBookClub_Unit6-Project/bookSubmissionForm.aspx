<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="bookSubmissionForm.aspx.cs" Inherits="bookSubmissionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div runat="server" id="messageBox" class="alert alert-warning" visible="false">This is an Alert message</div>

    <h1>Book Submission</h1>
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label for="bookName">Book Name:</label>
                <input type="text" class="form-control" id="bookName" runat="server" required="required" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label for="author">Author Name:</label>
                <input type="text" class="form-control" id="author" runat="server" required="required" />
            </div>
        </div>
    </div>
    <div class="form-group">
        <label for="bookDescription">Date of Release:</label>
        <input type="text" class="form-control" id="bookDescription" runat="server" required="required" />
    </div>

    <asp:button runat="server" cssclass="btn btn-default" text="Submit" onclick="SubmitNewBook" />

</asp:Content>

