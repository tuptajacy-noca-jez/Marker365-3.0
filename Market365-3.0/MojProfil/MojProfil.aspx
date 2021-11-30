<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="Market365_3._0.MojProfil.MojProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mój Profil</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div>
           
            <div>
            <table>
                <tr>
                    
                    <td colspan="2">
                    <div class="pad">
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" CssClass="czcionka"></asp:Label>
                </div>
                        </td>   
                </tr>
                <tr>
                     <td colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="Aby zmienić hasło wprowadź stare hasło oraz dwukrotnie nowe hasło" Font-Size="Large" CssClass="czcionka"></asp:Label>
                    </td>
                </tr>
                <tr>
                 
                    <td>
                        <asp:TextBox ID="password" runat="server" placeholder="Stare Hasło" AutoPostBack="True" BorderStyle="Solid" CssClass="ceil" Font-Size="X-Large" ToolTip="Hasło musi składać się z min. 8 znaków, zawierać małe i duże litery" OnTextChanged="password_TextChanged" TextMode="Password"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="newPassword" runat="server" placeholder="Nowe Hasło" AutoPostBack="True" BorderStyle="Solid" CssClass="ceil" Font-Size="X-Large" TextMode="Password" ToolTip="Hasło musi składać się z min. 8 znaków, zawierać małe i duże litery, cyfrę oraz znak specjalny"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="newPasswordValidator" runat="server" ErrorMessage="Hasło nie spełnia wymagań" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&amp;*-.]).{8,}$" ControlToValidate="newPassword" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Hasła nie są zgodne" Font-Size="X-Large" ForeColor="Red" ControlToCompare="newPasswordConfirm" ControlToValidate="newPassword" ValidationGroup="profileChanges">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="newPasswordConfirm" runat="server" placeholder="Potwierdz nowe Hasło" AutoPostBack="True" BorderStyle="Solid" CssClass="ceil" Font-Size="X-Large" TextMode="Password" ToolTip="Hasło musi składać się z min. 8 znaków, zawierać małe i duże litery, cyfrę oraz znak specjalny"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="newPasswordConfirmValidator" runat="server" ErrorMessage="Hasło nie spełnia wymagań" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&amp;*-.]).{8,}$" ControlToValidate="newPasswordConfirm" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Hasła nie są zgodne" Font-Size="X-Large" ForeColor="Red" ControlToCompare="newPassword" ControlToValidate="newPasswordConfirm" ValidationGroup="profileChanges">*</asp:CompareValidator>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="zipCode" runat="server" placeholder="Kod pocztowy" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="zipCodeValidator" runat="server" ErrorMessage="Nieprawidłowy kod pocztowy" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]{2}-[0-9]{3}" ControlToValidate="zipCode" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="zipCodeRequiredValidator" runat="server" ErrorMessage="Pole nie może być puste" ControlToValidate="zipCode" Display="Dynamic" ForeColor="Red" Font-Size="X-Large" ValidationGroup="profileChanges">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="city" runat="server" placeholder="Miejscowość" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="cityValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa miasta" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="city" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="cityRequiredValidator" runat="server" ErrorMessage="Pole nie może być puste" ControlToValidate="city" Display="Dynamic" ForeColor="Red" Font-Size="X-Large" ValidationGroup="profileChanges">*</asp:RequiredFieldValidator>                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="street" runat="server" placeholder="Ulica" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="streetValidator" runat="server" ErrorMessage="Nieprawidłowa nazwa ulicy" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*( [A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż][a-ząćęłńóśźż]*)*" ControlToValidate="street" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="streetRequiredValidator" runat="server" ErrorMessage="Pole nie może być puste" ControlToValidate="street" Display="Dynamic" ForeColor="Red" Font-Size="X-Large" ValidationGroup="profileChanges">*</asp:RequiredFieldValidator>                                        
                    </td>
                    <td>
                        <asp:TextBox ID="houseNumber" runat="server" placeholder="Numer domu/mieszkania" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="houseNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer domu" Font-Size="X-Large" ForeColor="Red" ValidationExpression="[0-9]+[A-Z]?(/?[0-9])*" ControlToValidate="houseNumber" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="houseNumberRequiredValidator" runat="server" ErrorMessage="Pole nie może być puste" ControlToValidate="houseNumber" Display="Dynamic" ForeColor="Red" Font-Size="X-Large" ValidationGroup="profileChanges">*</asp:RequiredFieldValidator>                                                            
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="phoneNumber" runat="server" placeholder="Telefon" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="phoneNumberValidator" runat="server" ErrorMessage="Nieprawidłowy numer telefonu" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^\d{9}$" ControlToValidate="phoneNumber" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="email" runat="server" placeholder="Adres email" CssClass="ceil" BorderStyle="Solid" Font-Size="X-Large" AutoPostBack="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="emailValidator" runat="server" ErrorMessage="Nieprawidłowy adres email" Font-Size="X-Large" ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ControlToValidate="email" ValidationGroup="profileChanges">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Font-Size="X-Large" CssClass="czcionka"></asp:Label>
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
