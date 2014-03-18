using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChartAccounts : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlDataAdapter da = new SqlDataAdapter("select * from Accounts", con);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //GridView1.DataSource = dt;
        //DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if(DropDownList1.SelectedItem.Text.Equals("TestAccount1"))

        string url;
        url = "TransactionPage.aspx?name=" + DropDownList1.SelectedItem.Text;
        Response.Redirect(url);
        
    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}