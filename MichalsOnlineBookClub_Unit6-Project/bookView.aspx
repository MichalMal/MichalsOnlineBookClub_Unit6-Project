<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="bookView.aspx.cs" Inherits="bookView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">

    <h1>
        <asp:Label runat="server" Text="Book Name" ID="bookNameTitle" />
    </h1>
    <h2 style="color: #414141">
        <asp:Label runat="server" Text="Author Name" ID="bookAuthorTitle" />
    </h2>
    <div runat="server" id="averageStarRating"></div>
    <asp:Label runat="server" Text="Book Description" ID="bookDescriptionText" />
    <div class="row">
        <div class="col-md-6">
            <asp:Repeater ID="reviewsRepeter" runat="server"></asp:Repeater>
        </div>
        <div class="col-md-6">
            <!-- TODO: Add if statement for option to review  -->
        </div>
    </div>
    <!--
        <asp:Label runat="server" Text="reviewStarRatingStars" ID="reviewStarsRating"></asp:Label>
        <asp:Label runat="server" Text="reviewRatingText" ID="reviewRatingText"></asp:Label>
        -->
</asp:Content>

