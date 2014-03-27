using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;


public partial class Account_Journalize : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True");

    List<string> controlIdList = new List<string>();
    List<string> controlIdListCR = new List<string>();
    int counter = 0;
    int counterCR = 0;

    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        controlIdList = (List<string>)ViewState["controlIdList"];
        if (controlIdList != null)
        {
            foreach (string Id in controlIdList)
            {
                counter++;
                TextBox tb = new TextBox();
                tb.ID = Id;
                LiteralControl lineBreak = new LiteralControl("<br />");
                PlaceHolder1.Controls.Add(tb);
                PlaceHolder1.Controls.Add(lineBreak);
            }
        }
        controlIdListCR = (List<string>)ViewState["controlIdListCR"];

        foreach (string crId in controlIdListCR)
        {
            counterCR++;
            TextBox cr = new TextBox();
            cr.ID = crId;
            LiteralControl lineBreak = new LiteralControl("<br />");
            PlaceHolder2.Controls.Add(cr);
            PlaceHolder2.Controls.Add(lineBreak);
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int ab = int.Parse(TextBox1.Text);
        int b = int.Parse(TextBox2.Text);

        if (ab==b)
        {
            string a = "DEFAULT";
            Int32 i, j, acct_id;
            String path;
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

            //get the highest transaction id from the transaction db to allow it to be incremented
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select top 1 trans_id from Transactions order by trans_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                i = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }
            //parse data to Transactions db...MUST BE DONE FIRST
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into Transactions values('" + (i + 1) + "','" + Membership.GetUser().UserName + "''"+ a +"','" + TextBox3.Text +"','" + path + "','" + Membership.GetUser().UserName + "','"+ a +")", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }


            //parse data to individualTransactions
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select top 1 trans_id from individualTransaction order by trans_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                i = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select top 1 indiv_trans_id from individualTransaction order by indiv_trans_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                j = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select acct_id from Accounts where acct_name like '" + DropDownList1.Text +"' ", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                acct_id = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }

            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into individualTransaction values('" + (i+1) + "','"+ Int32.Parse(TextBox1.Text)+ "','Debit','" + acct_id + "','"+  (j+1) +")", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                cmd1.ExecuteNonQuery();

                con.Close();
            }






            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select top 1 indiv_trans_id from individualTransaction order by indiv_trans_id DESC", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                j = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select acct_id from Accounts where acct_name like '" + DropDownList2.Text + "' ", con);
                acct_id = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ApplicationDomain;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into individualTransaction values('" + (i + 1) + "','" + Int32.Parse(TextBox1.Text) + "','Credit','" + acct_id + "','" + (j + 1) + ")", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                cmd1.ExecuteNonQuery();

                con.Close();
            }






            
            //con.Open();
            
            //SqlCommand cmd = new SqlCommand("insert into individualTransactions values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + path + "')", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //Label1.Text = "Image Uploaded";
            
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";

            Response.RedirectPermanent("Journalize.aspx");
                



        }
        else
        {
            Label1.Text = "Please Upload an Image";
        }


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {


        using (SqlConnection con = new SqlConnection("Provider=SQLNCLI11;Data Source=i4bbv5vnt4.database.windows.net;User ID=TeamCache;Initial Catalog=TeamCacAh4UPauaP"))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("insert values (1234) into test", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
            

            con.Close();
        }
        /**
        counter++;
        TextBox tb = new TextBox();        
        tb.ID = "DebitDynamicTB" + counter;
        

        LiteralControl lineBreak = new LiteralControl("<br/>");
        PlaceHolder1.Controls.Add(tb);
        PlaceHolder1.Controls.Add(lineBreak);
        controlIdList.Add(tb.ID);
        ViewState["controlIdList"] = controlIdList;
        **/

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        counterCR++;
        TextBox cr = new TextBox();
        cr.ID = "CreditDynamicTB" + counterCR;

        DropDownList dl = new DropDownList();
        dl.ID = "DynamicDropDownList" + counter;

        LiteralControl lineBreak = new LiteralControl("<br/>");
        PlaceHolder2.Controls.Add(cr);
        PlaceHolder3.Controls.Add(dl);
        PlaceHolder3.Controls.Add(lineBreak);
        controlIdListCR.Add(cr.ID);
        controlIdListCR.Add(dl.ID); 
        ViewState["controlIdListCR"] = controlIdListCR;
    }
}