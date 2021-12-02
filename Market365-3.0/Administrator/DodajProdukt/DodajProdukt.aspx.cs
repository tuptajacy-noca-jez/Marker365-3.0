using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
           //// Label2.Text = "Witaj " + currentUser.Name;
          ////  Label3.ForeColor = System.Drawing.Color.Black;
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

            byte[] imageArray = System.IO.File.ReadAllBytes(@"FileUpload.FormFile");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);


            String Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [products] ([products].[name], [products].[description], [products].[price], [products].[unit], [products].[image])"+ "Values (@param1, @param2, @param3, @param4, @param5)", sql);
            command.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = nazwa.Text;
            command.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = opis.Text;
            command.Parameters.Add("@param3", SqlDbType.Real).Value = Convert.ToDouble(cena.Text);
            command.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = jednostka.Text;
            command.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = base64ImageRepresentation; //To wez w Base64 czy sie dopytaj czy cokolwiek
            SqlDataAdapter ada = new SqlDataAdapter();

            ada.InsertCommand = command;
            ada.InsertCommand.ExecuteNonQuery();
            sql.Close();

           



            Response.Redirect("~/Administrator/Administrato.aspx");

        }
    }
}       
    
