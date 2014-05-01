using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Transactions : System.Web.UI.Page
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
    }
}