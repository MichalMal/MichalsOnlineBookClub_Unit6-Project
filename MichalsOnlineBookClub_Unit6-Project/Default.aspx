<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Templates_Index" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    
    <title>Michal's Online Book Club</title>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
        <div class="row">
            <div class="col-sm-4 text-right vcenter">
                <h2 class="margin">Welcome To Michal's Online Book Club</h2>
                <b>Where you can rate your collection of books that you enjoyed reading!</b>
            </div><!--
            --><div class="col-sm-8 vcenter">
                <div id="banner-carousel" class="carousel slide" data-ride="carousel">
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <div class="col-sm-4">
                                <img src="Images/51A685AMYoL._SL160_.jpg" />
                            </div>
                        </div>
                        <div class="item">
                            <img src="Images/51wTLf4JVwL._SL160_.jpg" />
                        </div>
                        <div class="item">
                            <img src="Images/41u9Jedk-mL._SL160_.jpg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

