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
    public partial class requestsrecieved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String x = "";
            x = (string)(Session["userun"].ToString());

            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("sm.aspx");
        }
    }
}