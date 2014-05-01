using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditIndividualAccount : System.Web.UI.Page
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


        float bal;
        string acct_name, active;


        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select acct_name from Accounts where acct_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            acct_name = Convert.ToString(cmd1.ExecuteScalar());

            con.Close();
        }

        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select acct_bal from Accounts where acct_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            bal = Convert.ToInt32(cmd1.ExecuteScalar());

            con.Close();
        }
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select acct_type from Accounts where acct_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            acct_type = Convert.ToString(cmd1.ExecuteScalar());

            con.Close();
        }
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select active from Accounts where acct_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            active = Convert.ToString(cmd1.ExecuteScalar());

            con.Close();
        }

        TextBox1.Text = acct_name;
        TextBox2.Text = bal.ToString();
        DropDownList1.Text = acct_type;
        DropDownList2.Text = active;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("update Accounts set active='" + DropDownList2.Text + "', last_updated = '" + DateTime.Now + "', last_updated_by = '" + Page.User.Identity.Name + "' where acct_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);
            cmd1.ExecuteNonQuery();

            con.Close();
        }
        Response.Redirect("~/Admin/EditIndividualAccount.aspx?acct_id=" + GridView1.Rows[0].Cells[0].Text);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/EditAccount.aspx");
    }
}