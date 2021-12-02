using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market365_3._0
{
    /// <summary>
    /// Przechowuje unformacje o użytkowniku
    /// </summary>
    public class User
    {
        private String login;
        private String password;
        private String name;
        private String surname;
        private String street;
        private String city;
        private String zipCode;
        private String houseNumber;
        private String phoneNumber;
        private String email;
        private bool isActive;

        public User()
        {
            this.login = "";
            this.password = "";
            this.name = "";
            this.surname = "";
            this.street = "";
            this.city = "";
            this.zipCode = "";
            this.houseNumber = "";
            this.phoneNumber = "";
            this.email = "";
            this.isActive = false;
        }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            this.name = "";
            this.surname = "";
            this.street = "";
            this.city = "";
            this.zipCode = "";
            this.houseNumber = "";
            this.phoneNumber = "";
            this.email = "";
            this.isActive = true;
        }


        public string Password { get => password; set => password = value; }
        public string Login { get => login; set => login = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }


    
}