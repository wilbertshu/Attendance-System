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
        lblModule.Text = Session["module"].ToString();
        Panel1.Visible = false;
        if (Session["uname"] != null)
        {
            txtUser.Text = Session["uname"].ToString();
        }
        if (String.IsNullOrEmpty((string)lblModule.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('You havent registered to the system!');window.location ='Homepage.aspx';", true);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;

        con.Open();
        string query = "select * from Student where name='" + txtSearch.Text + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            txtFeedback.Visible = true;
            txtName.Text = (reader["name"].ToString());
            txtEmail.Text = (reader["email"].ToString());
            txtGender.Text = (reader["gender"].ToString());
            txtModule.Text = (reader["class"].ToString());
        }
        else
        {
            Panel1.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('Data record not found');window.location ='Teacher_Studentfeedback.aspx';",
            true);
        }
        con.Close();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        txtSearch.Text = null;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        if (Session["uname"] != null)
        {
            string query1 = "insert into Feedback (username, targetuser, feedback) values (@uname,@tuser,@feedback)";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@uname", txtUser.Text);
            cmd1.Parameters.AddWithValue("@tuser", txtName.Text);
            cmd1.Parameters.AddWithValue("@feedback", txtFeedback.Text);
            cmd1.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Feedback Sent!');window.location ='Homepage.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('You havent logged in!');window.location ='Login.aspx';", true);
        }
        con.Close();
    }
}