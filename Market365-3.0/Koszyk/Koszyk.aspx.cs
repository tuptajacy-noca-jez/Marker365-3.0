using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Koszyk
{
    public partial class Koszyk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void anulujButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/stronaGłówna/stronaGłówna.aspx");
        }

        protected static string ReturnEncodedBase64UTF8(object rawImg)
        {
            string img = "data:image/jpg;base64,{0}";
            byte[] toEncodeAsBytes = (byte[])rawImg;
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return String.Format(img, returnValue);
        }
    }
}