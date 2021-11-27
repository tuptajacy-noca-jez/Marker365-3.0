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
        User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Password = password.Text;
            password.Attributes.Add("value", Password);
            currentUser = new User();
        }

        protected void zaloguj_Click(object sender, EventArgs e)
        {
            if (Logowanie())
                Response.Redirect("/StronaGlowna/StronaGlowna.aspx");
        }
        public bool Logowanie()
        {
            String Polaczenie;
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(1) from [customers] WHERE login=@login AND password=@password", sql);
            cmd.Parameters.AddWithValue("@login", login.Text.Trim());
            cmd.Parameters.AddWithValue("@password", password.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 1)
            {
                cmd = new SqlCommand("update [customers] set isActive=@isActive WHERE login='" + login.Text + "'", sql);
                cmd.Parameters.AddWithValue("@isActive", "true");
                cmd.ExecuteNonQuery();
                updateCurrentUser(login.Text.Trim(), password.Text.Trim(), sql);
                return true;
            }
            else
            {
                Validacion.Text = "Nieprawidłowy login lub hasło";
                Validacion.Visible = true;
                return false;
            }

        }
        public void updateCurrentUser(string login, string password, SqlConnection sql)
        {

            currentUser.Login = login;
            currentUser.Password = password;
            SqlCommand cmd = new SqlCommand("select * from [customers] WHERE login='" + login + "'", sql);
            SqlDataReader mdr = cmd.ExecuteReader();
            if (mdr.Read())
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
                sql.Close();
            }

            Application["user"] = currentUser;
        }
        protected void zamowienia_Click(object sender, EventArgs e)
        {

        }

        protected void mojProfil_Click(object sender, EventArgs e)
        {

        }

        protected void koszyk_Click(object sender, EventArgs e)
        {

        }

        protected void sklep_Click(object sender, EventArgs e)
        {

        }
        protected void rejestracja_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Rejestracja/Rejestracja.aspx");
        }

        protected void przeglad_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sklep/Sklep.aspx");
        }
    }
}