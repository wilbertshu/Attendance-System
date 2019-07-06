using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

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
            txtCountry.Text = (reader["country"].ToString());
            if (txtUser.Text == "Student")
            {
                panelClass.Visible = true;
                txtSearch.Enabled = false;
            }
            else if (txtUser.Text == "Teacher")
            {
                panelModule.Visible = true;
                txtSearch.Enabled = false;
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
        txtSearch.Enabled = true;
    }

    public string ToSHA256(string value)
    {
        SHA256 sha256 = SHA256.Create();

        byte[] hashData = sha256.ComputeHash(Encoding.Default.GetBytes(value));
        StringBuilder returnValue = new StringBuilder();

        for (int i = 0; i < hashData.Length; i++)
        {
            returnValue.Append(hashData[i].ToString());
        }

        return returnValue.ToString();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (txtUser.Text == "Student")
        {
            con.Open();
            string query = "select count(*) from Users where email = '" + ToSHA256(txtMail.Text) + "'";          
            SqlCommand cmd = new SqlCommand(query, con);
            int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (check > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Email already exist, please re-enter a new one');</script>");
            }
            else
            {
                string query2 = "update Users set name='" + txtName.Text + "',email ='" + ToSHA256(txtMail.Text) + "',class ='" + ddlClass.SelectedItem + "' where username = '" + txtUsername.Text + "'";
                string query3 = "update Student set name='" + txtName.Text + "',email ='" + ToSHA256(txtMail.Text) + "',class ='" + ddlClass.SelectedItem + "' where username = '" + txtUsername.Text + "'";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('Saved changed!');window.location ='Edit_User.aspx';",
                                true);
            }
            con.Close();
        }
        else if (txtUser.Text == "Teacher")
        {
            con.Open();
            string query = "select count(*) from Users where email = '" + ToSHA256(txtMail.Text) + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (check > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Email already exist, please re-enter a new one');</script>");
            }
            else
            {
                string query2 = "update Users set name='" + txtName.Text + "',email ='" + ToSHA256(txtMail.Text) + "',module ='" + ddlModule.SelectedItem + "' where username = '" + txtUsername.Text + "'";
                string query3 = "update Teacher set name='" + txtName.Text + "',email ='" + ToSHA256(txtMail.Text) + "',module ='" + ddlModule.SelectedItem + "' where username = '" + txtUsername.Text + "'";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('Saved changed!');window.location ='Edit_User.aspx';",
                                true);
            }
            con.Close();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            "alert('Unable to change due to different user type!');window.location ='Edit_User.aspx';",
                            true);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtUser.Text == "Student")
        {
            con.Open();
            string query = "delete from Users where username = '" + txtUsername.Text + "'";
            string query2 = "delete from Student where username = '" + txtUsername.Text + "'";
            string query3 = "delete from Attendance where name = '" + txtName.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('User has been Deleted!');window.location ='Edit_User.aspx';",
                                true);
            con.Close();
        }
        else if (txtUser.Text == "Teacher")
        {
            con.Open();
            string query = "delete from Users where username = '" + txtUsername.Text + "'";
            string query2 = "delete from Teacher where username = '" + txtUsername.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('User has been Deleted!');window.location ='Edit_User.aspx';",
                                true);
            con.Close();
        }
        else
        {
            con.Open();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('Unable to change due to different user type!');window.location ='Edit_User.aspx';",
                                true);
            con.Close();
        }
    }

}
    



