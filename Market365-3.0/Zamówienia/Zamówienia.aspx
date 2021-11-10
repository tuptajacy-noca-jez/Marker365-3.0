<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zamówienia.aspx.cs" Inherits="Market365_3._0.Zamówienia.Zamówienia" %>

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
            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table width="100%" runat="server" id="tblProducts">
                        <tr runat="server">
                            <th runat="server"></th>
                            <th runat="server"></th>
                            <th runat="server"></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td>
                            <asp:Image ID="obrazZamowienia" runat="server" />
                        </td>
                        <td class="input">
                            <asp:Label ID="nazwaZamowienia" runat="server" Text="Przykladowa nazwa zamowienia" Font-Bold="true" /><br>
                            <asp:Label ID="opisZamowienia" runat="server" Text="Przykladowy tekst zamowienia" />
                        </td>
                        <td>
                            <asp:ImageButton ID="edycjaZamowienia" runat="server" ImageUrl="~/images/edit.PNG" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
