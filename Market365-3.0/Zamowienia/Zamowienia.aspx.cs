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
            currUser = (User)Session["user"];
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            //SqlDataAdapter ada = new SqlDataAdapter("SELECT TOP 1 [products].[image],[orders].Id,[orders].value from [orders] INNER JOIN[orderPosition] on[orders].[Id] =[orderPosition].[IdOrder] INNER JOIN[products] ON[orderPosition].[IdProduct] =[products].[Id]WHERE orders.userlogin = '"+ currUser.Login +"'", Polaczenie); // where [userlogin]='zalogowanyuzytkownik'
            //List<Order>

            SqlDataAdapter ada = new SqlDataAdapter("SELECT DISTINCT[orders].Id,[orders].value " +
                "from[orders] WHERE[orders].userlogin = '" +currUser.Login+"'", sql);

            DataTable dt = new DataTable();
            ada.Fill(dt);

            dt.Columns.Add("image");

            

            foreach (DataRow row in dt.Rows)
            {
                SqlCommand ad = new SqlCommand("SELECT TOP 1 products.image FROM products " +
                    " INNER JOIN orderPosition on products.Id = orderPosition.IdProduct " +
                    " WHERE orderPosition.IdOrder = '" + row["Id"].ToString() + "'; ",sql);
                SqlDataReader sqlDataReader = ad.ExecuteReader();
                sqlDataReader.Read();
                int l = sqlDataReader.FieldCount;
                object[] values = new object[l];
                int c = sqlDataReader.GetValues(values);

                row["image"]=values[0].ToString();
                sqlDataReader.Close();

            }



            //ada.Fill(dt);
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