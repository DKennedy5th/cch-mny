
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class User_Journalize : System.Web.UI.Page
{
    static int myCount = 2;
    private TextBox[] dynamicTextBoxes;
    private DropDownList[] debitCreditDDL;
    private DropDownList[] accountDDL;


    protected void Page_Init(object sender, EventArgs e)
    {
        Control myControl = GetPostBackControl(this.Page);

        if ((myControl != null))
        {
            if ((myControl.ClientID.ToString() == "btnAddTextBox"))
            {
                myCount = myCount + 1;
            }
        }
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        dynamicTextBoxes = new TextBox[myCount];
        debitCreditDDL = new DropDownList[myCount];
        accountDDL = new DropDownList[myCount];
        int i;

        for (i = 0; i < myCount; i += 1)
        {
            LiteralControl literalBreak = new LiteralControl("<br />");
            TextBox textBox = new TextBox();
            textBox.ID = "myTextBox" + i.ToString();
            PlaceHolder3.Controls.Add(textBox);
            
            dynamicTextBoxes[i] = textBox;

            DropDownList dropList = new DropDownList();
            dropList.ID = "myDropList" + i.ToString();
            dropList.Items.Add(new ListItem("Debit"));
            dropList.Items.Add(new ListItem("Credit"));
            PlaceHolder4.Controls.Add(dropList);
            debitCreditDDL[i] = dropList;

            DropDownList acctDDL = new DropDownList();


            using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Accounts", con);
                    DataTable subjects = new DataTable();
                    adapter.Fill(subjects);

                    acctDDL.DataSource = subjects;
                    acctDDL.DataBind();
                    acctDDL.DataTextField = "acct_name";
                    acctDDL.DataValueField = "acct_name";
                    acctDDL.DataBind();

                    accountDDL[i] = acctDDL;
                }
                catch (Exception ex)
                {
                    // Handle the error
                }

            }
            PlaceHolder2.Controls.Add(acctDDL);


            

            PlaceHolder3.Controls.Add(literalBreak);    
            PlaceHolder2.Controls.Add(literalBreak);
            PlaceHolder4.Controls.Add(literalBreak);
        }
    }


    protected void btnAddTextBox_Click(object sender, EventArgs e)
    {
        // Handled in preInit due to event sequencing.

    }


    protected void MyButton_Click(object sender, EventArgs e)
    {
        MyLabel.Text = "";
        //loop variables i and counter
        int i, counter;
        int debitTotal = 0;
        int creditTotal = 0;
        //transaction id
        int j;
        //acct id
        int acct_id;
        //individual trans id
        int individual_trans_id;

        string a = "DEFAULT";
        string path;
        for (i = 0; i < myCount; i += 1)
        {
            if (debitCreditDDL[i].Text.Equals("Debit"))
            {
                debitTotal += Convert.ToInt32(dynamicTextBoxes[i].Text); 
            }
            else if (debitCreditDDL[i].Text.Equals("Credit"))
            {
                creditTotal += Convert.ToInt32(dynamicTextBoxes[i].Text);
            }
        }
            if (debitTotal != creditTotal)
            {
                MyLabel.Text = "credit and debits must be equal";
            }
            else if (debitTotal == creditTotal)
            {

                if (FileUpload1.HasFile)
                {
                    String str = FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str);
                    path = "~//Account/uploads//" + str.ToString();
                }
                else
                {
                    path = "null";
                }

                //get the highest trans id so it can be incremented by 1 for the entry
                using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Select top 1 trans_id from Transactions order by trans_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                    j = (Int32)cmd1.ExecuteScalar();

                    con.Close();
                }
                //parse data to Transactions db...MUST BE DONE FIRST
                using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("insert into Transactions values('" + (j + 1) + "','" + Page.User.Identity.Name + "','" + DateTime.Now + "','" + DescriptionTextBox.Text + "','" + path + "','" + Page.User.Identity.Name + "', '" + DateTime.Now + "','Pending Approval')", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
                
                for (counter = 0; counter < myCount; counter += 1)
                {

                
                using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Select top 1 indiv_trans_id from individualTransaction order by indiv_trans_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                    individual_trans_id = (Int32)cmd1.ExecuteScalar();

                    con.Close();
                }

                    using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                    {
                        con.Open();
                        string s = accountDDL[counter].Text;
                        SqlCommand cmd1 = new SqlCommand("Select acct_id from Accounts where acct_name like '" + s + "' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                        acct_id = (Int32)cmd1.ExecuteScalar();

                        con.Close();
                    }                   

                    
                    using (SqlConnection con = new SqlConnection("Data Source=i4bbv5vnt4.database.windows.net;Initial Catalog=TeamCacAh4UPauaP;Persist Security Info=True;User ID=TeamCache;Password=Password!"))
                    {
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("insert into individualTransaction values('" + (j+1) +"','"+ Convert.ToInt32(dynamicTextBoxes[counter].Text) +"','"+ debitCreditDDL[counter].Text +"','"+ acct_id +"','"+ (individual_trans_id + 1) +"')", con);
                        cmd1.ExecuteNonQuery();

                        con.Close();
                    }
                    
                }
                





                MyLabel.Text = "Entry is now pending approval";
                myCount = 2;
                Response.Redirect("~/User/Journalize.aspx");
            }

            

    }



    public static Control GetPostBackControl(Page thePage)
    {
        Control myControl = null;
        string ctrlName = thePage.Request.Params.Get("__EVENTTARGET");
        if (((ctrlName != null) & (ctrlName != string.Empty)))
        {
            myControl = thePage.FindControl(ctrlName);
        }
        else
        {
            foreach (string Item in thePage.Request.Form)
            {
                Control c = thePage.FindControl(Item);
                if (((c) is System.Web.UI.WebControls.Button))
                {
                    myControl = c;
                }
            }

        }
        return myControl;
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (myCount > 2)
        {
            myCount = myCount - 1;
        }
        
    }
}
