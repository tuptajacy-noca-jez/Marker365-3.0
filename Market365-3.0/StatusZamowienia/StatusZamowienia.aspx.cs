using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.StatusZamowienia {
    public partial class StronaZamowienia : System.Web.UI.Page {

        private Order order;
        public DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e) {
            order = (Order)Application["order"];
            try {
                loadOrders();
                ordersListViev.DataSource = dt;
                ordersListViev.DataBind();
                                
            }
            catch (Exception) {
                //carry on
            }
        }

        protected void returnToOrders_Click(object sender, EventArgs e) {
            Response.Redirect("~/Zamowienia/Zamowienia.aspx/");
        }

        private void loadOrders() {
            try {

                string Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

                SqlConnection sql = new SqlConnection(Polaczenie);
                sql.Open();
                SqlCommand cmd = new SqlCommand("select * from [orderPosition] WHERE IdOrder=@IdOrder", sql);

                cmd.Parameters.AddWithValue("@IdOrder", order.OrderId);
                sql.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(dt);
                sql.Close();

            }
            catch (Exception) {
                //carry on
            }

            
            
        }
    }
}