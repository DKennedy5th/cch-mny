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
        load_assets(sender, e, start, end);
    }

    protected float AssetSum(object sender, EventArgs e)
    {
        SqlDataReader rdr;
        float sum = 0;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT acct_bal FROM Accounts WHERE acct_type = 'Assets'", con);
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

    protected float LiabilitiesSum(object sender, EventArgs e)
    {
        SqlDataReader rdr;
        float sum = 0;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT acct_bal FROM Accounts WHERE acct_type = 'Expenses'", con);
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


    protected void load_assets(object sender, EventArgs e, DateTime strt, DateTime endd)
    {
        float liabSum = 0;
        float equitSum = 0;
        float asstSum = 0;
        SqlDataReader rdr;
        int rwcc = 0;
        int rwcd = 0;
        int rwcc2 = 0;
        int asstRowCount = 0;
        int liabRowCount = 0;
        int equityRowCount = 0;

        // Build table rows for the Assets
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
                    //strtRslt.Text = Convert.ToString(resultStart);
                    //endRslt.Text = Convert.ToString(resultEnd);
                    String acctBal = rdr["acct_start_bal"].ToString();
                    float accnt_balance = Convert.ToSingle(acctBal);
                    if (resultStart <= 0 && resultEnd >= 0)
                    {
                        if (rdr["acct_type"].ToString() == "Assets")
                        {
                            if (asstRowCount == 0)
                            {
                                TableRow hdr = new TableRow();
                                BalanceTable.Rows.Add(hdr);
                                TableCell assts = new TableCell();
                                assts.Font.Bold = true;
                                assts.Font.Size = 16;
                                assts.HorizontalAlign = HorizontalAlign.Center;
                                assts.Text = "Assets";
                                TableCell hdrblnk1 = new TableCell();
                                TableCell hdrblnk2 = new TableCell();
                                hdr.Cells.Add(assts);
                                hdr.Cells.Add(hdrblnk1);
                                hdr.Cells.Add(hdrblnk2);
                            }


                            TableRow tmp = new TableRow();
                            BalanceTable.Rows.Add(tmp);
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
                            asstSum += accnt_balance;
                            //accnt_balance += get_trans_credits(sender, e, tran_result, rdr["acct_id"].ToString());

                            String accnt_bal_strng = accnt_balance.ToString("F2");
                            String accnt_bal_cents = accnt_bal_strng.Substring(accnt_bal_strng.Length - 3, 3);
                            accnt_bal_strng = accnt_bal_strng.Substring(0, accnt_bal_strng.Length - 3);
                            if (accnt_bal_strng.Length > 3)
                                accnt_bal_strng = formatCommas(accnt_bal_strng) + accnt_bal_cents;
                            else
                                accnt_bal_strng = accnt_bal_strng + accnt_bal_cents;

                            if (rwcd == 0)
                                tmpB.Text = "$" + accnt_bal_strng;
                            else
                                tmpB.Text = accnt_bal_strng;

                            tmpB.HorizontalAlign = HorizontalAlign.Right;
                            tmpB.Width = 20;
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpBl);
                            tmp.Cells.Add(tmpB);
                            asstRowCount++;
                            rwcd++;
                        }
                    }
                }
            }
            String asstSumString = asstSum.ToString("F2");
            String asstSumCents = "";
            if (asstSumString.Length > 3)
            {
                asstSumCents = asstSumString.Substring(asstSumString.Length - 3, 3);
                asstSumString = asstSumString.Substring(0, asstSumString.Length - 3);
            }
            TableRow asstSumR = new TableRow();
            TableCell sum = new TableCell();
            TableCell sumBlnk = new TableCell();
            TableCell sumTxt = new TableCell();
            sumTxt.Text = "&nbsp;&nbsp;&nbsp;Total assets";
            sumBlnk.Text = "";
            sum.Text = "$" + formatCommas(asstSumString) + asstSumCents;
            sum.Font.Underline = true;
            asstSumR.Cells.Add(sumTxt);
            asstSumR.Cells.Add(sumBlnk);
            asstSumR.Cells.Add(sum);
            BalanceTable.Rows.Add(asstSumR);
            con.Close();
        }

        // Build table rows for the Liabilities
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
                    //strtRslt.Text = Convert.ToString(resultStart);
                    //endRslt.Text = Convert.ToString(resultEnd);
                    String acctBal = rdr["acct_start_bal"].ToString();
                    float accnt_balance = Convert.ToSingle(acctBal);
                    if (resultStart <= 0 && resultEnd >= 0)
                    {
                        if (rdr["acct_type"].ToString() == "Liabilities")
                        {

                            if (liabRowCount == 0)
                            {
                                TableRow hdr = new TableRow();
                                BalanceTable.Rows.Add(hdr);
                                TableCell liab = new TableCell();
                                liab.Font.Bold = true;
                                liab.Font.Size = 16;
                                liab.HorizontalAlign = HorizontalAlign.Center;
                                liab.Text = "Liabilities";
                                TableCell hdrblnk1 = new TableCell();
                                TableCell hdrblnk2 = new TableCell();
                                hdr.Cells.Add(liab);
                                hdr.Cells.Add(hdrblnk1);
                                hdr.Cells.Add(hdrblnk2);
                            }

                            TableRow tmp = new TableRow();
                            BalanceTable.Rows.Add(tmp);
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
                            liabSum += accnt_balance;

                            String accnt_bal_strng = accnt_balance.ToString("F2");
                            String accnt_bal_cents = accnt_bal_strng.Substring(accnt_bal_strng.Length - 3, 3);
                            accnt_bal_strng = accnt_bal_strng.Substring(0, accnt_bal_strng.Length - 3);
                            if (accnt_bal_strng.Length > 3)
                                accnt_bal_strng = formatCommas(accnt_bal_strng) + accnt_bal_cents;
                            else
                                accnt_bal_strng = accnt_bal_strng + accnt_bal_cents;

                            if (rwcd == 0)
                                tmpB.Text = "$" + accnt_bal_strng;
                            else
                                tmpB.Text = accnt_bal_strng;

                            tmpB.HorizontalAlign = HorizontalAlign.Right;
                            tmpB.Width = 20;
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpB);
                            tmp.Cells.Add(tmpBl);
                            rwcc++;
                            liabRowCount++;
                        }
                    }
                }
            }
            String liabSumString = liabSum.ToString("F2");
            String liabSumCents = "";
            if (liabSumString.Length > 3)
            {
                liabSumCents = liabSumString.Substring(liabSumString.Length - 3, 3);
                liabSumString = liabSumString.Substring(0, liabSumString.Length - 3);
            }
            TableRow liabSumR = new TableRow();
            TableCell sum = new TableCell();
            TableCell sumBlnk = new TableCell();
            TableCell sumTxt = new TableCell();
            sumTxt.Text = "&nbsp;&nbsp;&nbsp;Total liabilities";
            sumBlnk.Text = "";
            sum.Text = "$" + formatCommas(liabSumString) + liabSumCents;
            liabSumR.Cells.Add(sumTxt);
            liabSumR.Cells.Add(sumBlnk);
            liabSumR.Cells.Add(sum);
            BalanceTable.Rows.Add(liabSumR);
            con.Close();

        }

        // Build table rows for the Owner's Equity
        if (equityRowCount == 0)
        {
            TableRow hdr = new TableRow();
            BalanceTable.Rows.Add(hdr);
            TableCell equit = new TableCell();
            equit.Font.Bold = true;
            equit.Font.Size = 16;
            equit.HorizontalAlign = HorizontalAlign.Center;
            equit.Text = "Owner's Equity";
            TableCell hdrblnk1 = new TableCell();
            TableCell hdrblnk2 = new TableCell();
            hdr.Cells.Add(equit);
            hdr.Cells.Add(hdrblnk1);
            hdr.Cells.Add(hdrblnk2);
        }
        equityRowCount++;

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
                    //strtRslt.Text = Convert.ToString(resultStart);
                    //endRslt.Text = Convert.ToString(resultEnd);
                    String acctBal = rdr["acct_start_bal"].ToString();
                    float accnt_balance = Convert.ToSingle(acctBal);
                    if (resultStart <= 0 && resultEnd >= 0)
                    {
                        if (rdr["acct_name"].ToString() == "Common Stock")
                        {
                            /*
                            if (equityRowCount == 0)
                            {
                                TableRow hdr = new TableRow();
                                BalanceTable.Rows.Add(hdr);
                                TableCell equit = new TableCell();
                                equit.Font.Bold = true;
                                equit.Font.Size = 16;
                                equit.HorizontalAlign = HorizontalAlign.Center;
                                equit.Text = "Owner's Equity";
                                TableCell hdrblnk1 = new TableCell();
                                TableCell hdrblnk2 = new TableCell();
                                hdr.Cells.Add(equit);
                                hdr.Cells.Add(hdrblnk1);
                                hdr.Cells.Add(hdrblnk2);
                            }
                        /*
                        if (rdr["acct_name"].ToString() == "Common Stock")
                        {

                            if (equityRowCount == 0)
                            {
                                TableRow hdr = new TableRow();
                                BalanceTable.Rows.Add(hdr);
                                TableCell equit = new TableCell();
                                equit.Font.Bold = true;
                                equit.Font.Size = 16;
                                equit.HorizontalAlign = HorizontalAlign.Center;
                                equit.Text = "Owner's Equity";
                                TableCell hdrblnk1 = new TableCell();
                                TableCell hdrblnk2 = new TableCell();
                                hdr.Cells.Add(equit);
                                hdr.Cells.Add(hdrblnk1);
                                hdr.Cells.Add(hdrblnk2);
                            }
                         */

                            TableRow tmp = new TableRow();
                            BalanceTable.Rows.Add(tmp);
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
                            equitSum += accnt_balance;

                            String accnt_bal_strng = accnt_balance.ToString("F2");
                            String accnt_bal_cents = accnt_bal_strng.Substring(accnt_bal_strng.Length - 3, 3);
                            accnt_bal_strng = accnt_bal_strng.Substring(0, accnt_bal_strng.Length - 3);
                            if (accnt_bal_strng.Length > 3)
                                accnt_bal_strng = formatCommas(accnt_bal_strng) + accnt_bal_cents;
                            else
                                accnt_bal_strng = accnt_bal_strng + accnt_bal_cents;

                            if (rwcd == 0)
                                tmpB.Text = "$" + accnt_bal_strng;
                            else
                                tmpB.Text = accnt_bal_strng;

                            tmpB.HorizontalAlign = HorizontalAlign.Right;
                            tmpB.Width = 20;
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpBl);
                            tmp.Cells.Add(tmpB);
                            equityRowCount++;
                            rwcc2++;
                        }
                    }
                }
            }
            //Retained Earnings Row

            String rtnEarnstrng = get_retained_earnings(sender, e, strt, endd).ToString("F2");
            String rtnEarn_cents = rtnEarnstrng.Substring(rtnEarnstrng.Length - 3, 3);
            rtnEarnstrng = rtnEarnstrng.Substring(0, rtnEarnstrng.Length - 3);
            if (rtnEarnstrng.Length > 3)
                rtnEarnstrng = formatCommas(rtnEarnstrng) + rtnEarn_cents;
            else
                rtnEarnstrng = rtnEarnstrng + rtnEarn_cents;

            TableRow tmpRE = new TableRow();
            BalanceTable.Rows.Add(tmpRE);
            TableCell tmpNRE = new TableCell();
            TableCell tmpBRE = new TableCell();
            TableCell tmpBlRE = new TableCell();
            tmpBRE.Text = rtnEarnstrng;
            tmpBRE.HorizontalAlign = HorizontalAlign.Right;
            tmpBRE.Width = 20;
            tmpBlRE.Text = "";
            tmpNRE.Text = "Retained Earnings";
            tmpRE.Cells.Add(tmpNRE);
            tmpRE.Cells.Add(tmpBlRE);
            tmpRE.Cells.Add(tmpBRE);
            equityRowCount++;
            rwcc2++;



            //Total Liabilities and Equity Row
            String tLESumString = (liabSum + equitSum + get_retained_earnings(sender, e, strt, endd)).ToString("F2");
            String tLESumCents = "";
            if (tLESumString.Length > 3)
            {
                tLESumCents = tLESumString.Substring(tLESumString.Length - 3, 3);
                tLESumString = tLESumString.Substring(0, tLESumString.Length - 3);
            }
            TableRow tLESumR = new TableRow();
            TableCell sum = new TableCell();
            TableCell sumBlnk = new TableCell();
            TableCell sumTxt = new TableCell();
            sumTxt.Text = "&nbsp;&nbsp;&nbsp;Total liabilities and equity";
            sumBlnk.Text = "";
            sum.Text = "$" + formatCommas(tLESumString) + tLESumCents;
            sum.Font.Underline = true;
            tLESumR.Cells.Add(sumTxt);
            tLESumR.Cells.Add(sumBlnk);
            tLESumR.Cells.Add(sum);
            BalanceTable.Rows.Add(tLESumR);
            con.Close();
        }
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