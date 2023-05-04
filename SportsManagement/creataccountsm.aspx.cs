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
    public partial class creataccountsm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            int x, y;
            SqlCommand checkstadium = new SqlCommand("select Name from dbo.stadium where Name=@stadium", conn);
            checkstadium.Parameters.AddWithValue("@stadium", stadiumname.Text);
            SqlDataReader sdrcheckstadium = checkstadium.ExecuteReader();
            if (sdrcheckstadium.HasRows) { x = 1; } else { x = 0; };
            conn.Close(); conn.Open();

            SqlCommand checkstadiumsm = new SqlCommand("select * from dbo.stadium s inner join dbo.stadium_manager sm on s.id=sm.stadium_id  where s.Name=@stadium", conn);
            checkstadiumsm.Parameters.AddWithValue("@stadium", stadiumname.Text);
            SqlDataReader sdrcheckstadiumsm = checkstadiumsm.ExecuteReader();
            if (sdrcheckstadiumsm.HasRows) { y = 1; } else { y = 0; };
            conn.Close(); conn.Open();

            SqlCommand check = new SqlCommand("select Username from dbo.sys_user where Username=@Username", conn);
            check.Parameters.AddWithValue("@Username", username.Text);
            SqlDataReader sdr = check.ExecuteReader();



            if (username.Text.Length == 0 || password.Text.Length == 0 || name.Text.Length == 0 || stadiumname.Text.Length == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                Literal1.Visible = true;
                Literal1.Text = "This username is already taken :( .Please try another one.";

            }
            else if (x == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "Please enter an existing stadium.";
            }
            else if (y == 1)
            {
                Literal1.Visible = true;
                Literal1.Text = "Their is already a stadium manager for the given stadium";
            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("addStadiumManager", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@name", name.Text));
                add.Parameters.Add(new SqlParameter("@stadium_name", stadiumname.Text));
                add.Parameters.Add(new SqlParameter("@username", username.Text));
                add.Parameters.Add(new SqlParameter("@password", password.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Session["user"] = username.Text;
                Response.Redirect("sm.aspx");

            }
        }
    }
}