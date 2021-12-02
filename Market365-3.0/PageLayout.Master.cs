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
            currentUser = (User)Application["user"];
            logOut.CssClass= "hiddenButton";
            logIn.CssClass = "hiddenButton";

            if (currentUser.IsActive) {
                logOut.CssClass = "logOutButton";
            }
            else {
                logIn.CssClass = "logInButton";
            }


            if (Request.Url.ToString().Contains("StronaStartowa")) {
                menuBand.Style.Add("visibility", "hidden");
                logIn.CssClass = "hiddenButton";
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
            if(currentUser.Login=="admin")
            Response.Redirect("/Administrator/Administrator.aspx");
            else
            Response.Redirect("~/StronaGlowna/StronaGlowna.aspx");
        }

        protected void logIn_Click(object sender, EventArgs e) {
            Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
        }
    }
}