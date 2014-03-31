using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChartOfAccounts : System.Web.UI.Page
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
    



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}