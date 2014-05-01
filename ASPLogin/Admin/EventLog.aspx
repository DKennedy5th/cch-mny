<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EventLog.aspx.cs" Inherits="Admin_EventLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <span class="auto-style1">Select a Category to refine the results:</span>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Created User</asp:ListItem>
            <asp:ListItem>Created Account</asp:ListItem>
            <asp:ListItem>Created Transaction</asp:ListItem>
            <asp:ListItem>Edited User Account</asp:ListItem>
            <asp:ListItem>Approved Transaction</asp:ListItem>
            <asp:ListItem>Rejected Transaction</asp:ListItem>
            <asp:ListItem>Edited Account Status</asp:ListItem>
            <asp:ListItem>Changed Password</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Filter" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="event_id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                <asp:BoundField DataField="action" HeaderText="action" SortExpression="action" />
                <asp:BoundField DataField="time" HeaderText="time" SortExpression="time" />
                <asp:BoundField DataField="trans_id" HeaderText="trans_id" SortExpression="trans_id" />
                <asp:BoundField DataField="acct_id" HeaderText="acct_id" SortExpression="acct_id" />
                <asp:BoundField DataField="username_updated" HeaderText="username_updated" SortExpression="username_updated" />
                <asp:BoundField DataField="user_acct_type" HeaderText="user_acct_type" SortExpression="user_acct_type" />
                <asp:BoundField DataField="report_name" HeaderText="report_name" SortExpression="report_name" />
                <asp:BoundField DataField="event_id" HeaderText="event_id" ReadOnly="True" SortExpression="event_id" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT * FROM [EventLog]"></asp:SqlDataSource>
    </p>
</asp:Content>

