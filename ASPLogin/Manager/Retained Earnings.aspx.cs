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
        String s1 = Request.QueryString["field1"];
        String s2 = Request.QueryString["field2"];
        //DateTime start = Convert.ToDateTime(s1);
        DateTime end = Convert.ToDateTime(s2);
        int mnth = end.Month;
        int year = end.Year;
        DateTime start = new DateTime(year, mnth, 1);
        DateTime prvEarningsStart = new DateTime(year,1,1);
        //DateTime prvEarningsEnd = start;
        asOf.Text = end.ToLongDateString();
        load_table(sender, e, start, end, prvEarningsStart);
    }


    protected void load_table(object sender, EventArgs e, DateTime strt, DateTime endd, DateTime prevEarn)
    {
        TableRow prvRE = new TableRow();
        RetainedEarnTable.Rows.Add(prvRE);
        TableCell prevRetEnDate = new TableCell();
        prevRetEnDate.Text = "Retained Earnings&nbsp;" + strt.ToShortDateString();
        float previousEarnings = get_retained_earnings(sender, e, prevEarn, strt);
        String pRE = previousEarnings.ToString("F2");
        TableCell prevRetEn = new TableCell();
        if (previousEarnings == 0)
            prevRetEn.Text = "$&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;";
        else
        {
            if (previousEarnings.ToString("F2").Length > 3)
            {
                String pRE_cents = pRE.Substring(pRE.Length - 3, 3);
                pRE = formatCommas(pRE.Substring(0, pRE.Length - 3));
                prevRetEn.Text = "$" + pRE + pRE_cents;
            }
            else
                prevRetEn.Text = "$" + pRE;
        }
        prvRE.Cells.Add(prevRetEnDate);
        prevRetEn.HorizontalAlign = HorizontalAlign.Right;
        prvRE.Cells.Add(prevRetEn);
    }


    protected float get_retained_earnings(object sender, EventArgs e, DateTime strt, DateTime endd)
    {
        float crSum = 0;
        float drSum = 0;
        float dividends = 0;
        SqlDataReader rdr;
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
                    String acctbal = rdr["acct_start_bal"].ToString();
                    float accnt_balance = Convert.ToSingle(acctbal);
                    if (resultStart <= 0 && resultEnd >= 0)
                    {
                        if (rdr["acct_type"].ToString() == "Revenue Account")
                        {
                            List<String> tran_result = get_transaction(sender, e, strt, endd);
                            foreach (String rslt in tran_result)
                            {
                                //float accnt_balance = get_trans_credits(sender, e, tran_result, rdr["acct_id"].ToString());
                                accnt_balance += get_trans_credits(sender, e, rslt, rdr["acct_id"].ToString(), "Credit");
                            }
                            crSum += accnt_balance;
                        }
                        else if (rdr["acct_type"].ToString() == "Expenses")
                        {
                            List<String> tran_result = get_transaction(sender, e, strt, endd);
                            foreach (String rslt in tran_result)
                            {
                                //float accnt_balance = get_trans_credits(sender, e, tran_result, rdr["acct_id"].ToString());
                                accnt_balance += get_trans_credits(sender, e, rslt, rdr["acct_id"].ToString(), "Debit");
                            }
                            drSum += accnt_balance;
                            //accnt_balance += get_trans_credits(sender, e, tran_result, rdr["acct_id"].ToString());
                        }
                        else if (rdr["acct_type"].ToString() == "Equity" && rdr["acct_name"].ToString() == "Dividends")
                        {
                            dividends += Convert.ToSingle(rdr["acct_bal"].ToString());
                        }


                    }

                }
            }
            //cmd1.ExecuteNonQuery();


            con.Close();
        }
        return (crSum - drSum) - dividends;
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


    protected String formatCommas(String amount)
    {
        String accnt_balance_strng = "";

        if (amount.Length > 3)
            accnt_balance_strng = amount;
        else
            return "";

        bool wasNeg = false;
        if (accnt_balance_strng.Substring(0, 1) == "-")
        {
            accnt_balance_strng = accnt_balance_strng.Substring(1, accnt_balance_strng.Length - 1);
            wasNeg = true;
        }

        if (accnt_balance_strng.Length > 12)
            accnt_balance_strng = accnt_balance_strng.Substring(0, (accnt_balance_strng.Length - 12)) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 12), 3) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 9), 3) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 6), 3) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 3), 3);
        else if (accnt_balance_strng.Length > 9 && accnt_balance_strng.Length <= 12)
            accnt_balance_strng = accnt_balance_strng.Substring(0, (accnt_balance_strng.Length - 9)) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 9), 3) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 6), 3) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 3), 3);
        else if (accnt_balance_strng.Length > 6 && accnt_balance_strng.Length <= 9)
            accnt_balance_strng = accnt_balance_strng.Substring(0, (accnt_balance_strng.Length - 6)) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 6), 3) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 3), 3);
        else
            accnt_balance_strng = accnt_balance_strng.Substring(0, (accnt_balance_strng.Length - 3)) + "," + accnt_balance_strng.Substring((accnt_balance_strng.Length - 3), 3);

        if (wasNeg == false)
            return accnt_balance_strng;
        else
            return "-" + accnt_balance_strng;
    }

}