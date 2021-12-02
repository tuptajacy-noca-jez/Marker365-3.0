using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Finalizacja_zamówienia {
    public partial class FinalizacjaZamowienia : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void returnButton_Click(object sender, EventArgs e) {
            Response.Redirect("~/SrtonaGlowna/SrtonaGlowna.aspx");
        }

        protected void orders_Click(object sender, EventArgs e) {
            Order order = (Order)Session["order"];
            Response.Redirect("~/StatusZamowienia/StatusZamowienia.aspx/"+order.OrderId);
        }
    }
}