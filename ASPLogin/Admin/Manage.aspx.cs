using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Manage : System.Web.UI.Page
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
        Label1.Text = Page.User.Identity.Name;
        Label2.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
        Label5.Visible = false;


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean validEntry = true;
        string username, password, password1, password2, password3;
        if (TextBox1.Text.Equals(""))
        {
            Label2.Visible = true;
            Label2.Text = "FIELD IS REQUIRED";
            Label2.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox2.Text.Equals(""))
        {
            Label3.Visible = true;
            Label3.Text = "FIELD IS REQUIRED";
            Label3.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox3.Text.Equals(""))
        {
            Label4.Visible = true;
            Label4.Text = "FIELD IS REQUIRED";
            Label4.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox2.Text != TextBox3.Text)
        {
            Label4.Visible = true;
            Label4.Text = "PASSWORDS MUST MATCH";
            Label4.ForeColor = Color.Red;
            validEntry = false;
        }



        //checks if first password is correct
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Password from userAccounts where username like '" + Page.User.Identity.Name + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            password = (string)cmd1.ExecuteScalar();

            con.Close();
        }
        if (TextBox1.Text != password)
        {
            Label2.Visible = true;
            Label2.Text = "PASSWORD DOESN'T MATCH CURRENT";
            Label2.ForeColor = Color.Red;
            validEntry = false;
        }
        if (TextBox2.Text == TextBox3.Text && password == TextBox3.Text)
        {
            Label5.Visible = true;
            Label5.Text = "CANNOT USE THE SAME PASSWORD AS CURRENT";
            Label5.ForeColor = Color.Red;
            validEntry = false;
        }
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Pass1 from PreviousPasswords where username like '" + Page.User.Identity.Name + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            password1 = (string)cmd1.ExecuteScalar();

            con.Close();
        }
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Pass2 from PreviousPasswords where username like '" + Page.User.Identity.Name + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            password2 = (string)cmd1.ExecuteScalar();

            con.Close();
        }
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select Pass3 from PreviousPasswords where username like '" + Page.User.Identity.Name + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            password3 = (string)cmd1.ExecuteScalar();

            con.Close();
        }
        if (password1 != null)
        {
            if (TextBox2.Text == TextBox3.Text && password1 == TextBox3.Text)
            {
                Label5.Visible = true;
                Label5.Text = "PASSWORD CANNOT MATCH ANY OF PREVIOUS 3";
                Label5.ForeColor = Color.Red;
                validEntry = false;
            }

        }
        if (password2 != null)
        {
            if (TextBox2.Text == TextBox3.Text && password2 == TextBox3.Text)
            {
                Label5.Visible = true;
                Label5.Text = "PASSWORD CANNOT MATCH ANY OF PREVIOUS 3";
                Label5.ForeColor = Color.Red;
                validEntry = false;
            }

        }
        if (password3 != null)
        {
            if (TextBox2.Text == TextBox3.Text && password3 == TextBox3.Text)
            {
                Label5.Visible = true;
                Label5.Text = "PASSWORD CANNOT MATCH ANY OF PREVIOUS 3";
                Label5.ForeColor = Color.Red;
                validEntry = false;
            }
        }


        int letterCount = TextBox2.Text.Length;
        string labelText = "";
        //Checks that it meets the lenght
        if (letterCount < 8)
        {
            labelText += "Password Must Contain 8 Letters";
            Label3.Text = labelText;
            Label3.Visible = true;
            Label3.ForeColor = Color.Red;
            validEntry = false;
        }
        Boolean capital = Regex.IsMatch(TextBox2.Text, "[A-Z]+");
        if (capital == false)
        {
            labelText = " Password Must Have A Capital Letter";
            Label3.Text = labelText;
            Label3.Visible = true;
            Label3.ForeColor = Color.Red;
            validEntry = false;
        }
        Boolean symbol = Regex.IsMatch(TextBox2.Text, @"\W");
        if (symbol == false)
        {

            labelText += " Password Must Contain A Symbol";
            Label3.Text = labelText;
            Label3.Visible = true;
            Label3.ForeColor = Color.Red;
            validEntry = false;
        }

        if (validEntry == true)
        {
            DateTime i;
            if (password1 == null)
            {
                using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("insert into PreviousPasswords values('" + Page.User.Identity.Name + "','" + TextBox1.Text + "',NULL,NULL,'"+ DateTime.Now +"',NULL,NULL)", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
                using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("update userAccounts set Password = '"+ TextBox2.Text +"' where username = '"+ Page.User.Identity.Name +"'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }

                addToEventLog();
                Response.Redirect("~/Admin/Default.aspx");
            }


            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("update PreviousPasswords set pass1 ='" + TextBox1.Text + "' where username ='" + Page.User.Identity.Name + "' ", con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("update userAccounts set Password = '" + TextBox2.Text + "' where username = '" + Page.User.Identity.Name + "'", con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }

            addToEventLog();
            Response.Redirect("~/Admin/Default.aspx");


        }



    }

    protected void addToEventLog()
    {
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
            SqlCommand cmd1 = new SqlCommand("insert into EventLog values('" + Page.User.Identity.Name + "','Changed Password','" + DateTime.Now + "',NULL,NULL,NULL,NULL,NULL,'" + (i + 1) + "')", con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
    }
}