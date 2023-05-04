using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace korafinale
{
    public partial class f : System.Web.UI.Page
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
            String x = "";
            x = (string)(Session["user"].ToString());

            SqlCommand getid = new SqlCommand("select national_id as nti from dbo.fan where Username=@x", conn);
            getid.Parameters.AddWithValue("@x", x);
            SqlDataReader sdrgetid = getid.ExecuteReader();
            sdrgetid.Read();
            String ni = sdrgetid.GetString(sdrgetid.GetOrdinal("nti"));
            conn.Close(); conn.Open();

            DateTime dateTime1;
            bool isDateTime1 = false;
            String[] formats = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime1 = DateTime.TryParseExact(st.Text, formats, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime1);

            int p;
            SqlCommand checkblk = new SqlCommand("select * from dbo.fan where Username=@x and fan_status =0", conn);
            checkblk.Parameters.AddWithValue("@x", x);
            SqlDataReader sdrcheckblk = checkblk.ExecuteReader();
            if (sdrcheckblk.HasRows) { p = 1; } else { p = 0; };
            conn.Close(); conn.Open();


            if (st.Text.Length == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "Please fill the textbox";
            }
            else if (isDateTime1 == false)
            {
                Literal1.Visible = true;
                Literal1.Text = "Please enter a valid date in a form of yyyy/MM/dd or yyyy/MM/dd HH:mm:ss ";
            }
            else if (p==1){
                Session["date"] = st.Text;
                Response.Redirect("availablematchesblock.aspx");
            }
            else
            {
                Session["date"] = st.Text;
                Session["id"] = ni;
                Response.Redirect("availableMatchesToAttend.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}