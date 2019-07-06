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

public partial class Home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        con.Open();
        string query = "select count(*) from Users where username='" + "Admin" + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        if (check==0)
        {
            string query1 = "insert into Users (name, username, password, email, gender, country, type) values (@name,@uname,@pword,@email,@gender,@country,@usertype)";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@name", "Admin");
            cmd1.Parameters.AddWithValue("@uname", "Admin");
            cmd1.Parameters.AddWithValue("@pword", ToSHA256("admin123"));
            cmd1.Parameters.AddWithValue("@email", ToSHA256("admin@mail.com"));
            cmd1.Parameters.AddWithValue("@gender", "Male");
            cmd1.Parameters.AddWithValue("@country", "Indonesia");
            cmd1.Parameters.AddWithValue("@usertype", "Admin");
            cmd1.ExecuteNonQuery();
        }
        con.Close();
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

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select count(*) from Users where username = '" + txtID.Text + "' and password = '" + ToSHA256(txtPass.Text) + "'", con);
        int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());

        if (count > 0)
        {
            SqlCommand cmdType = new SqlCommand("select type from Users where username = '" + txtID.Text + "'", con);
            string uType = cmdType.ExecuteScalar().ToString().Replace(" ", "");
            Session["uType"] = uType;
            Session["uname"] = txtID.Text;
            
            Response.Redirect("My_Profile.aspx");
        }
        else
        {
            lblError.Visible = true;
        }
        con.Close();
    }

}