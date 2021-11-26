<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sklep.aspx.cs" Inherits="Market365_3._0.Sklep.Sklep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Market365 - Sklep</title>
</head>
<body>
    <form id="form1" runat="server">
          <div>
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
              <div class ="listaProd">
                  <div class="produkt">
                      <table>
                          <tr>
                              <td class="zdjecie">ZDJĘCIE</td>
                              <td class="opis">Opis</td>
                              <td class="prodSter">Przyciski</td>
                          </tr>

                      </table>

                  </div>
                  TU JEST LISTA PRODUKTÓW W SKLEPIE</br>
         
              </div>

                <div class ="przeglad">
                    <asp:Button ID="doKoszyka" runat="server" Text="Do koszyka" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Height="60px" Width="380px" CssClass="button" BorderStyle="Solid" />
                </div>
        </div>
    </form>
</body>
</html>
