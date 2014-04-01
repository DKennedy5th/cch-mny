<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Transactions.aspx.cs" Inherits="Admin_Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="trans_id" HeaderText="trans_id" SortExpression="trans_id" />
            <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
            <asp:BoundField DataField="debit_credit" HeaderText="debit_credit" SortExpression="debit_credit" />
            <asp:BoundField DataField="acct_id" HeaderText="acct_id" SortExpression="acct_id" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [trans_id], [amount], [debit_credit], [acct_id] FROM [individualTransaction] WHERE ([acct_id] = @acct_id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="acct_id" QueryStringField="acct_id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

