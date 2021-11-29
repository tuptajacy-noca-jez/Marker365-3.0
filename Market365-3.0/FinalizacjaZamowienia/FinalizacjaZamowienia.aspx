<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="FinalizacjaZamowienia.aspx.cs" Inherits="Market365_3._0.Finalizacja_zamówienia.FinalizacjaZamowienia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Style/produktStyle.css" rel="stylesheet" type="text/css">
    <title>Dziękujemy za zakupy!</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="listElem productPricelabel" style="margin-top:12pt;">
        <div style="margin:auto 0;">
            <p>Dziekujemy za złożenie zamówienia.</p>
            <p>Twoje zamówienie zostało przekazane do realizacji. <br/>Status możesz sprawdzić w zakładce "Zamówienia"</p>
        </div>

        <div style="margin-left:40pt;">
            <img runat="server" src="~/images/thanks-man.jpg" />
        </div>
    </div>

    <div ID="returnButtonStyle">
           <asp:Button runat="server" ID="orders" Text="Sprawdź szczegóły zamówienia" OnClick="orders_Click" Class="Button"/>
           <asp:Button runat="server" ID="returnButton" Text="Powrót na stronę główną" OnClick="returnButton_Click" Class="Button"/>
    </div>
</asp:Content>
