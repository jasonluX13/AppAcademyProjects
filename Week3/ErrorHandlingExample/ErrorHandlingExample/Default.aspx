<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ErrorHandlingExample.Default" Trace="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:TextBox ID="Number1" runat="server"></asp:TextBox>
                <asp:Label ID="Operation" runat="server" Text="+"></asp:Label>
                <asp:TextBox ID="Number2" runat="server"></asp:TextBox>
                <asp:Button ID="Sum" Text="Sum" runat="server" OnClick="Sum_Click" />
            </div>
            <asp:Label ID="Result" Text="Result: " runat="server"></asp:Label>
            <br />
            <asp:HyperLink href="Default.aspx" runat="server" Text="Clear"></asp:HyperLink>
            <br />
            <asp:HyperLink runat="server" Text="Go Bye Bye" NavigateUrl="~/Xyzzy.aspx" />
        </div>
    </form>
</body>
</html>
