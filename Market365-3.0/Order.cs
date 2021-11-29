using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market365_3._0
{
    public class Order
    {
        private String login;
        private List<Int32> productsId;
        private List<float> productsQuantity;
        private String orderId;
        private String name;
        private String surname;
        private String street;
        private String city;
        private String zipCode;
        private String houseNumber;
        private String phoneNumber;
        private String email;
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
        public List<float> ProductsQuantity { get => productsQuantity; set => productsQuantity = value; }
    }


}