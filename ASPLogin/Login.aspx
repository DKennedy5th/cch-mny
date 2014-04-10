<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" Font-Size="Medium">
        <FailureTextStyle Font-Size="Medium" />
        <TitleTextStyle Font-Bold="True" Font-Size="X-Large" Font-Underline="False" />
        <ValidatorTextStyle Font-Size="Large" />
    </asp:Login>
</asp:Content>

