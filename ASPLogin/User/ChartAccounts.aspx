﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ChartAccounts.aspx.cs" Inherits="User_ChartOfAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="acct_id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="acct_id" DataNavigateUrlFormatString="TransactionsPage.aspx?acct_id={0}" DataTextField="acct_name" HeaderText="Account Name" />
            <asp:BoundField DataField="active" HeaderText="active" SortExpression="active" />
            <asp:BoundField DataField="acct_bal" HeaderText="acct_bal" SortExpression="acct_bal" />
            <asp:BoundField DataField="created_by" HeaderText="created_by" SortExpression="created_by" />
            <asp:BoundField DataField="created_at" HeaderText="created_at" SortExpression="created_at" />
            <asp:BoundField DataField="last_updated" HeaderText="last_updated" SortExpression="last_updated" />
            <asp:BoundField DataField="last_updated_by" HeaderText="last_updated_by" SortExpression="last_updated_by" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [acct_name], [active], [acct_bal], [created_by], [created_at], [last_updated], [last_updated_by], [acct_id] FROM [Accounts]"></asp:SqlDataSource>
</asp:Content>

