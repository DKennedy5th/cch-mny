﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Label2.Visible = false;
        DropDownList1.Visible = false;
        DropDownList2.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Visible = true;
        Label1.Text = "Update the Users Role";

        Label2.Visible = true;
        Label2.Text = "Lock or Unlock the User Account";        

        DropDownList1.Visible = true;
        DropDownList2.Visible = true;

        Button2.Visible = true;

        Button3.Visible = true;

        

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList2.Text.Equals("Lock Account"))
        {
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update userAccounts set type_of_account='" + DropDownList1.Text + "', IsLocked = 1, LockedDateTime = '"+ DateTime.Now +"' where username = '"+ GridView1.Rows[0].Cells[0].Text +"'" , con);
                cmd1.ExecuteNonQuery();

                con.Close();
            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update userAccounts set type_of_account='" + DropDownList1.Text + "', IsLocked = 0, LockedDateTime = NULL where username = '" + GridView1.Rows[0].Cells[0].Text + "'", con);
                cmd1.ExecuteNonQuery();

                con.Close();
            }
        }

        Response.Redirect("~/Admin/EditUsers.aspx?username=" + GridView1.Rows[0].Cells[0].Text);

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Label2.Visible = false;
        DropDownList1.Visible = false;
        DropDownList2.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
    }
}