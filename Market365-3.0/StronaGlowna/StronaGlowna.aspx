<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StronaGlowna.aspx.cs" Inherits="Market365_3._0.StronaGlowna.WebForm1" %>

<!DOCTYPE html>
<script runat="server">

    protected void zamowienia_Click(object sender, EventArgs e)
    {

    }

    protected void mojProfil_Click(object sender, EventArgs e)
    {

    }

    protected void koszyk_Click(object sender, EventArgs e)
    {

    }

    protected void sklep_Click(object sender, EventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div>
        <form id="form1" runat="server">
            <div class="header">
                <table>
                    <tr>
                        <td class="tdhead">

                        </td>
                        <td class="tdhead">
                            <div class="namep">
                                <asp:Label ID="Label1" runat="server" Text="Market365"></asp:Label>
                            </div>
                        </td>
                        <td class="tdhead">
                            <div class ="buttonLogout">
                                <asp:Button CssClass="buttonL" ID="wyloguj" runat="server" Text="Wyloguj"/>
                            </div>

                        </td>
                    </tr>
                </table>
            </div>
            <div class="bestdeals">

                TU BĘDZIE PASEK REKLAM

            </div>

            <div class="menu">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="sklep" runat="server" Text="Sklep"  Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="sklep_Click" CssClass="button" BorderStyle="Solid"/>

                        </td>

                        <td>
                            <asp:Button ID="koszyk" runat="server" Text="Koszyk" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="koszyk_Click" CssClass="button" BorderStyle="Solid"/>

                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="zamowienia" runat="server" Text="Zamówienia" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="zamowienia_Click" CssClass="button" BorderStyle="Solid"/>

                        </td>

                        <td>
                            <asp:Button ID="mojProfil" runat="server" Text="Mój profil" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="mojProfil_Click" CssClass="button" BorderStyle="Solid"/>

                        </td>

                    </tr>

                </table>


            </div>
        </form>

    </div>
</body>
</html>
