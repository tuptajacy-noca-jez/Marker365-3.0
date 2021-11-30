using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Market365_3._0.StronaProduktu {

    
    
    public partial class StronaProduktu : System.Web.UI.Page{

        private int productID;
        
        protected void Page_Load(object sender, EventArgs e) {
            Uri uri= Request.Url;
            productID = getProductNumber(uri.ToString());

            //ID = 10;
            Produkt produkt = new Produkt(productID);
            var values = produkt.values;

            string[] converedValues = new string[values.Length];

            for (int i = 0; i < values.Length; ++i) {
                try {
                    converedValues[i] = values[i].ToString();
                }
                catch(Exception) {

                }
            }

            try {
                string afterFormatString = char.ToUpper(converedValues[1][0]) + converedValues[1].Substring(1);
                productNameLabel.Text = afterFormatString;
                priceTag.Text= converedValues[3] +" zł/"+ converedValues.Last();
            }
            catch (NullReferenceException ex) {
                //carryon
            }

        }

       
        static void CaptLetter() {
            string str = "educative";

            if (str.Length == 0)
                System.Console.WriteLine("Empty String");
            else if (str.Length == 1)
                System.Console.WriteLine(char.ToUpper(str[0]));
            else
                System.Console.WriteLine(char.ToUpper(str[0]) + str.Substring(1));
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
                        
                        //sqlDataReader.Close();
                        if (sqlDataReader.HasRows) {
                            sqlDataReader.Close();
                            cmd = new SqlCommand("UPDATE [cartPosition] SET (IdProduct=@IdProduct,quantit=@quantity) WHERE IdCard=@IdCard", sql);
                            cmd.Parameters.AddWithValue("@IdProduct", productID);
                            cmd.Parameters.AddWithValue("@quantity", amount+int.Parse(values[2].ToString())); ;
                            cmd.Parameters.AddWithValue("@IdCard", currUser.Login);
                        }
                        else {
                            sqlDataReader.Close();
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
    }
}