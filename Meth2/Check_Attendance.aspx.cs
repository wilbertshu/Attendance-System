using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUname.Text = Session["studName"].ToString();
            lblClass.Text = Session["studClass"].ToString();
        if (String.IsNullOrEmpty((string)lblClass.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('You havent registered to the system!');window.location ='Homepage.aspx';", true);
        }
    }

        public string fetchData()
        {
            string htmlStr = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select * from Attendance where name='" + lblUname.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(4);
                string module = reader.GetString(2);
                string attendance = reader.GetString(3);

                htmlStr += "<tr><td>" + date + " </td><td>" + module + "</td><td>" + attendance + "</td></tr>";
            }
            con.Close();
            return htmlStr;
        }

}