﻿using System;
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

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string a = "DEFAULT";
        Int32 i;
        string str;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            //SqlCommand cmd1 = new SqlCommand();


            con.Open();
            //int b = 1234;
            SqlCommand cmd1 = new SqlCommand("Select top 1 acct_id from Accounts where (acct_type = '" + DropDownList1.Text + "')order by acct_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            i = (Int32)cmd1.ExecuteScalar();

            con.Close();
        }
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Accounts values('" + (i + 1) + "','" + DropDownList1.Text + "','Report_Type','" + Page.User.Identity.Name + "','" + DateTime.Now + "','" + TextBox1.Text + "','" + Int32.Parse(TextBox2.Text) + "','" + Int32.Parse(TextBox2.Text) + "','" + DropDownList2.Text + "','" + Page.User.Identity.Name + "','" + DateTime.Now + "','" + DateTime.Now + "','" + Page.User.Identity.Name + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        Response.RedirectPermanent("AddAccount.aspx");

    }
}