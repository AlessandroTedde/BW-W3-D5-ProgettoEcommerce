<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="BW_W3_D5_ProgettoEcommerce.Dettaglio" %>


<asp:Content ID="DetailContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="itemTitle" class="text-center display-3 mt-2" runat="server"></h2>
        <div id="detailsBox" class="container text-center" runat="server">
        </div>
        <div class="container text-center">
                <asp:Button ID="Button1" CssClass="btn btn-outline-success me-3" runat="server" Text="Aggiungi al Carrello" OnClick="addToCart_Click" />
                <asp:Button ID="Button2" CssClass="btn btn-outline-warning" runat="server" Text="Vai al Carrello" OnClick="goToCart_Click" />
           </div>
        <p id="addedMessage" class="mt-2 fs-2 text-success text-center" runat="server"></p>
    </asp:Content>
