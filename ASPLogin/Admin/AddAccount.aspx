<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddAccount.aspx.cs" Inherits="Admin_AddAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 154px;
    }
        .auto-style3 {
            width: 154px;
            height: 47px;
        }
        .auto-style4 {
            height: 47px;
        }
        .auto-style5 {
            width: 154px;
            height: 62px;
        }
        .auto-style6 {
            height: 62px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style5">Account Name</td>
        <td class="auto-style6">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" Font-Underline="True" ForeColor="#FF3300" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Account Type</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Assets</asp:ListItem>
                <asp:ListItem>Liabilities</asp:ListItem>
                <asp:ListItem>Equity</asp:ListItem>
                <asp:ListItem>Revenue Account</asp:ListItem>
                <asp:ListItem>Cost of Sales</asp:ListItem>
                <asp:ListItem>Expenses</asp:ListItem>
                <asp:ListItem>Gain on Sale of Assets</asp:ListItem>
                <asp:ListItem>Loss on Sale of Assets</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Starting Balance</td>
        <td class="auto-style4">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Active</td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
            <asp:Button ID="Button2" runat="server" Text="Clear Form" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="acct_id" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="acct_id" HeaderText="acct_id" ReadOnly="True" SortExpression="acct_id" />
                    <asp:BoundField DataField="acct_type" HeaderText="acct_type" SortExpression="acct_type" />
                    <asp:BoundField DataField="acct_name" HeaderText="acct_name" SortExpression="acct_name" />
                    <asp:BoundField DataField="acct_bal" HeaderText="acct_bal" SortExpression="acct_bal" DataFormatString="&quot;{0:c}&quot;" />
                    <asp:BoundField DataField="active" HeaderText="active" SortExpression="active" />
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [acct_id], [acct_type], [acct_name], [acct_bal], [active] FROM [Accounts]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationDomainConnectionString %>" SelectCommand="SELECT [acct_id], [acct_name], [active], [acct_type] FROM [Accounts]"></asp:SqlDataSource>
        </td>
    </tr>
</table>
</asp:Content>

