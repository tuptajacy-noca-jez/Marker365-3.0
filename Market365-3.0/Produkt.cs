using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Market365_3._0 {
    /// <summary>
    /// Przechowuje informacje o produkcie
    /// </summary>
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


        /// <summary>
        /// Konstruktor bezargumentowy tworzy pustą klasę
        /// </summary>
        public Produkt() { }

        /// <summary>
        /// Konstruktor z parametrem idProdukt tworzy instancję klasy oraz uzupełnia dane
        /// </summary>
        /// <param name="idProdukt">id produktu którego dane chcemy pobrać</param>
        public Produkt(int idProdukt) {
            this.idProdukt = idProdukt;
            fetchData(this.idProdukt);
        }

        /// <summary>
        /// Konstruktor z parametrem idProdukt oraz userId tworzy instancję klasy oraz uzupełnia dane o produkcie,
        /// dodatkowo przechowuje informacje czy produkt jest na liście ulubionych użytkownika
        /// </summary>
        /// <param name="idProdukt">id produktu którego dane chcemy pobrać</param>
        /// <param name="userId">id użytkownika dla którego chcemy sprawdzić czy produkt jest w liście ulubionych</param>
        public Produkt(int idProdukt, string userId) {
            this.idProdukt = idProdukt;
            fetchData(idProdukt, userId);
        }

        /// <summary>
        /// Konstruktor z parametrem idProdukt oraz quantity tworzy instancję klasy oraz uzupełnia dane o produkcie,
        /// dodatkowo przechowuje informacje o ilości produktu
        /// </summary>
        /// <param name="idProdukt">id produktu którego dane chcemy pobrać</param>
        /// <param name="quantity">ilość danego produktu</param>
        public Produkt(int idProdukt,double quantity) {
            this.idProdukt = idProdukt;
            this.ilosc = quantity;
            fetchData(this.idProdukt);
        }

        /// <summary>
        /// Konstruktor z parametrem idProdukt, quantity oraz totalValue tworzy instancję klasy oraz uzupełnia dane o produkcie,
        /// dodatkowo przechowuje informacje o ilości produktu oraz łącznej wartości - pomocne do przechowywania danych o pozycji w koszyku/zamówieniu
        /// </summary>
        /// <param name="idProdukt">id produktu którego dane chcemy pobrać</param>
        /// <param name="quantity">ilość danego produktu</param>
        /// <param name="totalValue">całkowita wartość produktu (w koszyku/zamówieniu)</param>
        public Produkt(int idProdukt, double quantity, double totalValue) {
            this.idProdukt = idProdukt;
            this.ilosc = quantity;
            this.totalValue = totalValue;
            fetchData(this.idProdukt);
        }

        /// <summary>
        /// Funkcja fetchData dla danego id produktu pobiera dane i zapisuje je w instancji klasy Produkt
        /// </summary>
        /// <param name="id"> Parametr id jest identyfikatorem produktu</param>
        /// <returns>
        /// Prawda - jeśli z powodzeniem zostaną pobrane i zapisane dane
        /// Fałsz - jeśli nie uda się pobrać i zapisać danych
        /// </returns>
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

        /// <summary>
        /// Funkcja fetchData z dwoma parametrami działa tak jak funkcja fetchData z jednym parametrem <see cref="fetchData(int)"/>,
        /// funkcja z dwoma parametrami dodatkowo daje informacje czy produkt jest w liście ulubionych użytkownika
        /// </summary>
        /// <param name="id"> Parametr id jest identyfikatorem produktu</param>
        /// <param name="usertID">Parametr usertID jest identyfikatorem użytkownika</param>
        /// <returns>
        /// Prawda - jeśli z powodzeniem zostaną pobrane i zapisane dane
        /// Fałsz - jeśli nie uda się pobrać i zapisać danych
        /// </returns>
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