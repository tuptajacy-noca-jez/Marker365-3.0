<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Koszyk.aspx.cs" Inherits="Market365_3._0.Koszyk.Koszyk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleFedorowicz.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Koszyk</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div id="placeholderBootstrap">
            <asp:ListView ID="ListView1" runat="server" >
                <LayoutTemplate>
                    <table width="100%" runat="server" id="tblProducts">
                        <tr runat="server">
                            <th runat="server"></th>
                            <th runat="server">Produkt<br>Cena/kg</th>
                            <th runat="server">Waga produktu (kg)</th>
                            <th runat="server">Cena</th>
                            <th runat="server"></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <span>Nie zostały zwrócone żadne dane.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                   <tr runat="server">
                        <td>
                            <img height="200px" id="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" border="1px"/>
                        </td>
                        <td class="input">
                            <asp:Label ID="nazwaProduktu" runat="server" Text='<%# Eval("name") %>' Font-Bold="true" /><br>
                            <asp:Label ID="cenaProduktu" runat="server" Text='<%# Eval("price") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="iloscProduktu" runat="server" width="100px" Text='<%# Eval("quantity")%>'></asp:TextBox>
                        </td>
                       <td>
                            <asp:Label ID="cenaProduktuSuma" runat="server" Text="0 zł"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="usunProdukt" runat="server" Text="Usuń" CssClass="buttonred" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>  
            <!--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [name], [image], [description], [price] FROM [products] "></asp:SqlDataSource>-->                   
            <asp:Button id="zamowButton" runat="server" Text="Zamów" CssClass="button" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="50px" Width="200px" BorderStyle="Solid" style="float:right" OnClick="zamowButton_Click" /> 
            <asp:Button id="anulujButton" runat="server" Text="Anuluj" CssClass="buttonred" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="50px" Width="200px" BorderStyle="Solid" style="float:right" OnClick="anulujButton_Click"/>          
            <asp:Label id="cenaSuma" CssClass="label" runat="server" style="float:right" Text="Do zapłaty:"></asp:Label>
        </div>
        </div>
</asp:Content>
