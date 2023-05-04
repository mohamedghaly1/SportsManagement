using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace korafinale
{
    public partial class creataccountsa : System.Web.UI.Page
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


            SqlCommand check = new SqlCommand("select Name,location from dbo.Club where Name=@Name and location=@location", conn);
            check.Parameters.AddWithValue("@Name", nameaddclub.Text);
            check.Parameters.AddWithValue("@location", locationaddclub.Text);
            SqlDataReader sdr = check.ExecuteReader();
            if (nameaddclub.Text.Length == 0 || locationaddclub.Text.Length == 0)
            {
                Literaladd.Visible = true;
                Literaladd.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                Literaladd.Visible = true;
                Literaladd.Text = "Their is already a club with that name and location";

            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("addClub", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@club", nameaddclub.Text));
                add.Parameters.Add(new SqlParameter("@location_club", locationaddclub.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Literaladd.Visible = true;
                Literaladd.Text = "It is added successfully";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            SqlCommand check = new SqlCommand("select Name from dbo.Club where Name=@Name", conn);
            check.Parameters.AddWithValue("@Name", namedeleteclub.Text);
            SqlDataReader sdr = check.ExecuteReader();
            if (namedeleteclub.Text.Length == 0)
            {
                Literaldeleteclub.Visible = true;
                Literaldeleteclub.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                conn.Close();
                SqlCommand delete = new SqlCommand("deleteClub", conn);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.Add(new SqlParameter("@club_name", namedeleteclub.Text));
                conn.Open();
                delete.ExecuteNonQuery();
                conn.Close();
                Literaldeleteclub.Visible = true;
                Literaldeleteclub.Text = "It is deleted successfully";

            }
            else
            {

                Literaldeleteclub.Visible = true;
                Literaldeleteclub.Text = "Their is no club with that name";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            SqlCommand check = new SqlCommand("select Name,Location,Capacity from dbo.stadium where Name=@Name and Location=@location and Capacity=@capacity", conn);
            check.Parameters.AddWithValue("@Name", namestadium.Text);
            check.Parameters.AddWithValue("@location", locationstadium.Text);
            check.Parameters.AddWithValue("@capacity", capacitystadium.Text);
            SqlDataReader sdr = check.ExecuteReader();
            if (namestadium.Text.Length == 0 || locationstadium.Text.Length == 0 || capacitystadium.Text.Length==0)
            {
                Literalstadium.Visible = true;
                Literalstadium.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                Literalstadium.Visible = true;
                Literalstadium.Text = "Their is already a stadium with the given information";

            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("addStadium", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@stadium_name", namestadium.Text));
                add.Parameters.Add(new SqlParameter("@location", locationstadium.Text));
                add.Parameters.Add(new SqlParameter("@capacity", capacitystadium.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Literalstadium.Visible = true;
                Literalstadium.Text = "It is added successfully";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            SqlCommand check = new SqlCommand("select national_id from dbo.fan where national_id=@national_id and fan_status=1", conn);
            check.Parameters.AddWithValue("@national_id", idblockfan.Text);
            SqlDataReader sdr = check.ExecuteReader();
            if (idblockfan.Text.Length == 0)
            {
                Literalblockfan.Visible = true;
                Literalblockfan.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                conn.Close();
                SqlCommand block = new SqlCommand("blockFan", conn);
                block.CommandType = CommandType.StoredProcedure;
                block.Parameters.Add(new SqlParameter("@national_id", idblockfan.Text));
                conn.Open();
                block.ExecuteNonQuery();
                conn.Close();
                Literalblockfan.Visible = true;
                Literalblockfan.Text = "This fan has been blocked successfully";

            }
            else
            {

                Literalblockfan.Visible = true;
                Literalblockfan.Text = "Please enter a valid id fan that is unblocked ";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            SqlCommand check = new SqlCommand("select Name from dbo.stadium where Name=@Name", conn);
            check.Parameters.AddWithValue("@Name", namedeletestadium.Text);
            SqlDataReader sdr = check.ExecuteReader();
            if (namedeletestadium.Text.Length == 0)
            {
                Literaldeletestadium.Visible = true;
                Literaldeletestadium.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                conn.Close();
                SqlCommand delete = new SqlCommand("deleteStadium", conn);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.Add(new SqlParameter("@stadium_name", namedeletestadium.Text));
                conn.Open();
                delete.ExecuteNonQuery();
                conn.Close();
                Literaldeletestadium.Visible = true;
                Literaldeletestadium.Text = "It is deleted successfully";

            }
            else
            {

                Literaldeletestadium.Visible = true;
                Literaldeletestadium.Text = "Their is no stadium with that name";
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}