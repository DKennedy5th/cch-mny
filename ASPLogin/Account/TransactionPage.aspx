<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TransactionPage.aspx.cs" Inherits="Account_TransactionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <asp:AccessDataSource ID="AccessDataSource1" runat="server"></asp:AccessDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
</asp:GridView>
<asp:SqlDataSource ID="transactionPageDB" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationDomainConnectionString %>" SelectCommand="SELECT [acct_name] FROM [Accounts]"></asp:SqlDataSource>
</asp:Content>

