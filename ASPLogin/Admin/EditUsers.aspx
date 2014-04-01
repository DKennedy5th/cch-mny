<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EditUsers.aspx.cs" Inherits="Admin_EditUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
            <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" />
            <asp:BoundField DataField="Lname" HeaderText="Lname" SortExpression="Lname" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="type_of_account" HeaderText="type_of_account" SortExpression="type_of_account" />
            <asp:CheckBoxField DataField="IsLocked" HeaderText="IsLocked" SortExpression="IsLocked" />
            <asp:BoundField DataField="LockedDateTime" HeaderText="LockedDateTime" SortExpression="LockedDateTime" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeamCacAh4UPauaPConnectionString %>" SelectCommand="SELECT [username], [Fname], [Lname], [email], [type_of_account], [IsLocked], [LockedDateTime] FROM [userAccounts] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:QueryStringParameter Name="username" QueryStringField="username" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

