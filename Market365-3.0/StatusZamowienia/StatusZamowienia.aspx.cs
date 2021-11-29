using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.StatusZamowienia {
    public partial class StronaZamowienia : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void returnToOrders_Click(object sender, EventArgs e) {
            Response.Redirect("~/Zamowienia/Zamowienia.aspx/");
        }
    }
}