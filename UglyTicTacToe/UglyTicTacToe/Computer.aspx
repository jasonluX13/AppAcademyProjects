<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Computer.aspx.cs" Inherits="UglyTicTacToe.Computer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TicTacToe</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to TicTacToe (AI)</h1>
            <h2 class="UglyLabel">
                <asp:Label ID="Winner" runat="server" Text=""></asp:Label>
            </h2>
          
            <asp:dropdownlist id="SelectAI" runat="server" >
                <asp:ListItem Text="AI 1" Value="1"></asp:ListItem>
                <asp:ListItem Text="AI 2" Value="2"></asp:ListItem>

            </asp:dropdownlist>
            <asp:Panel ID="GameBoard" runat="server">
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
            </asp:Panel>
  
            <br />
            <h2>
                <asp:HyperLink href="Game.aspx" runat="server" Text="Play Against Human"></asp:HyperLink>
            </h2>
            <h1>To Reset, click the image below.</h1>
            <asp:ImageButton ID="ResetGame" class="BigButton" Text="Reset Game" runat="server" imageurl="https://i.imgur.com/z4JTPzC.gif" OnClick="ResetGame_Click" />
        </div>
    </form>
</body>
</html>
