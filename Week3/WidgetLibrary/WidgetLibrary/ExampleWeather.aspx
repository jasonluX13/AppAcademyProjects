<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExampleWeather.aspx.cs" Inherits="WidgetLibrary.ExampleWeather" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Widget Library</h1>

    <h2>Weather Control Documentation</h2>

    <p>
        This control prints the current weather at the entered zipcode.
    </p>

    <h3>Available Properties</h3>
    <ul>
        <li>No special properties.</li>

    </ul>

    <h3>Examples</h3>

    <pre>&lt;wl:weather runat="server" /&gt;</pre>

    <!-- This content is being rendered by an instance of the Weather user control -->
    <div>
        <wl:Weather runat="server" />
    </div>
</asp:Content>
