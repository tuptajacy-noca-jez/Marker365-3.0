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
    public partial class stronaStartowa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Password = password.Text;
            password.Attributes.Add("value", Password);
        }

        protected void zaloguj_Click(object sender, EventArgs e)
        {
         
            String Polaczenie;
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(1) from [customers] WHERE login=@login AND password=@password",sql);
            cmd.Parameters.AddWithValue("@login", login.Text.Trim());
            cmd.Parameters.AddWithValue("@password", password.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            
            if (count==1)
            {
                cmd = new SqlCommand("update [customers] set isActive=@isActive WHERE login='"+login.Text+"'", sql);
                cmd.Parameters.AddWithValue("@isActive", "true");
                cmd.ExecuteNonQuery();
                Validacion.Text = "Zalogowano";
            }
            else
            Validacion.Text = "Nieprawidłowy login lub hasło";
            Validacion.Visible = true;
        }

        protected void rejestracja_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Rejestracja/Rejestracja.aspx");
        }
    }
}