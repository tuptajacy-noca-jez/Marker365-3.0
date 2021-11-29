using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Market365_3._0;

namespace projekt
{
    public partial class stronaStartowa : System.Web.UI.Page
    {
        //User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Password = password.Text;
            password.Attributes.Add("value", Password);
        }

        protected void zaloguj_Click(object sender, EventArgs e)
        {
            Logowanie(); 
        }
        /// <summary>
        /// method responsible for log in 
        /// </summary>
        public void Logowanie()
        {
            String Polaczenie;
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(1) from [customers] WHERE login=@login AND password=@password", sql);
            cmd.Parameters.AddWithValue("@login", login.Text.Trim());
            cmd.Parameters.AddWithValue("@password", password.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 1) {
                cmd = new SqlCommand("update [customers] set isActive=@isActive WHERE login='" + login.Text + "'", sql);
                cmd.Parameters.AddWithValue("@isActive", "true");
                cmd.ExecuteNonQuery();
                Validacion.Text = "Zalogowano";
                updateCurrentUser(login.Text.Trim(), password.Text.Trim(), sql);
                sql.Close();
                Response.Redirect("/StronaGlowna/StronaGlowna.aspx");
                
            }
            else {
                sql.Close();
                Validacion.Text = "Nieprawidłowy login lub hasło";
            }
                
            Validacion.Visible = true;

            
        }

        /// <summary>
        /// Method <c>updateCurrentUser</c> take login and password as strings and already opened SqlConnection;
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="sql"></param>
        public void updateCurrentUser(string login,string password, SqlConnection sql)
        {
            User currentUser = new User();
            currentUser.Login = login;
            currentUser.Password = password;
            SqlCommand cmd = new SqlCommand("select * from [customers] WHERE login='" + login + "'", sql);
            SqlDataReader mdr = cmd.ExecuteReader();

            if(mdr.Read())
            {
                currentUser.Name = mdr["name"].ToString();
                currentUser.Surname = mdr["surname"].ToString();
                currentUser.City = mdr["city"].ToString();
                currentUser.ZipCode = mdr["zipCode"].ToString();
                currentUser.Street = mdr["street"].ToString();
                currentUser.HouseNumber = mdr["houseNumber"].ToString();
                currentUser.PhoneNumber = mdr["phoneNumber"].ToString();
                currentUser.Email = mdr["email"].ToString();
                currentUser.IsActive = true;
            }

            Application["user"] = currentUser;
        }
        
        protected void rejestracja_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Rejestracja/Rejestracja.aspx");
        }

        protected void przeglad_Click(object sender, EventArgs e) {
            Response.Redirect("/Sklep/Sklep.aspx");
        }
    }
}