using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_AddAccount : System.Web.UI.Page
{

    //SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        
        

        

        string a = "DEFAULT";
        Int32 i;
        string str;
        using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
        {
            //SqlCommand cmd1 = new SqlCommand();


            con.Open();
            //int b = 1234;
            SqlCommand cmd1 = new SqlCommand("Select top 1 acct_id from accounts where (acct_type = '"+ DropDownList1.Text +"')order by acct_id DESC",con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            i = (Int32)cmd1.ExecuteScalar();
       
            con.Close();
        }
        using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Accounts values('" + (i+1) + "','" + DropDownList1.Text + "','" + Membership.GetUser().UserName + "','" + DateTime.Now + "','" + TextBox1.Text + "','" + Int32.Parse(TextBox2.Text) + "','" + Int32.Parse(TextBox2.Text) + "','" + DropDownList2.Text + "','" + Membership.GetUser().UserName + "','" + DateTime.Now + "','" + DateTime.Now + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        Response.RedirectPermanent("AddAccount.aspx");

    }
}