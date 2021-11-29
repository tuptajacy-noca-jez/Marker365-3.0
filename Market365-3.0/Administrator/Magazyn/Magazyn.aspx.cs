using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Market365_3._0.Administrator.Magazyn
{
    public partial class Magazyn : System.Web.UI.Page
    {

        List<int> ids;
        List<float> quantities;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

            ids = (List<Int32>)Application["orderProductIds"];
            quantities = (List<float>)Application["orderProductquantity"];

            ids.Add(ids[0]);
            quantities.Add(quantities[0]);

        }

    
}
}