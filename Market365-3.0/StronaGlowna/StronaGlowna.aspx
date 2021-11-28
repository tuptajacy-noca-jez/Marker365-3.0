<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="StronaGlowna.aspx.cs" Inherits="Market365_3._0.StronaGlowna.StronaGlowna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Market365 - Strona Główna</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                <asp:Button CssClass="buttonL" ID="wyloguj" runat="server" Text="Wyloguj" ToolTip="Wyloguj się z konta"/>
                            </div>

                        </td>
                    </tr>
                </table>
            </div>

            <div class="bestdeals">
                <div class="produktDeals">
                     <asp:Image ID="produktDealsImg" runat="server"
                                      Height="50" Width="50"
                                      ImageUrl="~/images/50x50.png"
                                      AlternateText="produktDealsImg"/><br />
                    Cebula <br />
                    2,50 zł/kg
                </div>                

                                <div class="produktDeals">
                     <asp:Image ID="Image1" runat="server"
                                      Height="50" Width="50"
                                      ImageUrl="~/images/50x50.png"
                                      AlternateText="produktDealsImg"/><br />
                    Cebula <br />
                    2,50 zł/kg
                </div>                
                <div class="produktDeals">
                     <asp:Image ID="Image2" runat="server"
                                      Height="50" Width="50"
                                      ImageUrl="~/images/50x50.png"
                                      AlternateText="produktDealsImg"/><br />
                    Cebula <br />
                    2,50 zł/kg
                </div>                
                <div class="produktDeals">
                     <asp:Image ID="Image3" runat="server"
                                      Height="50" Width="50"
                                      ImageUrl="~/images/50x50.png"
                                      AlternateText="produktDealsImg"/><br />
                    Cebula <br />
                    2,50 zł/kg
                </div>                
                <div class="produktDeals">
                     <asp:Image ID="Image4" runat="server"
                                      Height="50" Width="50"
                                      ImageUrl="~/images/50x50.png"
                                      AlternateText="produktDealsImg"/><br />
                    Cebula <br />
                    2,50 zł/kg
                </div>                
                <div class="produktDeals">
                     <asp:Image ID="Image5" runat="server"
                                      Height="50" Width="50"
                                      ImageUrl="~/images/50x50.png"
                                      AlternateText="produktDealsImg"/><br />
                    Cebula <br />
                    2,50 zł/kg
                </div>                

            </div>

            <div class="menu">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="sklep" runat="server" Text="Sklep"  Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="sklep_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przeglądaj produkty w sklepie"/>

                        </td>

                        <td>
                            <asp:Button ID="koszyk" runat="server" Text="Koszyk" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="koszyk_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przejdź do swojego koszyka"/>

                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="zamowienia" runat="server" Text="Zamówienia" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="zamowienia_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przeglądaj swoje zamówienia"/>

                        </td>

                        <td>
                            <asp:Button ID="mojProfil" runat="server" Text="Mój profil" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="95%" OnClick="mojProfil_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przejdź do ustawień swojego konta"/>

                        </td>

                    </tr>

                </table>
            </div>
</asp:Content>
