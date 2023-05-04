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
    public partial class pendingrequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String x = "";
            x = (string)(Session["userun"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.allPendingRequests(@username)", conn);
                cmd.Parameters.Add(new SqlParameter("@username", x));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            String x = "";
            x = (string)(Session["userun"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


                if (e.CommandName == "accept")
            {
                int crow = Convert.ToInt32(e.CommandArgument.ToString());
                string crname = GridView1.Rows[crow].Cells[2].Text;
                string gcname = GridView1.Rows[crow].Cells[3].Text;
                string st = GridView1.Rows[crow].Cells[4].Text;

                SqlCommand getName = new SqlCommand("select c.Name as clubname from dbo.Club_Representative cr inner join club c on c.Id=cr.club_id inner join dbo.sys_user su on su.Username=cr.username where @crname=su.Name", conn);
                getName.Parameters.AddWithValue("@crname", crname);
                SqlDataReader sdrgetname = getName.ExecuteReader();
                sdrgetname.Read();
                String clubnames = sdrgetname.GetString(sdrgetname.GetOrdinal("clubname"));
                conn.Close();conn.Open();

                SqlCommand getCap = new SqlCommand("select s.Capacity as cap from stadium s inner join stadium_manager sm on s.id=sm.stadium_id where sm.Username=@x", conn);
                getCap.Parameters.AddWithValue("@x", x);
                SqlDataReader sdrgetCap = getCap.ExecuteReader();
                sdrgetCap.Read();
                int capacity = sdrgetCap.GetInt32(sdrgetCap.GetOrdinal("cap"));
                conn.Close(); conn.Open();

                SqlCommand status = new SqlCommand("acceptRequest",conn);
                status.CommandType = CommandType.StoredProcedure;
                status.Parameters.Add(new SqlParameter("@sm_username",x));
                status.Parameters.Add(new SqlParameter("@hosting_club_name", clubnames));
                status.Parameters.Add(new SqlParameter("@competing_club_name", gcname));
                status.Parameters.Add(new SqlParameter("@start_time", st));
                status.ExecuteNonQuery();

                SqlCommand ticket = new SqlCommand("addTicket", conn);
                ticket.CommandType = CommandType.StoredProcedure;
                ticket.Parameters.Add(new SqlParameter("@name_host_club", clubnames));
                ticket.Parameters.Add(new SqlParameter("@name_guest_club", gcname));
                ticket.Parameters.Add(new SqlParameter("@start_time", st));
                for (int i = 0; i < capacity; i++) ticket.ExecuteNonQuery();



                Response.Redirect("pendingrequests.aspx");


            }

            if (e.CommandName == "reject")
            {
                int crow = Convert.ToInt32(e.CommandArgument.ToString());
                string crname = GridView1.Rows[crow].Cells[2].Text;
                string gcname = GridView1.Rows[crow].Cells[3].Text;
                string st = GridView1.Rows[crow].Cells[4].Text;

                SqlCommand getName = new SqlCommand("select c.Name as clubname from dbo.Club_Representative cr inner join club c on c.Id=cr.club_id inner join dbo.sys_user su on su.Username=cr.username where @crname=su.Name", conn);
                getName.Parameters.AddWithValue("@crname", crname);
                SqlDataReader sdrgetname = getName.ExecuteReader();
                sdrgetname.Read();
                String clubnames = sdrgetname.GetString(sdrgetname.GetOrdinal("clubname"));
                conn.Close(); conn.Open();

                SqlCommand status = new SqlCommand("rejectRequest", conn);
                status.CommandType = CommandType.StoredProcedure;
                status.Parameters.Add(new SqlParameter("@sm_username", x));
                status.Parameters.Add(new SqlParameter("@hosting_club_name", clubnames));
                status.Parameters.Add(new SqlParameter("@competing_club_name", gcname));
                status.Parameters.Add(new SqlParameter("@start_time", st));
                status.ExecuteNonQuery();
                Response.Redirect("pendingrequests.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("sm.aspx");
        }
    }
}