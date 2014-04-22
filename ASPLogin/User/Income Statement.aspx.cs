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
        load_income(sender, e, start, end);
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


    protected void load_income(object sender, EventArgs e, DateTime strt, DateTime endd)
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
                    String stupid = rdr["acct_start_bal"].ToString();
                    float accnt_balance = Convert.ToSingle(stupid);
                    if (resultStart <= 0 && resultEnd >= 0)
                    {
                        if (rdr["acct_type"].ToString() == "Revenue Account")
                        {
                            if (rwcc == 0)
                            {
                                TableRow rev = new TableRow();
                                IncomeTable.Rows.Add(rev);
                                TableCell revhdr = new TableCell();
                                revhdr.Text = "Revenues:";
                                rev.Cells.Add(revhdr);
                            }
                            TableRow tmp = new TableRow();
                            IncomeTable.Rows.Add(tmp);
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
                                //tmpB.Text = "$" + accnt_balance.ToString() + ".00";
                                tmpB.Text = "$" + formatCommas(accnt_balance.ToString()) + ".00";
                                tmpB.HorizontalAlign = HorizontalAlign.Right;
                                tmpB.Width = 20;
                            }
                            else
                            {
                                //tmpB.Text = accnt_balance.ToString() + ".00";
                                tmpB.Text = formatCommas(accnt_balance.ToString()) + ".00";
                                tmpB.HorizontalAlign = HorizontalAlign.Right;
                                tmpB.Width = 20;
                            }
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpBl);
                            tmp.Cells.Add(tmpB);
                            rwcc++;
                        }
                        else if (rdr["acct_type"].ToString() == "Expenses")
                        {
                            if (rwcd == 0)
                            {
                                TableRow expns = new TableRow();
                                IncomeTable.Rows.Add(expns);
                                TableCell expnshdr = new TableCell();
                                expnshdr.Text = "Operating Expenses:";
                                expns.Cells.Add(expnshdr);
                            }
                            TableRow tmp = new TableRow();
                            IncomeTable.Rows.Add(tmp);
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
                                //tmpB.Text = "$" + accnt_balance.ToString() + ".00";
                                tmpB.Text = "$" + formatCommas(accnt_balance.ToString()) + ".00";
                                tmpB.HorizontalAlign = HorizontalAlign.Right;
                                tmpB.Width = 20;
                            }
                            else
                            {
                                //tmpB.Text = accnt_balance.ToString() + ".00";
                                tmpB.Text = formatCommas(accnt_balance.ToString()) + ".00";
                                tmpB.HorizontalAlign = HorizontalAlign.Right;
                                tmpB.Width = 20;
                            }
                            tmpBl.Text = "";
                            tmp.Cells.Add(tmpN);
                            tmp.Cells.Add(tmpB);
                            tmp.Cells.Add(tmpBl);
                            rwcd++;
                        }

                        
                    }

                }
            }
            //cmd1.ExecuteNonQuery();


            con.Close();
        }
        TableRow totalR = new TableRow();
        totalR.Font.Bold = true;
        IncomeTable.Rows.Add(totalR);
        TableCell totalC = new TableCell();
        totalC.Text = "  Total Expenses";
        totalR.Cells.Add(totalC);
        TableCell blank = new TableCell();
        totalR.Cells.Add(blank);
        TableCell totalDR = new TableCell();
        totalDR.Text = "$" + formatCommas(drSum.ToString()) + ".00";
        totalDR.HorizontalAlign = HorizontalAlign.Right;
        totalDR.Font.Underline = true;
        totalR.Cells.Add(totalDR);


        TableRow ntIncm = new TableRow();
        ntIncm.Font.Bold = true;
        IncomeTable.Rows.Add(ntIncm);
        TableCell totalCR = new TableCell();
        TableCell nthead = new TableCell();
        nthead.Text = "Net Income ";
        ntIncm.Cells.Add(nthead);
        TableCell blank2 = new TableCell();
        ntIncm.Cells.Add(blank2);
        totalCR.Text = "$" + formatCommas((crSum - drSum).ToString()) + ".00";
        totalCR.Font.Underline = true;
        totalCR.HorizontalAlign = HorizontalAlign.Right;
        ntIncm.Cells.Add(totalCR);


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
        String accnt_balance_strng = amount;
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