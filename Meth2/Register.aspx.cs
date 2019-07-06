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
    protected void Page_Load(object sender, EventArgs e)
    {

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
    protected void btnRegister_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        try
        {
            con.Open();
            string query = "select count(*) from Users where email='" + ToSHA256(txtEmail.Text) + "'" ;
            string query2 = "select count(*) from Users where username='" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            int check2 = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
            if (check > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Email already exist, please re-enter a new one');</script>");
            }

            else if (check2 > 0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Username already exist, please re-enter a new one');</script>");
            }

            else
            {
                string query1 = "insert into Users (name, username, password, email, gender, country, type) values (@name,@uname,@pword,@email,@gender,@country,@usertype)";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@name", txtName.Text);
                cmd1.Parameters.AddWithValue("@uname", txtID.Text);
                cmd1.Parameters.AddWithValue("@pword", ToSHA256(txtPass.Text));
                cmd1.Parameters.AddWithValue("@email", ToSHA256(txtEmail.Text));
                cmd1.Parameters.AddWithValue("@gender", ddlGender.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@country", ddlCountry.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@usertype", ddlType.SelectedItem.ToString());
                cmd1.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Registration Success!');window.location ='Register.aspx';", true);
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }
}