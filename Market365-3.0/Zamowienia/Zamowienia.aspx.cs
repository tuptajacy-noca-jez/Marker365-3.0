using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Zamówienia
{
    public partial class Zamówienia : System.Web.UI.Page
    {
        User currUser;
        String Polaczenie;
        protected void Page_Load(object sender, EventArgs e)
        {
            currUser = (User)Application["user"];
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlDataAdapter ada = new SqlDataAdapter("SELECT TOP 1 [products].[image],[orders].Id,[orders].value from [orders] INNER JOIN[orderPosition] on[orders].[Id] =[orderPosition].[IdOrder] INNER JOIN[products] ON[orderPosition].[IdProduct] =[products].[Id]WHERE orders.userlogin = '"+ currUser.Login +"'", Polaczenie); // where [userlogin]='zalogowanyuzytkownik'
            DataSet dt = new DataSet();
            ada.Fill(dt);
            sql.Close();

            ListView1.DataSource = dt;
            ListView1.DataBind();
            
        }

        protected void edycjaZamowienia_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string buttonId = button.AlternateText;
            Response.Redirect("~/StatusZamowienia/StatusZamowienia.aspx/"+ buttonId);
        }


    }
}