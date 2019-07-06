using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] != null)
        {
            lblName.Visible = true;
            lblName.Text = ("Welcome Back, ") + Session["uType"].ToString();
        }

        con.Open();
        string query = "select count(*) from Class where class='" + "Science-1" + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        if (check == 0)
        {
            string query1 = "insert into Class (class) values (@class)";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@class", "Science-1");
            cmd1.ExecuteNonQuery();
        }
        con.Close();
    }
}