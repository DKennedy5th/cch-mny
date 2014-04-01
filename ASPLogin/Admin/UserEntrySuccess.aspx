<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="UserEntrySuccess.aspx.cs" Inherits="Admin_UserEntrySuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        User Successfully Added</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add New User" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Return Home" />
    </p>
</asp:Content>

