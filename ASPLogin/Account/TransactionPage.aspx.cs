﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_TransactionPage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!");
    protected void Page_Load(object sender, EventArgs e)
    {
        string chart = Request.QueryString["name"];
        SqlDataAdapter da = new SqlDataAdapter("select * from Accounts where acct_name = '" + chart + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView2.DataSource = dt;
        DataBind();

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}