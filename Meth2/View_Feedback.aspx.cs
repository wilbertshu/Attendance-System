using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string fetchData()
    {
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        string query = "select * from Feedback";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            string targetuser = reader.GetString(2);
            string feedback = reader.GetString(3);

            htmlStr += "<tr><td>" + id + "</td><td>" + username + " </td><td>" + targetuser + "</td><td>" + feedback + "</td></tr>";
        }
        con.Close();
        return htmlStr;
    }

}

