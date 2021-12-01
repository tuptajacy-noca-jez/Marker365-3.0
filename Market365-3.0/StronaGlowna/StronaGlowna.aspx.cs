using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Market365_3._0.StronaGlowna
{
    public partial class StronaGlowna : System.Web.UI.Page {

        User currUser;

        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(getRandomDrink));
        }

        protected void sklep_Click(object sender, EventArgs e)
        {
            
            //Server.Transfer("~/Sklep/Sklep.aspx");
            
            Response.Redirect("~/Sklep/Sklep.aspx");
        }

        protected void zamowienia_Click(object sender, EventArgs e)
        {
            currUser = (User)Application["user"];
            if (currUser.IsActive == false)
            {
                Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
            }
            else
            {
                //Server.Transfer("~/Zamowienia/Zamowienia.aspx");
                Response.Redirect("~/Zamowienia/Zamowienia.aspx");
            }
        }

        protected void koszyk_Click(object sender, EventArgs e)
        {
            currUser = (User)Application["user"];
            if (currUser.IsActive == false)
            {
                Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
            }
            else
            {
                //Server.Transfer("~/Koszyk/Koszyk.aspx");
                Response.Redirect("~/Koszyk/Koszyk.aspx");
            }
        }

        protected void mojProfil_Click(object sender, EventArgs e)
        {
            currUser = (User)Application["user"];
            if (currUser.IsActive == false)
            {
                Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
            }
            else
            {
                //Server.Transfer("~/MojProfil/MojProfil.aspx");
                Response.Redirect("~/MojProfil/MojProfil.aspx");
            }
        }

        private async Task getRandomDrink()
        {
            DrinkList.Items.Clear();
            Helper.InitializeClient();
            var drink = await DrinkProcessor.LoadDrink();
            DrinkImage.ImageUrl = drink.strDrinkThumb;
            DrinkName.Text = drink.strDrink;
            if (drink.strIngredient1 != null)
                DrinkList.Items.Add(drink.strIngredient1);
            if (drink.strIngredient2 != null)
                DrinkList.Items.Add(drink.strIngredient2);
            if (drink.strIngredient3 != null)
                DrinkList.Items.Add(drink.strIngredient3);
            if (drink.strIngredient4 != null)
                DrinkList.Items.Add(drink.strIngredient4);
            if (drink.strIngredient5 != null)
                DrinkList.Items.Add(drink.strIngredient5);
            DrinkInstructions.Text = drink.strInstructions;
        }

        /*
        protected void produktDeals_Click(object sender, EventArgs e) {

            Response.Redirect("~/StronaProduktu/StronaProduktu.aspx");
        }
        */
    }
}