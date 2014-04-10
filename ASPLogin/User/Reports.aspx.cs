using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void load_report(object sender, EventArgs e)
    {
        if (ReportSelection.SelectedValue == "Trial Balance")
        {
            //strtDate.SelectedDate = 28;
            Server.Transfer("~/User/Trial Balance.aspx?field1=" + strtDate.SelectedDate + "&field2=" + endDate.SelectedDate, false);
        }
        else
        {
            //reportGen.PostBackUrl = "~/User/Trial Balance.aspx";
        }
    }

}