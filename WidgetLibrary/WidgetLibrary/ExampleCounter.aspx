<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExampleCounter.aspx.cs" Inherits="WidgetLibrary.ExampleCounter" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h1>Widget Library</h1>

    <h2>Counter Control Documentation</h2>

    <p>
        This control creates a counter that can be incremented or decremented.
    </p>

    <h3>Available Properties</h3>
    <ul>
        <li>No special properties.</li>

    </ul>

    <h3>Examples</h3>

    <pre>&lt;wl:counter runat="server" /&gt;</pre>

    <!-- This content is being rendered by an instance of the Counter user control -->
    <div>
        <wl:Counter runat="server" />
    </div>



</asp:Content>
