using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddAccount : System.Web.UI.Page
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
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string a = "DEFAULT";
        Int32 i;
        string str;
        string debit_credit;
        string username;
        string accountName;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            //SqlCommand cmd1 = new SqlCommand();


            con.Open();
            //int b = 1234;
            SqlCommand cmd1 = new SqlCommand("Select top 1 acct_id from Accounts where (acct_type = '" + DropDownList1.Text + "')order by acct_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            i = (Int32)cmd1.ExecuteScalar();

            con.Close();
        }
        if (DropDownList1.Text == "Assets" || DropDownList1.Text == "Cost of Sales" || DropDownList1.Text == "Expenses" || DropDownList1.Text == "Loss on Sale of Assets")
        {
            debit_credit = "Debit";
        }
        else
        {
            debit_credit = "Credit";
        }

        //check if username exists already
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select acct_name from Accounts where acct_name like '" + TextBox1.Text + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            accountName = (string)cmd1.ExecuteScalar();

            con.Close();
        }
        //determines if the account name already exists and displays an error
        if (TextBox1.Text.Trim().Equals(accountName))
        {
            Label1.Visible = true;
            Label1.Text = "Account Name Already Exists";
            
        }

        else
        {
             //add new account into database
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Accounts values('" + (i + 1) + "','" + DropDownList1.Text + "','Report_Type','" + Page.User.Identity.Name + "','" + DateTime.Now + "','" + TextBox1.Text + "','" + float.Parse(TextBox2.Text) + "','" + float.Parse(TextBox2.Text) + "','" + DropDownList2.Text + "','" + Page.User.Identity.Name + "','" + DateTime.Now + "','" + DateTime.Now + "','" + Page.User.Identity.Name + "','" + debit_credit + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }


            Int32 k;
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select top 1 event_id from EventLog order by event_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                k = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }

            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into EventLog values('" + Page.User.Identity.Name + "','Created Account','" + DateTime.Now + "',NULL,'"+ (i+1) +"',NULL,NULL,NULL,'"+ (k+1) +"')", con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }

            Response.RedirectPermanent("AddAccount.aspx");
        }
    }
}