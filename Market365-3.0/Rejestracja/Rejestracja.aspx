<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Rejestracja.aspx.cs" Inherits="projekt.Rejestracja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/Style/StyleGadomski.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Rejestracja</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <div>
            
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="login" runat="server" placeholder="Login" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="loginValidator" runat="server" ErrorMessage="Podany login jest za krótki" ControlToValidate="login" Display="Dynamic" ForeColor="Red" ValidationExpression=".{4,}" Font-Size="X-Large" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="password" runat="server" placeholder="Hasło" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True" ToolTip="Hasło musi składać się z min. 8 znaków, zawierać małe i duże litery oraz cyfrę" TextMode="Password"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="passwordValidator" runat="server" ErrorMessage="Hasło nie spełnia wymagań" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ControlToValidate="password" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="name" runat="server" placeholder="Imię" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="nameValidator" runat="server" ErrorMessage="Nieprawidłowe imię" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]{2}[a-z]*" ControlToValidate="name" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                         <asp:TextBox ID="surname" runat="server" placeholder="Nazwisko" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="surnameValidator" runat="server" ErrorMessage="Nieprawidłowe nazwisko" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]{2}[a-z]*" ControlToValidate="surname" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="zipCode" runat="server" placeholder="Kod pocztowy" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="zipCodeValidator" runat="server" ErrorMessage="Nieprawidłowy kod pocztowy" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]{2}-[0-9]{3}" ControlToValidate="zipCode" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                         <asp:TextBox ID="city" runat="server" placeholder="Miejscowość" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="cityValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa miasta" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="city" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="street" runat="server" placeholder="Ulica" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="streetValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa ulicy" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="street" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                         <asp:TextBox ID="houseNumber" runat="server" placeholder="Numer domu/mieszkania" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="houseNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer domu" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]+[A-Z]?(/?[0-9])*" ControlToValidate="houseNumber" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="phoneNumber" runat="server" placeholder="Telefon" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="phoneNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer telefonu" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^\d{9}$" ControlToValidate="phoneNumber" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                         <asp:TextBox ID="email" runat="server" placeholder="Adres email" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="emailValidator" runat="server" ErrorMessage="Nieprawidłowy adres email" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ControlToValidate="email" ValidationGroup="rejestration">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Size="Large" ForeColor="Red" ValidationGroup="rejestration" />
                    </td>
                </tr>
            </table>
                
            <div class="zarejestruj" >
                        <asp:Button ID="zarejestruj" runat="server"  Text="Zarejestruj" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px"  CssClass="button" BorderStyle="Solid" OnClick="zarejestruj_Click" />
            </div>
                
        </div>
    </div>
</asp:Content>
