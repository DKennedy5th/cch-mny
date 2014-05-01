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
        DateTime start = Convert.ToDateTime(s1);
        DateTime end = Convert.ToDateTime(s2);
        to.Text = end.ToLongDateString();
        from.Text = start.ToLongDateString();
        load_events(sender, e, start, end);
        //strtLbl.Text = Convert.ToString(start);
        //endLbl.Text = Convert.ToString(end);
    }

    protected void load_events(object sender, EventArgs e, DateTime strt, DateTime endd)
    {

        SqlDataReader rdr;
        using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT username, action, time, trans_id, acct_id, username_updated, user_acct_type, report_name, event_id  FROM EventLog", con);
            rdr = cmd1.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                        TableRow events = new TableRow();
                        EventTable.Rows.Add(events);
                        TableCell usern = new TableCell();
                        TableCell action = new TableCell();
                        TableCell time = new TableCell();
                        TableCell transid = new TableCell();
                        TableCell acctid = new TableCell();
                        TableCell userupdated = new TableCell();
                        TableCell useraccnttype = new TableCell();
                        TableCell reportname = new TableCell();
                        TableCell eventid = new TableCell();
                        usern.Text = "";
                        action.Text = "";
                        time.Text = "";
                        transid.Text = "";
                        acctid.Text = "";
                        userupdated.Text = "";
                        useraccnttype.Text = "";
                        reportname.Text = "";
                        eventid.Text = "";

                        if (rdr["username"] != null)
                            usern.Text = rdr["username"].ToString();
                        if (rdr["action"] != null)
                            action.Text = rdr["action"].ToString();
                        if (rdr["time"] != null)
                            time.Text = rdr["time"].ToString();
                        if (rdr["trans_id"] != null)
                            transid.Text = rdr["trans_id"].ToString();
                        if (rdr["acct_id"] != null)
                            acctid.Text = rdr["acct_id"].ToString();
                        if (rdr["username_updated"] != null)
                            userupdated.Text = rdr["username_updated"].ToString();
                        if (rdr["user_acct_type"] != null)
                            useraccnttype.Text = rdr["user_acct_type"].ToString();
                        if (rdr["report_name"] != null)
                            reportname.Text = rdr["report_name"].ToString();
                        if (rdr["event_id"] != null)
                            eventid.Text = rdr["event_id"].ToString();

                        events.Cells.Add(usern);
                        events.Cells.Add(action);
                        events.Cells.Add(time);
                        events.Cells.Add(transid);
                        events.Cells.Add(acctid);
                        events.Cells.Add(userupdated);
                        events.Cells.Add(useraccnttype);
                        events.Cells.Add(reportname);

                }
            }
            //cmd1.ExecuteNonQuery();


            con.Close();
        }
    }
}