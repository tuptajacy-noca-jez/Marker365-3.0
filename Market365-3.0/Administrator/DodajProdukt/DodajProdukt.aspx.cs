using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Administrator.DodajProdukt
{
    public partial class DodajProdukt : System.Web.UI.Page
    {
        User currentUser;

        //User pomUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            // passwordValidator.Validate();
            //  pomUser = new User(currentUser.Login, currentUser.Password);
          //  cityValidator.Validate();
           // streetValidator.Validate();
         //   houseNumberValidator.Validate();
         //   phoneNumberValidator.Validate();
          //  emailValidator.Validate();
          //  zipCodeValidator.Validate();
          //  newPasswordValidator.Validate();
          //  newPasswordConfirmValidator.Validate();
          //  CompareValidator1.Validate();
           // CompareValidator2.Validate();
           // password.ForeColor = System.Drawing.Color.Black;
          //  string Password = password.Text;
          //  password.Attributes.Add("value", Password);
          //  string NewPassword = newPassword.Text;
          //  newPassword.Attributes.Add("value", NewPassword);
         //   string NewPasswordConfirm = newPasswordConfirm.Text;
          //  newPasswordConfirm.Attributes.Add("value", NewPasswordConfirm);

            // string ZipCode = zipCode.Text;
            // zipCode.Attributes.Add("value", ZipCode);
            currentUser = (User)Application["user"];
            Label2.Text = "Witaj " + currentUser.Name;
            Label3.ForeColor = System.Drawing.Color.Black;
          //  Label3.Text = "";
           // if (zipCode.Text == "" && city.Text == "" && street.Text == "" && houseNumber.Text == "")
            //    ZaladujDane();
        }
        /// <summary>
        /// load current user data to textboxes
        /// </summary>
        public void ZaladujDane()
        {
           // city.Text = currentUser.City;
           // zipCode.Text = currentUser.ZipCode;
           // street.Text = currentUser.Street;
           // houseNumber.Text = currentUser.HouseNumber;
           // phoneNumber.Text = currentUser.PhoneNumber;
          //  email.Text = currentUser.Email;

        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void zapisz_Click(object sender, EventArgs e)
        {
            //passwordValidator.Validate();
           


        }
    }
}