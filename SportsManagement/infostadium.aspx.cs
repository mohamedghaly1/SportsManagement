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
    public partial class infostadium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String x = "";
            x = (string)(Session["userun"].ToString());

            SqlCommand getName = new SqlCommand("select s.Name as stadiumname from dbo.stadium_manager sm inner join dbo.stadium s on sm.stadium_id=s.id where sm.Username=@x", conn);
            getName.Parameters.AddWithValue("@x", x);
            SqlDataReader sdrgetname = getName.ExecuteReader();
            sdrgetname.Read();
            String stadiumnames = sdrgetname.GetString(sdrgetname.GetOrdinal("stadiumname"));
            conn.Close();
            


            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select cr.Name as club_represntative,ch.Name as host_name,cg.Name as guest_name,m.Start_time as start_time,m.End_time as end_time,r.accept_status as status from dbo.request r inner join dbo.match m on r.match_id=m.Id  inner join dbo.sys_user cr on r.cr_username=cr.Username inner join dbo.Club ch on m.host_id=ch.Id inner join dbo.Club cg on m.guest_id=cg.Id where r.sm_username=@user", conn);
                cmd.Parameters.Add(new SqlParameter("@user", x));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView11.DataSource = dr;
                    GridView11.DataBind();
                }
                conn.Close();
            }

            using (SqlConnection conn2 = new SqlConnection(connStr))
            {
                conn2.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.allStadiums where name=@user", conn2);
                cmd.Parameters.Add(new SqlParameter("@user", stadiumnames));
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
            Response.Redirect("sm.aspx");
        }
    }
}