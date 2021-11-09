<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="Market365_3._0.MojProfil.MojProfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mój Profil</title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <div class="header">
                <div class="namep">
                    <asp:Label ID="Label1" runat="server" Text="Market365"></asp:Label>
                </div>
            </div>
            <div>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="password" runat="server" placeholder="Hasło" AutoPostBack="True" BorderStyle="Solid" CssClass="ceil" Font-Size="X-Large" TextMode="Password" ToolTip="Hasło musi składać się z min. 8 znaków, zawierać małe i duże litery oraz cyfrę"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="passwordValidator" runat="server" ErrorMessage="Hasło nie spełnia wymagań" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ControlToValidate="password" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="zipCode" runat="server" placeholder="Kod pocztowy" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="zipCodeValidator" runat="server" ErrorMessage="Nieprawidłowy kod pocztowy" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]{2}-[0-9]{3}" ControlToValidate="zipCode" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="city" runat="server" placeholder="Miejscowość" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="cityValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa miasta" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="city" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="street" runat="server" placeholder="Ulica" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="streetValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa ulicy" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="street" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="houseNumber" runat="server" placeholder="Numer domu/mieszkania" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="houseNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer domu" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]+[A-Z]?(/?[0-9])*" ControlToValidate="houseNumber" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="phoneNumber" runat="server" placeholder="Telefon" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="phoneNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer telefonu" Display="Dynamic" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^\d{9}$" ControlToValidate="phoneNumber" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="email" runat="server" placeholder="Adres email" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="emailValidator" runat="server" ErrorMessage="Nieprawidłowy adres email" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ControlToValidate="email" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
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
                        <div class="zapisz">
                <asp:Button ID="zapisz" runat="server" Text="Zapisz" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px" CssClass="button" BorderStyle="Solid" />
            </div>
                   </td> 
                </tr>
            </table>
               
            
             </div>
        </div>
    </form>
</body>
</html>
