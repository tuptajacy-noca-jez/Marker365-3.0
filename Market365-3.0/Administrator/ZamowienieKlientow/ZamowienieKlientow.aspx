<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="ZamowienieKlientow.aspx.cs" Inherits="Market365_3._0.Administrator.ZamowienieKlientow.ZamowienieKlientow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div>
            <asp:ListView ID="ListView2" runat="server" DataKeyNames="Id">
                <LayoutTemplate>
                    <table width="100%" runat="server" id="tblOrders">
                        <tr runat="server">
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
                    Brak zamówień.
                </EmptyDataTemplate>                
                <ItemSeparatorTemplate>
                    <br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td>
                            <img height="200px" ="obrazZamowienia" src="data:image/jpg;base64,<%# Eval("image") %>" />
                        </td>
                        <td class="input">
                            <asp:Label ID="nazwaZamowienia" runat="server" Text='<%# "Id zamówienia: " + Eval("Id")%>' Font-Bold="true" /><br/>
                            <asp:Label ID="opisZamowienia" runat="server" Text='<%# "Cena: " + Eval("value") + " zł"%>' /><br />
                             <asp:Label ID="imie" runat="server" Text='<%# "Dane klienta: " + Eval("name") + Eval("surname")%>' Font-Bold="true" />
                        </td>
                        <td class="input">
                            <asp:Label ID="status" runat="server" Text='<%# "Status zamówienia: " + Eval("status")%>' Font-Bold="true" /><br/>
                        </td>

                 
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <!--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=market365dbserver.database.windows.net;Initial Catalog=Market365_db;Persist Security Info=True;User ID=market365admin;Password=WATwcy18" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [image], [opis] FROM [orders]"></asp:SqlDataSource>-->
        </div>

    </asp:Content>
