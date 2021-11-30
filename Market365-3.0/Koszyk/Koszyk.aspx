<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Koszyk.aspx.cs" Inherits="Market365_3._0.Koszyk.Koszyk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleFedorowicz.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Koszyk</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div id="placeholderBootstrap">
            <asp:ListView ID="ListView1" runat="server" >
                <LayoutTemplate>
                    <table width="100%" runat="server" id="tblProducts">
                        <tr runat="server">
                            <th runat="server"></th>
                            <th runat="server">Produkt<br>Cena/Jednostka</th>
                            <th runat="server">Ilość</th>
                            <th runat="server">Cena</th>
                            <th runat="server"></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                    <div style="">
                    </div>
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <span>Koszyk pusty.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                   <tr runat="server">
                        <td>
                            <img height="200px" id="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" border="1px"/>
                        </td>
                        <td class="input">
                            <asp:Label ID="nazwaProduktu" runat="server" Text='<%# Eval("name") %>' Font-Bold="true" /><br>
                            <asp:Label ID="cenaProduktu" runat="server" Text='<%# Eval("price") %>' />
                        </td>
                        <td>
                           <!-- <asp:TextBox ID="iloscProduktu" runat="server"  width="100px" Text='<%# Eval("quantity")%>' ToolTip='<%# Eval("id") %>' OnTextChanged="iloscProduktu_TextChanged" Visible="True" AutoPostBack="True"></asp:TextBox>  -->                          
                            <asp:DropDownList ID="iloscProduktuu" runat="server" Width="50px" AutoPostBack="true" Text='<%# Eval("quantity")%>' ToolTip='<%# Eval("id") %>' OnSelectedIndexChanged="iloscproduktu_TextChanged1">
                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                       <td>
                            <asp:Label ID="cenaProduktuSuma" runat="server" Text='<%# Double.Parse(Eval("price").ToString())*Double.Parse(Eval("quantity").ToString()) %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="usunProdukt" runat="server" Text="Usuń" CssClass="buttonred" ToolTip='<%# Eval("id") %>' OnClick="usunProdukt_Click"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>  
            <!--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [name], [image], [description], [price] FROM [products] "></asp:SqlDataSource>-->                   
            <asp:Button id="zamowButton" runat="server" Text="Zamów" CssClass="button" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="50px" Width="200px" BorderStyle="Solid" style="float:right" OnClick="zamowButton_Click" /> 
            <asp:Button id="anulujButton" runat="server" Text="Anuluj" CssClass="buttonred" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="50px" Width="200px" BorderStyle="Solid" style="float:right" OnClick="anulujButton_Click"/>          
            <asp:Label id="cenaSuma" CssClass="label" runat="server" style="float:right" Text="Do zapłaty:"></asp:Label>
        </div>
        </div>
</asp:Content>
