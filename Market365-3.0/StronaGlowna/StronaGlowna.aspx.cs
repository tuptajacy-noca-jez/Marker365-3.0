﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.StronaGlowna
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sklep_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Sklep/Sklep.aspx");
        }

        protected void zamowienia_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Zamowienia/Zamowienia.aspx");
        }

        protected void koszyk_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Koszyk/Koszyk.aspx");
        }

        protected void mojProfil_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/MojProfil/MojProfil.aspx");
        }
    }
}