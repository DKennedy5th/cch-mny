<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Trial Balance.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Table ID="Table1" runat="server" Height="146px" HorizontalAlign="Center" ViewStateMode="Disabled" Width="85%" BorderColor="Black" BorderStyle="Solid" BorderWidth="0px" CellPadding="-1" GridLines="Both">
        <asp:TableRow align="Center" runat="server">
            <asp:TableCell></asp:TableCell>
            <asp:TableCell Font-Size="X-Large" Font-Bold="True" HorizontalAlign="Center">Team Cache<br />Trial Balance<br /><asp:Label ID="Label1" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>





        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="acct_id" DataSourceID="DRSource" ForeColor="#333333" GridLines="None" Width="85%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                  <asp:HyperLinkField DataNavigateUrlFields="acct_id" DataNavigateUrlFormatString="TransactionsPage.aspx?acct_id={0}" DataTextField="acct_name" HeaderText="Account Name" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
              </asp:GridView>
            </asp:TableCell>
            <asp:TableCell>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="acct_id" DataSourceID="DRSource" ForeColor="#333333" GridLines="None" Width="85%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                  <asp:BoundField DataField="acct_bal" HeaderText="DR" SortExpression="acct_bal" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
              </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>






        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="acct_id" DataSourceID="CRSource" ForeColor="#333333" GridLines="None" Width="85%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                  <asp:HyperLinkField DataNavigateUrlFields="acct_id" DataNavigateUrlFormatString="TransactionsPage.aspx?acct_id={0}" DataTextField="acct_name" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
              </asp:GridView>
            </asp:TableCell>
            <asp:TableCell ColumnSpan="200"></asp:TableCell>
            <asp:TableCell>
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="acct_id" DataSourceID="CRSource" ForeColor="#333333" GridLines="None" Width="85%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                  <asp:BoundField DataField="acct_bal" HeaderText="CR" SortExpression="acct_bal" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
              </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Total: </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
     
    <asp:SqlDataSource ID="DRSource" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [acct_name], [acct_id], [acct_bal] FROM [Accounts] WHERE ([acct_type]='Assets' OR [acct_type]='Expenses')"></asp:SqlDataSource></>
    <asp:SqlDataSource ID="CRSource" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [acct_name], [acct_id], [acct_bal] FROM [Accounts] WHERE ([acct_type]='Liabilities' OR [acct_type]='Equity' OR [acct_type]='Revenue Account')"></asp:SqlDataSource></>
    
</asp:Content>

