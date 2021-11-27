<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="StronaProduktu.aspx.cs" Inherits="Market365_3._0.StronaProduktu.StronaProduktu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nazwa Produktu</title>
    <link href="../Style/produktStyle.css" rel="stylesheet" type="text/css">
    <link href="../Style/styleMaster.css" rel="stylesheet" type="text/css" />
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Container">
        <div class="Container">
            <div class="containerElement" ID="productNameBlock">
                <asp:label runat="server" ID="productNameLabel" CssClass="productNameLabel">[Nazwa Produktu]</asp:Label>
            </div>
            <div class="containerElement">
                <svg 
                    xmlns="http://www.w3.org/2000/svg" 
                    class="icons liked unliked" 
                    width="100"
                    height="100"
                    viewBox="-3.3 -3.3 30 30"
                    stroke-width="2" 
                    stroke="currentColor" 
                    fill="none" 
                    preserveAspectRatio ="xMidyMid meet"
                    stroke-linecap="round" 
                    stroke-linejoin="round"
                    >
              <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
              <path d="M19.5 13.572l-7.5 7.428l-7.5 -7.428m0 0a5 5 0 1 1 7.5 -6.566a5 5 0 1 1 7.5 6.572" />
            </svg>
            </div>
        </div>

        <div class="Container">
                <div class="leftContent">
                    <div class="Container">
                            <img runat="server" src="~/images/340x453.png" class="productImage"/>
                    </div>

                    <div class="Container">
                        <div class="containerElement">
                            <svg 
                            xmlns="http://www.w3.org/2000/svg" 
                            class="icons liked unliked" 
                            width="100"
                            height="100"
                            viewBox="-3.3 -3.3 30 30"
                            stroke-width="2" 
                            stroke="currentColor" 
                            fill="none" 
                            preserveAspectRatio ="xMidyMid meet"
                            stroke-linecap="round" 
                            stroke-linejoin="round"
                            >
                         <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                         <path d="M12 17.75l-6.172 3.245l1.179 -6.873l-5 -4.867l6.9 -1l3.086 -6.253l3.086 6.253l6.9 1l-5 4.867l1.179 6.873z" />
                        </svg>

                        <svg 
                            xmlns="http://www.w3.org/2000/svg" 
                            class="icons liked unliked" 
                            width="100"
                            height="100"
                            viewBox="-3.3 -3.3 30 30"
                            stroke-width="2" 
                            stroke="currentColor" 
                            fill="none" 
                            preserveAspectRatio ="xMidyMid meet"
                            stroke-linecap="round" 
                            stroke-linejoin="round"
                            >
                         <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                         <path d="M12 17.75l-6.172 3.245l1.179 -6.873l-5 -4.867l6.9 -1l3.086 -6.253l3.086 6.253l6.9 1l-5 4.867l1.179 6.873z" />
                        </svg>

                        <svg 
                            xmlns="http://www.w3.org/2000/svg" 
                            class="icons liked unliked" 
                            width="100"
                            height="100"
                            viewBox="-3.3 -3.3 30 30"
                            stroke-width="2" 
                            stroke="currentColor" 
                            fill="none" 
                            preserveAspectRatio ="xMidyMid meet"
                            stroke-linecap="round" 
                            stroke-linejoin="round"
                            >
                         <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                         <path d="M12 17.75l-6.172 3.245l1.179 -6.873l-5 -4.867l6.9 -1l3.086 -6.253l3.086 6.253l6.9 1l-5 4.867l1.179 6.873z" />
                        </svg>

                        <svg 
                            xmlns="http://www.w3.org/2000/svg" 
                            class="icons liked unliked" 
                            width="100"
                            height="100"
                            viewBox="-3.3 -3.3 30 30"
                            stroke-width="2" 
                            stroke="currentColor" 
                            fill="none" 
                            preserveAspectRatio ="xMidyMid meet"
                            stroke-linecap="round" 
                            stroke-linejoin="round"
                            >
                         <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                         <path d="M12 17.75l-6.172 3.245l1.179 -6.873l-5 -4.867l6.9 -1l3.086 -6.253l3.086 6.253l6.9 1l-5 4.867l1.179 6.873z" />
                        </svg>

                        <svg 
                            xmlns="http://www.w3.org/2000/svg" 
                            class="icons liked unliked" 
                            width="100"
                            height="100"
                            viewBox="-3.3 -3.3 30 30"
                            stroke-width="2" 
                            stroke="currentColor" 
                            fill="none" 
                            preserveAspectRatio ="xMidyMid meet"
                            stroke-linecap="round" 
                            stroke-linejoin="round"
                            >
                         <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                         <path d="M12 17.75l-6.172 3.245l1.179 -6.873l-5 -4.867l6.9 -1l3.086 -6.253l3.086 6.253l6.9 1l-5 4.867l1.179 6.873z" />
                        </svg>
                        </div>
                    </div>

                    <div class="Container">
                        <div class="containerElement">
                            <asp:label runat="server" ID="priceTag" CssClass="productPriceLabel">99.99 zł/kg</asp:Label>
                        </div>
                    </div>

                    
                </div>
                <div class="rightContent">
                    <div class="Container"  >
                        <div id="productDescription">
                            <table>
                                <tr ><td font-weight="bold">Składnik</td><td font-weight="bold">Zawartość w 100 [g]</td></tr>
                                <tr><td>Kalorie (wartość energetyczna)</td><td>40 kcal / 167 kJ</td></tr>
                                <tr><td>Tłuszcz ogółem</td><td>0,002 g</td></tr>
                                <tr><td>Białko</td><td>0,002 g</td></tr>
                                <tr><td>Kwasy tłuszczowe nasycone</td><td>0,002 g</td></tr>
                                <tr><td>Kwasy tłuszczowe jednonienasycone</td><td>0,002 g</td></tr>
                                <tr><td>Kwasy tłuszczowe wielonienasycone</td><td>0,002 g</td></tr>
                                <tr><td>Kwasy tłuszczowe omega-3</td><td>0,002 g</td></tr>
                                <tr><td>Kwasy tłuszczowe omega-6</td><td>0,015 g</td></tr>
                                <tr><td>Węglowodany</td><td>9,34 g</td></tr>
                            </table>
                        </div>
                    </div>
                    <div class="Container" id="orderHandle">
                        <div class="containerElement">
                            <asp:TextBox runat="server" ID="amountTextBox" CssClASS="amountTextBox" ToolTip="ilość w kg ..."></asp:TextBox>
                        </div>
                        <div class="containerElement">
                            <asp:Button runat="server" ID="addToCart" text="Dodaj do koszyka" CssClass="Button"/>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>
