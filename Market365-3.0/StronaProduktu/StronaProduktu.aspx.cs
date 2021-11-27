using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Market365_3._0.StronaProduktu {

    
    
    public partial class StronaProduktu : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e) {


            string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sql = new SqlConnection(Polaczenie);

            try {
                sql.Open();
                SqlCommand cmd = new SqlCommand("select * from [products] WHERE ID=@id", sql);
                //cmd.Parameters.AddWithValue("@id", produktID);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1) {
                    //cmd = new SqlCommand("update [customers] set isActive=@isActive WHERE login='" + login.Text + "'", sql);
                    cmd.Parameters.AddWithValue("@isActive", "true");
                    cmd.ExecuteNonQuery();
                }
                sql.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public string Index(string id) {
            return "ID =" + id;
        }

    }
}