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
        float crSum = 0;
        float drSum = 0;
        SqlDataReader rdr;
        int rwcc = 0;
        int rwcd = 0;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT acct_name, acct_bal, acct_start_bal, created_at, acct_id, acct_type FROM Accounts", con);
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
                    String stupid = rdr["acct_start_bal"].ToString();
                    float accnt_balance = Convert.ToSingle(stupid);
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

                            List<String> tran_result = get_transaction(sender, e, strt, endd);
                            foreach (String rslt in tran_result)
                            {
                                //float accnt_balance = get_trans_credits(sender, e, tran_result, rdr["acct_id"].ToString());
                                accnt_balance += get_trans_credits(sender, e, rslt, rdr["acct_id"].ToString(), "Debit");
                            }
                            drSum += accnt_balance;
                            //accnt_balance += get_trans_credits(sender, e, tran_result, rdr["acct_id"].ToString());
                            if (rwcd == 0)
                            {
                                tmpB.Text = "$" + accnt_balance.ToString() + ".00";
                            }
                            else
                            {
                                tmpB.Text = accnt_balance.ToString() + ".00";
                            }
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpB);
                            tmp.Cells.Add(tmpBl);
                            rwcd++;
                        }

                        else if (rdr["acct_type"].ToString() == "Equity" || rdr["acct_type"].ToString() == "Liabilities" || rdr["acct_type"].ToString() == "Revenue Account")
                        {
                            TableRow tmp = new TableRow();
                            Table2.Rows.Add(tmp);
                            TableCell tmpN = new TableCell();
                            TableCell tmpB = new TableCell();
                            TableCell tmpBl = new TableCell();

                            tmpN.Text = rdr["acct_name"].ToString();

                            List<String> tran_result = get_transaction(sender, e, strt, endd);
                            foreach (String rslt in tran_result)
                            {
                                //float accnt_balance = get_trans_credits(sender, e, tran_result, rdr["acct_id"].ToString());
                                accnt_balance += get_trans_credits(sender, e, rslt, rdr["acct_id"].ToString(), "Credit");
                            }
                            crSum += accnt_balance;
                            if (rwcc == 0)
                            {
                                tmpB.Text = "$" + accnt_balance.ToString() + ".00";
                            }
                            else
                            {
                                tmpB.Text = accnt_balance.ToString() + ".00";
                            }
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpBl);
                            tmp.Cells.Add(tmpB);
                            rwcc++;
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
        totalDR.Text = "$" + drSum + ".00";
        totalR.Cells.Add(totalDR);
        TableHeaderCell totalCR = new TableHeaderCell();
        totalCR.Text = "$" + crSum + ".00";
        totalR.Cells.Add(totalCR);


    }

    protected List<String> get_transaction(object sender, EventArgs e, DateTime strt, DateTime endd)
    {
        List<String> results = new List<String>();
        //int i = 0;
        SqlDataReader trans_rdr;
        using (SqlConnection conn = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            conn.Open();
            SqlCommand trans_cmd = new SqlCommand("SELECT trans_id, valid_at FROM Transactions", conn);
            trans_rdr = trans_cmd.ExecuteReader();

            if (trans_rdr.HasRows)
            {
                while (trans_rdr.Read())
                {
                    DateTime trnsDate = Convert.ToDateTime(trans_rdr["valid_at"]);
                    int resultStart = DateTime.Compare(strt, trnsDate);
                    int resultEnd = DateTime.Compare(endd, trnsDate);
                    strtRslt.Text = Convert.ToString(resultStart);
                    endRslt.Text = Convert.ToString(resultEnd);

                    if (resultStart <= 0 && resultEnd >= 0)
                    {

                        //results[i] = trans_rdr["trans_id"].ToString();.
                        results.Add(trans_rdr["trans_id"].ToString());
                        //i++;
                    }

                }
            }
        }
        //return ""; // Blank string returned if no applicable transactions are found.
        return results;
    }

    protected float get_trans_credits(object sender, EventArgs e, String trans_ID, String acct_ID, String acct_TYPE)
    {
        float accnt_sum = 0;
        SqlDataReader ind_trans_rdr;
        using (SqlConnection conn = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            conn.Open();
            SqlCommand ind_trans_cmd = new SqlCommand("SELECT amount, acct_id, debit_credit FROM individualTransaction WHERE trans_id = " + trans_ID, conn);
            ind_trans_rdr = ind_trans_cmd.ExecuteReader();

            if (ind_trans_rdr.HasRows)
            {
                while (ind_trans_rdr.Read())
                {
                    //String test1 = ind_trans_rdr["trans_id"].ToString();
                    String test2 = ind_trans_rdr["acct_id"].ToString();
                    //if (ind_trans_rdr["trans_id"].ToString() == trans_ID && ind_trans_rdr["acct_id"].ToString() == acct_ID)
                    if (ind_trans_rdr["acct_id"].ToString() == acct_ID)
                    {
                        //return ind_trans_rdr["trans_id"].ToString();
                        String test3 = ind_trans_rdr["amount"].ToString();
                        float num = Convert.ToSingle(ind_trans_rdr["amount"]);
                        if (ind_trans_rdr["debit_credit"].ToString() == acct_TYPE)
                        {
                            accnt_sum += num;
                        }
                        else
                            accnt_sum -= num;
                    }

                }
            }
            return accnt_sum;
        }
        
    }


}