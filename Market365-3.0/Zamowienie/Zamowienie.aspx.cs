using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Zamowienie
{
    public partial class Zamowienie : System.Web.UI.Page
    {
        User currentUser;
        Order newOrder;
        List<int> ids;
        List<double> quantities;
        string Polaczenie;
        double sum;
        double rabat;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            nameValidator.Validate();
            surnameValidator.Validate();
            zipCodeValidator.Validate();
            cityValidator.Validate();
            streetValidator.Validate();
            houseNumberValidator.Validate();
            phoneNumberValidator.Validate();
            currentUser = (User)Application["user"];
            newOrder =  (Order) Application["order"];
            ids = (List<Int32>) Application["orderProductIds"];
            sum = (double)Application["cartValue"];
            quantities = (List<double>)Application["orderProductquantity"];
            value.Text = "Wartość koszyka: " + sum + "zł";
            rabat = 1;
            
            if (discount.Text =="alerabat2137")
            {
                rabat = 0.9;
                value.Visible = false;
                discountValue.Visible = true;
                newOrder.Value = sum*rabat;               
            }
            else
            {
                newOrder.Value = sum;
            }
                
            discountValue.Text = "Wartość koszyka po rabacie: " + sum*rabat+ "zł";
            if (zipCode.Text == "" && city.Text == "" && street.Text == "" && houseNumber.Text == "")
                ZaladujDane();
            
        }
        public void CreateOrder()
        {
            newOrder.ProductsId = ids;
            newOrder.ProductsQuantity = quantities;
            newOrder.Login = currentUser.Login;
            newOrder.OrderId = currentUser.Login + DateTime.Now.Ticks.ToString();
                newOrder.City=city.Text;
                newOrder.ZipCode=zipCode.Text;
                newOrder.Street=street.Text;
                newOrder.HouseNumber=houseNumber.Text;
                newOrder.PhoneNumber=phoneNumber.Text; ;
                newOrder.Email=email.Text;
            
                Application["order"] = newOrder;
            AddOrderToDatabase();
        }
        public void AddOrderToDatabase()
        {
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [orders] VALUES (@Id,@userlogin,@value,@name,@surname,@zipCode,@city,@street,@houseNumber,@phoneNumber,@email)", sql);
            cmd.Parameters.AddWithValue("@Id", newOrder.OrderId);
            cmd.Parameters.AddWithValue("@userlogin", currentUser.Login);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@surname", surname.Text);
            cmd.Parameters.AddWithValue("@street", street.Text);
            cmd.Parameters.AddWithValue("@houseNumber", houseNumber.Text);
            cmd.Parameters.AddWithValue("@zipCode", zipCode.Text);
            cmd.Parameters.AddWithValue("@city", city.Text);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber.Text);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@value", newOrder.Value);
            cmd.ExecuteNonQuery();
            sql.Close();

            sql.Open();
            
            for(int i=0;i<ids.Count();i++)
            {
                cmd = new SqlCommand("INSERT INTO [orderPosition] VALUES (@IdOrder,@IdProduct,@quantity)", sql);
                cmd.Parameters.AddWithValue("@IdOrder", newOrder.OrderId);
                cmd.Parameters.AddWithValue("@IdProduct", ids[i]);
                cmd.Parameters.AddWithValue("@quantity", quantities[i]);
                cmd.ExecuteNonQuery();

            }
            sql.Close();
        }
        public void ZaladujDane()
        {
            name.Text= currentUser.Name;
            surname.Text = currentUser.Surname;
            city.Text = currentUser.City;
            zipCode.Text = currentUser.ZipCode;
            street.Text = currentUser.Street;
            houseNumber.Text = currentUser.HouseNumber;
            phoneNumber.Text = currentUser.PhoneNumber;
            email.Text = currentUser.Email;
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Koszyk/Koszyk.aspx");
        }

        protected void order_Click(object sender, EventArgs e)
        {
        if (streetValidator.IsValid == true && houseNumberValidator.IsValid == true && zipCodeValidator.IsValid == true && cityValidator.IsValid == true && phoneNumberValidator.IsValid == true && emailValidator.IsValid == true)
        {
                CreateOrder();
                Application["cart"] = null;
                UsunKoszyk();
            Response.Redirect("/FinalizacjaZamowienia/FinalizacjaZamowienia.aspx");
        }
        }

        public void UsunKoszyk()
        {
            Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);
            sql.Open();
            SqlCommand cmd = new SqlCommand("DELETE from [cartPosition] WHERE IdCard='" + currentUser.Login + "'", sql);
            cmd.ExecuteNonQuery();
            sql.Close();
        }
    }
}