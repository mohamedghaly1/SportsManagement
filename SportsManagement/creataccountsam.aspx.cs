using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace korafinale
{
    public partial class creataccountsam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            SqlCommand check = new SqlCommand("select Username from dbo.sys_user where Username=@Username", conn);
            check.Parameters.AddWithValue("@Username", username.Text);
            SqlDataReader sdr = check.ExecuteReader();



            if (username.Text.Length == 0 || password.Text.Length == 0 || name.Text.Length == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "please fill the textboxes";
            }
            else if (sdr.HasRows)
            {
                Literal1.Visible = true;
                Literal1.Text = "This username is already taken :( .Please try another one.";

            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("addAssociationManager", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@name", name.Text));
                add.Parameters.Add(new SqlParameter("@username", username.Text));
                add.Parameters.Add(new SqlParameter("@password", password.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Session["user"] = username.Text;
                Response.Redirect("sam.aspx");
          
            }
        }
    }
}