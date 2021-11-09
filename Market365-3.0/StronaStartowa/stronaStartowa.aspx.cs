using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projekt
{
    public partial class stronaStartowa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_TextChanged(object sender, EventArgs e)
        {
         
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void zaloguj_Click(object sender, EventArgs e)
        {
            Validacion.Visible = true;
        }

        protected void rejestracja_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Rejestracja/Rejestracja.aspx");
        }
    }
}