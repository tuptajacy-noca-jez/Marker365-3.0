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
        String Polaczenie;
        protected void Page_Load(object sender, EventArgs e)
        {
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlDataAdapter ada = new SqlDataAdapter("select * from [orders]", Polaczenie); // where [userlogin]='zalogowanyuzytkownik'
            DataSet dt = new DataSet();
            ada.Fill(dt);
            sql.Close();

            //ListView1.DataSource = dt;
            //ListView1.DataBind();
            
        }

        protected void edycjaZamowienia_Click(object sender, ImageClickEventArgs e)
        {   
            
        }
    }

}