using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Globalization;

namespace korafinale
{
    public partial class cr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null) Response.Redirect("login.aspx");
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String x = "";
            x = (string)(Session["user"].ToString());

            SqlCommand getName = new SqlCommand("select c.Name as clubname from dbo.Club_Representative cr inner join dbo.Club c on cr.club_id=c.Id  where cr.username=@x", conn);
            getName.Parameters.AddWithValue("@x", x);
            SqlDataReader sdrgetname = getName.ExecuteReader();
            sdrgetname.Read();
            String clubnames = sdrgetname.GetString(sdrgetname.GetOrdinal("clubname"));
            conn.Close();conn.Open();

            int z;
            SqlCommand checkr = new SqlCommand("select * from dbo.request r inner join dbo.Club_Representative cr on r.cr_username=cr.username inner join dbo.stadium_manager sm on sm.Username=r.sm_username inner join dbo.sys_user su on sm.Username=su.Username where r.cr_username=@x and su.Name=@y and r.accept_status='Unhandled'", conn);
            checkr.Parameters.AddWithValue("@x", x);
            checkr.Parameters.AddWithValue("@y", namesm.Text);
            SqlDataReader sdrcheckr = checkr.ExecuteReader();
            if (sdrcheckr.HasRows) { z = 1; } else { z = 0; };
            conn.Close(); conn.Open();

            int o;
            SqlCommand checkmatch = new SqlCommand("select * from dbo.match m inner join dbo.club c on m.host_id=c.Id where c.name=@x and m.Start_time=@y ", conn);
            checkmatch.Parameters.AddWithValue("@x", clubnames);
            checkmatch.Parameters.AddWithValue("@y", starttime.Text);
            SqlDataReader sdrcheckmatch = checkmatch.ExecuteReader();
            if (sdrcheckmatch.HasRows) { o = 1; } else { o = 0; };
            conn.Close(); conn.Open();

            DateTime dateTime1;
            bool isDateTime1 = false;
            String[] formats = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime1 = DateTime.TryParseExact(starttime.Text, formats, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime1);


            SqlCommand checkmanger = new SqlCommand("select * from dbo.sys_user su inner join dbo.stadium_manager sm on su.Username=sm.Username  where su.Name=@name", conn);
            checkmanger.Parameters.AddWithValue("@name", namesm.Text);
            SqlDataReader sdrcheckmanager = checkmanger.ExecuteReader();
    



            if (namesm.Text.Length == 0 || starttime.Text.Length == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "please fill the textboxes";
            }
            else if (!sdrcheckmanager.HasRows)
            {
                Literal1.Visible = true;
                Literal1.Text = "their is no stadium manager with that name.";

            }
            else if (z == 1)
            {
                Literal1.Visible = true;
                Literal1.Text = "The request has been sent already";
            }
            else if (isDateTime1 == false || (DateTime.Compare(DateTime.Now, dateTime1) >= 0))
            {
                Literal1.Visible = true;
                Literal1.Text = "Please enter a valid date in a form of yyyy/MM/dd or yyyy/MM/dd HH:mm:ss ";
            }
            else if (o == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "Their is no match with the given time for this club";
            }
            else
            {
                conn.Close(); conn.Open();
                SqlCommand getstadium = new SqlCommand("select s.Name as stadiumname from dbo.stadium s inner join dbo.stadium_manager sm on sm.stadium_id=s.id inner join dbo.sys_user su on su.Username=sm.Username  where su.Name=@x", conn);
                getstadium.Parameters.AddWithValue("@x", namesm.Text);
                SqlDataReader sdrgetstadium = getstadium.ExecuteReader();
                sdrgetstadium.Read();
                String stadiumname = sdrgetstadium.GetString(sdrgetstadium.GetOrdinal("stadiumname"));
                


                conn.Close();
                SqlCommand add = new SqlCommand("addHostRequest", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@club_name", clubnames));
                add.Parameters.Add(new SqlParameter("@stadium_name", stadiumname));
                add.Parameters.Add(new SqlParameter("@start_time", starttime.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Literal1.Visible = true;
                Literal1.Text = "The request has been sent";


            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            DateTime dateTime1;
            bool isDateTime1 = false;
            String[] formats = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime1 = DateTime.TryParseExact(date.Text, formats, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime1);

            if (date.Text.Length == 0)
            {
                Literal2.Visible = true;
                Literal2.Text = "please fill the textboxes";
            }
            else if (isDateTime1 == false || (DateTime.Compare(DateTime.Now, dateTime1) >= 0))
            {
                Literal2.Visible = true;
                Literal2.Text = "Please enter a valid date in a form of yyyy/MM/dd or yyyy/MM/dd HH:mm:ss ";
            }
            else
            {
                Session["time"]=date.Text;
                Response.Redirect("viewavalstadium.aspx");
            }


        }

        protected void Button1_Click1(object sender, EventArgs e)

        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String x = "";
            x = (string)(Session["user"].ToString());

            SqlCommand getName = new SqlCommand("select c.Name as clubname from dbo.Club_Representative cr inner join dbo.Club c on cr.club_id=c.Id  where cr.username=@x", conn);
            getName.Parameters.AddWithValue("@x", x);
            SqlDataReader sdrgetname = getName.ExecuteReader();
            sdrgetname.Read();
            String clubnames = sdrgetname.GetString(sdrgetname.GetOrdinal("clubname"));

            Session["club"] = clubnames;
            Response.Redirect("viewinfoclub.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String x = "";
            x = (string)(Session["user"].ToString());

            SqlCommand getName = new SqlCommand("select c.Name as clubname from dbo.Club_Representative cr inner join dbo.Club c on cr.club_id=c.Id  where cr.username=@x", conn);
            getName.Parameters.AddWithValue("@x", x);
            SqlDataReader sdrgetname = getName.ExecuteReader();
            sdrgetname.Read();
            String clubnames = sdrgetname.GetString(sdrgetname.GetOrdinal("clubname"));

            Session["club"] = clubnames;
            Response.Redirect("viewmatchesclub.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}