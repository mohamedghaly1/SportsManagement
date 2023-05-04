using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace korafinale
{
    public partial class availablematchesblock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String d = "";
            d = (string)(Session["date"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.availableMatchesToAttend(@date)", conn);
                cmd.Parameters.Add(new SqlParameter("@date", d));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("f.aspx");
        }
    }
}