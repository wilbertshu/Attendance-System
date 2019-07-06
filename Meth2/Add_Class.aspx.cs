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
        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
        con.Open();
        string query = "select count(*) from Class where class='" + txtClass.Text + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        if (check > 0)
        {
            Response.Write("<script type=\"text/javascript\">alert('Class already exist, please re-enter a new one');</script>");
        }
        else
        {
            string query1 = "insert into Class (class) values (@class)";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@class", txtClass.Text);
            cmd1.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('Added Success!');window.location ='Add_Class.aspx';", true);
        }
        con.Close();
    }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtClass.Text = null;
    }
}