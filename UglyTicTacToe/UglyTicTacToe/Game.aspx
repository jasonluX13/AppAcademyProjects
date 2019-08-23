<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="UglyTicTacToe.Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to TicTacToe</h1>
            <h2 class="UglyLabel">
                <asp:Label ID="Winner"  runat="server" Text=""></asp:Label>
            </h2>
            <div id="row1">
                <asp:Button ID="aa" class="UglyButton" Text="  " runat="server" OnClick="aa_Click" />
                <asp:Button ID="ab" class="UglyButton" Text="  " runat="server" OnClick="ab_Click" />
                <asp:Button ID="ac" class="UglyButton" Text="  " runat="server" OnClick="ac_Click" />
            </div>
            <div id="row2">
                <asp:Button ID="ba" class="UglyButton" Text="  " runat="server" OnClick="ba_Click" />
                <asp:Button ID="bb" class="UglyButton" Text="  " runat="server" OnClick="bb_Click" />
                <asp:Button ID="bc" class="UglyButton" Text="  " runat="server" OnClick="bc_Click" />
            </div>
            <div id="row3">
                <asp:Button ID="ca" class="UglyButton" Text="  " runat="server" OnClick="ca_Click" />
                <asp:Button ID="cb" class="UglyButton" Text="  " runat="server" OnClick="cb_Click" />
                <asp:Button ID="cc" class="UglyButton" Text="  " runat="server" OnClick="cc_Click" />
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="ResetGame" Text="Reset Game" runat="server" OnClick="ResetGame_Click" />
        </div>
    </form>
</body>
</html>
