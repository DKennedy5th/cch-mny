<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Contact Team Cache</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            7705555555
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <a href="mailtoTeamCacheSupport@gmail.com">TeamCacheSupport@gmail.com</a>
        </p>
        <p>
            <span class="label">Marketing:</span>
            <a href="TeamCacheMarketing@gmail.com">TeamCacheMarketing@gmail.com</a>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="TeamCache@gmail.com">TeamCache@gmail.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            1100 South Marietta Pkwy SE,</p>
        <p>
            Marietta, GA 30060</p>
    </section>
</asp:Content>