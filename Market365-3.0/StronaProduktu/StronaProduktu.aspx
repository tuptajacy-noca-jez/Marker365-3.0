<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="StronaProduktu.aspx.cs" Inherits="Market365_3._0.StronaProduktu.StronaProduktu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nazwa Produktu</title>
    <link href="../Style/produktStyle.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Container">
        <div class="productName">
            <asp:label runat="server" ID="productNameLabel" CssClass="productNameLabel">[Nazwa Produktu]</asp:Label>
            <img runat="server" src="~/resources/icons/heart.svg" onclick="" class="icons heartIcon"/>
        </div>
        <div class="Container">
            <div cssClass="KLDaneZamieszkania">
                <div class="leftContent">
                    
                </div>
                <div class="rightContent">
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
