﻿<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="DJournal.aspx.cs" Inherits="Account_DJournal" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title><%: Page.Title %> - My ASP.NET Application</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">      
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" /> 
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 156px;
        }
        .auto-style5 {
            width: 75px;
        }
        .auto-style6 {
            width: 72px;
        }
    </style>
    
</head>
<body>
                    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <%--Framework scripts--%>
            <asp:ScriptReference Name="MsAjaxBundle" />
            <asp:ScriptReference Name="jquery" />
            <asp:ScriptReference Name="jquery.ui.combined" />
            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
            <asp:ScriptReference Name="WebFormsBundle" />
            <%--Site scripts--%>

        </Scripts>
    </asp:ScriptManager>

    <header>
        <div class="content-wrapper">
            <div class="float-left">
                <p class="site-title">
                    <a id="A1" runat="server" href="~/"><img src="images/cacheLogo.jpg"></a></p>
            </div>
            <div class="float-right">
                <section id="login">
                    <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul>
                                <li><a id="registerLink" runat="server" href="~/Account/Register.aspx">Register</a></li>
                                <li><a id="loginLink" runat="server" href="~/Account/Login.aspx">Log in</a></li>
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <p>
                                Hello, <a id="A2" runat="server" class="username" href="~/Account/Manage.aspx" title="Manage your account">
                                    <asp:LoginName ID="LoginName1" runat="server" CssClass="username" />
                                </a>!
                                <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" />
                            </p>
                        </LoggedInTemplate>
                    </asp:LoginView>
                </section>
                <nav>
                    <ul id="menu">
                        <li><a id="A3" runat="server" href="~/">Home</a></li>
                        <li><a id="A4" runat="server" href="~/About.aspx">About</a></li>
                        <li><a id="A5" runat="server" href="~/Contact.aspx">Contact</a></li>
                        <li><a id="A6" runat="server" href="~/Account/ChartAccounts.aspx">Chart of Accounts</a></li>
                        <li><a id="A7" runat="server" href="~/Account/Journalize.aspx">Journalize</a></li>
                        <li><a id="A8" runat="server" href="~/Account/AddAccount.aspx">Add Account</a></li>
                    </ul>
                </nav>
            </div>
        </div>
    </header>

      <div id="body">
        
        <section class="content-wrapper main-content clear-fix">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">             
        <ContentTemplate>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder><br />
                    </td>
                    <td class="auto-style4">
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder><br />
                    </td>
                    <td class="auto-style5">
                        <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder><br />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddTextBox" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
                    <table class="auto-style1">
                        <tr>
                            <td>

                    <asp:TextBox ID="DescriptionTextBox" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                        </tr>
                    </table>
    <br />

        <br />
    <asp:Button ID="btnAddTextBox" runat="server"  Text="Add Entry Field" OnClick="btnAddTextBox_Click" />
    <br /><br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Button runat="server" ID="MyButton" Text="Submit" OnClick="MyButton_Click" />
            <br /><br />
            <asp:Label runat="server" ID="MyLabel"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>

            
        </section>
    </div>
                



        </form>
</body>
</html>