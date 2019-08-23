<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="UglyTicTacToe.Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TicTacToe</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to TicTacToe (Two Player)</h1>
            <h2 class="UglyLabel">
                <asp:Label ID="Winner" runat="server" Text=""></asp:Label>
            </h2>
            <asp:Panel ID="GameBoard" runat="server">

                <asp:Button ID="aa" class="UglyButton" Text="  " runat="server" OnClick="aa_Click" />
                <asp:Button ID="ab" class="UglyButton" Text="  " runat="server" OnClick="ab_Click" />
                <asp:Button ID="ac" class="UglyButton" Text="  " runat="server" OnClick="ac_Click" />
                <br />
                <asp:Button ID="ba" class="UglyButton" Text="  " runat="server" OnClick="ba_Click" />
                <asp:Button ID="bb" class="UglyButton" Text="  " runat="server" OnClick="bb_Click" />
                <asp:Button ID="bc" class="UglyButton" Text="  " runat="server" OnClick="bc_Click" />

                <br />
                <asp:Button ID="ca" class="UglyButton" Text="  " runat="server" OnClick="ca_Click" />
                <asp:Button ID="cb" class="UglyButton" Text="  " runat="server" OnClick="cb_Click" />
                <asp:Button ID="cc" class="UglyButton" Text="  " runat="server" OnClick="cc_Click" />

            </asp:Panel>
            <br />
            <br />
            <br />
            <h2>
                <asp:HyperLink href="Computer.aspx" runat="server" Text="Play Against Computer (Warning, may cause seizures)"></asp:HyperLink>
            </h2>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="ResetGame" Text="Reset Game" runat="server" OnClick="ResetGame_Click" />
        </div>
    </form>
</body>
</html>
