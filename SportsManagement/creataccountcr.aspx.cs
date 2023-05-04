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
    public partial class creataccountcr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            int x,y;
            SqlCommand checkclub = new SqlCommand("select Name from dbo.Club where Name=@clubname", conn);
            checkclub.Parameters.AddWithValue("@clubname", clubname.Text);
            SqlDataReader sdrcheckclub = checkclub.ExecuteReader();
            if (sdrcheckclub.HasRows) { x = 1; } else { x=0; };
            conn.Close();conn.Open();

            SqlCommand checkclubrep = new SqlCommand("select * from dbo.Club c inner join dbo.Club_Representative cr on c.Id=cr.club_id  where c.Name=@clubname", conn);
            checkclubrep.Parameters.AddWithValue("@clubname", clubname.Text);
            SqlDataReader sdrcheckclubrep = checkclubrep.ExecuteReader();
            if (sdrcheckclubrep.HasRows) { y = 1; } else { y = 0; };
            conn.Close(); conn.Open();

            SqlCommand check = new SqlCommand("select Username from dbo.sys_user where Username=@Username", conn);
            check.Parameters.AddWithValue("@Username", username.Text);
            SqlDataReader sdr = check.ExecuteReader();



            if (username.Text.Length == 0 || password.Text.Length == 0 || name.Text.Length == 0 || clubname.Text.Length==0)
            {
                Literal1.Visible = true;
                Literal1.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                Literal1.Visible = true;
                Literal1.Text = "This username is already taken :( .Please try another one.";

            }
            else if(x==0)
            {
                Literal1.Visible = true;
                Literal1.Text = "Please enter an existing club.";
            }
            else if (y == 1)
            {
                Literal1.Visible = true;
                Literal1.Text = "Their is already a club representitive for the given club";
            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("addRepresentative", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@name", name.Text));
                add.Parameters.Add(new SqlParameter("@club_name", clubname.Text));
                add.Parameters.Add(new SqlParameter("@username", username.Text));
                add.Parameters.Add(new SqlParameter("@password", password.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Session["user"] = username.Text;
                Response.Redirect("cr.aspx");

            }
        }
    }
}