using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Administrator
{
    public partial class Administrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dodaj_Click(object sender, EventArgs e)
        {

            //Server.Transfer("~/Sklep/Sklep.aspx");

            Response.Redirect("~/Administrator/DodajProdukt/DodajProdukt.aspx");

        }

        protected void zamowieniaKlientow_Click(object sender, EventArgs e)
        {
            //Server.Transfer("~/Zamowienia/Zamowienia.aspx");
            Response.Redirect("~/Administrator/ZamowienieKlientow/ZamowienieKlientow.aspx");
        }

        protected void magazyn_Click(object sender, EventArgs e)
        {
            //Server.Transfer("~/Koszyk/Koszyk.aspx");
            Response.Redirect("~/Administrator/Magazyn/Magazyn.aspx");

        }

        protected void mojProfil_Click(object sender, EventArgs e)
        {
            //Server.Transfer("~/MojProfil/MojProfil.aspx");
            Response.Redirect("~/MojProfil/MojProfil.aspx");
        }
    }
}