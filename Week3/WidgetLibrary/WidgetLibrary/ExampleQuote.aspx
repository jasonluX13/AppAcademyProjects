<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExampleQuote.aspx.cs" Inherits="WidgetLibrary.ExampleQuote" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Widget Library</h1>

    <h2>Quote of the Day Control Documentation</h2>

    <p>
        This control simply prints a quote of the day.
    </p>

    <h3>Available Properties</h3>
    <ul>
        <li>`Randomize`: A boolean which when set to true, will return a random quote. It defaults to false.</li>

    </ul>

    <h3>Examples</h3>

    <pre>&lt;wl:quoteoftheday runat="server" /&gt;</pre>

    <!-- This content is being rendered by an instance of the QuoteOfTheDay user control -->
    <div>
        <wl:QuoteOfTheDay runat="server" />
    </div>

    <pre>&lt;wl:quoteoftheday randomize="true" runat="server" /&gt;</pre>

    <!-- This content is being rendered by an instance of the QuoteOfTheDay user control -->
    <div>
        <wl:QuoteOfTheDay Randomize="true" runat="server" />
    </div>

    <p>
        <a href="Default.aspx">Return to Home</a>
    </p>
</asp:Content>
