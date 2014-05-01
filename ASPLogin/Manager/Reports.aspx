<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="User_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server" DataKeyNames="acct_id" DataSourceID="SqlDataSource1" ForeColor="#333333">
    <asp:Table ID="Table1" runat="server" Height="178px" HorizontalAlign="Center" Width="85%">
        <asp:TableHeaderRow>
             <asp:TableHeaderCell>Report Type</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
             <asp:TableCell>
                 <asp:DropDownList ID="ReportSelection" runat="server">
                     <asp:ListItem>Select Type</asp:ListItem>
                     <asp:ListItem Value="Trial Balance">Trial Balance</asp:ListItem>
                     <asp:ListItem Value="Income Statement">Income Statement</asp:ListItem>
                     <asp:ListItem Value="Event Report">Event Report</asp:ListItem>
                 </asp:DropDownList>
             </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Calendar runat="server" ID="strtDate" Caption="Start Date" Visible="false"></asp:Calendar>
                <asp:Calendar runat="server" ID="endDate" Caption="As of:"></asp:Calendar>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button runat="server" ID="reportGen" Text="Generate Report" OnClick="load_report" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    

</asp:Content>

