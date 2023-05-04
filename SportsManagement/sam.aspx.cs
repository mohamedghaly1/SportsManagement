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
    public partial class sam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            int x, y;

            SqlCommand checkclub1 = new SqlCommand("select Id from dbo.Club where Name=@c1Name", conn);
            SqlCommand checkclub2 = new SqlCommand("select Id from dbo.Club where Name=@c2Name", conn);
            SqlCommand checkmatch = new SqlCommand("select * from dbo.match m inner join dbo.Club c1 on m.host_id=c1.Id inner join dbo.Club c2 on m.guest_id=c2.Id  where Start_time=@st and End_time=@ed and c1.Name=@c1Name and c2.Name=@c2Name", conn);
            checkclub1.Parameters.AddWithValue("@c1Name", hostclubname.Text);
            checkclub2.Parameters.AddWithValue("@c2Name", guestclubname.Text);
            checkmatch.Parameters.AddWithValue("@c1Name", hostclubname.Text);
            checkmatch.Parameters.AddWithValue("@c2Name", guestclubname.Text);
            checkmatch.Parameters.AddWithValue("@st", sarttime.Text);
            checkmatch.Parameters.AddWithValue("@ed", endtime.Text);
            
            SqlDataReader sdrc1 = checkclub1.ExecuteReader();
            if (sdrc1.HasRows) { x = 1; } else { x=0; };
            conn.Close();conn.Open();
            
            SqlDataReader sdrc2 = checkclub2.ExecuteReader();
            if (sdrc2.HasRows) { y = 1; } else { y = 0; };
            conn.Close(); conn.Open();
            
            SqlDataReader sdrm = checkmatch.ExecuteReader();

            DateTime dateTime1;
            bool isDateTime1 = false;
            String[] formats = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime1 = DateTime.TryParseExact(sarttime.Text, formats, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime1);
            
            DateTime dateTime2;
            bool isDateTime2 = false;
            String[] formats2 = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime2 = DateTime.TryParseExact(endtime.Text, formats2, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime2);

            if (endtime.Text.Length == 0 || sarttime.Text.Length == 0 || guestclubname.Text.Length == 0 || hostclubname.Text.Length == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "please fill the textboxes";
            }
            else if (guestclubname.Text==hostclubname.Text)
            {
                Literal1.Visible = true;
                Literal1.Text = "Please enter two different clubs";

            }
            else if(x==0 || y==0)
            {
                Literal1.Visible = true;
                Literal1.Text = "Please enter valid clubs";
            }
            else if (isDateTime1 == false || isDateTime2== false || (DateTime.Compare(DateTime.Now, dateTime1) >= 0) || (DateTime.Compare(dateTime1, dateTime2) >= 0))
            {
                Literal1.Visible = true;
                Literal1.Text = "Please enter a valid start and end date in a form of yyyy/MM/dd or yyyy/MM/dd HH:mm:ss ";
            }
            else if (sdrm.HasRows)
            {
                Literal1.Visible = true;
                Literal1.Text = "Their is existing match with the given information already";
            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("addNewMatch", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@name_host", hostclubname.Text));
                add.Parameters.Add(new SqlParameter("@name_guest", guestclubname.Text));
                add.Parameters.Add(new SqlParameter("@start_time", sarttime.Text));
                add.Parameters.Add(new SqlParameter("@end_time", endtime.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Literal1.Visible = true;
                Literal1.Text = "The match has been added successfully";


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            int x, y;

            SqlCommand checkclub1 = new SqlCommand("select Id from dbo.Club where Name=@c1Name", conn);
            SqlCommand checkclub2 = new SqlCommand("select Id from dbo.Club where Name=@c2Name", conn);
            SqlCommand checkmatch = new SqlCommand("select * from dbo.match m inner join dbo.Club c1 on m.host_id=c1.Id inner join dbo.Club c2 on m.guest_id=c2.Id  where Start_time=@st and End_time=@ed and c1.Name=@c1Name and c2.Name=@c2Name", conn);
            checkclub1.Parameters.AddWithValue("@c1Name", hostclubnamedelete.Text);
            checkclub2.Parameters.AddWithValue("@c2Name", guestclubnamedelete.Text);
            checkmatch.Parameters.AddWithValue("@c1Name", hostclubnamedelete.Text);
            checkmatch.Parameters.AddWithValue("@c2Name", guestclubnamedelete.Text);
            checkmatch.Parameters.AddWithValue("@st", sarttimedelete.Text);
            checkmatch.Parameters.AddWithValue("@ed", endtimedelete.Text);

            SqlDataReader sdrc1 = checkclub1.ExecuteReader();
            if (sdrc1.HasRows) { x = 1; } else { x = 0; };
            conn.Close(); conn.Open();

            SqlDataReader sdrc2 = checkclub2.ExecuteReader();
            if (sdrc2.HasRows) { y = 1; } else { y = 0; };
            conn.Close(); conn.Open();

            SqlDataReader sdrm = checkmatch.ExecuteReader();

            DateTime dateTime1;
            bool isDateTime1 = false;
            String[] formats = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime1 = DateTime.TryParseExact(sarttimedelete.Text, formats, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime1);

            DateTime dateTime2;
            bool isDateTime2 = false;
            String[] formats2 = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime2 = DateTime.TryParseExact(endtimedelete.Text, formats2, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime2);



            if (endtimedelete.Text.Length == 0 || sarttimedelete.Text.Length == 0 || guestclubnamedelete.Text.Length == 0 || hostclubnamedelete.Text.Length == 0)
            {
                Literal2.Visible = true;
                Literal2.Text = "please fill the textboxes";
            }
            else if (guestclubnamedelete.Text == hostclubnamedelete.Text)
            {
                Literal2.Visible = true;
                Literal2.Text = "Please enter two different clubs";

            }
            else if (x == 0 || y == 0)
            {
                Literal2.Visible = true;
                Literal2.Text = "Please enter valid clubs";
            }
            else if (isDateTime1 == false || isDateTime2 == false || (DateTime.Compare(DateTime.Now, dateTime1) >= 0) || (DateTime.Compare(dateTime1, dateTime2) >= 0))
            {
                Literal2.Visible = true;
                Literal2.Text = "Please enter a valid start and end date in a form of yyyy/MM/dd or yyyy/MM/dd HH:mm:ss ";
            }
            else if (!sdrm.HasRows)
            {
                Literal2.Visible = true;
                Literal2.Text = "Their is no match with the given information";
            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("deleteMatch", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@name_host", hostclubnamedelete.Text));
                add.Parameters.Add(new SqlParameter("@name_guest", guestclubnamedelete.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Literal2.Visible = true;
                Literal2.Text = "The match has been deleted successfully";


            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewallmatches.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewalreadyplayed.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewneverplayed.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}