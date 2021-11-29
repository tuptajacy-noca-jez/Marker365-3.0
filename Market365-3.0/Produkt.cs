﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Market365_3._0 {
    public class Produkt {
        public Int32 id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public float quantity { get; set; }
        public string unit { get; set; }
        public float ocena { get; set; }




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