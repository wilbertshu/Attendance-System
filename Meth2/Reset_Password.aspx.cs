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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        con.Open();
        string query = "update Users set password='" + ToSHA256(txtPass.Text) + "' where email = '" + ToSHA256(txtEmail.Text) + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this, this.GetType(),
        "alert",
        "alert('Password is updated if you got the correct e-mail!');window.location ='Reset_Password.aspx';",
        true);
        con.Close();
    }
}