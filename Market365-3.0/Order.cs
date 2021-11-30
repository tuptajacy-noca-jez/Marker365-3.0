using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Market365_3._0
{
    public class Order
    {
        private String login;
        private List<Int32> productsId;
        private List<double> productsQuantity;
        private String orderId;
        private String name;
        private String surname;
        private String street;
        private String city;
        private String zipCode;
        private String houseNumber;
        private String phoneNumber;
        private String email;
        private string status;
        private double value;
         

        public Order()
        {
            this.ProductsId = null;
            this.login = "";
            this.orderId = "";
            this.name = "";
            this.surname = "";
            this.street = "";
            this.city = "";
            this.zipCode = "";
            this.houseNumber = "";
            this.phoneNumber = "";
            this.email = "";
            this.value = 0;
        }

        public Order(string id) {
            orderId = id;
            try {
                fetchData(id);
            }
            catch {
                this.ProductsId = null;
                this.login = "-1";
                this.orderId = "-1";
                this.name = "-1";
                this.surname = "-1";
                this.street = "-1";
                this.city = "-1";
                this.zipCode = "-1";
                this.houseNumber = "-1";
                this.phoneNumber = "-1";
                this.email = "-1";
                this.value = 0;
            }
        }

        public string OrderId { get => orderId; set => orderId = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public double Value { get => value; set => this.value = value; }
        public List<int> ProductsId { get => productsId; set => productsId = value; }
        public string Login { get => login; set => login = value; }
        public List<double> ProductsQuantity { get => productsQuantity; set => productsQuantity = value; }
        public string Status { get => status; set => status = value; }



        //Krystian done that
        private void fetchData(string id) {
            string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            
            try {
                sql.Open();
                SqlCommand cmd = new SqlCommand("select * from [orders] WHERE Id=@id", sql);
                
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                int fieldCount;
                object[] values;

                fieldCount = sqlDataReader.FieldCount;
                values = new dynamic[fieldCount];

                
                sqlDataReader.GetValues(values);
               
                this.value = Double.Parse(values[2].ToString());
                Status = values[11].ToString();


                cmd = new SqlCommand("SELECT * FROM [orderPosition] WHERE IdOrder = @idOrder",sql);
                cmd.Parameters.AddWithValue("@idOrder", orderId);

                sqlDataReader.Close();
                sqlDataReader = cmd.ExecuteReader();

                fieldCount = sqlDataReader.FieldCount;
                values = new dynamic[fieldCount];
                //sqlDataReader.GetValues(values);


                productsId = new List<int>();
                productsQuantity = new List<double>();

                try{
                    while (sqlDataReader.Read()) {
                        sqlDataReader.GetValues(values);
                        productsId.Add(Int32.Parse(values[1].ToString()));
                        productsQuantity.Add(Double.Parse(values[2].ToString()));
                    }
                }
                catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }

               sql.Close();

                return;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return;
            }
        }
    }


    



}