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
            orderID.Text = "Zamówienie nr:" + "2137";
            value.Text = "Wartość koszyka: " + "9,11" + "zł";
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Koszyk/Koszyk.aspx");
        }
    }
}