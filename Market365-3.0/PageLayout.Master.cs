using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0 {
    public partial class Site1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            User currentUser = (User)Application["user"];
            logOut.CssClass= "hiddenButton";
            if (currentUser.IsActive) {
                logOut.CssClass = "loginButton";
            }

            if (Request.Url.ToString().Contains("StronaStartowa")) {
                menuBand.Style.Add("visibility", "hidden");
            }
            else {
                menuBand.Style.Add("visibility", "visible");
            }
        }


        protected void logOut_Click(object sender, EventArgs e) {
            logOut.CssClass = "hiddenButton";
            Application["user"] = new User();           

            Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
        }

        protected void logoButton_Click(object sender, EventArgs e) {
            Response.Redirect("~/StronaGlowna/StronaGlowna.aspx");
        }
    }
}