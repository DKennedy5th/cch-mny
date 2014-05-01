using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_EditTransactions : System.Web.UI.Page
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
        if (acct_type.Equals("Admin"))
        {
            Response.Redirect("~/Admin/Default.aspx");
        }

        Button2.Visible = true;
        Button3.Visible = true;
        string approved_rejected;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("select status from Transactions where trans_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);
            approved_rejected = cmd1.ExecuteScalar().ToString().Trim();
            con.Close();
        }

        Label1.Text = approved_rejected;
        if (approved_rejected.Equals("Rejected"))
        {
            Button2.Visible = false;
            Button3.Visible = false;

        }
        if (approved_rejected.Equals("Approved"))
        {
            Button2.Visible = false;
            Button3.Visible = false;
        }

        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Int32 rowCount = this.GridView1.Rows.Count;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("update transactions set status = 'Approved', valid_by = '" + Page.User.Identity.Name + "', valid_at ='" + DateTime.Now + "' where trans_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        for (int i = 0; i < rowCount; i++)
        {
            string debit_credit, acct_default_side;
            Int32 acct_number = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
            Int32 acct_bal;
            debit_credit = GridView1.Rows[i].Cells[2].Text;
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select default_side from Accounts where acct_id = '" + acct_number + "'", con);
                acct_default_side = cmd1.ExecuteScalar().ToString();
                con.Close();
            }

            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select acct_bal from Accounts where acct_id = '" + acct_number + "'", con);
                acct_bal = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
            }

            if (acct_default_side == debit_credit)
            {
                using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("update Accounts set acct_bal = '" + (acct_bal + Convert.ToInt32(GridView1.Rows[i].Cells[3].Text))  + "', last_updated_by = '" + Page.User.Identity.Name + "', last_updated ='" + DateTime.Now + "' where acct_id = '" + acct_number + "'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            else if (acct_default_side != debit_credit)
            {
                using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("update Accounts set acct_bal = '" + (acct_bal - Convert.ToInt32(GridView1.Rows[i].Cells[3].Text)) + "', last_updated_by = '" + Page.User.Identity.Name + "', last_updated ='" + DateTime.Now + "' where acct_id = '" + acct_number + "'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        Response.Redirect("~/Manager/Default.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("update transactions set status = 'Rejected'where trans_id = '" + GridView1.Rows[0].Cells[0].Text + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Default.aspx");
    }
}