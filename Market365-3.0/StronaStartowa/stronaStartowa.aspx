<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="stronaStartowa.aspx.cs" Inherits="projekt.stronaStartowa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" type="text/css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
    <title>Market365</title>

    <style type="text/css">
        body {background-image: url('/images/sklep.jpg');}
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="main-header">
            <div class="input">
                <div class="pad">
                    <asp:TextBox ID="login" runat="server" Height="30px" placeholder="Login" Width="300px" Font-Size="Large"  CssClass="inputText" BorderStyle="Solid"></asp:TextBox>
                </div>
                <div class="pad">
                    <asp:TextBox ID="password" runat="server" Height="30px" placeholder="Hasło" Width="300px" Font-Size="Large"  CssClass="inputText" BorderStyle="Solid" TextMode="Password"></asp:TextBox>
                </div>
                <div class="pad">
                    <asp:Label ID="Validacion" runat="server" Text="Nieprawidłowy login lub hasło" ForeColor="Red" Visible="False" Font-Size="Large" Font-Bold="True"></asp:Label>
                </div>
            </div>

            <div class ="buttons">
                <div class="pad" >
                    <asp:Button ID="zaloguj" runat="server" onmouseover="this.style.backgroudColor='red'" Text="Zaloguj" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px" OnClick="zaloguj_Click" CssClass="button" BorderStyle="Solid" />
                </div>
                <div class="pad" >
                    <asp:Button ID="rejestracja" runat="server" Text="Rejestracja" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="90px" Width="300px" CssClass="button" BorderStyle="Solid" OnClick="rejestracja_Click" />
                </div>
            </div>
            <div class ="przeglad">
                <asp:Button ID="przeglad" runat="server" Text="Przeglądaj bez rejestracji" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Height="60px" Width="380px" CssClass="button" BorderStyle="Solid" OnClick="przeglad_Click" />
            </div>
        </div>
    </div> 
</asp:Content>
