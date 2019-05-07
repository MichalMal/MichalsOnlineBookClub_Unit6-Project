<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="usersList.aspx.cs" Inherits="usersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">

        <h1>User List</h1>
        <p>this is a mockup of a user table</p>
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Age</th>
                        <th>City</th>
                        <th>Country</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>Anna</td>
                        <td>Pitt</td>
                        <td>35</td>
                        <td>New York</td>
                        <td>USA</td>
                    </tr>
                </tbody>
            </table>


            <asp:GridView ID="GridView1" runat="server" DataSourceID="BookClubDB"></asp:GridView>


            <asp:SqlDataSource ID="BookClubDB" runat="server"></asp:SqlDataSource>


        </div>


</asp:Content>

