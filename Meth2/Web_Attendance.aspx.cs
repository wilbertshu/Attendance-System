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
    protected void Page_Load(object sender, EventArgs e)
    {
        lblModule.Text = Session["module"].ToString();
        panelAttendance.Visible = false;
        lblDate.Text = "Marking attendance for: " + DateTime.Now.ToShortDateString();
        if (String.IsNullOrEmpty((string)lblModule.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('You havent registered to the system!');window.location ='Homepage.aspx';", true);
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        lblClass.Text = ddlClass.SelectedItem.ToString();
        con.Open();
        string query = "select * from Student where class='" + ddlClass.SelectedValue + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            panelAttendance.Visible = true;
            panelSearch.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('Data record not found');",
            true);
            ddlClass.SelectedValue = null;
        }
        con.Close();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            String name = row.Cells[0].Text;
            /*String email = row.Cells[1].Text;*/
            RadioButton rbtn1 = (row.Cells[1].FindControl("rbtn1") as RadioButton);
            RadioButton rbtn2 = (row.Cells[1].FindControl("rbtn2") as RadioButton);
            String dateofclass = DateTime.Now.ToShortDateString();
            String status;
            if (rbtn1.Checked)
            {
                status = "Present";
            }
            else
            {
                status = "Absent";
            }
            saveattendance(name, status, dateofclass);
        }
        if (!String.IsNullOrEmpty((string)lblModule.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('Attendance saved!');window.location ='Web_Attendance.aspx';", true);
        }
    }
    private void saveattendance(String name, String status, String dateofclass)
    {
        if (String.IsNullOrEmpty((string)lblModule.Text))
        {
            Response.Write("<script type=\"text/javascript\">alert('Attendance failed to save due to no access!');</script>");
        }
        else
        {
            con.Open();
            string query1 = "insert into Attendance (name, module, attendance, date, class) values (@name,@module,@attendance,@date,@class)";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@name", name);
            cmd1.Parameters.AddWithValue("@module", lblModule.Text);
            cmd1.Parameters.AddWithValue("@attendance", status);
            cmd1.Parameters.AddWithValue("@date", DateTime.Now);
            cmd1.Parameters.AddWithValue("@class", lblClass.Text);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
    }
}