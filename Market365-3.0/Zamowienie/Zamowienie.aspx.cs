using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Zamowienie
{
    public partial class Zamowienie : System.Web.UI.Page
    {
        User currentUser;
        Order newOrder;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            nameValidator.Validate();
            surnameValidator.Validate();
            zipCodeValidator.Validate();
            cityValidator.Validate();
            streetValidator.Validate();
            houseNumberValidator.Validate();
            phoneNumberValidator.Validate();
            discountValidator.Validate();
            currentUser = (User)Application["user"];
            newOrder =  (Order) Application["order"];
            value.Text = "Wartość koszyka: " + "9,11" + "zł";
            discountValue.Text = "Wartość koszyka z kodem rabatowym: ";
            if (zipCode.Text == "" && city.Text == "" && street.Text == "" && houseNumber.Text == "")
                ZaladujDane();
            
        }
        public void CreateOrder()
        {
            //newOrder.ProductsId=
            newOrder.Login = currentUser.Login;
                newOrder.City=city.Text;
                newOrder.ZipCode=zipCode.Text;
                newOrder.Street=street.Text;
                newOrder.HouseNumber=houseNumber.Text;
                newOrder.PhoneNumber=phoneNumber.Text; ;
                newOrder.Email=email.Text;
                newOrder.OrderId = currentUser.Login + DateTime.Now.Ticks.ToString();
            //newOrder.Value=
                Application["order"] = newOrder;
        }
        public void ZaladujDane()
        {
            city.Text = currentUser.City;
            zipCode.Text = currentUser.ZipCode;
            street.Text = currentUser.Street;
            houseNumber.Text = currentUser.HouseNumber;
            phoneNumber.Text = currentUser.PhoneNumber;
            email.Text = currentUser.Email;
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Koszyk/Koszyk.aspx");
        }

        protected void order_Click(object sender, EventArgs e)
        {
        if (streetValidator.IsValid == true && houseNumberValidator.IsValid == true && zipCodeValidator.IsValid == true && cityValidator.IsValid == true && phoneNumberValidator.IsValid == true && emailValidator.IsValid == true)
        {
                CreateOrder();
            Response.Redirect("/FinalizacjaZamowienia/FinalizacjaZamowienia.aspx");
        }
        }
    }
}