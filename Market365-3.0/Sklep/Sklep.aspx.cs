using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Sklep
{
    public partial class Sklep : System.Web.UI.Page
    {

        List<int> ids;
        List<float> quantities;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int buttonId = Int32.Parse(button.ToolTip);
            System.Console.WriteLine("OK");
            System.Console.WriteLine(buttonId);

        }

        protected void doKoszyka_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Koszyk/Koszyk.aspx");
        }
    }

}