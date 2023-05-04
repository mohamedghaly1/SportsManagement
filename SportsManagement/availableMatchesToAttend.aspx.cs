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
    public partial class availableMatchesToAttend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String d = "";
            d = (string)(Session["date"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.availableMatchesToAttend(@date)", conn);
                cmd.Parameters.Add(new SqlParameter("@date", d));
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
            Button btn = (sender as Button);
            String x = "";
            x = (string)(Session["id"].ToString());
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            if (e.CommandName == "purchase")
            {

                int crow = Convert.ToInt32(e.CommandArgument.ToString());
                string ch = GridView1.Rows[crow].Cells[1].Text;
                string cg = GridView1.Rows[crow].Cells[2].Text;
                string st = GridView1.Rows[crow].Cells[3].Text;

                conn.Close();

                SqlCommand add = new SqlCommand("purchaseTicket", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@national_id", x));
                add.Parameters.Add(new SqlParameter("@hosting_club_name", ch));
                add.Parameters.Add(new SqlParameter("@competing_club_name", cg));
                add.Parameters.Add(new SqlParameter("@start_time",st));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("availableMatchesToAttend.aspx");


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("f.aspx");
        }
    }
}