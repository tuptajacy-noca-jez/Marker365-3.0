using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Market365_3._0;
namespace Market365_3._0.MojProfil
{
    public partial class MojProfil : System.Web.UI.Page
    {
        User currentUser;

        //User pomUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            // passwordValidator.Validate();
            //  pomUser = new User(currentUser.Login, currentUser.Password);
            cityValidator.Validate();
            streetValidator.Validate();
            houseNumberValidator.Validate();
            phoneNumberValidator.Validate();
            emailValidator.Validate();
            zipCodeValidator.Validate();
            newPasswordValidator.Validate();
            newPasswordConfirmValidator.Validate();
            CompareValidator1.Validate();
            CompareValidator2.Validate();
            password.ForeColor = System.Drawing.Color.Black;
            string Password = password.Text;
            password.Attributes.Add("value", Password);
            string NewPassword = newPassword.Text;
            newPassword.Attributes.Add("value", NewPassword);
            string NewPasswordConfirm = newPasswordConfirm.Text;
            newPasswordConfirm.Attributes.Add("value", NewPasswordConfirm);

            // string ZipCode = zipCode.Text;
            // zipCode.Attributes.Add("value", ZipCode);
            currentUser = (User)Application["user"];
            Label2.Text = "Witaj " + currentUser.Name;
            Label3.ForeColor = System.Drawing.Color.Black;
            Label3.Text = "";
            if (zipCode.Text == "" && city.Text == "" && street.Text == "" && houseNumber.Text == "")
                ZaladujDane();
        }
        /// <summary>
        /// load current user data to textboxes
        /// </summary>
        public void ZaladujDane()
        {
            city.Text = currentUser.City;
            zipCode.Text = currentUser.ZipCode;
            street.Text = currentUser.Street;
            houseNumber.Text = currentUser.HouseNumber;
            phoneNumber.Text = currentUser.PhoneNumber;
            email.Text = currentUser.Email;

        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void zapisz_Click(object sender, EventArgs e)
        {
            //passwordValidator.Validate();
            if (newPasswordValidator.IsValid == true && newPasswordConfirmValidator.IsValid == true && CompareValidator1.IsValid == true && streetValidator.IsValid == true && CompareValidator2.IsValid == true && houseNumberValidator.IsValid == true && zipCodeValidator.IsValid == true && cityValidator.IsValid == true && phoneNumberValidator.IsValid == true && emailValidator.IsValid == true)
            {
                String Polaczenie;
                Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                SqlConnection sql = new SqlConnection(Polaczenie);
                sql.Open();
                if (password.Text == "")
                {
                    SqlCommand cmd = new SqlCommand("update [customers] set city=@city,zipCode=@zipCode,street=@street,houseNumber=@houseNumber,phoneNumber=@phoneNumber,email=@email WHERE login='" + currentUser.Login + "'", sql);
                    cmd.Parameters.AddWithValue("@city", city.Text);
                    cmd.Parameters.AddWithValue("@zipCode", zipCode.Text);
                    cmd.Parameters.AddWithValue("@street", street.Text);
                    cmd.Parameters.AddWithValue("@houseNumber", houseNumber.Text);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                    currentUser.City = city.Text;
                    currentUser.ZipCode = zipCode.Text;
                    currentUser.HouseNumber = houseNumber.Text;
                    currentUser.Street = street.Text;
                    currentUser.PhoneNumber = phoneNumber.Text;
                    currentUser.Email = email.Text;
                    Application["user"] = currentUser;
                    Label3.Text = "Zmiany zostały zapisane!";
                }
                else
                {
                    if (currentUser.Password == password.Text && newPassword.Text != "" && newPasswordConfirm.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("update [customers] set password=@password,city=@city,zipCode=@zipCode,street=@street,houseNumber=@houseNumber,phoneNumber=@phoneNumber,email=@email WHERE login='" + currentUser.Login + "'", sql);
                        cmd.Parameters.AddWithValue("@password", newPassword.Text);
                        cmd.Parameters.AddWithValue("@city", city.Text);
                        cmd.Parameters.AddWithValue("@zipCode", zipCode.Text);
                        cmd.Parameters.AddWithValue("@street", street.Text);
                        cmd.Parameters.AddWithValue("@houseNumber", houseNumber.Text);
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber.Text);
                        cmd.Parameters.AddWithValue("@email", email.Text);
                        cmd.ExecuteNonQuery();
                        sql.Close();
                        currentUser.Password = newPassword.Text;
                        currentUser.City = city.Text;
                        currentUser.ZipCode = zipCode.Text;
                        currentUser.HouseNumber = houseNumber.Text;
                        currentUser.Street = street.Text;
                        currentUser.PhoneNumber = phoneNumber.Text;
                        currentUser.Email = email.Text;
                        Application["user"] = currentUser;
                        Label3.Text = "Zmiany zostały zapisane!";
                    }
                    else
                    {
                        Label3.ForeColor = System.Drawing.Color.Red;
                        Label3.Text = "Błędne Hasło!";
                    }

                }

            }


        }


    }
}