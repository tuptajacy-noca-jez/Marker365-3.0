using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Market365_3._0 {
    public class Produkt {
        public string image;
        public string name;
        public float price;
        public string unit;
        public float ocena;




        public int idProdukt;
        public float ilosc;

        public dynamic[] values;

        public Produkt() { }

        public Produkt(int idProdukt) {
            this.idProdukt = idProdukt;

            fetchData(this.idProdukt);
        }
        

        private bool fetchData(int id) {

            string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            try {
                sql.Open();
                SqlCommand cmd = new SqlCommand("select * from [products] WHERE ID=@id", sql);

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();
                int l = sqlDataReader.FieldCount;
                values = new dynamic[l];
                int c = sqlDataReader.GetValues(values);

                sql.Close();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
    }
}