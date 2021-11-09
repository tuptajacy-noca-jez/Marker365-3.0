using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projekt
{
    public partial class Rejestracja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            loginValidator.Validate();
            passwordValidator.Validate();
            nameValidator.Validate();
            surnameValidator.Validate();
            zipCodeValidator.Validate();
            cityValidator.Validate();
            streetValidator.Validate();
            houseNumberValidator.Validate();
            phoneNumberValidator.Validate();
            emailValidator.Validate();
        }
    }
}