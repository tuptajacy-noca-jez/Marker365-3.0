<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="DodajProdukt.aspx.cs" Inherits="Market365_3._0.Administrator.DodajProdukt.DodajProdukt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Market365 - Dodaj produkt</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
           
            <div>
            <table>
                <tr>
                    
                    <td colspan="2">
                    <div class="pad">
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large"></asp:Label>
                </div>
                        </td>   
                </tr>
                <tr>
                     <td colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="W tym miejscu możesz dodać nowy produkt do sprzedaży" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                 
                    <td>
                        <asp:TextBox ID="nazwa" runat="server" placeholder="Nazwa produktu" AutoPostBack="True" BorderStyle="Solid" CssClass="ceil" Font-Size="X-Large" ToolTip="Dodaj nazwę produktu" OnTextChanged="password_TextChanged" ></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="opis" runat="server" placeholder="Opis produktu" AutoPostBack="True" BorderStyle="Solid" CssClass="ceil" Font-Size="X-Large"  ToolTip="Opisz towar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                           <td>
                        <asp:TextBox ID="cena" runat="server" placeholder="Cena produktu" AutoPostBack="True" BorderStyle="Solid" CssClass="ceil" Font-Size="X-Large" ToolTip="Dodaj cenę produktu"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="jednostka" runat="server" placeholder="Jednostka" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True" ToolTip="Kg/dg/g/szt..."></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Size="Large" ForeColor="Red" ValidationGroup="profileChanges" />
                    </td>
                </tr>
                <tr>
                    <td>
                        </td>
                    <td>
                        <div class="przeglad">
                <asp:Button ID="zapisz" runat="server" Text="Zapisz" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px" CssClass="button" BorderStyle="Solid" OnClick="zapisz_Click" />
            </div>
                   </td> 
                </tr>
                
            </table>
               
            
             </div>
        </div>
</asp:Content>
