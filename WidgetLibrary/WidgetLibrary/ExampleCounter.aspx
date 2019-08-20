<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleCounter.aspx.cs" Inherits="WidgetLibrary.ExampleCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                <wl:counter runat="server" />
            </div>

           

            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
