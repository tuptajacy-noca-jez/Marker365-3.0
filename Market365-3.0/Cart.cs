using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Market365_3._0
{
    public class Cart
    {
        public string currUser;
        public DataTable dt = new DataTable();
        public List<Produkt> produkts;

       public Cart(string User)
        {
            this.currUser = User;

            string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            SqlCommand cmd = new SqlCommand("select [products].*,[cartPosition].[quantity] from [products],[cartPosition],[cart] WHERE [cart].Id= "+ currUser +" , sql"); // może nie działać
            sql.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.Fill(dt);
            sql.Close();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                Produkt produkt = new Produkt();
                produkt.image = dt.Rows[i]["image"].ToString();
                produkt.name = dt.Rows[i]["name"].ToString();
                produkt.price = (float)Convert.ToDouble(dt.Rows[i]["price"]);
                //produkt.unit = Convert.ToInt32(dt.Rows[i]["quantity"]); // czy unit == ilosc w koszyku
                produkts.Add(produkt);
            }
        }
    }
}