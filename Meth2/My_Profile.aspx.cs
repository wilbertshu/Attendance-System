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
    public static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] != null)
        {
            txtUsername.Text = Session["uname"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select * from Users where username='" + txtUsername.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = (reader["name"].ToString());
                txtUsername.Text = (reader["username"].ToString());
                txtEmail.Text = (reader["email"].ToString());
                txtGender.Text = (reader["gender"].ToString());
                txtType.Text = (reader["type"].ToString());
                txtCountry.Text = (reader["country"].ToString());
                if (txtType.Text == "Student")
                {
                    panelClass.Visible = true;
                    txtClass.Text = (reader["class"].ToString());
                    Session["studName"] = txtName.Text;
                    Session["studClass"] = txtClass.Text;
                }
                else if (txtType.Text == "Teacher")
                {
                    panelModule.Visible = true;
                    txtModule.Text = (reader["module"].ToString());
                    Session["module"] = txtModule.Text;
                }
                else if (txtType.Text == "Admin")
                {
                    panelChange.Visible = false; ;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Data record not found');window.location ='Homepage.aspx';",
                true);
            }
            con.Close();
         }
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
    protected void btnChange_Click(object sender, EventArgs e) {
        con.Open();
        string query = "update Users set password='" + ToSHA256(txtPass.Text) + "' where email = '" + txtEmail.Text + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Saved Changes! Please log in again.');window.location ='Homepage.aspx';",
                true);
        Session.Abandon();
        con.Close();
    }

}