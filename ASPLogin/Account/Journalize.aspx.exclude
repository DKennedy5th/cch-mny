<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Journalize.aspx.cs" Inherits="Account_Journalize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 317px;
        }
        .auto-style4 {
            width: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Debit</td>
            <td class="auto-style4">
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="journalAccount" DataTextField="acct_name" DataValueField="acct_name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="journalAccount" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationDomainConnectionString %>" SelectCommand="SELECT [acct_name] FROM [Accounts]"></asp:SqlDataSource>
                <asp:Button ID="Button2" runat="server" Text="+" OnClick="Button2_Click"/>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Panel ID="Panel2" runat="server">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Credit</td>
            <td class="auto-style4">
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="journalAccount" DataTextField="acct_name" DataValueField="acct_name">
                </asp:DropDownList>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="+" />
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Description</td>
            <td class="auto-style2" colspan="2">
                <asp:TextBox ID="TextBox3" runat="server" Height="94px" Width="728px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Upload Source Document</td>
            <td class="auto-style2" colspan="2">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Submit</td>
            <td class="auto-style2" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Submit" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
    
</asp:Content>

