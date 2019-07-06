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
        panelGuest.Visible = false;
        panelStudent.Visible = false;
        panelTeacher.Visible = false;
    }
    public string fetchData()
    {
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        string query = "select * from Users";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int num = reader.GetInt32(0);
            string fullname = reader.GetString(1);
            string username = reader.GetString(2);
            string email = reader.GetString(4);
            string gender = reader.GetString(5);
            string country = reader.GetString(6);
            string type = reader.GetString(7);

            htmlStr += "<tr><td>" + num + "</td><td>" + fullname + " </td><td>" + username + "</td><td>" + email + "</td><td>" + gender + "</td><td>" + country + "</td><td>" + type + "</td></tr>";
        }
        con.Close();
        return htmlStr;
    }

    public string fetchData2()
    {
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        string query = "select * from Student";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int num = reader.GetInt32(0);
            string name = reader.GetString(1);
            string username = reader.GetString(2);
            string email = reader.GetString(3);
            string gender = reader.GetString(4);
            string Class = reader.GetString(6);

            htmlStr += "<tr><td>" + num + "</td><td>" + name + " </td><td>" + username + "</td><td>" + email + "</td><td>" + gender + "</td><td>" + Class + "</td></tr>";
        }
        con.Close();
        return htmlStr;
    }

    public string fetchData3()
    {
        string htmlStr = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        string query = "select * from Teacher";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int num = reader.GetInt32(0);
            string name = reader.GetString(1);
            string username = reader.GetString(2);
            string email = reader.GetString(3);
            string gender = reader.GetString(4);
            string module = reader.GetString(6);

            htmlStr += "<tr><td>" + num + "</td><td>" + name + " </td><td>" + username + "</td><td>" + email + "</td><td>" + gender + "</td><td>" + module + "</td></tr>";
        }
        con.Close();
        return htmlStr;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if(ddlUser.SelectedIndex == 0)
        {
            panelGuest.Visible = true;
            panelStudent.Visible = false;
            panelTeacher.Visible = false;
        }
        else if (ddlUser.SelectedIndex == 1)
        {
            panelStudent.Visible = true;
            panelGuest.Visible = false;
            panelTeacher.Visible = false;
        }
        else if (ddlUser.SelectedIndex == 2)
        {
            panelTeacher.Visible = true;
            panelStudent.Visible = false;
            panelGuest.Visible = false;
        }
    }
}

