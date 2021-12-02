using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;

namespace Market365_3._0.StronaProduktu {

    
    
    public partial class StronaProduktu : System.Web.UI.Page{

        private int productID;

        Produkt produkt;
        
        protected void Page_Load(object sender, EventArgs e) {
            string b = sender.GetType().Name;
            Uri uri= Request.Url;
            UriProcessor uriProcessor = new UriProcessor(uri);
            string[] uriParameters = uriProcessor.UriDecoder();
            productID = int.Parse(uriParameters[0]);
            User user = (User)Session["user"];

            if (user.IsActive) {
                deleteFromCart.CssClass = "ButtonRed visibilityOn";
                toCart.CssClass = "Button visibilityOn";

            }
            else {
                deleteFromCart.CssClass = "visibilityOff";
                toCart.CssClass = "visibilityOff";
            }

            if (productID != -1) {
                try {
                    
                    if (user.IsActive) {
                        produkt = new Produkt(productID, user.Login);
                    }
                    else {
                        produkt = new Produkt(productID);
                    }
                    
                    likeButtonSourceChanger(produkt.favourite);
                    var values = produkt.values;

                    string[] converedValues = new string[values.Length];

                    for (int i = 0; i < values.Length; ++i) {
                        try {
                            converedValues[i] = values[i].ToString();
                        }
                        catch (Exception ex) {
                            Debug.WriteLine(ex.Message);
                        }
                    }

                    try {
                        string afterFormatString = char.ToUpper(converedValues[1][0]) + converedValues[1].Substring(1);
                        productNameLabel.Text = afterFormatString;
                        priceTag.Text = converedValues[3] + " zł/" + converedValues.Last();
                        productImage.Src = "data:image/jpg;base64," + converedValues[4];
                        productDesc.Text = converedValues[2];
                        lightUpStarts();
                    }
                    catch (NullReferenceException ex) {
                        Debug.WriteLine(ex.Message);
                    }
                }
                catch(Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private int getProductNumber(string URI) {
            try {
                string[] bufer = URI.Split('/');
                return Int32.Parse(bufer.Last());
            }
            catch (FormatException) {
                return -1;
            }
        }







        
        public  void addToCart_Click(object sender, EventArgs e) {
            try {
                Uri uri = Request.Url;
                productID = getProductNumber(uri.ToString());
                Produkt produkt = new Produkt(productID);

                User currUser = (User)Session["user"];
                if (currUser.IsActive == false) {
                    Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
                }
                else {
                    int amount = int.Parse(amountTextBox.Text);
                    if (amount > 0) {
                        Button button = (Button)sender;

                        String Polaczenie;
                        Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                        SqlConnection sql = new SqlConnection(Polaczenie);
                        SqlCommand cmd;

                        cmd = new SqlCommand("SELECT *  FROM [cartPosition] WHERE IdProduct=@IdProduct", sql);
                        cmd.Parameters.AddWithValue("@IdProduct", produkt.idProdukt);
                        sql.Open();

                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        sqlDataReader.Read();

                        int l = sqlDataReader.FieldCount;
                        object[] values=new object[l];
                        bool hasRows = sqlDataReader.HasRows;
                        if (hasRows) {
                            _ = sqlDataReader.GetValues(values);
                        }
                        
                        
                        sqlDataReader.Close();
                        
                        if (hasRows) {
                            cmd = new SqlCommand("UPDATE [cartPosition] SET quantity=@quantity WHERE IdCard=@IdCard AND IdProduct=@IdProduct", sql);
                            int amountPresent = int.Parse(values[2].ToString());
                            amountPresent += amount;
                            if (amountPresent <= 0) {
                                cmd = new SqlCommand("DELETE * FROM [cartPosition] WHERE IdCard=@IdCard AND IdProduct=@IdProduct", sql);
                            }
                            else 
                                cmd.Parameters.AddWithValue("@quantity", (double)amountPresent);
                        }
                        else {
                            cmd = new SqlCommand("INSERT INTO [cartPosition] VALUES (@IdCard,@IdProduct,@quantity)", sql);
                            cmd.Parameters.AddWithValue("@quantity", amount);
                        }
                        cmd.Parameters.AddWithValue("@IdCard", currUser.Login);
                        cmd.Parameters.AddWithValue("@IdProduct", productID);
                        cmd.ExecuteNonQuery();
                        sql.Close();
                    }
                }
            }
            catch (Exception ex) {
                Debug.Write(ex.Message);
            }
           
        }

        
        public void like_click(object sender, EventArgs e) {
            try {
                User user = (User)Session["user"];
                if (!user.IsActive) {
                    return;
                }
                Uri uri = Request.Url;
                UriProcessor uriProcessor = new UriProcessor(uri);
                string[] uriParameters = uriProcessor.UriDecoder();

                string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

                SqlConnection sql = new SqlConnection(Polaczenie);

                SqlCommand cmd = new SqlCommand(
                   "SELECT COUNT(IdProduct) FROM favouritesPosition WHERE IdCustomer=@IdCustomer AND IdProduct=@IdProduct;", sql);
                cmd.Parameters.AddWithValue("@IdCustomer", user.Login);
                cmd.Parameters.AddWithValue("@IdProduct", uriParameters[0]);

                sql.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                var count = sqlDataReader.GetValue(0);
                sqlDataReader.Close();

                if ((int)count == 0) {//dodaj produkt do ulubionych
                    cmd = new SqlCommand(
                        "INSERT INTO[favouritesPosition] (IdProduct, IdCustomer) VALUES (@IdProduct, @IdCustomer);", sql);
                    produkt.favourite = true;
                }
                else {//usun produkt z ulubionych
                    cmd = new SqlCommand(
                        "DELETE FROM [favouritesPosition]  WHERE IdCustomer=@IdCustomer AND IdProduct=@IdProduct;", sql);
                    produkt.favourite = false;
                }
                cmd.Parameters.AddWithValue("@IdCustomer", user.Login);
                cmd.Parameters.AddWithValue("@IdProduct", int.Parse(uriParameters[0]));

                cmd.ExecuteNonQuery();

                sql.Close();
                likeButtonSourceChanger(produkt.favourite);
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public void likeButtonSourceChanger(bool isFavourite) {
            if (isFavourite) {
                likeButtonV22.ImageUrl = "../resources/icons/hearfilled.png";
                likeButtonV22.Attributes.Add("onmouseover", "this.src='/resources/icons/hearEmpty.png'");
                likeButtonV22.Attributes.Add("onmouseout", "this.src='/resources/icons/hearfilled.png'");
            }
            else {
                likeButtonV22.ImageUrl = "../resources/icons/hearEmpty.png";
                likeButtonV22.Attributes.Add("onmouseover", "this.src='/resources/icons/hearfilled.png'");
                likeButtonV22.Attributes.Add("onmouseout", "this.src='/resources/icons/hearEmpty.png'");
            }
        }


        private void lightUpStarts() {
            ImageButton[] imageButtons = new ImageButton[5];
            imageButtons[0]= star1;
            imageButtons[1]= star2;
            imageButtons[2]= star3;
            imageButtons[3]= star4;
            imageButtons[4]= star5;
            for(int i=0; i < 5;  ++i) {
                imageButtons[0].ImageUrl= "/resources/icons/starUnrated.png";
            }

            for (int i = 1; i <= produkt.ocena;++i) {
                imageButtons[i-1].ImageUrl = "/resources/icons/starRated.png";
                imageButtons[i-1].Attributes.Add("onmouseover", "this.src='/resources/icons/starUnrated.png'");
                imageButtons[i-1].Attributes.Add("onmouseout", "this.src='/resources/icons/starRated.png'");
            }
            for(int i = (int)produkt.ocena+1; i<=5;++i) {
                imageButtons[i - 1].ImageUrl = "/resources/icons/starUnrated.png";
                imageButtons[i - 1].Attributes.Add("onmouseover", "this.src='/resources/icons/starRated.png'");
                imageButtons[i - 1].Attributes.Add("onmouseout", "this.src='/resources/icons/starUnrated.png'");
            }
        }
        public void starButton_Click(object sender, EventArgs e) {
            ImageButton button = (ImageButton)sender;
            int rate = int.Parse(button.ID.ToString().Last().ToString());
            User user = (User)Session["user"];
            if (!user.IsActive) {
                return;
            }
            try {
                //User user = (User)Session["user"];
                Uri uri = Request.Url;
                UriProcessor uriProcessor = new UriProcessor(uri);
                string[] uriParameters = uriProcessor.UriDecoder();

                string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

                SqlConnection sql = new SqlConnection(Polaczenie);

                SqlCommand cmd = new SqlCommand(
                   "SELECT COUNT (userlogin) FROM Ratings WHERE userlogin=@IdCustomer AND idproduct=@IdProduct;", sql);
                cmd.Parameters.AddWithValue("@IdCustomer", user.Login);
                cmd.Parameters.AddWithValue("@IdProduct", uriParameters[0]);

                sql.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                var count = sqlDataReader.GetValue(0);
                sqlDataReader.Close();

                if ((int)count == 0) {//dodaj ocenę
                    cmd = new SqlCommand(
                        "INSERT INTO [Ratings] VALUES (@IdCustomer, @IdProduct, @rate );", sql);
                }
                else {//edytuj ocenę
                    cmd = new SqlCommand(
                        "UPDATE [Ratings] SET rate=@rate WHERE userlogin=@IdCustomer AND idproduct=@IdProduct;", sql);
                }
                produkt.ocena = rate;
                cmd.Parameters.AddWithValue("@IdCustomer", user.Login);
                cmd.Parameters.AddWithValue("@IdProduct", int.Parse(uriParameters[0]));
                cmd.Parameters.AddWithValue("@rate", rate);

                cmd.ExecuteNonQuery();

                sql.Close();
                lightUpStarts();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        private void parametersHandle(string[] args) {
            if (args[1] == "likeButton") {
                
            }
            else if (args[1] == "starButton") {
                try {

                }
                catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        protected void returnToShop_Click(object sender, EventArgs e) {
            Server.Transfer("~/Sklep/Sklep.aspx");
        }

        protected void toCart_Click(object sender, EventArgs e) {
            Server.Transfer("~/Koszyk/Koszyk.aspx");
        }

        protected void deleteFromCart_Click(object sender, EventArgs e) {
            try {
                Button button = (Button)sender;
                User currUser = (User)Session["user"];
                String Polaczenie;
                Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                SqlConnection sql = new SqlConnection(Polaczenie);
                SqlCommand cmd;

                cmd = new SqlCommand("SELECT *  FROM [cartPosition] WHERE IdProduct=@IdProduct", sql);
                cmd.Parameters.AddWithValue("@IdProduct", produkt.idProdukt);
                sql.Open();

                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                int l = sqlDataReader.FieldCount;
                object[] values = new object[l];
                bool hasRows = sqlDataReader.HasRows;

                sqlDataReader.Close();

                if (hasRows) {
                    cmd = new SqlCommand("DELETE FROM [cartPosition] WHERE IdCard=@IdCard AND IdProduct=@IdProduct", sql);

                    cmd.Parameters.AddWithValue("@IdCard", currUser.Login);
                    cmd.Parameters.AddWithValue("@IdProduct", productID);

                    cmd.ExecuteNonQuery();
                }
                
                sql.Close();
            }
            catch(Exception ex ) {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}