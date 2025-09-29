using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bike
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BttnRedirect1_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ListaProduse.aspx");
        }

        protected void BttnRedirect2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaCategorii.aspx");
        }

        protected void BttnRedirect3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaBrands.aspx");
        }
    }
}