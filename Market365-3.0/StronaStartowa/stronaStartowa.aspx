﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stronaStartowa.aspx.cs" Inherits="projekt.stronaStartowa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Style/StyleGadomski.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
    
    </style>
</head>
<body>
        <div class="main-header">
            <div class="name">
                <asp:Label ID="Label1" runat="server" Text="Market365" Font-Bold="True"></asp:Label>
            </div>
            <form id="form1" runat="server">
            <div class ="input">
                <div class="pad">
                <asp:TextBox ID="Login" runat="server" Height="30px" placeholder="Login" Width="300px" Font-Size="Large" OnTextChanged="Login_TextChanged"  CssClass="inputText" BorderStyle="Solid" ></asp:TextBox>
                </div>
                <div class="pad">
                <asp:TextBox ID="Password" runat="server" Height="30px" placeholder="Hasło" Width="300px" Font-Size="Large" OnTextChanged="Password_TextChanged" CssClass="inputText" BorderStyle="Solid" ></asp:TextBox>
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
                    <asp:Button ID="przeglad" runat="server" Text="Przeglądaj bez rejestracji" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Height="60px" Width="380px" CssClass="button" BorderStyle="Solid" />
                </div>
            </form>
        </div>
       
</body>
</html>