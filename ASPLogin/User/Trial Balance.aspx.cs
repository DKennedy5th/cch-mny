using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //load_fields(sender, e);
        String s1 = Request.QueryString["field1"];
        String s2 = Request.QueryString["field2"];
        DateTime start = Convert.ToDateTime(s1);
        DateTime end = Convert.ToDateTime(s2);
        asOf.Text = end.ToLongDateString();
        load_fields2(sender, e, start, end);
        strtLbl.Text = Convert.ToString(start);
        endLbl.Text = Convert.ToString(end);
    }

    protected float CRSum(object sender, EventArgs e)
    {
        SqlDataReader rdr;
        float sum = 0;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT acct_bal FROM Accounts WHERE acct_type = 'Equity' OR acct_type = 'Liabilities' OR acct_type = 'Revenue Account'", con);
            rdr = cmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    float num = Convert.ToSingle(rdr["acct_bal"]);
                    sum += num;
                }
            }
            con.Close();
        }
        return sum;
    }

    protected float DRSum(object sender, EventArgs e)
    {
        SqlDataReader rdr;
        float sum = 0;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT acct_bal FROM Accounts WHERE acct_type = 'Assets' OR acct_type = 'Expenses'", con);
            rdr = cmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    float num = Convert.ToSingle(rdr["acct_bal"]);
                    sum += num;
                }
            }
            con.Close();
        }
        return sum;
    }


    protected void load_fields(object sender, EventArgs e)
    {
        SqlDataReader rdr;
        float sum = 0;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT acct_name, acct_bal, acct_type FROM Accounts", con);
            rdr = cmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["acct_type"].ToString()=="Assets" || rdr["acct_type"].ToString()=="Expenses")
                    {
                        TableRow tmp = new TableRow();
                        Table2.Rows.Add(tmp);
                        TableCell tmpN = new TableCell();
                        TableCell tmpB = new TableCell();
                        TableCell tmpBl = new TableCell();
                        tmpN.Text = rdr["acct_name"].ToString();
                        tmpB.Text = rdr["acct_bal"].ToString();
                        tmpBl.Text = "";
                        tmp.Cells.Add(tmpN);
                        tmp.Cells.Add(tmpB);
                        tmp.Cells.Add(tmpBl);
                    }

                    else if (rdr["acct_type"].ToString() == "Equity" || rdr["acct_type"].ToString() == "Liabilities" || rdr["acct_type"].ToString() == "Revenue Account")
                    {
                        TableRow tmp = new TableRow();
                        Table2.Rows.Add(tmp);
                        TableCell tmpN = new TableCell();
                        TableCell tmpB = new TableCell();
                        TableCell tmpBl = new TableCell();
                        tmpN.Text = rdr["acct_name"].ToString();
                        tmpB.Text = rdr["acct_bal"].ToString();
                        tmpBl.Text = "";
                        tmp.Cells.Add(tmpN);
                        tmp.Cells.Add(tmpBl);
                        tmp.Cells.Add(tmpB);
                    }
                }
            }
            //cmd1.ExecuteNonQuery();


            con.Close();
        }
        TableHeaderRow totalR = new TableHeaderRow();
        Table2.Rows.Add(totalR);
        TableHeaderCell totalC = new TableHeaderCell();
        totalC.Text = "Total: ";
        totalR.Cells.Add(totalC);
        TableHeaderCell totalDR = new TableHeaderCell();
        totalDR.Text = "$" + DRSum(sender, e);
        totalR.Cells.Add(totalDR);
        TableHeaderCell totalCR = new TableHeaderCell();
        totalCR.Text = "$" + CRSum(sender, e);
        totalR.Cells.Add(totalCR);


    }

    protected void load_fields2(object sender, EventArgs e, DateTime strt, DateTime endd)
    {
        SqlDataReader rdr;
        float sum = 0;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT acct_name, acct_bal, created_at, acct_id, acct_type FROM Accounts", con);
            rdr = cmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    DateTime accntDate = Convert.ToDateTime(rdr["created_at"]);
                    int resultStart = DateTime.Compare(strt, accntDate);
                    int resultEnd = DateTime.Compare(endd, accntDate);
                    strtRslt.Text = Convert.ToString(resultStart);
                    endRslt.Text = Convert.ToString(resultEnd);

                    if (resultStart <= 0 && resultEnd >= 0)
                    {
                        if (rdr["acct_type"].ToString() == "Assets" || rdr["acct_type"].ToString() == "Expenses")
                        {
                            TableRow tmp = new TableRow();
                            Table2.Rows.Add(tmp);
                            TableCell tmpN = new TableCell();
                            TableCell tmpB = new TableCell();
                            TableCell tmpBl = new TableCell();
                            tmpN.Text = rdr["acct_name"].ToString();
                            tmpB.Text = rdr["acct_bal"].ToString();
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpB);
                            tmp.Cells.Add(tmpBl);
                        }

                        else if (rdr["acct_type"].ToString() == "Equity" || rdr["acct_type"].ToString() == "Liabilities" || rdr["acct_type"].ToString() == "Revenue Account")
                        {
                            TableRow tmp = new TableRow();
                            Table2.Rows.Add(tmp);
                            TableCell tmpN = new TableCell();
                            TableCell tmpB = new TableCell();
                            TableCell tmpBl = new TableCell();
                            tmpN.Text = rdr["acct_name"].ToString();
                            tmpB.Text = rdr["acct_bal"].ToString();
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpBl);
                            tmp.Cells.Add(tmpB);
                        }
                    }

                }
            }
            //cmd1.ExecuteNonQuery();


            con.Close();
        }
        TableHeaderRow totalR = new TableHeaderRow();
        Table2.Rows.Add(totalR);
        TableHeaderCell totalC = new TableHeaderCell();
        totalC.Text = "Total: ";
        totalR.Cells.Add(totalC);
        TableHeaderCell totalDR = new TableHeaderCell();
        totalDR.Text = "$" + DRSum(sender, e);
        totalR.Cells.Add(totalDR);
        TableHeaderCell totalCR = new TableHeaderCell();
        totalCR.Text = "$" + CRSum(sender, e);
        totalR.Cells.Add(totalCR);


    }

    protected void load_accounts(object sender, EventArgs e, DateTime strt, DateTime endd)
    {
        SqlDataReader accntldr;

    }

}