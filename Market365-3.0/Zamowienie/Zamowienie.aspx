<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Zamowienie.aspx.cs" Inherits="Market365_3._0.Zamowienie.Zamowienie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Zamowienie</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div>
            <div>
            <table>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="orderID" runat="server" Text="" Font-Size="XX-Large"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="name" runat="server" placeholder="Imię" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="nameValidator" runat="server" ErrorMessage="Nieprawidłowe imię" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]{2}[a-z]*" ControlToValidate="name" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="surname" runat="server" placeholder="Nazwisko" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="surnameValidator" runat="server" ErrorMessage="Nieprawidłowe nazwisko" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]{2}[a-z]*" ControlToValidate="surname" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="zipCode" runat="server" placeholder="Kod pocztowy" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="zipCodeValidator" runat="server" ErrorMessage="Nieprawidłowy kod pocztowy" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]{2}-[0-9]{3}" ControlToValidate="zipCode" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="city" runat="server" placeholder="Miejscowość" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="cityValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa miasta" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="city" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="street" runat="server" placeholder="Ulica" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="streetValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa ulicy" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="street" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="houseNumber" runat="server" placeholder="Numer domu/mieszkania" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="houseNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer domu" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]+[A-Z]?(/?[0-9])*" ControlToValidate="houseNumber" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="phoneNumber" runat="server" placeholder="Telefon" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="phoneNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer telefonu" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^\d{9}$" ControlToValidate="phoneNumber" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="discount" runat="server" placeholder="Kod rabatowy" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="discountValidator" runat="server" ErrorMessage="Nieprawidłowy adres email" Font-Size="X-Large" ForeColor="Red" ControlToValidate="discount" ValidationGroup="orderGroup">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                  <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Size="Large" ForeColor="Red" ValidationGroup="orderGroup" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="value" runat="server" Font-Size="XX-Large"></asp:Label>
                        </td>
                    <td>     
                        <asp:Button ID="cancel" runat="server" Text="Anuluj" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px" CssClass="buttonred" BorderStyle="Solid" OnClick="cancel_Click" />
                   </td> 
                    <td>     
                <asp:Button ID="order" runat="server" Text="Zamów" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px" CssClass="button" BorderStyle="Solid" />
                   </td> 
                </tr>
            </table>
               
            
             </div>
        </div>
</asp:Content>
