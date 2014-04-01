<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="EditTransactions.aspx.cs" Inherits="Manager_EditTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="indiv_trans_id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="trans_id" HeaderText="trans_id" SortExpression="trans_id" />
            <asp:BoundField DataField="indiv_trans_id" HeaderText="indiv_trans_id" ReadOnly="True" SortExpression="indiv_trans_id" />
            <asp:BoundField DataField="debit_credit" HeaderText="debit_credit" SortExpression="debit_credit" />
            <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
            <asp:BoundField DataField="acct_id" HeaderText="acct_id" SortExpression="acct_id" />
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
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [indiv_trans_id], [debit_credit], [amount], [acct_id], [trans_id] FROM [individualTransaction] WHERE ([trans_id] = @trans_id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="trans_id" QueryStringField="trans_id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Post Transaction" />
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Reject Transaction" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return To Account Home" />
</asp:Content>

