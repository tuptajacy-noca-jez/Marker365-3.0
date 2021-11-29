using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Market365_3._0.StronaProduktu {

    
    
    public partial class StronaProduktu : System.Web.UI.Page{

        private int ID;
        
        protected void Page_Load(object sender, EventArgs e) {
            Uri uri= Request.Url;
            ID = getProductNumber(uri.ToString());

            //ID = 10;
            Produkt produkt = new Produkt(ID);
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
        


        public string Index(string id) {
            return "ID =" + id;
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
    }
}