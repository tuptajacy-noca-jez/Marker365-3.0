<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="StronaGlowna.aspx.cs" Inherits="Market365_3._0.StronaGlowna.StronaGlowna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Market365 - Strona Główna</title>
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
                    <asp:Button ID="sklep" runat="server" Text="Sklep" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="sklep_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przeglądaj produkty w sklepie" />

                </td>

                <td>
                    <asp:Button ID="koszyk" runat="server" Text="Koszyk" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="koszyk_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przejdź do swojego koszyka" />

                </td>

            </tr>

            <tr>
                <td>
                    <asp:Button ID="zamowienia" runat="server" Text="Zamówienia" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="zamowienia_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przeglądaj swoje zamówienia" />

                </td>

                <td>
                    <asp:Button ID="mojProfil" runat="server" Text="Mój profil" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="mojProfil_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przejdź do ustawień swojego konta" />

                </td>

            </tr>

        </table>
    </div>

<audio autoplay loop>
	<source src="../resources/barka.mp3" />
</audio>

</asp:Content>
