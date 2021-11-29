<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="StatusZamowienia.aspx.cs" Inherits="Market365_3._0.StatusZamowienia.StronaZamowienia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Status Zamówienia nr: </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="basicContainer categoryCSSClass">
            <asp:label runat="server" ID="orderNrLabel" class="productNameLabel">Zamówienie nr [nr]</asp:Label>
    </div>

    <div class="basicContainer">
        <div ID="placeholderBootstrap">
            <div class="gridContainer">
                <div class="listElem gridBox-1">
                    <img runat="server" src="~/images/150x150.png" class="productImage"/>
                </div>

                <div class="listElem nameTag gridBox-2">
                    <div class="containerElement">
                        <asp:label runat="server" ID="productNameLabel" class="smallProductNameLabel">[Nazwa Produktu]</asp:Label><br />
                        <asp:label runat="server" ID="productPrice" class="productPricelabel">[cena]</asp:Label>
                    </div>
                </div>
                
                
                <div class="listElem gridBox-3">
                    <div class="containerElement">
                        <asp:label runat="server" ID="amountLabelPlaceholder" class="productPricelabel">[ilość]</asp:Label>
                    </div>
                </div>

                <div class="listElem gridBox-4">
                    <div class="containerElement">
                        <asp:label runat="server" ID="priceLabelPlaceholder" class="productPricelabel">[wartość]</asp:Label>
                    </div>
                </div>
            </div>


            <!--
                Do usunięcia
                -->


            <div class="gridContainer">
                <div class="listElem gridBox-1">
                    <img runat="server" src="~/images/150x150.png" class="productImage"/>
                </div>

                <div class="listElem nameTag gridBox-2">
                    <div class="containerElement">
                        <asp:label runat="server" ID="Label4" class="smallProductNameLabel">[Nazwa Produktu]</asp:Label><br />
                        <asp:label runat="server" ID="Label5" class="productPricelabel">[ilość]</asp:Label>
                    </div>
                </div>
                
                
                <div class="listElem gridBox-3">
                    <div class="containerElement">
                        <asp:label runat="server" ID="Label6" class="productPricelabel">[ilość]</asp:Label>
                    </div>
                </div>

                <div class="listElem gridBox-4">
                    <div class="containerElement">
                        <asp:label runat="server" ID="Label7" class="productPricelabel">[wartość]</asp:Label>
                    </div>
                </div>
            </div>

            <!--
                /Do usunięcia
                -->

            
            <asp:PlaceHolder runat="server" ID="ordersPlaceHolder">
                <!--
                Przerobic model ^ na dynamiczny placeholder;
                -->
            </asp:PlaceHolder>
        </div>
    </div>

    <div class="basicContainer">
        <asp:label runat="server" ID="Label2" class="productNameLabel">Status: [Status] </asp:Label><br />
        <asp:label runat="server" ID="Label1" class="productNameLabel">Wartość zamówienia:</asp:Label><br />
        <asp:label runat="server" ID="Label3" class="productPriceLabel">[wartość zamówienia]</asp:Label><br />
    </div>

    <div class="basicContainer" ID="returnButtonStyle">
        <asp:Button runat="server" ID="returnToOrders" text="Powrót do zamówień" CssClass="Button" OnClick="returnToOrders_Click"/>
    </div>
</asp:Content>
