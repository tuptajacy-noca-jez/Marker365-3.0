using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0 {
    public partial class Site1 : System.Web.UI.MasterPage {

        User currentUser;

        protected void Page_Load(object sender, EventArgs e) {
            currentUser =(User)Application["user"];
            logOut.CssClass= "hiddenButton";
            if (currentUser.IsActive) {
                logOut.CssClass = "loginButton";
            }
        }

        protected void logowanieButton_Click(object sender, EventArgs e) {
            Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
        }

        protected void rejestracjaButton_Click(object sender, EventArgs e) {
            Response.Redirect("~/Rejestracja/rejestracja.aspx");
        }

        protected void logOut_Click(object sender, EventArgs e) {
            Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
        }

        protected void logoButton_Click(object sender, EventArgs e) {
            Response.Redirect("~/StronaGlowna/StronaGlowna.aspx");
        }
    }
}