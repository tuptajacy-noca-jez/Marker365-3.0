﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Koszyk
{
    public partial class Koszyk : System.Web.UI.Page
    {
        Cart kosz;
        string currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser=(string)Application["currentUser"];
            kosz = new Cart(currentUser);
            ListView1.DataSource = kosz.dt;
            ListView1.DataBind();
        }

        protected void anulujButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/stronaGłówna/stronaGłówna.aspx");
        }

        protected void zamowButton_Click(object sender, EventArgs e)
        {
            kosz = new Cart(currentUser); //odświeżenie danych tak na wszelki wypadek
            List<int> ids = new List<int>();
            List<float> quantities = new List<float>();
            double cartValue = 0.0;
            foreach (var item in kosz.produkts)
            {
                ids.Add(item.id);
                quantities.Add(item.quantity);
                cartValue += item.price * item.quantity;
            }
            Application.Lock();
            Application["orderProductIds"] = ids;
            Application["orderProductquantity"] = quantities;
            Application["cartValue"] = cartValue;
            Application.UnLock();

            Response.Redirect("~/Zamowienie/Zamowienie.aspx");
        }   

        protected void iloscProduktu_TextChanged(object sender, EventArgs e)
        {
            //ListView1.SelectedIndex;
        }
    }
}