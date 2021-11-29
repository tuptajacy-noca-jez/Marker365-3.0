using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.StatusZamowienia {
    public partial class StronaZamowienia : System.Web.UI.Page {

        private Order order;
        public DataTable dt = new DataTable();
        public string idZamowienia;





        protected void Page_Load(object sender, EventArgs e) {
            Uri uri = Request.Url;
            idZamowienia = getOrderID(uri.ToString());
            //idZamowienia = "test637737918145452143";
            order = new Order(idZamowienia);
            //_ = order.ProductsId;
            //_ = order.ProductsQuantity;
            try {
                loadProducts();
                ordersListViev.DataSource = dt;
                ordersListViev.DataBind();

                labelTotalVale.Text=order.Value.ToString();
                orderNrLabel.Text = idZamowienia;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                //carry on
            }
        }

        protected void returnToOrders_Click(object sender, EventArgs e) {
            Response.Redirect("~/Zamowienia/Zamowienia.aspx/");
        }

        private void loadProducts() {
            try {

                string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

                SqlConnection sql = new SqlConnection(Polaczenie);
                //sql.Open();
                //SqlCommand cmd = new SqlCommand("select * from [orderPosition] WHERE IdOrder=@IdOrder", sql);


                SqlCommand cmd = new SqlCommand(
                   "select [orderPosition].*, [products].[name], [products].[price], [products].[image] " +
                   " from [products] INNER JOIN [orderPosition] ON [orderPosition].IdProduct = [products].Id " +
                   " WHERE [orderPosition].IdOrder = '"+ idZamowienia + "'", sql);

                sql.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(dt);
                //_ = dt.Columns;
                
                sql.Close();

            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                //carry on
            }
        }

        private string getOrderID(string URI) {
            try {
                string[] bufer = URI.Split('/');
                return bufer.Last();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return "-1";
            }
        }
    }
}