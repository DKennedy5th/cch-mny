using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
        Label5.Visible = false;
        Label6.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean validEntry = true;
        if (TextBox1.Text.Equals(""))
        {
            Label1.Visible = true;
            Label1.Text = "FIELD IS REQUIRED";
            Label1.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox2.Text.Equals(""))
        {
            Label2.Visible = true;
            Label2.Text = "FIELD IS REQUIRED";
            Label2.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox3.Text.Equals(""))
        {
            Label3.Visible = true;
            Label3.Text = "FIELD IS REQUIRED";
            Label3.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox4.Text.Equals(""))
        {
            Label4.Visible = true;
            Label4.Text = "FIELD IS REQUIRED";
            Label4.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox5.Text.Equals(""))
        {
            Label5.Visible = true;
            Label5.Text = "FIELD IS REQUIRED";
            Label5.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox6.Text.Equals(""))
        {
            Label6.Visible = true;
            Label6.Text = "FIELD IS REQUIRED";
            Label6.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox6.Text != TextBox5.Text)
        {
            Label6.Visible = true;
            Label6.Text = "PASSWORDS MUST MATCH";
            Label6.ForeColor = Color.Red;
            validEntry = false;
        }
        if(validEntry == true)
        {
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("insert into userAccounts values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','"+ DropDownList1.Text +"','1','Sample to Update Later', '3','0',NULL)", con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
                
            Response.Redirect("~/Admin/UserEntrySuccess.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Default.aspx");
    }
}