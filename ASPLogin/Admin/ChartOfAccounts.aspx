<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ChartOfAccounts.aspx.cs" Inherits="Admin_ChartOfAccounts" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
    }
        .auto-style3 {
            width: 253px;
        height: 23px;
    }
    .auto-style4 {
        height: 23px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="acct_name" HeaderText="acct_name" SortExpression="acct_name" />
                        <asp:BoundField DataField="active" HeaderText="active" SortExpression="active" />
                        <asp:BoundField DataField="created_at" HeaderText="created_at" SortExpression="created_at" />
                        <asp:BoundField DataField="valid_at" HeaderText="valid_at" SortExpression="valid_at" />
                        <asp:BoundField DataField="valid_by" HeaderText="valid_by" SortExpression="valid_by" />
                        <asp:BoundField DataField="created_by" HeaderText="created_by" SortExpression="created_by" />
                        <asp:BoundField DataField="acct_type" HeaderText="acct_type" SortExpression="acct_type" />
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
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [acct_name], [active], [created_at], [valid_at], [valid_by], [created_by], [acct_type], [last_updated], [last_updated_by] FROM [Accounts]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationDomainConnectionString %>" SelectCommand="SELECT [acct_name], [acct_bal] FROM [Accounts]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

