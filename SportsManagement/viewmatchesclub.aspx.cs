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
    public partial class viewmatchesclub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String x = "";
            x = (string)(Session["club"].ToString());

            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.upcomingMatchesOfClub(@clubname)", conn);
                cmd.Parameters.Add(new SqlParameter("@clubname", x));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView11.DataSource = dr;
                    GridView11.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("cr.aspx");
        }
    }
}