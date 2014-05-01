<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Balance Sheet.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">  
    <asp:Table ID="ISHead" runat="server" Height="115px" Width="90%" EnableTheming="True" CellPadding="2" CellSpacing="2">
        <asp:TableRow>
            <asp:TableCell Font-Size="X-Large" Font-Bold="true" HorizontalAlign="Center">Team Cache Money<br />Balance Sheet<br />As of <asp:Label runat="server" ID="asOf"></asp:Label></asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
    <asp:Table ID="BalanceTable" runat="server" Height="115px" Width="90%" EnableTheming="True" CellPadding="2" CellSpacing="2">    
    </asp:Table>
</asp:Content>