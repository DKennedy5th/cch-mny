using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string acct_type;
        string uname = Page.User.Identity.Name;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select type_of_account from userAccounts where username like '" + uname + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            acct_type = (string)cmd1.ExecuteScalar();

            con.Close();
        }
        if (acct_type.Equals("User"))
        {
            Response.Redirect("~/User/Default.aspx");
        }
        if (acct_type.Equals("Manager"))
        {
            Response.Redirect("~/Manager/Default.aspx");
        }

        Label1.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
        Label5.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
        Label8.Visible = false;
        Label9.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean validEntry = true;
        string username;
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
        //command to see if the username exists already
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select username from userAccounts where username like '" + TextBox1.Text + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            username = (string)cmd1.ExecuteScalar();

            con.Close();
        }
        //determines if the username already exists and displays an error
        if (TextBox1.Text.Trim().Equals(username))
        {
            Label1.Visible = true;
            Label1.Text = "Account Name Already Exists";
            Label1.ForeColor = Color.Red;
            validEntry = false;

        }

        //Logic for password Validation
        string passVerification = TextBox5.Text;
        
        Label7.Visible = false;
        Label8.Visible = false;
        Label9.Visible = false;
        int letterCount = TextBox5.Text.Length;
        
        //Checks that it meets the lenght
        if(letterCount < 8)
        {
            Label7.Text = "Password Must Contain 8 Letters";
            Label7.Visible = true;
            Label7.ForeColor = Color.Red;
            validEntry = false;
        }
         Boolean capital = Regex.IsMatch(TextBox5.Text, "[A-Z]+");
         if(capital == false)
         {

             Label8.Text = "Password Must Have A Capital Letter";
             Label8.Visible = true;
             Label8.ForeColor = Color.Red;
             validEntry = false;
         }
         Boolean symbol = Regex.IsMatch(TextBox5.Text, @"\W");
         if (symbol == false)
         {

             Label9.Text = "Password Must Contain A Symbol";
             Label9.Visible = true;
             Label9.ForeColor = Color.Red;
             validEntry = false;
         }


        if(validEntry == true)
        {
            //add user to db
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("insert into userAccounts values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','"+ DropDownList1.Text +"','1','Sample to Update Later', '3','0',NULL)", con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }

            //EventLog
            Int32 i;
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select top 1 event_id from EventLog order by event_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                i = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into EventLog values('" + Page.User.Identity.Name + "','Created User','" + DateTime.Now + "',NULL,NULL,NULL,NULL,NULL,'"+ (i+1) +"')", con);
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