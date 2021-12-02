using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Market365_3._0.Sklep
{
    public partial class Sklep : System.Web.UI.Page
    {

        User currUser;
        String Polaczenie;
        protected void Page_Load(object sender, EventArgs e)
        {
                            
        }
        /// <summary>
        /// This method realise adding product to shopping cart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddButton_Click(object sender, EventArgs e)
        {
            currUser = (User)Session["user"];
            if (currUser.IsActive == false)
            {
                Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
            }
            else
            {

                ImageButton button = (ImageButton)sender;
                int buttonId = Int32.Parse(button.ToolTip);

                try
                {
                    String Polaczenie;
                    Polaczenie = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                    SqlConnection sql = new SqlConnection(Polaczenie);
                    SqlCommand cmd = new SqlCommand("INSERT INTO [cartPosition] VALUES (@IdOrder,@IdProduct,@quantity)", sql);
                    cmd.Parameters.AddWithValue("@IdOrder", currUser.Login);
                    cmd.Parameters.AddWithValue("@IdProduct", buttonId);
                    cmd.Parameters.AddWithValue("@quantity", 1);
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    sql.Close();
                }
                catch (Exception) { }
                
            }

        }
        /// <summary>
        /// When user is logged this method redirect to shopping cart page, but when he isn't logged on his account method redirect him to start page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void doKoszyka_Click(object sender, EventArgs e)
        {
            currUser = (User)Session["user"];
            if (currUser.IsActive == false)
            {
                Response.Redirect("~/StronaStartowa/StronaStartowa.aspx");
            }
            else
            {
                Response.Redirect("~/Koszyk/Koszyk.aspx");
            }
        }
    }

}