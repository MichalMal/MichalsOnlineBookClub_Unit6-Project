<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="bookCollection.aspx.cs" Inherits="bookCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <h1>List of Books</h1>
    <asp:GridView runat="server" ID="bookList" CssClass="table table-bordered table-responsive">
    </asp:GridView>
    
    <a class="btn btn-success" role="button" href="bookSubmissionForm.aspx">Submit a new Book?</a>
</asp:Content>

