using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace korafinale
{
    public partial class defineUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        protected void SAM_Click(object sender, EventArgs e)
        {
            Response.Redirect("creataccountsam.aspx");
        }

        protected void CR_Click(object sender, EventArgs e)
        {
            Response.Redirect("creataccountcr.aspx");
        }

        protected void SM_Click(object sender, EventArgs e)
        {
            Response.Redirect("creataccountsm.aspx");
        }

        protected void F_Click(object sender, EventArgs e)
        {
            Response.Redirect("creataccountf.aspx");
        }
    }
}