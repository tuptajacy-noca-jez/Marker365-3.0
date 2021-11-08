<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="Market365_3._0.MojProfil.MojProfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <div class="header">
                <div class="namep">
                    <asp:Label ID="Label1" runat="server" Text="Market365"></asp:Label>
                </div>
            </div>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="kodPocztowy" runat="server" placeholder="Kod pocztowy" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="Miejscowość" runat="server" placeholder="Miejscowość" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="ulica" runat="server" placeholder="Ulica" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="numerDomu" runat="server" placeholder="Numer domu/mieszkania" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="telefon" runat="server" placeholder="Telefon" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="email" runat="server" placeholder="Adres email" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="zapisz">
                <asp:Button ID="zapisz" runat="server" Text="Zapisz" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px" CssClass="button" BorderStyle="Solid" />
            </div>
        </div>
    </form>
</body>
</html>
