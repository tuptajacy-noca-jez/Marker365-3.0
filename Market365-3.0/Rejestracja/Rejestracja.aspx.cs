using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace projekt
{
    
    public partial class Rejestracja : System.Web.UI.Page
    {
        String Polaczenie;
        
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
            string Password = password.Text;
            password.Attributes.Add("value", Password);
        }

        protected void zarejestruj_Click(object sender, EventArgs e)
        {
            if (loginValidator.IsValid == true && passwordValidator.IsValid == true && nameValidator.IsValid == true && surnameValidator.IsValid == true && streetValidator.IsValid == true && houseNumberValidator.IsValid == true && zipCodeValidator.IsValid == true && cityValidator.IsValid == true && phoneNumberValidator.IsValid == true && emailValidator.IsValid == true)
            {
                if (checkLogin())
                {
                    Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                    SqlConnection sql = new SqlConnection(Polaczenie);
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO [customers] VALUES (@login,@password,@name,@surname,@street,@houseNumber,@zipCode,@city,@phoneNumber,@email,@isActive)", sql);
                    cmd.Parameters.AddWithValue("@login", login.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@surname", surname.Text);
                    cmd.Parameters.AddWithValue("@street", street.Text);
                    cmd.Parameters.AddWithValue("@houseNumber", houseNumber.Text);
                    cmd.Parameters.AddWithValue("@zipCode", zipCode.Text);
                    cmd.Parameters.AddWithValue("@city", city.Text);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@isActive", false);
                    cmd.ExecuteNonQuery();
                    sql.Close();
                }
                else
                {
                    loginValidator.IsValid = false;
                    loginValidator.ErrorMessage = "Podany login jest już zajęty";
                }
            }
        }
        bool checkLogin()
        {
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select [login] from [customers]");
            cmd.Connection = sql;
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                if (rd[0].ToString() == login.Text)
                    return false;
            }
            return true;
        }
    }
}