<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Koszyk.aspx.cs" Inherits="Market365_3._0.Koszyk.Koszyk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Style/StyleFedorowicz.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Koszyk</title>
</head>
<body>
    <div class="header">
        <div class="def">
            <asp:Label ID="Label1" runat="server" Text="Market365 - Koszyk"></asp:Label>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="list">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
                <LayoutTemplate>
                    <table width="100%" runat="server" id="tblProducts">
                        <tr runat="server">
                            <th runat="server"></th>
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
                    <span>Nie zostały zwrócone żadne dane.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                   <tr runat="server">
                        <td>
                            <img height="200px" id="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" />
                        </td>
                        <td class="input">
                            <asp:Label ID="nazwaProduktu" runat="server" Text='<%# Eval("name") %>' Font-Bold="true" /><br>
                            <asp:Label ID="cenaProduktu" runat="server" Text='<%# Eval("price") %>' />
                        </td>
                        <td>
                            <asp:DropDownList ID="iloscProduktu" runat="server" ItemType="number">
                                <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="usunProdukt" runat="server" Text="Usuń" CssClass="buttonred" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>  
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [name], [image], [description], [price] FROM [products] "></asp:SqlDataSource>
            <asp:Label id="cenaSuma" CssClass="label" runat="server" Text="Do zapłaty:"></asp:Label>        
            <asp:Button id="zamowButton" runat="server" Text="Zamów" CssClass="button" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="50px" Width="200px" BorderStyle="Solid" style="float:right" /> 
            <asp:Button id="anulujButton" runat="server" Text="Anuluj" CssClass="buttonred" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="50px" Width="200px" BorderStyle="Solid" style="float:right" OnClick="anulujButton_Click"/>          
        </div>
    </form>
</body>
</html>
