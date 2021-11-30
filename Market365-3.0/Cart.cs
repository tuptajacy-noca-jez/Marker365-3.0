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
        /// <summary>
        /// Zawiera indormacje o aktualnie zalogowanym użytkowniku
        /// </summary>
        public string currUser;
        /// <summary>
        /// Tabela danych dt zawiera wszytskie informacje o produktach w koszyku pobrane z bazy danych oraz ilość tych produktów w koszyku
        /// </summary>
        public DataTable dt = new DataTable();
        /// <summary>
        /// lista produkts zawiera informacje o produktach w koszyku jako klasy Produkt
        /// </summary>
        public List<Produkt> produkts = new List<Produkt>();

        /// <summary>
        /// Konstruktor Cart() tworzy pustą klasę z przygotowaną tabelą danych oraz listą (pustą) produktów w koszyku
        /// </summary>
        public Cart() { }
        /// <summary>
        /// Konstruktor Cart(string) umożliwia pobranie aktualnej listy produktów dla użytkownika User podanego jako pierwszy argument
        /// </summary>
        /// <param name="User">aktualnie zalogowany użytkownik</param>
       public Cart(string User)
        {
            this.currUser = User;

            string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            SqlCommand cmd = new SqlCommand("select [products].*,[cartPosition].[quantity] from [cartPosition] " +
                "INNER JOIN [products] ON[cartPosition].IdProduct =[products].Id " +
                "WHERE[cartPosition].IdCard = '"+ currUser +"';", sql);
            sql.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.Fill(dt);
            sql.Close();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                Produkt produkt = new Produkt();
                produkt.id = Convert.ToInt32(dt.Rows[i]["Id"]);
                produkt.image = dt.Rows[i]["image"].ToString();
                produkt.name = dt.Rows[i]["name"].ToString();
                produkt.price = (float)Convert.ToDouble(dt.Rows[i]["price"]);
                produkt.quantity = (float)Convert.ToDouble(dt.Rows[i]["quantity"]);
                produkts.Add(produkt);
            }
        }
    }
}