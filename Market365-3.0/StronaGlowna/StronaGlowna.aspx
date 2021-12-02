<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="StronaGlowna.aspx.cs" Inherits="Market365_3._0.StronaGlowna.StronaGlowna" Async="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Market365 - Strona Główna</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="bestdeals">
<asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <LayoutTemplate>
                <div class="produktDeals">
                <table class="tbCenter" runat="server" id="tblProducts">
                    <tr runat="server">
                        <th runat="server"></th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
                </div>
            </LayoutTemplate>
            <EmptyDataTemplate>
                <span>Nie zostały zwrócone żadne dane.</span>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td class ="produktDeals" runat="server" onclick="produktDeals_Click">
                    <a href="../StronaProduktu/StronaProduktu.aspx/<%# Eval("id") %>">
                        <img height="100px" id="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" /><br />
                        <asp:Label ID="nazwaProduktu" runat="server" Text='<%# Eval("name") %>' Font-Bold="true" /><br />
                        <asp:Label ID="cenaProduktu" runat="server" Text='<%# Eval("price") %>' />&nbspzł/<asp:Label ID="Label1" runat="server" Text='<%# Eval("unit") %>' />
                     </a>
                </td>
            </ItemTemplate>
        </asp:ListView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP 10 [Id], [name], [image], [description], [price], [unit] FROM [products] ORDER BY NEWID()"></asp:SqlDataSource>
</div>    
    
     <div class =" apiMain">
    <div class="apiLeft">
        <div class="api3">
            <asp:Button ID="Button1" runat="server" Text="Sklep" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="70%" OnClick="sklep_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przeglądaj produkty w sklepie" />
        </div>
       <div class="api3">
               <asp:Button ID="Button2" runat="server" Text="Koszyk" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="70%" OnClick="koszyk_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przejdź do swojego koszyka" />
       </div>
        <div class="api3">
             <asp:Button ID="Button3" runat="server" Text="Zamówienia" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="70%" OnClick="zamowienia_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przeglądaj swoje zamówienia" />
        </div>
        <div class="api3">
              <asp:Button ID="Button4" runat="server" Text="Mój profil" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="70%" OnClick="mojProfil_Click" CssClass="button" BorderStyle="Solid" ToolTip="Przejdź do ustawień swojego konta" />
        </div>
    

       
    </div>
    
    <div class ="apiRight">
        <div class="api2">
             <asp:Label ID="DrinkLabel" runat="server" Text="Polecane Drinki" ></asp:Label>
        </div>
        <div class="api2">
             <asp:Image ID="DrinkImage" runat="server" Height="137px" Width="138px" />
        </div>
        <div class="api2">
             <asp:Label ID="DrinkName" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="DrinkInstructions" runat="server" Height="45px" Width="384px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="api2">
            <asp:ListBox ID="DrinkList" runat="server" Enabled="False" Height="113px" Width="241px"></asp:ListBox>
        </div>
    

    </div>
 </div>


</asp:Content>
