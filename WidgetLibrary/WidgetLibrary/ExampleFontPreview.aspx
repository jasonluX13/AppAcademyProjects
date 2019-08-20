<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleFontPreview.aspx.cs" Inherits="WidgetLibrary.ExampleFontPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Font Preview</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                <wl:fontpreview runat="server" />
            </div>

            
            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
