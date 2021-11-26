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
                              <td class="zdjecie">
                                  <asp:Image ID="produktImg" runat="server"
                                      Height="250" Width="250"
                                      ImageUrl="~/images/250x250.png"
                                      AlternateText="produktImg"/></td>
                              <td class="opis">Cebula - worek 1 kg<br />Cena: 5,00 zł/kg</td>
                              <td class="prodSter">
                                  <svg xmlns="http://www.w3.org/2000/svg"
                                      class="icon icon-tabler icon-tabler-chevron-right"
                                      width="40"
                                      height="40"
                                      viewBox="0 0 24 24"
                                      stroke-width="2"
                                      stroke="currentColor"
                                      fill="none"
                                      stroke-linecap="round"
                                      stroke-linejoin="round">
                                      <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                      <polyline points="9 6 15 12 9 18" />
                                    </svg>


                                  <svg xmlns="http://www.w3.org/2000/svg"
                                      class="icon icon-tabler icon-tabler-plus"
                                      width="40" 
                                      height="40" 
                                      viewBox="0 0 24 24"
                                      stroke-width="2"
                                      stroke="currentColor"
                                      fill="none"
                                      stroke-linecap="round"
                                      stroke-linejoin="round">
                                      <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                                      <line x1="12" y1="5" x2="12" y2="19" />
                                      <line x1="5" y1="12" x2="19" y2="12" />
                                    </svg>

                              </td>
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
