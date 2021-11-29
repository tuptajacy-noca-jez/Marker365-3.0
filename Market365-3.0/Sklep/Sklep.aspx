<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Sklep.aspx.cs" Inherits="Market365_3._0.Sklep.Sklep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <link href="/Style/StyleBrzezinski.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Market365 - Sklep</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                <td class="zdjecie">
                    <img height="200px" id="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" />
                </td>
                <td class="opis">
                    <asp:Label ID="nazwaProduktu" runat="server" Text='<%# Eval("name") %>' Font-Bold="true" /><br />
                    Cena:
                    <asp:Label ID="cenaProduktu" runat="server" Text='<%# Eval("price") %>' />
                    zł
                </td>
                <td class="prodSter">
                    <a href="../StronaProduktu/StronaProduktu.aspx/<%# Eval("id") %>">
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
                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                            <polyline points="9 6 15 12 9 18" />
                        </svg>
                    </a>
                    <asp:ImageButton ID="AddButton" 
                        runat="server"
                        ImageUrl="../resources/icons/tabler-icon-chevron-right.jpg"
                        heigh="40px"
                        width="40px"
                        OnClick="AddButton_Click" 
                        Text='+'
                        ToolTip='<%# Eval("id") %>'/>
                    <!--<button id='Button1' runat="server" onclick="AddButton_Click" ToolTip='<%# Eval("id") %>'>
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
                        <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                        <line x1="12" y1="5" x2="12" y2="19" />
                        <line x1="5" y1="12" x2="19" y2="12" />
                    </svg>
                    </button>-->
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [name], [image], [description], [price] FROM [products] "></asp:SqlDataSource>
    <table class="table">
        <tr class="table">
            <td class="td25"></td>
            <td class="td25"></td>
            <td class="td25"></td>
            <td class="td25">
                <asp:Button ID="doKoszyka" runat="server" Text="Do koszyka" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Height="60px" Width="380px" CssClass="button" BorderStyle="Solid" ToolTip="Przejdź do swojego koszyka" OnClick="doKoszyka_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
