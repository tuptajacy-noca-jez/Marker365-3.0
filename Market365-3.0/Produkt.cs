using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Market365_3._0 {
    public class Produkt {
        public Int32 id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public float quantity { get; set; }
        public string unit { get; set; }
        public float ocena { get; set; }

        public bool favourite { get; set; }




        public int idProdukt;
        public double ilosc;
        public double totalValue;

        /// <summary>
        /// [0] - id
        /// [1] - name
        /// [2] - description
        /// [3] - price
        /// [4] - image
        /// [5] - unit
        /// </summary>
        public object[] values;



        public Produkt() { }

        public Produkt(int idProdukt) {
            this.idProdukt = idProdukt;

            fetchData(this.idProdukt);
        }


        public Produkt(int idProdukt, string userId) {
            this.idProdukt = idProdukt;

            fetchData(idProdukt, userId);
        }

        public Produkt(int idProdukt,double quantity) {
            this.idProdukt = idProdukt;
            this.ilosc = quantity;
            fetchData(this.idProdukt);
        }

        public Produkt(int idProdukt, double quantity, double totalValue) {
            this.idProdukt = idProdukt;
            this.ilosc = quantity;
            this.totalValue = totalValue;
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
                sqlDataReader.Close();



                cmd = new SqlCommand(
                        "SELECT avg(rate) FROM Ratings WHERE idproduct=@IdProduct;", sql);
                cmd.Parameters.AddWithValue("@IdProduct", idProdukt);

                sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                var avgRate = sqlDataReader.GetValue(0);
               
                
                sqlDataReader.Close();
                try {
                    ocena = Convert.ToInt32(avgRate);
                }
                catch(Exception ex) {
                    ocena = 0;
                }
                

                sql.Close();
                return true;
            }
            catch (Exception ex) {
                Trace.Write(ex.Message);
                //Console.WriteLine(ex.Message);
                return false;
            }
        }


        private bool fetchData(int id, string usertID) {

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
                sqlDataReader.Close();

                cmd = new SqlCommand(
                        "SELECT COUNT (IdProduct) FROM favouritesPosition WHERE IdCustomer=@IdCustomer AND IdProduct=@IdProduct;", sql);
                cmd.Parameters.AddWithValue("@IdCustomer", usertID);
                cmd.Parameters.AddWithValue("@IdProduct", idProdukt);

                sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                var count = sqlDataReader.GetValue(0);
                sqlDataReader.Close();

                if ((int)count == 0) {//dodaj produkt do ulubionych
                    favourite = false;
                }
                else {
                    favourite = true;
                }




                cmd = new SqlCommand(
                        "SELECT rate FROM Ratings WHERE userlogin=@IdCustomer AND idproduct=@IdProduct;", sql);
                cmd.Parameters.AddWithValue("@IdCustomer", usertID);
                cmd.Parameters.AddWithValue("@IdProduct", idProdukt);

                sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                var rate = sqlDataReader.GetValue(0);
                sqlDataReader.Close();

                if (rate == null) {//dodaj produkt do ulubionych
                    cmd = new SqlCommand(
                         "SELECT avg(rate) FROM Ratings WHERE idproduct=@IdProduct;", sql);
                    cmd.Parameters.AddWithValue("@IdProduct", idProdukt);

                    sqlDataReader = cmd.ExecuteReader();
                    sqlDataReader.Read();

                    var avgRate = sqlDataReader.GetValue(0);
                    try {
                        ocena = Convert.ToInt32(avgRate);
                    }
                    catch (Exception ex) {
                        ocena = 0;
                    }
                    sqlDataReader.Close();
                }
                else {
                    ocena = (int)rate;
                }










                sql.Close();
                return true;
            }
            catch (Exception ex) {
                Trace.Write(ex.Message);
                //Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}