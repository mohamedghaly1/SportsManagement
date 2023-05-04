using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace korafinale
{
    public partial class creataccountf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["korafinale"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            int x;
            SqlCommand checkid = new SqlCommand("select * from dbo.fan where national_id=@id", conn);
            checkid.Parameters.AddWithValue("@id", nationalid.Text);
            SqlDataReader sdrcheckid = checkid.ExecuteReader();
            if (sdrcheckid.HasRows) { x = 1; } else { x = 0; };
            conn.Close(); conn.Open();

            DateTime dateTime1;
            bool isDateTime1 = false;
            String[] formats = { "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd" };
            isDateTime1 = DateTime.TryParseExact(birthdate.Text, formats, new CultureInfo("en-us"), DateTimeStyles.None, out dateTime1);


            SqlCommand check = new SqlCommand("select Username from dbo.sys_user where Username=@Username", conn);
            check.Parameters.AddWithValue("@Username", username.Text);
            SqlDataReader sdr = check.ExecuteReader();





            if (username.Text.Length == 0 || password.Text.Length == 0 || name.Text.Length == 0 || nationalid.Text.Length == 0 || adress.Text.Length == 0 || birthdate.Text.Length == 0 || phonenumber.Text.Length == 0)
            {
                Literal1.Visible = true;
                Literal1.Text = "please fill the textboxes";
            }
            else if (x == 1)
            {
                Literal1.Visible = true;
                Literal1.Text = "The national id you have entered is already taken.If it is not you CONTACT US!";
            }
            else if (sdr.HasRows)
            {
                Literal1.Visible = true;
                Literal1.Text = "This username is already taken :( .Please try another one.";

            }
            else if(isDateTime1==false || (DateTime.Compare(DateTime.Now, dateTime1) <=0 )){
                Literal1.Visible = true;
                Literal1.Text = "Please enter a valid birth date in a form of yyyy/MM/dd ";
            }
            else
            {
                conn.Close();
                SqlCommand add = new SqlCommand("addFan", conn);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.Add(new SqlParameter("@name", name.Text));
                add.Parameters.Add(new SqlParameter("@username", username.Text));
                add.Parameters.Add(new SqlParameter("@password", password.Text));
                add.Parameters.Add(new SqlParameter("@national_id", nationalid.Text));
                add.Parameters.Add(new SqlParameter("@birth_date", birthdate.Text));
                add.Parameters.Add(new SqlParameter("@address", adress.Text));
                add.Parameters.Add(new SqlParameter("@phone_number", phonenumber.Text));
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Session["user"] = username.Text;
                Response.Redirect("f.aspx");

            }
        }
    }
}