<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExampleFontPreview.aspx.cs" Inherits="WidgetLibrary.ExampleFontPreview" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Widget Library</h1>

    <h2>Font Preview Control Documentation</h2>

    <p>
        This control simply allows you to preview a font.
    </p>

    <h3>Available Properties</h3>
    <ul>
        <li>No special properties</li>

    </ul>

    <h3>Examples</h3>

    <pre>&lt;wl:fontpreview runat="server" /&gt;</pre>

    <!-- This content is being rendered by an instance of the QuoteOfTheDay user control -->
    <div>
        <wl:FontPreview runat="server" />
    </div>

</asp:Content>
