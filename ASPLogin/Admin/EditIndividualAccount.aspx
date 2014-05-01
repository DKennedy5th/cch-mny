<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EditIndividualAccount.aspx.cs" Inherits="Admin_EditIndividualAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 212px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="acct_id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="acct_id" HeaderText="acct_id" ReadOnly="True" SortExpression="acct_id" />
            <asp:BoundField DataField="acct_type" HeaderText="acct_type" SortExpression="acct_type" />
            <asp:BoundField DataField="report_type" HeaderText="report_type" SortExpression="report_type" />
            <asp:BoundField DataField="acct_name" HeaderText="acct_name" SortExpression="acct_name" />
            <asp:BoundField DataField="acct_bal" HeaderText="acct_bal" SortExpression="acct_bal" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [acct_id], [acct_type], [report_type], [acct_name], [acct_bal], [active] FROM [Accounts] WHERE ([acct_id] = @acct_id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="acct_id" QueryStringField="acct_id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                Update Active Status</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Return To Edit Accounts List" />
            </td>
        </tr>
    </table>
</asp:Content>

