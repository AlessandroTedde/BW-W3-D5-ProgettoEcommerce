<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="BW_W3_D5_ProgettoEcommerce.Carrello" %>

<asp:Content ID="CartContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Carrello</h2>
    <asp:GridView ID="CartGrid" runat="server" AutoGenerateColumns="False" ShowFooter="True" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:ImageField DataImageUrlField="ImmagineUrl" ControlStyle-Height="110" ItemStyle-CssClass="pe-4" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" HeaderStyle-CssClass="pt-3 pe-4" ItemStyle-CssClass="pt-2 pe-4">
                <HeaderStyle CssClass="pt-3 pe-4"></HeaderStyle>

                <ItemStyle CssClass="pt-2 pe-4"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Prezzo" HeaderText="Prezzo">
                <HeaderStyle CssClass="pt-3 pe-4"></HeaderStyle>

                <ItemStyle CssClass="pt-2 pe-4"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Quantita" HeaderText="Quantità">
                <HeaderStyle CssClass="pt-3 pe-4"></HeaderStyle>

                <ItemStyle CssClass="pt-2 pe-4"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Subtotale" HeaderStyle-CssClass="pt-3 pe-4" ItemStyle-CssClass="pt-2">
                <ItemTemplate>
                    <%# Convert.ToDouble(Eval("Prezzo")) * Convert.ToInt32(Eval("Quantita")) + "€" %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    <div>
        <asp:Label ID="TotalLabel" CssClass="fs-3" runat="server" Text="" />
    </div>
    <p class="d-inline-block fs-3 me-4 mt-3"><asp:Label ID="EmptyCartLabel" runat="server" Text="Il carrello è vuoto" Visible="False" /></p>
    <asp:Button ID="EmptyCartButton" CssClass="btn btn-primary mt-3 me-3" runat="server" Text="Svuota carrello" OnClick="EmptyCartButton_Click" />
    <asp:Button ID="ContinueShoppingButton" CssClass="btn btn-primary mt-3" runat="server" Text="Continua a fare shopping" OnClick="ContinueShoppingButton_Click" />
    <asp:Label ID="ErrorLabel" runat="server" Visible="False" />
    <asp:Label ID="SuccessLabel" runat="server" Visible="False" />
</asp:Content>
