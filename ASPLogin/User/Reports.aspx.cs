using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Reports : System.Web.UI.Page
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
        if (acct_type.Equals("Manager"))
        {
            Response.Redirect("~/Manager/Default.aspx");
        }
        if (acct_type.Equals("Admin"))
        {
            Response.Redirect("~/Admin/Default.aspx");
        }
    }

    protected void load_report(object sender, EventArgs e)
    {
        int year = DateTime.Now.Year;
        DateTime start = new DateTime(year, 1, 1);
        if (ReportSelection.SelectedValue == "Trial Balance")
        {
            //strtDate.SelectedDate = 28;
            //Server.Transfer("~/User/Trial Balance.aspx?field1=" + strtDate.SelectedDate + "&field2=" + endDate.SelectedDate, false);
            Server.Transfer("~/User/Trial Balance.aspx?field1=" + start + "&field2=" + endDate.SelectedDate, false);
        }
        else if (ReportSelection.SelectedValue == "Income Statement")
        {
            Server.Transfer("~/User/Income Statement.aspx?field1=" + start + "&field2=" + endDate.SelectedDate, false);
        }
        else if (ReportSelection.SelectedValue == "Balance Sheet")
        {
            Server.Transfer("~/User/Balance Sheet.aspx?field1=" + start + "&field2=" + endDate.SelectedDate, false);
        }
    }

}