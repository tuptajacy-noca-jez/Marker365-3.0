using System;
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
            //currentUser=Application["currentUser"];
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
            foreach (var item in kosz.produkts)
            {
                ids.Add(item.id);
                quantities.Add(item.quantity);
            }
            Application.Lock();
            Application["orderProductIds"] = ids;
            Application["orderProductquantity"] = quantities;
            Application.UnLock();
        }

        protected static string ReturnEncodedBase64UTF8(object rawImg)
        {
            string img = "data:image/jpg;base64,{0}";
            byte[] toEncodeAsBytes = (byte[])rawImg;
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return String.Format(img, returnValue);
        }
    }
}