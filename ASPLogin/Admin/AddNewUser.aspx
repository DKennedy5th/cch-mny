﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddNewUser.aspx.cs" Inherits="Admin_AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 178px;
        }
        .auto-style4 {
            height: 23px;
            width: 178px;
        }
        .auto-style5 {
            width: 178px;
            height: 47px;
        }
        .auto-style6 {
        }
        .auto-style7 {
            width: 200px;
        }
        .auto-style8 {
            height: 23px;
            width: 200px;
        }
        .auto-style9 {
            height: 47px;
            width: 200px;
        }
        .auto-style10 {
            width: 178px;
            height: 60px;
        }
        .auto-style11 {
            width: 200px;
            height: 60px;
        }
        .auto-style12 {
            height: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Username<br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">First Name<br />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Last Name<br />
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">E-mail<br />
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6" rowspan="3">
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Password<br />
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Confirm Password<br />
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style11">
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Type of Account</td>
            <td class="auto-style8">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create User" />
            </td>
            <td class="auto-style8">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancel" />
            </td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

