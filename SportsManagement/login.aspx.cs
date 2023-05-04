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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            int sam, cr, sm, sa, f;
            SqlCommand checksam = new SqlCommand("select * from dbo.Sports_Association_Manager where Username=@Username", conn);
            SqlCommand checkcr = new SqlCommand("select * from dbo.Club_Representative where Username=@Username", conn);
            SqlCommand checksm = new SqlCommand("select * from dbo.stadium_manager where Username=@Username", conn);
            SqlCommand checksa = new SqlCommand("select * from dbo.system_admin where Username=@Username", conn);
            SqlCommand checkf = new SqlCommand("select * from dbo.fan where Username=@Username", conn);
            checksam.Parameters.AddWithValue("@Username", username.Text);
            checkcr.Parameters.AddWithValue("@Username", username.Text);
            checksm.Parameters.AddWithValue("@Username", username.Text);
            checksa.Parameters.AddWithValue("@Username", username.Text);
            checkf.Parameters.AddWithValue("@Username", username.Text);
            SqlDataReader sdrsam = checksam.ExecuteReader();
            if (sdrsam.HasRows) { sam = 1; } else { sam = 0; };
            conn.Close();conn.Open();
            SqlDataReader sdrcr = checkcr.ExecuteReader();
            if (sdrcr.HasRows) { cr = 1; } else { cr = 0; };
            conn.Close(); conn.Open();
            SqlDataReader sdrsm = checksm.ExecuteReader();
            if (sdrsm.HasRows) { sm = 1; } else { sm = 0; };
            conn.Close(); conn.Open();
            SqlDataReader sdrsa = checksa.ExecuteReader();
            if (sdrsa.HasRows) { sa = 1; } else { sa = 0; };
            conn.Close(); conn.Open();
            SqlDataReader sdrf = checkf.ExecuteReader();
            if (sdrf.HasRows) { f = 1; } else { f = 0; };
            conn.Close(); conn.Open();


            SqlCommand loginproc = new SqlCommand("select Username,Password from dbo.sys_user where Username=@Username and Password=@Password", conn);
            loginproc.Parameters.AddWithValue("@Username", username.Text);
            loginproc.Parameters.AddWithValue("@Password", password.Text);
            SqlDataReader sdr = loginproc.ExecuteReader();
            if (username.Text.Length == 0 || password.Text.Length == 0)
            {
                Literalstatus.Visible = true;
                Literalstatus.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                Session["user"] = username.Text;
                if (sam == 1){
                    Response.Redirect("sam.aspx");
                }
                else if (sa == 1)
                {
                    Response.Redirect("creataccountsa.aspx");

                }
                else if (cr == 1)
                {
                    Response.Redirect("cr.aspx");

                }
                else if (sm == 1)
                {
                    Response.Redirect("sm.aspx");
                }
                else if (f == 1)
                {
                    Response.Redirect("f.aspx");
                }

            }
            else
            {
                Literalstatus.Visible = true;
                Literalstatus.Text = "username or password is incorrect";


            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("defineUser.aspx");
        }
    }
}