<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleWeather.aspx.cs" Inherits="WidgetLibrary.ExampleWeather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weather</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                <wl:weather runat="server" />
            </div>

            <p>
                <a href="Default.aspx">Return to Home</a>
            </p>
        </div>
    </form>
</body>
</html>
