<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="Event Report.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">  
    <asp:Table ID="ISHead" runat="server" Height="115px" Width="90%" EnableTheming="True" CellPadding="2" CellSpacing="2">
        <asp:TableRow>
            <asp:TableCell Font-Size="X-Large" Font-Bold="true" HorizontalAlign="Center">Team Cache Money<br />Event Log<br />From <asp:Label runat="server" ID="from"></asp:Label><br />To <asp:Label runat="server" ID="to"></asp:Label></asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
    <asp:Table ID="EventTable" runat="server" Height="115px" Width="90%" EnableTheming="True" CellPadding="2" CellSpacing="2">
        <asp:TableRow HorizontalAlign="NotSet">
            <asp:TableCell Font-Bold="true" Font-Underline="true">Username</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">Action</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">Time</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">Transaction ID</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">Account ID</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">Username Updated</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">User Account Type</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">Report Name</asp:TableCell>
            <asp:TableCell Font-Bold="true" Font-Underline="true">Event ID</asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
</asp:Content>