<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="bookView.aspx.cs" Inherits="bookView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div runat="server" id="messageBox" class="alert alert-warning" visible="false">This is an Alert message</div>

    <h1>
        <asp:label runat="server" text="Book Name" id="bookNameTitle" />
    </h1>
    <h2 style="color: #414141">
        <asp:label runat="server" text="Author Name" id="bookAuthorTitle" />
    </h2>
    <div runat="server" id="averageStarRating"></div>
    <asp:label runat="server" text="Book Description" id="bookDescriptionText" />
    <div class="row">
        <div class="col-md-6">
            <h3>Reviews</h3>
            <asp:repeater id="reviewsRepeter" runat="server">
                <ItemTemplate>
                    <div style="border: 1px solid #414141; padding: 15px">
                        <div id="ratingOutput"><%# CreateStarsReview(Eval("rating")) %></div>
                        <div id="descriptionOutput" runat="server"><%# Eval("ratingDescription") %></div>
                    </div>
                 </ItemTemplate>
            </asp:repeater>

        </div>
        <div class="col-md-6">
            <% if (Request.Cookies["LoggedIn"] == null || Request.Cookies["LoggedIn"] != null && Request.Cookies["LoggedIn"].Value == "false")
                { %>
            <h2>Log In To Submit a Review For this book</h2>
            <% }
                else
                { %>
            <% if (CheckUserForReviews())
                { %>
            <h2>You have Already Reviewed This Book</h2>
            <% }
                else
                { %>
            <h2>Submit a Review of your own</h2>
            <div class="form-group">
                <label for="rating">Rating out of 5:</label>
                <select class="form-control" id="reviewRating" runat="server">
                    <option value="" disabled="disabled" selected="selected">Choose your option</option>
                    <option value="0">0</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                </select>
            </div>
            <div class="form-group">
                <label for="reviewDescription">Review Description:</label>
                <input type="text" class="form-control" id="rewiewDescription" runat="server" required="required" />
            </div>

            <asp:button runat="server" cssclass="btn btn-default" text="Submit" onclick="SubmitNewBook" />

            <% } %>
            <% } %>
        </div>
    </div>
    <!--
        <asp:Label runat="server" Text="reviewStarRatingStars" ID="reviewStarsRating"></asp:Label>
        <asp:Label runat="server" Text="reviewRatingText" ID="reviewRatingText"></asp:Label>
        -->
</asp:Content>

