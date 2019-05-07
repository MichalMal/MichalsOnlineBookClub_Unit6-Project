<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="bookSubmissionForm.aspx.cs" Inherits="bookSubmissionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">

        <h1>Book Submission</h1>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="bookName">Book Name:</label>
                    <input type="text" class="form-control" id="bookName" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="author">Author Name:</label>
                    <input type="text" class="form-control" id="author" />
                </div>
            </div>
        </div>
        <div class="form-group">
            <label for="releaseDate">Date of Release:</label>
            <input type="date" class="form-control" id="releaseDate" />
        </div>
        <button type="submit" class="btn btn-default">Submit</button>

</asp:Content>

