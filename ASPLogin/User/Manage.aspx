<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Admin_Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            font-size: medium;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
        }
        .auto-style5 {
            width: 193px;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <p class="auto-style1">
        <strong>Manage Account</strong></p>
    <p class="auto-style2">
        You are logged in as
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <table class="auto-style3">
        <tr>
            <td class="auto-style5"><strong>Change Password</strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">Current Password</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" style="font-size: large" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">New Password</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style2" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="auto-style1" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Confirm New Password</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="auto-style1" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="2">
                <asp:Label ID="Label5" runat="server" style="font-size: large" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Change Password" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

