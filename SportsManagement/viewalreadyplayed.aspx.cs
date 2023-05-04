using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace korafinale
{
    public partial class viewalreadyplayed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand checkmatch = new SqlCommand("select c1.name as host_club,c2.name as guest_club,m.Start_time as start_time,m.End_time as end_time from dbo.match m inner join dbo.Club c1 on m.host_id=c1.Id inner join dbo.Club c2 on m.guest_id=c2.Id where m.Start_time < CURRENT_TIMESTAMP", conn);
            SqlDataAdapter da = new SqlDataAdapter(checkmatch);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("sam.aspx");
        }
    }
}