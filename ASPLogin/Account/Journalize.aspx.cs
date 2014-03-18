using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


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
        if (FileUpload1.HasFile)
        {
            string a = "DEFAULT";
            Int32 i, j;
            String str = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str);
            String path = "~//Account/uploads//" + str.ToString();

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
                SqlCommand cmd1 = new SqlCommand("insert into individualTransactions values('" + (i+1) + "','""", con);// where (acct_type like 'Account Payable')order by acct_id DESC", con);
                j = (Int32)cmd1.ExecuteScalar();

                con.Close();
            }
            
            con.Open();
            
            SqlCommand cmd = new SqlCommand("insert into individualTransactions values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + path + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Image Uploaded";
            
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
        counter++;
        TextBox tb = new TextBox();
        tb.ID = "DebitDynamicTB" + counter;

        LiteralControl lineBreak = new LiteralControl("<br/>");
        PlaceHolder1.Controls.Add(tb);
        PlaceHolder1.Controls.Add(lineBreak);
        controlIdList.Add(tb.ID);
        ViewState["controlIdList"] = controlIdList;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        counterCR++;
        TextBox cr = new TextBox();
        cr.ID = "CreditDynamicTB" + counterCR;

        LiteralControl lineBreak = new LiteralControl("<br/>");
        PlaceHolder2.Controls.Add(cr);
        PlaceHolder2.Controls.Add(lineBreak);
        controlIdListCR.Add(cr.ID);
        ViewState["controlIdListCR"] = controlIdListCR;
    }
}