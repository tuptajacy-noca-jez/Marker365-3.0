<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StronaGlowna.aspx.cs" Inherits="Market365_3._0.StronaGlowna.WebForm1" %>

<!DOCTYPE html>

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

        </form>

    </div>
</body>
</html>
