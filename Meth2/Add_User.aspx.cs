using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    public static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        panelModule.Visible = false;
        panelClass.Visible = false;
        panelData.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        con.Open();
        string query = "select * from Users where name='" + txtSearch.Text + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            panelData.Visible = true;
            txtName.Text = (reader["name"].ToString());
            txtUsername.Text = (reader["username"].ToString());
            txtMail.Text = (reader["email"].ToString());
            txtGender.Text = (reader["gender"].ToString());
            txtUser.Text = (reader["type"].ToString());
            if (txtUser.Text == "Student")
            {
                panelClass.Visible = true;
            }
            else if (txtUser.Text == "Teacher")
            {
                panelModule.Visible = true;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('Data record not found');",
            true);
            txtSearch.Text = null;
        }
        con.Close();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        panelModule.Visible = false;
        panelClass.Visible = false;
        panelData.Visible = false;
        txtSearch.Text = null;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtUser.Text == "Student")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();
                string query = "select count(*) from Student where name='" + txtName.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (check > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Name already exist!');window.location ='Add_User.aspx';", true);
                }
                else
                {
                    string query1 = "insert into Student (name, username, email, gender, type, class) values (@name,@username,@email,@gender,@type,@class)";
                    string query3 = "update Users set class='" + ddlClass.SelectedItem.ToString() + "' where email = '" + txtMail.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd1.Parameters.AddWithValue("@name", txtName.Text);
                    cmd1.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd1.Parameters.AddWithValue("@email", txtMail.Text);
                    cmd1.Parameters.AddWithValue("@gender", txtGender.Text);
                    cmd1.Parameters.AddWithValue("@type", txtUser.Text);
                    cmd1.Parameters.AddWithValue("@class", ddlClass.SelectedItem.ToString());
                    cmd1.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Student Added!');window.location ='Add_User.aspx';", true);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }

        else if (txtUser.Text == "Teacher")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();
                string query = "select count(*) from Teacher where name='" + txtName.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (check > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Name already exist!');window.location ='Add_User.aspx';", true);
                }
                else
                {
                    string query1 = "insert into Teacher (name, username, email, gender, type, module) values (@name,@username,@email,@gender,@type,@module)";
                    string query3 = "update Users set module='" + ddlModule.SelectedItem.ToString() + "' where email = '" + txtMail.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd1.Parameters.AddWithValue("@name", txtName.Text);
                    cmd1.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd1.Parameters.AddWithValue("@email", txtMail.Text);
                    cmd1.Parameters.AddWithValue("@gender", txtGender.Text);
                    cmd1.Parameters.AddWithValue("@type", txtUser.Text);
                    cmd1.Parameters.AddWithValue("@module", ddlModule.SelectedItem.ToString());
                    cmd1.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Teacher Added!');window.location ='Add_User.aspx';", true);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('Unable to change due to different user type!');window.location ='Add_User.aspx';", true);
        }
    }
}