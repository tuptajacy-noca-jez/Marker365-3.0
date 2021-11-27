<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zamowienia.aspx.cs" Inherits="Market365_3._0.Zamówienia.Zamówienia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Style/StyleFedorowicz.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Zamówienia</title>
</head>
<body>
    <div class="header">
        <div class="def">
            <asp:Label ID="Label1" runat="server" Text="Market365 - Zamówienia"></asp:Label>
        </div>
    </div>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <LayoutTemplate>
                    <table width="100%" runat="server" id="tblOrders">
                        <tr runat="server">
                            <th runat="server"></th>
                            <th runat="server"></th>
                            <th runat="server"></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                    <div style="">
                    </div>
                </LayoutTemplate>                              
                <EmptyDataTemplate>
                    Nie zostały zwrócone żadne dane.
                </EmptyDataTemplate>                
                <ItemSeparatorTemplate>
                    <br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td>
                            <img height="200px" ="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" />
                        </td>
                        <td class="input">
                            <asp:Label ID="nazwaZamowienia" runat="server" Text='<%# Eval("Id") %>' Font-Bold="true" /><br/>
                            <asp:Label ID="opisZamowienia" runat="server" Text='<%# Eval("opis") %>' />
                        </td>
                        <td>
                            <asp:ImageButton ID="edycjaZamowienia" runat="server" ImageUrl="~/images/edit.PNG" OnClick="edycjaZamowienia_Click"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [image], [opis] FROM [orders]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
