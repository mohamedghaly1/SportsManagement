using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

namespace korafinale
{
    public partial class viewinfoclub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            String x = "";
            x = (string)(Session["club"].ToString());
            
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.allClubs where name=@clubname ", conn);
                cmd.Parameters.Add(new SqlParameter("@clubname", x));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView3.DataSource = dr;
                    GridView3.DataBind();
                }
            }


            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select ch.Name as host_club,cg.Name as guest_club,r.accept_status as status from dbo.request r inner join dbo.match m on r.match_id=m.Id inner join dbo.Club ch on m.host_id=ch.Id inner join dbo.Club cg on m.guest_id=cg.Id  where cg.Name = @clubname or ch.Name = @clubname", conn);
                cmd.Parameters.Add(new SqlParameter("@clubname", x));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
            



            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.upcomingMatchesOfClub(@clubname)", conn);
                cmd.Parameters.Add(new SqlParameter("@clubname", x));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView2.DataSource = dr;
                    GridView2.DataBind();
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("cr.aspx");
        }
    }
}