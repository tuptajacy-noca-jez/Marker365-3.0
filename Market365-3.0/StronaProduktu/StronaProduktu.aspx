<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="StronaProduktu.aspx.cs" Inherits="Market365_3._0.StronaProduktu.StronaProduktu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title id="productTitle" runat="server"></title>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="Container">
    <div class="Container">
        <div class="containerElement" ID="productNameBlock">
            <asp:label runat="server" ID="productNameLabel" Class="productNameLabel">[Nazwa Produktu]</asp:Label>
        </div>
        <div class="containerElement">
            <asp:ImageButton 
                runat="server" 
                ID="likeButtonV22"
                heigh="75px"
                width="75px"
                ImageURL="/resources/icons/hearEmpty.png"
                OnClick="like_click" 
                class="likeImageButton"
                onmouseover="this.src='/resources/icons/hearfilled.png'" onmouseout="this.src='/resources/icons/hearEmpty.png'"
                >
            </asp:ImageButton>
        </div>
    </div>
    

    <div class="Container">
        <div class="leftContent">
            <div class="Container">
                    <Img id="productImage" runat="server" src="~/images/340x453.png" class="productImage"/>
            </div>

            <div class="Container">
                <div class="containerElement">
                    <div class="containerElement">
                        <asp:ImageButton 
                            runat="server" 
                            ID="star1"
                            heigh="75px"
                            width="75px"
                            ImageURL="/resources/icons/starUnrated.png"
                            OnClick="starButton_Click" 
                            class="likeImageButton"
                            onmouseover="this.src='/resources/icons/starRated.png'" onmouseout="this.src='/resources/icons/starUnrated.png'"
                            />
                        <asp:ImageButton 
                            runat="server" 
                            ID="star2"
                            heigh="75px"
                            width="75px"
                            ImageURL="/resources/icons/starUnrated.png"
                            OnClick="starButton_Click" 
                            class="likeImageButton"
                            onmouseover="this.src='/resources/icons/starRated.png'" onmouseout="this.src='/resources/icons/starUnrated.png'"
                            />
                        <asp:ImageButton 
                            runat="server" 
                            ID="star3"
                            heigh="75px"
                            width="75px"
                            ImageURL="/resources/icons/starUnrated.png"
                            OnClick="starButton_Click" 
                            class="likeImageButton"
                            onmouseover="this.src='/resources/icons/starRated.png'" onmouseout="this.src='/resources/icons/starUnrated.png'"
                            />
                        <asp:ImageButton 
                            runat="server" 
                            ID="star4"
                            heigh="75px"
                            width="75px"
                            ImageURL="/resources/icons/starUnrated.png"
                            OnClick="starButton_Click" 
                            class="likeImageButton"
                            onmouseover="this.src='/resources/icons/starRated.png'" onmouseout="this.src='/resources/icons/starUnrated.png'"
                            />
                        <asp:ImageButton 
                            runat="server" 
                            ID="star5"
                            heigh="75px"
                            width="75px"
                            ImageURL="/resources/icons/starUnrated.png"
                            OnClick="starButton_Click" 
                            class="likeImageButton"
                            onmouseover="this.src='/resources/icons/starRated.png'" onmouseout="this.src='/resources/icons/starUnrated.png'"
                            />
                    </div>
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
                       <asp:Label runat="server" ID="productDesc"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="Container">
    <div class="Container" id="orderHandle">
        <div class="containerElement">
            <asp:TextBox runat="server" ID="amountTextBox" CssClASS="amountTextBox" ToolTip="ilość w kg ..."></asp:TextBox>
        </div>
        <div class="containerElement">
            <asp:Button runat="server" ID="addToCart" text="Dodaj do koszyka" CssClass="Button" OnClick ="addToCart_Click"/>
        </div>
    </div>
</div>

<div class="Container navigationButtons">
    <div class="containerElement">
        <asp:Button runat="server" ID="deleteFromCart" text="Usun ten produkt z koszyka" CssClass="ButtonRed" OnClick ="deleteFromCart_Click"/>
    </div>
    <div class="containerElement">
        <asp:Button runat="server" ID="returnToShop" text="Powrót do sklepu" CssClass="Button" OnClick ="returnToShop_Click"/>
    </div>
    <div class="containerElement">
        <asp:Button runat="server" ID="toCart" text="Przejdź do koszyka" CssClass="Button" OnClick ="toCart_Click"/>
    </div>

</div>
</asp:Content>
