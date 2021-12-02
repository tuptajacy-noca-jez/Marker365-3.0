<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="Market365_3._0.Administrator.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Market365 | Administrator</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="bestdeals">
<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <LayoutTemplate>
                <div class="produktDeals">
                <table class="tbCenter" runat="server" id="tblProducts">
                    <tr runat="server">
                        <th runat="server"></th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
                </div>
            </LayoutTemplate>
            <EmptyDataTemplate>
                <span>Nie zostały zwrócone żadne dane.</span>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td class ="produktDeals" runat="server" onclick="produktDeals_Click">
                    <a href="../StronaProduktu/StronaProduktu.aspx/<%# Eval("id") %>">
                        <img height="100px" id="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" /><br />
                        <asp:Label ID="nazwaProduktu" runat="server" Text='<%# Eval("name") %>' Font-Bold="true" /><br />
                        <asp:Label ID="cenaProduktu" runat="server" Text='<%# Eval("price") %>' />&nbspzł/<asp:Label ID="Label1" runat="server" Text='<%# Eval("unit") %>' />
                     </a>
                </td>
            </ItemTemplate>
        </asp:ListView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP 10 [Id], [name], [image], [description], [price], [unit] FROM [products] ORDER BY NEWID()"></asp:SqlDataSource>
</div> 

        <div class="menu">
        <table>
            <tr>
                <td>
                    <asp:Button ID="ListaProdukt" runat="server" Text="Dodaj produkt" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="dodaj_Click" CssClass="button" BorderStyle="Solid" ToolTip="Dodaj produkty" />

                </td>


            </tr>

            <tr>
                <td>
                    <asp:Button ID="zamowieniaKlientow" runat="server" Text="Zamówienia Klientów" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="zamowieniaKlientow_Click" CssClass="button" BorderStyle="Solid" ToolTip="Zarządzaj zamówieniami klientów" />

                </td>


            </tr>

        </table>
    </div>





</asp:Content>
