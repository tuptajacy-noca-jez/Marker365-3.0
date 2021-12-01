using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Market365_3._0.StronaProduktu {

    
    
    public partial class StronaProduktu : System.Web.UI.Page{

        private int productID;

        Produkt produkt;
        
        protected void Page_Load(object sender, EventArgs e) {
           /* if (!IsPostBack) {
                _="Elo Elo";
            }*/
            

            string b = sender.GetType().Name;
            Uri uri= Request.Url;
            UriProcessor uriProcessor = new UriProcessor(uri);
            string[] uriParameters = uriProcessor.UriDecoder();
            productID = int.Parse(uriParameters[0]);
            if (productID != -1) {
                try {
                    User user = (User)Application["user"];
                    produkt = new Produkt(productID, user.Login);
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







        //TO DO check UPDATE CASE
        public  void addToCart_Click(object sender, EventArgs e) {
            try {
                Uri uri = Request.Url;
                productID = getProductNumber(uri.ToString());
                Produkt produkt = new Produkt(productID);

                User currUser = (User)Application["user"];
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
                        _ = sqlDataReader.GetValues(values);
                        bool hasRows = sqlDataReader.HasRows;
                        sqlDataReader.Close();
                        
                        if (hasRows) {
                            cmd = new SqlCommand("UPDATE [cartPosition] SET (IdProduct=@IdProduct,quantit=@quantity) WHERE IdCard=@IdCard", sql);
                            cmd.Parameters.AddWithValue("@IdProduct", productID);
                            cmd.Parameters.AddWithValue("@quantity", amount+int.Parse(values[2].ToString())); ;
                            cmd.Parameters.AddWithValue("@IdCard", currUser.Login);
                        }
                        else {
                            cmd = new SqlCommand("INSERT INTO [cartPosition] VALUES (@IdOrder,@IdProduct,@quantity)", sql);
                            cmd.Parameters.AddWithValue("@IdOrder", currUser.Login);
                            cmd.Parameters.AddWithValue("@IdProduct", productID);
                            cmd.Parameters.AddWithValue("@quantity", amount);
                        }
                        cmd.ExecuteNonQuery();
                        sql.Close();
                        
                        //double totalValue = amount * Double.Parse(produkt.values[3].ToString());
                        //int amount = int.Parse(amountTextBox.Text);
                    }
                }
            }
            catch (Exception ex) {
                Debug.Write(ex.Message);
            }
           
        }

        
        public void like_click(object sender, EventArgs e) {
            try {
                User user = (User)Application["user"];
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
                likeButtonV22.CssClass = "unlikeImageButton";
                //likeButtonV22.ImageUrl = "../resources/icons/hearfilled.png";
            }
            else {
                likeButtonV22.CssClass = "likeImageButton ";
                //likeButtonV22.ImageUrl = "../resources/icons/hearEmpty.png";
            }
        }

        public void starButton_Click(object sender, EventArgs e) {
            ImageButton button = (ImageButton)sender;
            int rate = int.Parse(button.ID.ToString().Last().ToString());
            User user = (User)Application["user"];
            if (!user.IsActive) {
                return;
            }
            try {
                //User user = (User)Application["user"];
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
                    produkt.favourite = true;
                }
                else {//edytuj ocenę
                    cmd = new SqlCommand(
                        "UPDATE [Ratings] SET rate=@rate WHERE IdCustomer=@IdCustomer AND IdProduct=@IdProduct;", sql);
                    produkt.favourite = false;
                }
                
                cmd.Parameters.AddWithValue("@IdCustomer", user.Login);
                cmd.Parameters.AddWithValue("@IdProduct", int.Parse(uriParameters[0]));
                cmd.Parameters.AddWithValue("@rate", rate);

                cmd.ExecuteNonQuery();

                sql.Close();
                //likeButtonSourceChanger(produkt.favourite);
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
    }
}